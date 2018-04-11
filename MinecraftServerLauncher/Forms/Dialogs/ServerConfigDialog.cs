using CSharpLibs.ConfigTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
  public partial class ServerConfigDialog : Form
  {

    #region ===== Configuration =====

    INIFile serverProperties = new INIFile();

    private string ServerPath = "";

    #endregion

    #region ===== ComboBox/DropDown Population =====

    private void PopulateLevelType()
    {
      ddLevelType.Items.Clear();
      ddLevelType.Items.Add("Default"); // DEFAULT
      ddLevelType.Items.Add("Superflat"); // FLAT
      ddLevelType.Items.Add("Large Biomes"); // LARGEBIOMES
      ddLevelType.Items.Add("Amplified"); // AMPLIFIED
      ddLevelType.Items.Add("Customized"); // CUSTOMIZED
    }

    private void PopulateGameMode()
    {
      ddGameMode.Items.Clear();
      ddGameMode.Items.Add("Survival"); // 0 = survival
      ddGameMode.Items.Add("Creative"); // 1 = creative
      ddGameMode.Items.Add("Adventure"); // 2 = adventure
      ddGameMode.Items.Add("Spectator"); // 3 = spectator
    }

    private void PopulateDifficulty()
    {
      ddDifficulty.Items.Clear();
      ddDifficulty.Items.Add("Peaceful"); // 0 = peaceful
      ddDifficulty.Items.Add("Easy"); // 1 = easy (default)
      ddDifficulty.Items.Add("Normal"); // 2 = normal
      ddDifficulty.Items.Add("Hard"); // 3 = hard
      // These are overruled if hardcore mode = true
    }

    #endregion

    #region ===== Populate Dialog =====

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

    private int IntDefault(string value, int defaultValue)
    {
      if (value.Length > 0)
      {
        int port = FixInt(value);
        if (port > 1024 && port < 65535)
        {
          return port;
        }
      }

      return defaultValue;
    }

    private bool BoolDefault(string value, bool defaultValue)
    {
      if (value.Length > 0)
      {
        switch (value.ToLower()[0])
        {
          case 't': return true;
          case 'f': return false;
        }
      }

      return defaultValue;
    }

    private void PopulateDialog()
    {
      // Server
      txtServerBindIP.Text = serverProperties.GetValue("server-ip");
      nudServerPort.Value = IntDefault(serverProperties.GetValue("server-port"), 25565);
      chkOnlineMode.Checked = BoolDefault(serverProperties.GetValue("online-mode"), true);
      // World generation
      // World options
      // Player options
      // MOTD
    }

    #endregion

    #region ===== Public Methods =====

    public void SetMinecraftServerPath(string path)
    {
      if (path.Length > 0)
      {
        ServerPath = path;
        // Check for a trailing backslash
        if (ServerPath[ServerPath.Length - 1] != '\\')
        {
          ServerPath += '\\';
        }

        if (File.Exists(ServerPath + "server.properties"))
        {
          serverProperties.Load(ServerPath + "server.properties", true);
        }
      }
    }

    #endregion

    #region ===== Form Events =====

    private void ServerConfigDialog_Load(object sender, EventArgs e)
    {
      // Pre-populate the three drop-down boxes
      PopulateLevelType();
      PopulateGameMode();
      PopulateDifficulty();
    }

    private void ServerConfigDialog_Shown(object sender, EventArgs e)
    {
      PopulateDialog();
    }

    #endregion

    #region ===== Constructor =====

    public ServerConfigDialog()
    {
      InitializeComponent();

      this.Shown += ServerConfigDialog_Shown;
    }

    #endregion

  }
}
