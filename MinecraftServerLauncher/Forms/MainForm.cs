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
        if (File.Exists(Config.Profiles[p].Path + Config.Profiles[p].Jar))
        {
          if (File.Exists(Config.Profiles[p].Path + "server-icon.png"))
          {
            ServerProfile profile = Config.Profiles[p];
            bool iconLoaded = false;

            if (profile.Icon != null)
            {
              profile.Icon.Dispose();
              profile.Icon = null;
            }

            try
            {
              profile.Icon = new Bitmap(Config.Profiles[p].Path + "server-icon.png");
              iconLoaded = true;
            }
            catch
            {
              if (profile.Icon != null)
              {
                profile.Icon.Dispose();
              }
              profile.Icon = null;
            }

            if (iconLoaded)
            {
              Config.Profiles[p] = profile;
            }

          }
        }
      }

      Invalidate();
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

    #endregion

    #region ===== ServerHost Events =====

    private void ServerHost_ServerStarting(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerStarting), serverHostID);
        return;
      }

      //WARNING: This is assuming both lists are synchronized
      if (profileSelectionIndex == serverHostID)
      {
        btnStart.Enabled = false;
      }
    }

    private void ServerHost_ConsoleChanged(int serverHostID, string logLevel, string logMessage)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string>(ServerHost_ConsoleChanged), serverHostID, logLevel, logMessage);
        return;
      }

      // leave as is for now ...
    }

    private void ServerHost_ServerStarted(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerStarted), serverHostID);
        return;
      }

      //WARNING: This is assuming both lists are synchronized
      if (profileSelectionIndex == serverHostID)
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
    }

    private void ServerHost_PlayerParted(int serverHostID, string playerName, string playerUUID, byte[] ip)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int, string, string, byte[]>(ServerHost_PlayerParted), serverHostID, playerName, playerUUID, ip);
        return;
      }

      // may not need this for now ...
    }

    private void ServerHost_ServerShuttingDown(int serverHostID)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(ServerHost_ServerShuttingDown), serverHostID);
        return;
      }

      //WARNING: This is assuming both lists are synchronized
      if (profileSelectionIndex == serverHostID)
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

      //WARNING: This is assuming both lists are synchronized
      if (profileSelectionIndex == serverHostID)
      {
        btnStart.Enabled = true;
      }

    }

    private List<ServerHost> mvarServerHosts = new List<ServerHost>();

    private void InitializeServerHostList()
    {
      for (int p = 0; p < Config.Count; p++)
      {
        mvarServerHosts.Add(new ServerHost(p));
        mvarServerHosts[p].ServerStarting += ServerHost_ServerStarting;
        mvarServerHosts[p].ConsoleChanged += ServerHost_ConsoleChanged;
        mvarServerHosts[p].ServerStarted += ServerHost_ServerStarted;
        mvarServerHosts[p].PlayerJoined += ServerHost_PlayerJoined;
        mvarServerHosts[p].PlayerParted += ServerHost_PlayerParted;
        mvarServerHosts[p].ServerShuttingDown += ServerHost_ServerShuttingDown;
        mvarServerHosts[p].ServerStopped += ServerHost_ServerStopped;
        mvarServerHosts[p].ConfigureServer(Config.Profiles[p]);
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

    private void btnRemove_Click(object sender, EventArgs e)
    {

    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      //TODO: implement starting this server
      if (profileSelectionIndex > -1)
      {

        mvarServerHosts[profileSelectionIndex].Start();
        btnStart.Enabled = false;
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      //TODO: implement stopping this server
      if (profileSelectionIndex > -1 && mvarServerHosts[profileSelectionIndex].Running)
      {
        mvarServerHosts[profileSelectionIndex].Stop();
        btnStop.Enabled = false;
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

          // Next up: render some text...
          e.Graphics.DrawString(Config.Profiles[p].Name, nameFont, Brushes.CornflowerBlue, (x + 64) + 10, y);

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
