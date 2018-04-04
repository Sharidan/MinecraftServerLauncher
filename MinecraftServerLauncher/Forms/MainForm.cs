using CSharpLibs.ConfigTools;
using CSharpLibs.Minecraft;
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

namespace MinecraftServerLauncher
{
  public partial class MainForm : Form
  {

    ServerProfileConfig config = new ServerProfileConfig();

    #region ===== Run Server Handling =====

    private ServerHost MinecraftServer = null;

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
        MinecraftServer.ConfigureServer(config.MinecraftPath, config.MinecraftJar, config.MemorySize);
        MinecraftServer.Start();
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {

    }

    private void btnServerInfo_Click(object sender, EventArgs e)
    {
      if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0)
      {
        INIFile serverProp = new INIFile();
        serverProp.MinecraftServerProperties = true;
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
    }

    #endregion

    #region ===== Constructor =====

    public MainForm()
    {
      InitializeComponent();

      this.Shown += MainForm_Shown;
    }

    #endregion

  }
}
