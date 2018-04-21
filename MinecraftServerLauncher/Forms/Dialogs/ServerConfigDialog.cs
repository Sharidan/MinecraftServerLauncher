using CSharpLibs.ConfigTools;
using System;
using System.IO;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
  public partial class ServerConfigDialog : Form
  {

    #region ===== Configuration =====

    INIFile serverProperties = new INIFile();

    private string ServerPath = "";

    #endregion

    #region ===== Internal Helper Methods =====

    #region Method: BoolDefault

    /// <summary>
    /// Attempts to convert the passed string based boolean into a real boolean.
    /// </summary>
    /// <param name="value">The stored "true"/"false" value to convert.</param>
    /// <param name="defaultValue">The default value to apply if the conversion fails.</param>
    /// <returns>Returns the converted boolean or default value.</returns>
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

    #endregion

    #region Method: ConvertChecked

    /// <summary>
    /// Converts a CheckBox .Checked property into a string value.
    /// </summary>
    /// <param name="checkBox">The CheckBox to convert.</param>
    /// <returns>Returns a string representation of the .Checked value.</returns>
    private string ConvertChecked(CheckBox checkBox)
    {
      if (checkBox.Checked)
      {
        return "true";
      }

      return "false";
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

    #region Method: GenerateDefaultSetup

    /// <summary>
    /// Generates a set of default settings.
    /// </summary>
    private void GenerateDefaultSetup()
    {
      serverProperties.Clear();
      serverProperties.VirtualGrouping = true;

      serverProperties.ClearComments();
      serverProperties.AddComment("#Minecraft server properties");
      serverProperties.AddComment("#(File Modification Datestamp)");

      // Server group
      serverProperties.SetValue("server-ip", "");
      serverProperties.SetValue("server-port", "25565");
      serverProperties.SetValue("online-mode", "true");

      // World generation group
      serverProperties.SetValue("level-name", "world");
      serverProperties.SetValue("level-type", "DEFAULT");
      serverProperties.SetValue("generator-settings", "");
      serverProperties.SetValue("level-seed", "");
      serverProperties.SetValue("allow-nether", "true");
      serverProperties.SetValue("spawn-protection", "16");

      // World options group
      serverProperties.SetValue("generate-structures", "true");
      serverProperties.SetValue("spawn-npcs", "true");
      serverProperties.SetValue("spawn-animals", "true");
      serverProperties.SetValue("spawn-monsters", "true");
      serverProperties.SetValue("enable-command-block", "false");

      // Player options group
      serverProperties.SetValue("gamemode", "0");
      serverProperties.SetValue("difficulty", "1");
      serverProperties.SetValue("hardcore", "false");
      serverProperties.SetValue("pvp", "true");
      serverProperties.SetValue("max-players", "20");
      serverProperties.SetValue("view-distance", "10");
      serverProperties.SetValue("white-list", "false");

      // Message of the day
      serverProperties.SetValue("motd", "A Minecraft server");
    }

    #endregion

    #region Method: IntDefault

    /// <summary>
    /// Attempts to convert the passed string value into an int.
    /// </summary>
    /// <param name="value">The stored numeric value to convert.</param>
    /// <param name="defaultValue">The default value to use if the conversion fails.</param>
    /// <returns>Returns the converted int value or the specified defaultValue if the conversion fails.</returns>
    private int IntDefault(string value, int defaultValue)
    {
      if (value.Length > 0)
      {
        return FixInt(value);
      }

      return defaultValue;
    }

    #endregion

    #region Method: IntSpawnProtection

    /// <summary>
    /// Attempts to convert the stored spawn protection value into an int.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>Returns the converted spawn protection value within the set min/max range.</returns>
    private int IntSpawnProtection(string value)
    {
      int range = FixInt(value);

      if (range < 4)
      {
        if (range == 0)
        {
          return 16;
        }
        return 4;
      }
      else if (range > 256)
      {
        return 256;
      }

      return range;
    }

    #endregion

    #region Method: PortDefault

    /// <summary>
    /// Attempts to convert the stored port string into an int value.
    /// </summary>
    /// <param name="portNumber">The stored port number to convert.</param>
    /// <param name="defaultValue">The default port number to use if the conversion fails.</param>
    /// <returns>Returns either the converted port number within the valid range or the default port number specified if the conversion fails.</returns>
    private int PortDefault(string portNumber, int defaultPort)
    {
      if (portNumber.Length > 0)
      {
        int port = FixInt(portNumber);
        if (port > 1024 && port < 65535)
        {
          return port;
        }
      }

      return defaultPort;
    }

    #endregion

    #region Method: StringDefault

    /// <summary>
    /// Checks the passed string value for contents and returns a value according to content.
    /// </summary>
    /// <param name="value">The primary value to check and return.</param>
    /// <param name="defaultValue">The default value to return if the primary value is empty.</param>
    /// <returns>Returns the primary value if it has contents, otherwise the default value.</returns>
    private string StringDefault(string value, string defaultValue)
    {
      if (value.Trim().Length > 0)
      {
        return value.Trim();
      }

      return defaultValue;
    }

    #endregion

    #region Method: ValidateLevelName

    /// <summary>
    /// Validates the passed level name by removing file system illegal characters and trimming any excess spaces.
    /// </summary>
    /// <param name="levelName">The levelName to validate.</param>
    /// <returns>Returns a formatted copy of the passed levelName, where file system illegal characters and excess spaces are removed.</returns>
    private string ValidateLevelName(string levelName)
    {
      const string illegal = ":\\*?<>|";
      string result = levelName.Trim();

      for (int i = 0; i < illegal.Length; i++)
      {
        result = result.Replace(illegal[i].ToString(), "");
      }

      return result.Trim();
    }

    #endregion

    #endregion

    #region ===== ComboBox/DropDown Handling =====

    #region ----- Populating ComboBoxes width values -----

    #region Method: PopulateDifficulty

    /// <summary>
    /// Populates the Difficulty drop-down.
    /// </summary>
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

    #region Method: PopulateGameMode

    /// <summary>
    /// Populates the GameMode drop-down.
    /// </summary>
    private void PopulateGameMode()
    {
      ddGameMode.Items.Clear();
      ddGameMode.Items.Add("Survival"); // 0 = survival
      ddGameMode.Items.Add("Creative"); // 1 = creative
      ddGameMode.Items.Add("Adventure"); // 2 = adventure
      ddGameMode.Items.Add("Spectator"); // 3 = spectator
    }

    #endregion

    #region Method: PopulateLevelType

    /// <summary>
    /// Populates the LevelType drop-down box.
    /// </summary>
    private void PopulateLevelType()
    {
      ddLevelType.Items.Clear();
      ddLevelType.Items.Add("Default"); // DEFAULT
      ddLevelType.Items.Add("Superflat"); // FLAT
      ddLevelType.Items.Add("Large Biomes"); // LARGEBIOMES
      ddLevelType.Items.Add("Amplified"); // AMPLIFIED
      ddLevelType.Items.Add("Customized"); // CUSTOMIZED
    }

    #endregion

    #endregion

    #region ----- Getting CombBox/DropDown values -----

    #region Method: GetComboBoxSelectedIndex

    /// <summary>
    /// Attempts to convert the .SelectedIndex of the passed ComboBox into a string value. If not entry is selected, the defaultValue is used.
    /// </summary>
    /// <param name="comboBox">The ComboBox to convert.</param>
    /// <param name="defaultValue">The default value to use, if no entry is selected.</param>
    /// <returns>Returns the string representation of the selected entry or default value if no entry is selected.</returns>
    private string GetComboBoxSelectedIndex(ComboBox comboBox, int defaultValue)
    {
      if (comboBox.SelectedIndex == -1)
      {
        return defaultValue.ToString();
      }

      return comboBox.SelectedIndex.ToString();
    }

    #endregion

    #region Method: GetSelectedLevelType

    /// <summary>
    /// Gets the string setting for the currently selected LevelType.
    /// </summary>
    /// <returns>Returns the string setting value according to the current .SelectedIndex of the LevelType ComboBox.</returns>
    private string GetSelectedLevelType()
    {
      if (ddLevelType.SelectedIndex > -1)
      {
        switch (ddLevelType.SelectedIndex)
        {
          case 0: return "DEFAULT";
          case 1: return "FLAT";
          case 2: return "LARGEBIOMES";
          case 3: return "AMPLIFIED";
          case 4: return "CUSTOMIZED";
        }
      }

      return "DEFAULT";
    }

    #endregion

    #endregion

    #region ----- Setting ComboBox .SelectedIndex according to stored values or defaults -----

    #region Method: SelectDifficulty

    /// <summary>
    /// Selects the specified entry in the Difficulty ComboBox.
    /// </summary>
    /// <param name="difficulty">The stored difficulty in server.properties</param>
    /// <param name="defaultValue">The default difficulty to select if the stored value is invalid.</param>
    /// <returns>Returns a valid Difficulty drop-down .SelectedIndex value according to the stored or default value.</returns>
    private int SelectDifficulty(string difficulty, int defaultValue)
    {
      int idx = FixInt(difficulty);

      if (idx >= 0 && idx < ddDifficulty.Items.Count)
      {
        return idx;
      }

      return defaultValue;
    }

    #endregion

    #region Method: SelectGameMode

    /// <summary>
    /// Selects the specified entry in the GameMode ComboBox.
    /// </summary>
    /// <param name="gameMode">The stored gamemode in server.properties</param>
    /// <returns>Returns a valid GameMode drop-down .SelectedIndex value according to the stored value or the first entry if not valid.</returns>
    private int SelectGameMode(string gameMode)
    {
      int idx = FixInt(gameMode);

      if (idx >= 0 && idx < ddGameMode.Items.Count)
      {
        return idx;
      }

      return 0; // Survival
    }

    #endregion

    #region Method: SelectLevelType

    /// <summary>
    /// Selects the specified entry in the LevelType ComboBox.
    /// </summary>
    /// <param name="levelType">The stored leveltype in server.properties</param>
    /// <returns>Returns a valid LevelType drop-down .SelectedIndex value according to the stored value or the first entry if not valid.</returns>
    private int SelectLevelType(string levelType)
    {
      int idx = FixInt(levelType);

      if (idx >= 0 && idx < ddLevelType.Items.Count)
      {
        return idx;
      }

      return 0; // DEFAULT
    }

    #endregion

    #endregion

    #endregion

    #region ===== Populate Dialog =====

    /// <summary>
    /// Populates the entire dialog with stored or default values.
    /// </summary>
    private void PopulateDialog()
    {
      // Server
      txtServerBindIP.Text = serverProperties.GetValue("server-ip");
      nudServerPort.Value = PortDefault(serverProperties.GetValue("server-port"), 25565);
      chkOnlineMode.Checked = BoolDefault(serverProperties.GetValue("online-mode"), true);
      // World generation
      txtLevelName.Text = StringDefault(serverProperties.GetValue("level-name"), "world");
      ddLevelType.SelectedIndex = SelectLevelType(serverProperties.GetValue("level-type"));
      txtGeneratorSettings.Text = serverProperties.GetValue("generator-settings");
      txtLevelSeed.Text = serverProperties.GetValue("level-seed");
      chkAllowNether.Checked = BoolDefault(serverProperties.GetValue("allow-nether"), true);
      nudSpawnProtection.Value = IntSpawnProtection(serverProperties.GetValue("spawn-protection"));
      // World options
      chkGenerateStructures.Checked = BoolDefault(serverProperties.GetValue("generate-structures"), true);
      chkSpawnNPCs.Checked = BoolDefault(serverProperties.GetValue("spawn-npcs"), true);
      chkSpawnAnimals.Checked = BoolDefault(serverProperties.GetValue("spawn-animals"), true);
      chkSpawnMonsters.Checked = BoolDefault(serverProperties.GetValue("spawn-monsters"), true);
      chkEnableCommandBlock.Checked = BoolDefault(serverProperties.GetValue("enable-command-block"), false);
      // Player options
      ddGameMode.SelectedIndex = SelectGameMode(serverProperties.GetValue("gamemode"));
      ddDifficulty.SelectedIndex = SelectDifficulty(serverProperties.GetValue("difficulty"), 1);
      chkHardcore.Checked = BoolDefault(serverProperties.GetValue("hardcore"), false);
      chkPvP.Checked = BoolDefault(serverProperties.GetValue("pvp"), true);
      nudMaximumPlayers.Value = IntDefault(serverProperties.GetValue("max-players"), 20);
      nudViewDistance.Value = IntDefault(serverProperties.GetValue("view-distance"), 10);
      chkWhitelist.Checked = BoolDefault(serverProperties.GetValue("white-list"), false);
      // MOTD
      txtMOTD.Text = StringDefault(serverProperties.GetValue("motd"), "A Minecraft server");
    }

    #endregion

    #region ===== Public Methods =====

    /// <summary>
    /// Sets the path to the Minecraft server instance that the dialog should lock to.
    /// </summary>
    /// <param name="path">The fully qualified path to where the Minecraft server instance resides.</param>
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
          // The server.properties file exists, so we'll try to load it from disk
          serverProperties.Load(ServerPath + "server.properties", true);
        }
        else
        {
          // No server.properties file was found, so we generate the default settings
          GenerateDefaultSetup();
        }
      }
    }

    #endregion

    #region ===== Control Events =====

    private void btnAccept_Click(object sender, EventArgs e)
    {
      string levelName = ValidateLevelName(txtLevelName.Text);

      if (levelName.Length > 0)
      {
        // Server group
        serverProperties.SetValue("server-ip", txtServerBindIP.Text.Trim());
        serverProperties.SetValue("server-port", ((int)nudServerPort.Value).ToString());
        serverProperties.SetValue("online-mode", ConvertChecked(chkOnlineMode));

        // World generation group
        serverProperties.SetValue("level-name", levelName);
        serverProperties.SetValue("level-type", GetSelectedLevelType());
        serverProperties.SetValue("generator-settings", txtGeneratorSettings.Text.Trim());
        serverProperties.SetValue("level-seed", txtLevelSeed.Text.Trim());
        serverProperties.SetValue("allow-nether", ConvertChecked(chkAllowNether));
        serverProperties.SetValue("spawn-protection", ((int)nudSpawnProtection.Value).ToString());

        // World options group
        serverProperties.SetValue("generate-structures", ConvertChecked(chkGenerateStructures));
        serverProperties.SetValue("spawn-npcs", ConvertChecked(chkSpawnNPCs));
        serverProperties.SetValue("spawn-animals", ConvertChecked(chkSpawnAnimals));
        serverProperties.SetValue("spawn-monsters", ConvertChecked(chkSpawnMonsters));
        serverProperties.SetValue("enable-command-block", ConvertChecked(chkEnableCommandBlock));

        // Player options group
        serverProperties.SetValue("gamemode", GetComboBoxSelectedIndex(ddGameMode, 0));
        serverProperties.SetValue("difficulty", GetComboBoxSelectedIndex(ddDifficulty, 1));
        serverProperties.SetValue("hardcore", ConvertChecked(chkHardcore));
        serverProperties.SetValue("pvp", ConvertChecked(chkPvP));
        serverProperties.SetValue("max-players", ((int)nudMaximumPlayers.Value).ToString());
        serverProperties.SetValue("view-distance", ((int)nudViewDistance.Value).ToString());
        serverProperties.SetValue("white-list", ConvertChecked(chkWhitelist));

        // Message of the day
        serverProperties.SetValue("motd", StringDefault(txtMOTD.Text.Trim(), "A Minecraft server"));

        // Save the changes to disk
        serverProperties.Save();

        // Closes this window, returning "OK" as the result
        this.DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(
          "The level name must be specified and must be a combination of the letters A to Z, both included.\n\nPlease correct and try again.",
          "Invalid level name specified!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation
          );
        txtLevelName.Focus();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
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
      // Populate the dialog with the loaded or generated default values
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
