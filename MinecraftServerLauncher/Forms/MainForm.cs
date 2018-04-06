using CSharpLibs.ConfigTools;
using CSharpLibs.Minecraft;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Update: 6. April 2018
 * So far this form is still one huge mess of test setups.
 * As we progress further with this project, most of the
 * current code in this form will be replaced.
 * 
 */

namespace MinecraftServerLauncher
{
  public partial class MainForm : Form
  {


    ServerProfileConfig config = new ServerProfileConfig();

    #region ===== Run Server Handling =====

    private ServerHost MinecraftServer = null;

    private bool MinecraftServerRunning = false;

    private void MinecraftServer_ServerStarting(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(MinecraftServer_ServerStarting), serverHostID);
        return;
      }

      // Past this line, it's thread safe and copied over to the main thread.

      System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server is starting up.");

      btnStart.Enabled = false;
    }

    private void MinecraftServer_ConsoleChanged(int serverHostID, string logLevel, string logMessage)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string>(MinecraftServer_ConsoleChanged), serverHostID, logLevel, logMessage);
        return;
      }

      // here it's thread safe :)

      System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ":" + logLevel + ">> " + logMessage);
    }

    private void MinecraftServer_ServerStarted(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(MinecraftServer_ServerStarted), serverHostID);
        return;
      }

      // yup...

      System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server started!");

      btnStop.Enabled = true;

      MinecraftServerRunning = true;
    }

    private void MinecraftServer_ServerShuttingDown(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(MinecraftServer_ServerShuttingDown), serverHostID);
        return;
      }

      // 

      System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server IS SHUTTING DOWN!!!");

      btnStop.Enabled = false;

      MinecraftServerRunning = false;
    }

    private void MinecraftServer_ServerStopped(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(MinecraftServer_ServerStopped), serverHostID);
        return;
      }

      //

      System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server stopped.");

      btnStart.Enabled = true;

      MinecraftServerRunning = false;
    }

    private void InitializeMinecraftServer()
    {
      MinecraftServer.ServerStarting += MinecraftServer_ServerStarting;
      MinecraftServer.ConsoleChanged += MinecraftServer_ConsoleChanged;
      MinecraftServer.ServerStarted += MinecraftServer_ServerStarted;
      MinecraftServer.ServerShuttingDown += MinecraftServer_ServerShuttingDown;
      MinecraftServer.ServerStopped += MinecraftServer_ServerStopped;
    }

    #endregion

    #region ===== Test RCon Handling =====

    // For testing purposes:
    // RCon port = 26665
    // RCon pass = s45SDikeruF5klsi75iys

    SourceRemoteConsole RCon = new SourceRemoteConsole();

    private void RCon_Connected()
    {
      if (InvokeRequired)
      {
        Invoke(new Action(RCon_Connected));
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  Connected to remote server.");

      btnDisconnect.Enabled = true;
    }

    private void RCon_ConnectFailed(Exception ex)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<Exception>(RCon_ConnectFailed), ex);
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  Connection to remote server failed!");
      System.Diagnostics.Debug.WriteLine("Error message: " + ex.Message);

      RCon.Disconnect();

      btnConnect.Enabled = true;
      btnDisconnect.Enabled = false;
    }

    private void RCon_Authenticated()
    {
      if (InvokeRequired)
      {
        Invoke(new Action(RCon_Authenticated));
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  Successfully authenticated!");

      txtCommand.Enabled = true;
      btnExecute.Enabled = true;
    }

    private void RCon_AuthenticationFailed()
    {
      if (InvokeRequired)
      {
        Invoke(new Action(RCon_AuthenticationFailed));
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  Authentication failed! This is likely due to incorrect password!");
    }

    private void RCon_ServerResponse(string responseMessage)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<string>(RCon_ServerResponse), responseMessage);
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  Server response received!");
      System.Diagnostics.Debug.WriteLine("     Message length: " + responseMessage.Length.ToString());
      System.Diagnostics.Debug.WriteLine("     Response      : " + responseMessage);
    }

    private void RCon_Disconnected()
    {
      if (InvokeRequired)
      {
        Invoke(new Action(RCon_Disconnected));
        return;
      }

      System.Diagnostics.Debug.WriteLine(">>>  RCon Disconnected.");

      btnConnect.Enabled = true;
      btnDisconnect.Enabled = false;
      txtCommand.Enabled = false;
      btnExecute.Enabled = false;
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

    #region ----- Test Buttons -----

    // For testing purposes:
    // RCon port = 26665
    // RCon pass = s45SDikeruF5klsi75iys

    private void btnConnect_Click(object sender, EventArgs e)
    {
      if (MinecraftServerRunning)
      {
        RCon.Connect(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), 26665, "s45SDikeruF5klsi75iys");
        btnConnect.Enabled = false;
      }
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
      if (MinecraftServerRunning)
      {
        if (RCon.IsConnected)
        {
          RCon.Disconnect();
          btnDisconnect.Enabled = false;
        }
      }
    }

    private void btnExecute_Click(object sender, EventArgs e)
    {
      if (MinecraftServerRunning)
      {
        if (RCon.IsConnected)
        {
          RCon.Execute(txtCommand.Text);
        }
      }
    }

    #endregion

    #endregion

    #region ===== Control Events =====

    private void txtMinecraftServerPath_TextChanged(object sender, EventArgs e)
    {
      btnSave.Enabled = true;
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      btnSave.Enabled = true;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Minecraft server jar|*.jar";
      dialog.Multiselect = false;
      dialog.CheckFileExists = true;

      if (dialog.ShowDialog(this) == DialogResult.OK)
      {
        txtMinecraftServerPath.Text = dialog.FileName;
      }

      dialog.Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      string filePathName = txtMinecraftServerPath.Text.Trim();

      if (filePathName.Length > 0)
      {
        if (File.Exists(filePathName))
        {
          config.MinecraftPath = filePathName.Substring(0, filePathName.LastIndexOf('\\') + 1);
          config.MinecraftJar = filePathName.Substring(filePathName.LastIndexOf('\\') + 1, filePathName.Length - (filePathName.LastIndexOf('\\') + 1));
          config.MemorySize = (int)numericUpDown1.Value;
          config.Save();
          btnSave.Enabled = false;
        }
      }
      else
      {
        //TODO: throw an error message to the user!
        MessageBox.Show(
          "The path and filename of the Minecraft server jar that you have specified is not valid.\n\nPlease check and try again.",
          "Invalid Minecraft server jar!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation
          );
        txtMinecraftServerPath.Focus();
      }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0 && config.MemorySize > 0)
      {
        MinecraftServer.RemoteConsolePort = 26665;
        MinecraftServer.UseRandomizedRConPassword = true;
        MinecraftServer.ConfigureServer(config.MinecraftPath, config.MinecraftJar, config.MemorySize);
        if (!MinecraftServer.Start())
        {
          MessageBox.Show(
            "Some configuration mismatch prevented the server from starting!\n\nPlease check the configuration and try again.",
            "Unable to start Minecraft server!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation
            );
        }
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      MinecraftServer.Stop();
    }

    private void btnServerInfo_Click(object sender, EventArgs e)
    {
      if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0)
      {
        INIFile serverProp = new INIFile();
        serverProp.VirtualGrouping = true;
        serverProp.Load(config.MinecraftPath + "server.properties");

        string msg = "";
        msg += "Server MOTD: " + serverProp.GetValue("", "motd") + "\n";
        msg += "RCon port: " + serverProp.GetValue("", "rcon.port") + "\n";
        msg += "RCon password: " + serverProp.GetValue("", "rcon.password") + "\n";

        MessageBox.Show(msg);
      }
    }

    #endregion

    #region ===== Form Events =====

    private void MainForm_Load(object sender, EventArgs e)
    {
      MinecraftServer = new ServerHost(398475);
      InitializeMinecraftServer();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0)
      {
        string path = config.MinecraftPath;
        if (path[path.Length - 1] != '\\')
        {
          path += '\\';
        }
        txtMinecraftServerPath.Text = path + config.MinecraftJar;
        numericUpDown1.Value = config.MemorySize;
      }
      else
      {
        numericUpDown1.Value = 256;
      }

      btnSave.Enabled = false;

      btnStart.Enabled = true;
      btnStop.Enabled = false;

      // For the RCon test...
      btnConnect.Enabled = true;
      btnDisconnect.Enabled = false;
      txtCommand.Enabled = false;
      btnExecute.Enabled = false;

    }

    #endregion

    #region ===== Constructor =====

    public MainForm()
    {
      InitializeComponent();

      this.Shown += MainForm_Shown;

      InitializeRCon();
    }

    #endregion

  }
}
