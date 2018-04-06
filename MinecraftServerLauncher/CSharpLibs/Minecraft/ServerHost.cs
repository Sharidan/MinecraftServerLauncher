using CSharpLibs.ConfigTools;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  class ServerHost
  {

    #region ===== Events =====

    #region Event: ConsoleChanged

    public delegate void ConsoleChangedEventHandler(int serverHostID, string logLevel, string logMessage);

    /// <summary>
    /// Triggers every time the Minecraft server console changes.
    /// </summary>
    public event ConsoleChangedEventHandler ConsoleChanged;

    protected void OnConsoleChanged(string logLevel, string logMessage)
    {
      ConsoleChanged?.Invoke(mvarID, logLevel, logMessage);
    }

    #endregion

    #region Event: ServerStarting

    public delegate void ServerStartingEventHandler(int serverHostID);

    /// <summary>
    /// Triggers when the Minecraft server begins it's startup process.
    /// </summary>
    public event ServerStartingEventHandler ServerStarting;

    protected void OnServerStarting()
    {
      ServerStarting?.Invoke(mvarID);
    }

    #endregion

    #region Event: ServerStarted

    public delegate void ServerStartedEventHandler(int serverHostID);

    /// <summary>
    /// Triggers when the Minecraft server has completed it's startup process.
    /// </summary>
    public event ServerStartedEventHandler ServerStarted;
    // This event will be raised once the output parser sees this line:
    // [14:57:57] [Server thread/INFO]: Done (2,631s)! For help, type "help" or "?"

    protected void OnServerStarted()
    {
      ServerStarted?.Invoke(mvarID);
    }

    #endregion

    #region Event: ServerShuttingDown

    public delegate void ServerShuttingDownEventHandler(int serverHostID);

    /// <summary>
    /// Triggers when the server starts shutting down.
    /// </summary>
    public event ServerShuttingDownEventHandler ServerShuttingDown;

    protected void OnServerShuttingDown()
    {
      ServerShuttingDown?.Invoke(mvarID);
    }

    #endregion

    #region Event: ServerStopped

    public delegate void ServerStoppedEventHandler(int serverHostID);

    /// <summary>
    /// Triggers when the server has stopped completely.
    /// </summary>
    public event ServerStoppedEventHandler ServerStopped;

    protected void OnServerStopped()
    {
      ServerStopped?.Invoke(mvarID);
    }

    #endregion

    #endregion

    #region ===== Internal Helper Methods =====

    #region Method: FixPath

    /// <summary>
    /// Ensures that the path has a trailing backslash
    /// </summary>
    /// <param name="path">The path to fix.</param>
    /// <returns>Returns the passed path with a trailing backslash.</returns>
    private string FixPath(string path)
    {
      if (path.Length > 0)
        if (path[path.Length - 1] != '\\')
          return path + '\\';

      return path;
    }

    #endregion

    #region Method: GeneratePassword

    private string GeneratePassword()
    {
      const string Letters = "qazxswedcvfrtgbnhyujmkiolp0987651234";
      Random rng = new Random(DateTime.Now.Millisecond);
      string result = "";

      for (int i = 0; i < 25; i++)
      {
        int index = 0;
        while (index < 1 || index > Letters.Length)
        {
          index = rng.Next(1, Letters.Length);
        }
        result += Letters[index - 1];
      }

      return result;
    }

    #endregion

    #region Method: UpdateServerProperties

    /// <summary>
    /// Updates the server.properties settings with remote console settings.
    /// </summary>
    /// <param name="enableRCon">When set true, remote console will be enabled allowing control of the server. When false, disables RCon and removes the settings</param>
    private void UpdateServerProperties(bool enableRCon)
    {
      if (File.Exists(mvarServerPath + "server.properties"))
      {
        INIFile INI = new INIFile(mvarServerPath + "server.properties", true);
        if (enableRCon)
        {
          INI.SetValue("", "enable-rcon", "true");
          INI.SetValue("", "rcon.port", mvarRemoteConsolePort.ToString());
          INI.SetValue("", "rcon.password", RConPassword);
          INI.SetValue("", "broadcast-rcon-to-ops", "true");
        }
        else
        {
          INI.SetValue("", "enable-rcon", "false");
          INI.SetValue("", "broadcast-rcon-to-ops", "false");
          INI.RemoveKey("", "rcon.port");
          INI.RemoveKey("", "rcon.password");
        }
        INI.Save();
      }
    }

    #endregion

    #endregion

    #region ===== RemoteConsole Support =====

    SourceRemoteConsole RCon = new SourceRemoteConsole();

    /// <summary>
    /// The current password in use for remote console.
    /// </summary>
    private string RConPassword = "";

    private void RCon_Connected()
    {
      //TODO: add whatever is needed after we've connected
    }

    private void RCon_ConnectFailed(Exception ex)
    {
      //TODO: maybe ?
    }

    private void RCon_Authenticated()
    {
      //TODO: handle that we are authenticated
    }

    private void RCon_AuthenticationFailed()
    {
      //TODO: Handle authentication failures
      // We'll force a disconnect
      RCon.Disconnect();
    }

    private void RCon_ServerResponse(string responseMessage)
    {
      //TODO: Handle incoming server responses
    }

    private void RCon_Disconnected()
    {
      //TODO: Handle other clean up as needed
    }

    private void InitializeRCon()
    {
      RCon.Connected += RCon_Connected;
      RCon.ConnectFailed += RCon_ConnectFailed;

      RCon.Authenticated += RCon_Authenticated;
      RCon.AuthenticationFailed += RCon_AuthenticationFailed;

      RCon.ServerResponse += RCon_ServerResponse;

      RCon.Disconnected += RCon_Disconnected;
    }

    #endregion

    #region ===== Thread Handling =====

    private Thread ServerThread = null;

    private void RunServer()
    {
      bool ServerShutdownSignaled = false;

      OnServerStarting();

      Process proc = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          FileName = "java",
          Arguments = "-Xmx" + mvarMemorySize.ToString() + "M -Xms" + mvarMemorySize.ToString() + "M -jar " + mvarServerJar, // + " nogui",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          RedirectStandardInput = true,
          CreateNoWindow = true,
          WorkingDirectory = mvarServerPath
        }
      };

      proc.Start();

      while (!proc.StandardOutput.EndOfStream)
      {
        string line = proc.StandardOutput.ReadLine();

        if (line.IndexOf("]:") > -1)
        {
          string logLevel = line.Substring(0, line.IndexOf("]:"));
          logLevel = logLevel.Substring(logLevel.LastIndexOf('/') + 1, logLevel.Length - (logLevel.LastIndexOf('/') + 1));
          string logMessage = line.Substring(line.IndexOf("]:") + 2, line.Length - (line.IndexOf("]:") + 2)).Trim();

          if (logMessage.IndexOf(' ') > -1)
          {
            if (logMessage.Substring(0, logMessage.IndexOf(' ')) == "Done" && logMessage.IndexOf("For help, type") > -1)
            {
              OnServerStarted();
            }
            else if (logMessage.ToLower().IndexOf("rcon running on") > -1)
            {
              if (logMessage.IndexOf(':') > -1)
              {
                string portInfo = logMessage.Substring(logMessage.LastIndexOf(':') + 1, logMessage.Length - (logMessage.LastIndexOf(':') + 1));
                int port = 0;
                if (!int.TryParse(portInfo, out port))
                {
                  port = 0;
                }

                if (port == mvarRemoteConsolePort)
                {
                  // We can now safely assume the server is listning for rcon connections!
                  // So ... start the rcon
                  RCon.Connect(new byte[] { 127, 0, 0, 1 }, mvarRemoteConsolePort, RConPassword);
                }
              }

            }
            else if (logMessage == "Stopping the server" || logMessage == "Stopping server")
            {
              if (!ServerShutdownSignaled)
              {
                // Tell RCon to disconnect, if it's running
                if (RCon.IsConnected)
                {
                  RCon.Disconnect();
                }
                OnServerShuttingDown();
                ServerShutdownSignaled = true;
              }
            }
          }
          OnConsoleChanged(logLevel, line);
        }
      }

      proc.WaitForExit();

      proc.Dispose();

      // Clean up the server.properties after run has completed
      UpdateServerProperties(false);

      OnServerStopped();
    }

    #endregion

    #region ===== Properties =====

    /// <summary>
    /// Determines whether this instance is locked: if locked, properties can not be changed while the server is running
    /// </summary>
    private bool Locked = false;

    #region Property: ID

    private int mvarID = 0;

    /// <summary>
    /// Holds the ID of this Minecraft server instance.
    /// </summary>
    public int ID
    {
      get { return mvarID; }
    }

    #endregion

    #region Property: MemorySize

    private int mvarMemorySize = 256;

    /// <summary>
    /// Determines the memory set aside for java to run this Minecraft server instance.
    /// </summary>
    public int MemorySize
    {
      get { return mvarMemorySize; }
      set
      {
        if (!Locked)
        {
          if (value >= 256 && value < 16384) //TODO: later on: replace with this comp's physical memory max
          {
            mvarMemorySize = value;
          }
        }
      }
    }

    #endregion

    #region Property: RemoteConsolePassword

    private string mvarRemoteConsolePassword = "";

    /// <summary>
    /// Indicates the password to use for authentication by means of remote console.
    /// </summary>
    public string RemoteConsolePassword
    {
      get { return mvarRemoteConsolePassword; }
      set
      {
        if (!Locked)
        {
          if (value.Trim().Length > 0)
          {
            mvarRemoteConsolePassword = value.Trim();
            mvarUseRandomizedRConPassword = false;
          }
        }
      }
    }

    #endregion

    #region Property: RemoteConsolePort

    private int mvarRemoteConsolePort = 25575;

    /// <summary>
    /// Indicates the port number to use for remote console access to the Minecraft server.
    /// </summary>
    public int RemoteConsolePort
    {
      get { return mvarRemoteConsolePort; }
      set
      {
        if (!Locked)
        {
          if (value > 1024 || value < 65536)
          {
            mvarRemoteConsolePort = value;
          }
        }
      }
    }

    #endregion

    #region Property: Running

    /// <summary>
    /// A flag that indicates whether the Minecraft server is running.
    /// </summary>
    public bool Running
    {
      get
      {
        return (ServerThread != null);
      }
    }

    #endregion

    #region Property: ServerJar

    private string mvarServerJar = "";

    /// <summary>
    /// Holds the name of the Minecraft server jar.
    /// </summary>
    public string ServerJar
    {
      get { return mvarServerJar; }
      set
      {
        if (!Locked)
        {
          if (mvarServerPath.Length > 0)
          {
            if (File.Exists(mvarServerPath + value))
            {
              mvarServerJar = value;
            }
          }
        }
      }
    }

    #endregion

    #region Property: ServerPath

    private string mvarServerPath = "";

    /// <summary>
    /// Determines the path to the Minecraft server.
    /// </summary>
    public string ServerPath
    {
      get { return mvarServerPath; }
      set
      {
        if (!Locked)
        {
          if (Directory.Exists(value))
          {
            mvarServerPath = FixPath(value.Trim());
          }
          else
          {
            mvarServerPath = "";
          }
        }
      }
    }

    #endregion

    #region Property: UseRandomizedRConPassword

    private bool mvarUseRandomizedRConPassword = false;

    /// <summary>
    /// Indicates whether to use randomized remote console passwords.
    /// </summary>
    public bool UseRandomizedRConPassword
    {
      get { return mvarUseRandomizedRConPassword; }
      set
      {
        if (!Locked)
        {
          mvarUseRandomizedRConPassword = value;
          if (mvarUseRandomizedRConPassword)
          {
            mvarRemoteConsolePassword = "";
          }
        }
      }
    }

    #endregion

    #endregion

    #region ===== Public Method =====

    #region Public Method: ConfigureServer

    /// <summary>
    /// Configures the path, jar and memory size for this server instance.
    /// </summary>
    /// <param name="serverPath">The path to the Minecraft server.</param>
    /// <param name="serverJar">The filename of the Minecraft server jar.</param>
    /// <param name="memorySize">The amount of memory in megabytes to set aside for the java instance.</param>
    public void ConfigureServer(string serverPath, string serverJar, int memorySize)
    {
      if (!Locked) // <-- will be true when the server is running!
      {
        if (Directory.Exists(serverPath))
        {
          mvarServerPath = FixPath(serverPath);
          if (File.Exists(mvarServerPath + serverJar))
          {
            mvarServerJar = serverJar;
            if (memorySize >= 256 && memorySize < 16384)
            {
              mvarMemorySize = memorySize;
            }
          }
        }
      }
    }

    #endregion

    #region Public Method: Start

    /// <summary>
    /// Attempt to start the Minecraft server.
    /// </summary>
    /// <returns>Returns true if the startup was successful, otherwise false.</returns>
    public bool Start()
    {
      bool validRConConfig = false;

      RConPassword = "";
      if (mvarUseRandomizedRConPassword)
      {
        validRConConfig = true;
        RConPassword = GeneratePassword();
      }
      else if (mvarRemoteConsolePassword.Trim().Length > 0)
      {
        validRConConfig = true;
        RConPassword = mvarRemoteConsolePassword;
      }

      if (mvarServerPath.Length > 0 && mvarServerJar.Length > 0)
      {
        if (validRConConfig)
        {
          UpdateServerProperties(true);
        }
        if (File.Exists(mvarServerPath + mvarServerJar) && validRConConfig)
        {
          // Yup: both path and file exists - let's do this!

          Locked = true; // Prevents properties from being changed!

          ServerThread = new Thread(new ThreadStart(RunServer));
          ServerThread.Start();

          while (!ServerThread.IsAlive)
            Thread.Sleep(5);

          return true;
        }
      }

      return false;
    }

    #endregion

    #region Public Method: Stop

    public void Stop()
    {
      if (Running)
      {
        if (RCon.IsConnected)
        {
          RCon.Execute("stop");
        }
      }
    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public ServerHost(int id)
    {
      mvarID = id;
      mvarMemorySize = 256;
      mvarServerJar = "";
      mvarServerPath = "";
      Locked = false;

      InitializeRCon();
    }

    #endregion

  }
}
