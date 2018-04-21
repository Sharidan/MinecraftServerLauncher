using CSharpLibs.ConfigTools;
using CSharpLibs.Minecraft;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

    private ServerProfileConfig Config = new ServerProfileConfig();

    #region ===== Internal Helper Methods =====

    #region Method: CheckServerProfiles

    private void CheckServerProfiles()
    {
      for (int p = 0; p < Config.Count; p++)
      {
        if (Config.Profiles[p].ID == -1)
        {
          // Assign a new ID to this server profile.
          Config.AssignID(p, NextServerID());
        }

        ServerProfile profile = Config.Profiles[p];

        if (File.Exists(Config.Profiles[p].Path + Config.Profiles[p].Jar))
        {
          if (File.Exists(Config.Profiles[p].Path + "server-icon.png"))
          {
            if (profile.Icon != null)
            {
              profile.Icon.Dispose();
              profile.Icon = null;
            }

            try
            {
              profile.Icon = new Bitmap(Config.Profiles[p].Path + "server-icon.png");
            }
            catch
            {
              if (profile.Icon != null)
              {
                profile.Icon.Dispose();
              }
              profile.Icon = null;
            }


          }
        }

        INIFile serverProperties = new INIFile(Config.Profiles[p].Path + "server.properties", true);

        profile.MaxPlayers = FixInt(serverProperties.GetValue("max-players"));
        profile.Port = FixInt(serverProperties.GetValue("server-port"));
        profile.MOTD = serverProperties.GetValue("motd");

        Config.Profiles[p] = profile;
      }

      Invalidate();
    }

    #endregion

    #region Method: FixInt

    /// <summary>
    /// Attempts to convert the passed string value into an int number.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>Returns the integer representation of the passed string if successful, otherwise zero.</returns>
    private int FixInt(string value)
    {
      int result = 0;

      // Try to parse the string as a number, if not successful
      if (!int.TryParse(value, out result))
      { // force the result to zero
        result = 0;
      }

      return result;
    }

    #endregion

    #region Method: GetMouseProfileIndex

    private int GetMouseProfileIndex(int mouseX, int mouseY)
    {
      int x = (innerWidth - ServerProfileMaximumWidth) / 2;
      int y = ServerProfileMargin;

      for (int p = 0; p < Config.Count; p++)
      {
        if ((mouseX >= x && mouseX < x + ServerProfileMaximumWidth) && (mouseY >= y && mouseY < y + 64))
        {
          return p;
        }

        y += 64 + (2 * ServerProfileMargin);
      }

      return -1;
    }

    private int GetMouseProfileIndex(MouseEventArgs e)
    {
      return GetMouseProfileIndex(e.X, e.Y);
    }

    #endregion

    #region Method: GetResourceBitmapByName

    private Bitmap GetResourceImageByName(string imageName)
    {
      System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
      string resourceName = asm.GetName().Name + ".Properties.Resources";
      var rm = new System.Resources.ResourceManager(resourceName, asm);
      return (Bitmap)rm.GetObject(imageName);
    }

    #endregion

    #region Method: GetServerHostIndex

    /// <summary>
    /// Attempts to find a matching ServerHost instance within the server hosts list, based on the passed ID.
    /// </summary>
    /// <param name="serverID">The server ID to look for.</param>
    /// <returns>Returns the list index if found, otherwise -1.</returns>
    private int GetServerHostIndex(int serverID)
    {
      for (int s = 0; s < mvarServerHosts.Count; s++)
      {
        if (mvarServerHosts[s].ID == serverID)
        {
          return s;
        }
      }

      return -1;
    }

    #endregion

    #region Method: GetServerProfileIndex

    /// <summary>
    /// Attempts to find a matching ServerProfile (within the Config), based on the passed ID.
    /// </summary>
    /// <param name="serverID">The server ID to look for.</param>
    /// <returns>Returns the list index if found, otherwise -1.</returns>
    private int GetServerProfileIndex(int serverID)
    {
      for (int s = 0; s < Config.Profiles.Count; s++)
      {
        if (Config.Profiles[s].ID == serverID)
        {
          return s;
        }
      }

      return -1;
    }

    #endregion

    #region Method: NextServerID

    private int CurrentServerID = -1;

    /// <summary>
    /// Generates the next available server ID.
    /// </summary>
    /// <returns>Returns an available server ID.</returns>
    private int NextServerID()
    {
      CurrentServerID++;
      return CurrentServerID;
    }

    #endregion

    #region Method: SelectServerProfile

    private void SelectServerProfile(int index)
    {
      if (index > -1)
      {
        profileSelectionIndex = index;

        btnEdit.Enabled = true;
        btnRemove.Enabled = true;

        //NOTE!! These need to be changed according to configuration instead of selection!!
        //WARNING: These lists may at some point become desyncd

        if (mvarServerHosts[profileSelectionIndex].Running)
        {
          btnStart.Enabled = false;
          btnStop.Enabled = true;
        }
        else
        {
          btnStart.Enabled = true;
          btnStop.Enabled = false;
        }
      }
      else
      {
        profileSelectionIndex = -1;

        btnEdit.Enabled = false;
        btnRemove.Enabled = false;
        btnStart.Enabled = false;
        btnStop.Enabled = false;
      }

      Invalidate();
    }

    #endregion

    #region Method: UpdatePlayerCount

    private void UpdatePlayerCount(int serverHostID)
    {
      int serverProfileIndex = GetServerProfileIndex(serverHostID);
      if (serverProfileIndex > -1)
      {
        int serverHostIndex = GetServerHostIndex(serverHostID);
        if (serverHostIndex > -1)
        {
          int playerCount = mvarServerHosts[serverHostIndex].OnlinePlayers.Count;
          if (Config.Profiles[serverProfileIndex].PlayerCount != playerCount)
          {
            ServerProfile profile = Config.Profiles[serverProfileIndex];
            profile.PlayerCount = playerCount;
            Config.Profiles[serverProfileIndex] = profile;
            // Force an update of the UI
            Invalidate();
          }
        }
      }
    }

    #endregion

    #region Method: UpdateServerStatus

    private enum ServerStatus
    {
      Stopped = 0,
      Starting = 1,
      Running = 2,
      Stopping = 3
    }

    private void UpdateServerStatus(int serverHostID, ServerStatus newStatus)
    {
      int serverProfileIndex = GetServerProfileIndex(serverHostID);
      if (serverProfileIndex > -1)
      {
        /*
         * Status:
         *   0 = Stopped
         *   1 = Starting up
         *   2 = Running
         *   3 = Stopping / shutting down
         * 
         */
        if (Config.Profiles[serverProfileIndex].Status != (byte)newStatus)
        {
          ServerProfile profile = Config.Profiles[serverProfileIndex];
          profile.Status = (byte)newStatus;
          Config.Profiles[serverProfileIndex] = profile;
          // Force an update of the UI
          Invalidate();
        }
      }
    }

    #endregion
    
    #endregion

    #region ===== ServerHost Events =====

    private void ServerHost_ServerStarting(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerStarting), serverHostID);
        return;
      }

      // Thread safe past this point
      UpdateServerStatus(serverHostID, ServerStatus.Starting);

      if (Config.Profiles[profileSelectionIndex].ID == serverHostID)
      {
        btnStart.Enabled = false;
      }
    }

    private void ServerHost_ConsoleChanged(int serverHostID, string logLevel, string logMessage, string modID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string, string>(ServerHost_ConsoleChanged), serverHostID, logLevel, logMessage, modID);
        return;
      }

      // leave as is for now ...
      System.Diagnostics.Debug.WriteLine("#" + serverHostID.ToString() + " [" + logLevel + "] [" + modID + "]: " + logMessage);
    }

    private void ServerHost_ServerStarted(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerStarted), serverHostID);
        return;
      }

      // Thread safe past this point
      UpdateServerStatus(serverHostID, ServerStatus.Running);

      if (Config.Profiles[profileSelectionIndex].ID == serverHostID)
      {
        btnStop.Enabled = true;
      }
    }

    private void ServerHost_PlayerJoined(int serverHostID, string playerName, string playerUUID, byte[] ip)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string, byte[]>(ServerHost_PlayerJoined), serverHostID, playerName, playerUUID, ip);
        return;
      }

      // may not need this for now ...
      UpdatePlayerCount(serverHostID);

    }

    private void ServerHost_PlayerParted(int serverHostID, string playerName, string playerUUID, byte[] ip)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string, byte[]>(ServerHost_PlayerParted), serverHostID, playerName, playerUUID, ip);
        return;
      }

      // may not need this for now ...
      UpdatePlayerCount(serverHostID);

    }

    private void ServerHost_ServerShuttingDown(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerShuttingDown), serverHostID);
        return;
      }

      // Thread safe past this point
      UpdateServerStatus(serverHostID, ServerStatus.Stopping);

      if (Config.Profiles[profileSelectionIndex].ID == serverHostID)
      {
        btnStop.Enabled = false;
      }
    }

    private void ServerHost_ServerStopped(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerStopped), serverHostID);
        return;
      }

      // Thread safe past this point
      UpdateServerStatus(serverHostID, ServerStatus.Stopped);

      if (Config.Profiles[profileSelectionIndex].ID == serverHostID)
      {
        btnStart.Enabled = true;
      }
    }

    private List<ServerHost> mvarServerHosts = new List<ServerHost>();

    private void InitializeServerHostList()
    {
      for (int p = 0; p < Config.Count; p++)
      {
        mvarServerHosts.Add(new ServerHost(Config.Profiles[p].ID));
        mvarServerHosts[p].ServerStarting += ServerHost_ServerStarting;
        mvarServerHosts[p].ConsoleChanged += ServerHost_ConsoleChanged;
        mvarServerHosts[p].ServerStarted += ServerHost_ServerStarted;
        mvarServerHosts[p].PlayerJoined += ServerHost_PlayerJoined;
        mvarServerHosts[p].PlayerParted += ServerHost_PlayerParted;
        mvarServerHosts[p].ServerShuttingDown += ServerHost_ServerShuttingDown;
        mvarServerHosts[p].ServerStopped += ServerHost_ServerStopped;
        mvarServerHosts[p].ConfigureServer(Config.Profiles[p]);
        //NOTE: The assignment of RCon port must be changed to avoid port conflicts!!
        mvarServerHosts[p].RemoteConsolePort = 25665 + p;
        mvarServerHosts[p].UseRandomizedRConPassword = true;
      }
    }

    #endregion

    #region ===== Control Events =====

    private void btnAdd_Click(object sender, EventArgs e)
    {
      ServerProfileConfigDialog dialog = new ServerProfileConfigDialog();
      
      if (dialog.ShowDialog(this) == DialogResult.OK)
      {
        Config.Add(dialog.Profile);
        Config.Save();
        CheckServerProfiles();
      }

      dialog.Dispose();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1)
        {
          if (mvarServerHosts[index].Running)
          {
            MessageBox.Show(
              "\"" + Config.Profiles[profileSelectionIndex].Name + "\" is currently running!\n\nPlease shut down the server before changing the configuration.",
              "Please shut down server!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation
              );
          }
          else
          {
            ServerProfileConfigDialog dialog = new ServerProfileConfigDialog();
            dialog.Profile = Config.Profiles[profileSelectionIndex];

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
              Config.Profiles[profileSelectionIndex] = dialog.Profile;
              Config.Save();
              CheckServerProfiles();
            }

            dialog.Dispose();
          }

        }
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {

    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1)
        {
          mvarServerHosts[index].Start();
          btnStart.Enabled = false;
        }
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1 && mvarServerHosts[index].Running)
        {
          mvarServerHosts[index].Stop();
          btnStop.Enabled = false;
        }
      }
    }

    #endregion

    #region ===== Rendering Stuff on Form =====

    private const int ServerProfileMaximumWidth = 500; // in pixels
    private const int ServerProfileMargin = 5; // in pixels

    private int innerWidth = 0;
    private int innerHeight = 0;

    private int profileHoverIndex = -1;

    private int profileSelectionIndex = -1;

    private Bitmap StatusIconStopped = null;
    private Bitmap StatusIconStarting = null;
    private Bitmap StatusIconRunning = null;
    private Bitmap StatusIconStopping = null;

    private void InitializeStatusIcons()
    {
      StatusIconStopped = GetResourceImageByName("Stopped");
      StatusIconStarting = GetResourceImageByName("Starting");
      StatusIconRunning = GetResourceImageByName("Running");
      StatusIconStopping = GetResourceImageByName("Stopping");
    }

    private void DrawSelectionBox(Graphics gr, int x, int y, Color color)
    {
      gr.FillRectangle(
        new SolidBrush(Color.FromArgb(64, color.R, color.G, color.B)),
        new Rectangle(
          x - ServerProfileMargin,
          y - ServerProfileMargin,
          ServerProfileMaximumWidth + (2 * ServerProfileMargin),
          64 + (2 * ServerProfileMargin)
          )
          );
      gr.DrawRectangle(
        new Pen(Color.FromArgb(255, color.R, color.G, color.B)),
        new Rectangle(
          x - ServerProfileMargin,
          y - ServerProfileMargin,
          (ServerProfileMaximumWidth + (2 * ServerProfileMargin)) - 1,
          (64 + (2 * ServerProfileMargin)) - 1
          )
        );
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (Config.Count > 0)
      {
        innerWidth = this.Width - 16; // in pixels
        innerHeight = this.Height - 38; // in pixels

        // Adjust for buttons at the bottom of the form:
        int profileHeight = innerHeight - ((2 * btnAdd.Height) + (3 * 6) + 8);
        // 2 buttons stacked on top of each other; each has a height of 23px
        // 3 spacings needed; each calculated to be 6px
        // add another 8px for the bottom most spacing - just because we can

        // Draw a line across the form showing the inner height
        e.Graphics.DrawLine(Pens.White, new Point(0, profileHeight), new Point(innerWidth, profileHeight));

        int x = (innerWidth - ServerProfileMaximumWidth) / 2;
        int y = ServerProfileMargin;

        Font nameFont = new Font(this.Font.FontFamily, 12.0f, FontStyle.Bold);
        Font miscFont = new Font(this.Font.FontFamily, 10.5f, FontStyle.Regular);

        for (int p = 0; p < Config.Count; p++)
        {
          // Hover and selection boxes
          if (p == profileSelectionIndex)
          {
            DrawSelectionBox(e.Graphics, x, y, Color.CornflowerBlue);
          }
          else if (p == profileHoverIndex)
          {
            DrawSelectionBox(e.Graphics, x, y, Color.FromArgb(255, 96, 96, 96));
          }

          if (Config.Profiles[p].Icon != null)
          {
            e.Graphics.DrawImage(Config.Profiles[p].Icon, x, y);
          }
          else
          {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(x, y, 64, 64));
          }

          // Render the current server status icon
          switch (Config.Profiles[p].Status)
          {
            case 0: // Stopped
              if (StatusIconStopped != null)
              {
                e.Graphics.DrawImage(
                  StatusIconStopped, 
                  x + (ServerProfileMaximumWidth - StatusIconStopped.Width), 
                  y + (64 - StatusIconStopped.Height)
                  );
              }
              break;
            case 1: // Starting
              if (StatusIconStarting != null)
              {
                e.Graphics.DrawImage(
                  StatusIconStarting,
                  x + (ServerProfileMaximumWidth - StatusIconStarting.Width),
                  y + (64 - StatusIconStarting.Height)
                  );
              }
              break;
            case 2: // Running
              if (StatusIconRunning != null)
              {
                e.Graphics.DrawImage(
                  StatusIconRunning,
                  x + (ServerProfileMaximumWidth - StatusIconRunning.Width),
                  y + (64 - StatusIconRunning.Height)
                  );
              }
              break;
            case 3: // Stopping
              if (StatusIconStopping != null)
              {
                e.Graphics.DrawImage(
                  StatusIconStopping,
                  x + (ServerProfileMaximumWidth - StatusIconStopping.Width),
                  y + (64 - StatusIconStopping.Height)
                  );
              }
              break;
          }

          // Next up: render some text...
          // First: the custom profile name
          e.Graphics.DrawString(
            Config.Profiles[p].Name, 
            nameFont, 
            Brushes.CornflowerBlue, 
            (x + 64) + 10,
            y
            );

          SizeF size = e.Graphics.MeasureString(Config.Profiles[p].Name, nameFont);

          // Render the MOTD:
          e.Graphics.DrawString(
            Config.Profiles[p].MOTD,
            miscFont,
            new SolidBrush(Color.FromArgb(255, 224, 224, 224)),
            (x + 64) + 12,
            y + size.Height
            );

          // Render current player count / max player count
          string playerInfo = Config.Profiles[p].PlayerCount.ToString() + " / " + Config.Profiles[p].MaxPlayers.ToString();
          size = e.Graphics.MeasureString(playerInfo, miscFont);
          e.Graphics.DrawString(playerInfo, miscFont, Brushes.White, x + (ServerProfileMaximumWidth - size.Width), y);

          // Render the configured port number
          e.Graphics.DrawString(
            "Port: " + Config.Profiles[p].Port.ToString(), 
            miscFont, 
            new SolidBrush(Color.FromArgb(255, 224, 224, 224)),
            (x + 64) + 12,
            y + (64 - (size.Height + 1))
            );

          y += 64 + (2 * ServerProfileMargin);
        }

      }

    }

    #endregion

    #region ===== Form Events =====

    private void MainForm_Load(object sender, EventArgs e)
    {
      CheckServerProfiles();
      InitializeServerHostList();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      SelectServerProfile(-1);
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
      int hoverIndex = GetMouseProfileIndex(e);

      if (hoverIndex > -1)
      { // Inside a server profile
        
        if (hoverIndex != profileHoverIndex)
        {
          profileHoverIndex = hoverIndex;
          Invalidate();
        }

      }
      else
      { // Outside a server profile

        if (profileHoverIndex > -1)
        {
          profileHoverIndex = -1;
          Invalidate();
        }

      }
    }

    private void MainForm_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        SelectServerProfile(GetMouseProfileIndex(e));
      }
    }

    #endregion

    #region ===== Constructor =====

    public MainForm()
    {
      InitializeComponent();
      InitializeStatusIcons();

      this.Shown += MainForm_Shown;

      this.MouseMove += MainForm_MouseMove;
      this.MouseClick += MainForm_MouseClick;

      SetStyle(
        ControlStyles.AllPaintingInWmPaint | 
        ControlStyles.OptimizedDoubleBuffer | 
        ControlStyles.ResizeRedraw | 
        ControlStyles.UserPaint, 
        true
        );
    }

    #endregion

  }
}
