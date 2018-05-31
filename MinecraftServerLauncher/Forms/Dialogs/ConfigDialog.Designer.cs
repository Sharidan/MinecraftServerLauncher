namespace MinecraftServerLauncher
{
  partial class ConfigDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.grpMemory = new System.Windows.Forms.GroupBox();
      this.lblMemorySize = new System.Windows.Forms.Label();
      this.nudMemory = new System.Windows.Forms.NumericUpDown();
      this.lblMemoryInfo = new System.Windows.Forms.Label();
      this.grpServerPath = new System.Windows.Forms.GroupBox();
      this.lblServerPath = new System.Windows.Forms.Label();
      this.txtServerPath = new System.Windows.Forms.TextBox();
      this.lblServerJar = new System.Windows.Forms.Label();
      this.txtServerJar = new System.Windows.Forms.TextBox();
      this.btnSelectServer = new System.Windows.Forms.Button();
      this.chkAutoStartServer = new System.Windows.Forms.CheckBox();
      this.txtServerName = new System.Windows.Forms.TextBox();
      this.lblServerName = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.grpMOTD = new System.Windows.Forms.GroupBox();
      this.txtMOTD2 = new System.Windows.Forms.TextBox();
      this.txtMOTD1 = new System.Windows.Forms.TextBox();
      this.grpPlayerOptions = new System.Windows.Forms.GroupBox();
      this.chkWhitelist = new System.Windows.Forms.CheckBox();
      this.lblViewDistanceInfo = new System.Windows.Forms.Label();
      this.nudViewDistance = new System.Windows.Forms.NumericUpDown();
      this.lblViewDistance = new System.Windows.Forms.Label();
      this.nudMaximumPlayers = new System.Windows.Forms.NumericUpDown();
      this.lblMaxPlayerSlots = new System.Windows.Forms.Label();
      this.chkPvP = new System.Windows.Forms.CheckBox();
      this.chkHardcore = new System.Windows.Forms.CheckBox();
      this.cbDifficulty = new System.Windows.Forms.ComboBox();
      this.lblDifficulty = new System.Windows.Forms.Label();
      this.cbGameMode = new System.Windows.Forms.ComboBox();
      this.lblGameMode = new System.Windows.Forms.Label();
      this.grpWorldOptions = new System.Windows.Forms.GroupBox();
      this.chkEnableCommandBlock = new System.Windows.Forms.CheckBox();
      this.chkSpawnMonsters = new System.Windows.Forms.CheckBox();
      this.chkSpawnAnimals = new System.Windows.Forms.CheckBox();
      this.chkSpawnNPCs = new System.Windows.Forms.CheckBox();
      this.chkGenerateStructures = new System.Windows.Forms.CheckBox();
      this.grpWorldGeneration = new System.Windows.Forms.GroupBox();
      this.lblSpawnProtectionInfo = new System.Windows.Forms.Label();
      this.nudSpawnProtection = new System.Windows.Forms.NumericUpDown();
      this.lblSpawnProtection = new System.Windows.Forms.Label();
      this.chkAllowNether = new System.Windows.Forms.CheckBox();
      this.txtLevelSeed = new System.Windows.Forms.TextBox();
      this.lblLevelSeed = new System.Windows.Forms.Label();
      this.txtGeneratorSettings = new System.Windows.Forms.TextBox();
      this.lblGeneratorSettings = new System.Windows.Forms.Label();
      this.cbLevelType = new System.Windows.Forms.ComboBox();
      this.lblLevelType = new System.Windows.Forms.Label();
      this.txtLevelName = new System.Windows.Forms.TextBox();
      this.lblLevelName = new System.Windows.Forms.Label();
      this.grpServer = new System.Windows.Forms.GroupBox();
      this.chkOnlineMode = new System.Windows.Forms.CheckBox();
      this.nudServerPort = new System.Windows.Forms.NumericUpDown();
      this.lblPort = new System.Windows.Forms.Label();
      this.lblBindToUPInfo = new System.Windows.Forms.Label();
      this.txtBindToIP = new System.Windows.Forms.TextBox();
      this.lblBindToIP = new System.Windows.Forms.Label();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.grpWarningMessages = new System.Windows.Forms.GroupBox();
      this.txtWarningBackup1 = new System.Windows.Forms.TextBox();
      this.lblBackup1 = new System.Windows.Forms.Label();
      this.txtWarningRestart1 = new System.Windows.Forms.TextBox();
      this.lblRestart1 = new System.Windows.Forms.Label();
      this.chkWarning1Min = new System.Windows.Forms.CheckBox();
      this.txtWarningBackup5 = new System.Windows.Forms.TextBox();
      this.lblBackup5 = new System.Windows.Forms.Label();
      this.txtWarningRestart5 = new System.Windows.Forms.TextBox();
      this.lblRestart5 = new System.Windows.Forms.Label();
      this.chkWarning5Mins = new System.Windows.Forms.CheckBox();
      this.txtWarningBackup10 = new System.Windows.Forms.TextBox();
      this.lblBackup10 = new System.Windows.Forms.Label();
      this.txtWarningRestart10 = new System.Windows.Forms.TextBox();
      this.lblRestart10 = new System.Windows.Forms.Label();
      this.chkWarning10Mins = new System.Windows.Forms.CheckBox();
      this.txtWarningPrompt = new System.Windows.Forms.TextBox();
      this.lblWarningPrompt = new System.Windows.Forms.Label();
      this.chkEnableWarningMessages = new System.Windows.Forms.CheckBox();
      this.grpScheduleEdit = new System.Windows.Forms.GroupBox();
      this.btnScheduleCancel = new System.Windows.Forms.Button();
      this.btnScheduleSave = new System.Windows.Forms.Button();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.btnRemoveSchedule = new System.Windows.Forms.Button();
      this.txtBackupPath = new System.Windows.Forms.TextBox();
      this.lblScheduleBackupPath = new System.Windows.Forms.Label();
      this.chkScheduleBackup = new System.Windows.Forms.CheckBox();
      this.cbScheduleMinute = new System.Windows.Forms.ComboBox();
      this.cbScheduleHour = new System.Windows.Forms.ComboBox();
      this.lblScheduleTime = new System.Windows.Forms.Label();
      this.btnNewSchedule = new System.Windows.Forms.Button();
      this.lstSchedules = new System.Windows.Forms.ListBox();
      this.lblScheduleList = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.grpMemory.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
      this.grpServerPath.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.grpMOTD.SuspendLayout();
      this.grpPlayerOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudViewDistance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPlayers)).BeginInit();
      this.grpWorldOptions.SuspendLayout();
      this.grpWorldGeneration.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSpawnProtection)).BeginInit();
      this.grpServer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
      this.tabPage3.SuspendLayout();
      this.grpWarningMessages.SuspendLayout();
      this.grpScheduleEdit.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(773, 515);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.grpMemory);
      this.tabPage1.Controls.Add(this.grpServerPath);
      this.tabPage1.Controls.Add(this.chkAutoStartServer);
      this.tabPage1.Controls.Add(this.txtServerName);
      this.tabPage1.Controls.Add(this.lblServerName);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(765, 489);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Profile";
      // 
      // grpMemory
      // 
      this.grpMemory.Controls.Add(this.lblMemorySize);
      this.grpMemory.Controls.Add(this.nudMemory);
      this.grpMemory.Controls.Add(this.lblMemoryInfo);
      this.grpMemory.Location = new System.Drawing.Point(24, 147);
      this.grpMemory.Name = "grpMemory";
      this.grpMemory.Size = new System.Drawing.Size(716, 86);
      this.grpMemory.TabIndex = 12;
      this.grpMemory.TabStop = false;
      this.grpMemory.Text = "Memory settings";
      // 
      // lblMemorySize
      // 
      this.lblMemorySize.AutoSize = true;
      this.lblMemorySize.Location = new System.Drawing.Point(19, 29);
      this.lblMemorySize.Name = "lblMemorySize";
      this.lblMemorySize.Size = new System.Drawing.Size(47, 13);
      this.lblMemorySize.TabIndex = 8;
      this.lblMemorySize.Text = "Memory:";
      // 
      // nudMemory
      // 
      this.nudMemory.Location = new System.Drawing.Point(104, 27);
      this.nudMemory.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
      this.nudMemory.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.nudMemory.Name = "nudMemory";
      this.nudMemory.Size = new System.Drawing.Size(82, 20);
      this.nudMemory.TabIndex = 9;
      this.nudMemory.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
      // 
      // lblMemoryInfo
      // 
      this.lblMemoryInfo.AutoSize = true;
      this.lblMemoryInfo.Location = new System.Drawing.Point(19, 57);
      this.lblMemoryInfo.Name = "lblMemoryInfo";
      this.lblMemoryInfo.Size = new System.Drawing.Size(276, 13);
      this.lblMemoryInfo.TabIndex = 10;
      this.lblMemoryInfo.Text = "How much memory to set aside for java to run this server.";
      // 
      // grpServerPath
      // 
      this.grpServerPath.Controls.Add(this.lblServerPath);
      this.grpServerPath.Controls.Add(this.txtServerPath);
      this.grpServerPath.Controls.Add(this.lblServerJar);
      this.grpServerPath.Controls.Add(this.txtServerJar);
      this.grpServerPath.Controls.Add(this.btnSelectServer);
      this.grpServerPath.Location = new System.Drawing.Point(24, 55);
      this.grpServerPath.Name = "grpServerPath";
      this.grpServerPath.Size = new System.Drawing.Size(716, 86);
      this.grpServerPath.TabIndex = 11;
      this.grpServerPath.TabStop = false;
      this.grpServerPath.Text = "Server path and jar";
      // 
      // lblServerPath
      // 
      this.lblServerPath.AutoSize = true;
      this.lblServerPath.Location = new System.Drawing.Point(19, 29);
      this.lblServerPath.Name = "lblServerPath";
      this.lblServerPath.Size = new System.Drawing.Size(65, 13);
      this.lblServerPath.TabIndex = 2;
      this.lblServerPath.Text = "Server path:";
      // 
      // txtServerPath
      // 
      this.txtServerPath.Location = new System.Drawing.Point(104, 26);
      this.txtServerPath.Name = "txtServerPath";
      this.txtServerPath.ReadOnly = true;
      this.txtServerPath.Size = new System.Drawing.Size(498, 20);
      this.txtServerPath.TabIndex = 3;
      // 
      // lblServerJar
      // 
      this.lblServerJar.AutoSize = true;
      this.lblServerJar.Location = new System.Drawing.Point(19, 55);
      this.lblServerJar.Name = "lblServerJar";
      this.lblServerJar.Size = new System.Drawing.Size(55, 13);
      this.lblServerJar.TabIndex = 4;
      this.lblServerJar.Text = "Server jar:";
      // 
      // txtServerJar
      // 
      this.txtServerJar.Location = new System.Drawing.Point(104, 52);
      this.txtServerJar.Name = "txtServerJar";
      this.txtServerJar.ReadOnly = true;
      this.txtServerJar.Size = new System.Drawing.Size(315, 20);
      this.txtServerJar.TabIndex = 5;
      // 
      // btnSelectServer
      // 
      this.btnSelectServer.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnSelectServer.Location = new System.Drawing.Point(619, 25);
      this.btnSelectServer.Name = "btnSelectServer";
      this.btnSelectServer.Size = new System.Drawing.Size(75, 23);
      this.btnSelectServer.TabIndex = 6;
      this.btnSelectServer.Text = "&Select";
      this.btnSelectServer.UseVisualStyleBackColor = true;
      this.btnSelectServer.Click += new System.EventHandler(this.btnSelectServer_Click);
      // 
      // chkAutoStartServer
      // 
      this.chkAutoStartServer.AutoSize = true;
      this.chkAutoStartServer.Location = new System.Drawing.Point(24, 251);
      this.chkAutoStartServer.Name = "chkAutoStartServer";
      this.chkAutoStartServer.Size = new System.Drawing.Size(207, 17);
      this.chkAutoStartServer.TabIndex = 7;
      this.chkAutoStartServer.Text = "Auto-start server when launcher starts.";
      this.chkAutoStartServer.UseVisualStyleBackColor = true;
      // 
      // txtServerName
      // 
      this.txtServerName.Location = new System.Drawing.Point(128, 19);
      this.txtServerName.Name = "txtServerName";
      this.txtServerName.Size = new System.Drawing.Size(315, 20);
      this.txtServerName.TabIndex = 1;
      // 
      // lblServerName
      // 
      this.lblServerName.AutoSize = true;
      this.lblServerName.Location = new System.Drawing.Point(21, 22);
      this.lblServerName.Name = "lblServerName";
      this.lblServerName.Size = new System.Drawing.Size(70, 13);
      this.lblServerName.TabIndex = 0;
      this.lblServerName.Text = "Server name:";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.grpMOTD);
      this.tabPage2.Controls.Add(this.grpPlayerOptions);
      this.tabPage2.Controls.Add(this.grpWorldOptions);
      this.tabPage2.Controls.Add(this.grpWorldGeneration);
      this.tabPage2.Controls.Add(this.grpServer);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(765, 489);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Settings";
      // 
      // grpMOTD
      // 
      this.grpMOTD.Controls.Add(this.txtMOTD2);
      this.grpMOTD.Controls.Add(this.txtMOTD1);
      this.grpMOTD.Location = new System.Drawing.Point(20, 385);
      this.grpMOTD.Name = "grpMOTD";
      this.grpMOTD.Size = new System.Drawing.Size(728, 86);
      this.grpMOTD.TabIndex = 4;
      this.grpMOTD.TabStop = false;
      this.grpMOTD.Text = "Message of the day";
      // 
      // txtMOTD2
      // 
      this.txtMOTD2.Location = new System.Drawing.Point(20, 50);
      this.txtMOTD2.Name = "txtMOTD2";
      this.txtMOTD2.Size = new System.Drawing.Size(682, 20);
      this.txtMOTD2.TabIndex = 1;
      // 
      // txtMOTD1
      // 
      this.txtMOTD1.Location = new System.Drawing.Point(20, 24);
      this.txtMOTD1.Name = "txtMOTD1";
      this.txtMOTD1.Size = new System.Drawing.Size(682, 20);
      this.txtMOTD1.TabIndex = 0;
      // 
      // grpPlayerOptions
      // 
      this.grpPlayerOptions.Controls.Add(this.chkWhitelist);
      this.grpPlayerOptions.Controls.Add(this.lblViewDistanceInfo);
      this.grpPlayerOptions.Controls.Add(this.nudViewDistance);
      this.grpPlayerOptions.Controls.Add(this.lblViewDistance);
      this.grpPlayerOptions.Controls.Add(this.nudMaximumPlayers);
      this.grpPlayerOptions.Controls.Add(this.lblMaxPlayerSlots);
      this.grpPlayerOptions.Controls.Add(this.chkPvP);
      this.grpPlayerOptions.Controls.Add(this.chkHardcore);
      this.grpPlayerOptions.Controls.Add(this.cbDifficulty);
      this.grpPlayerOptions.Controls.Add(this.lblDifficulty);
      this.grpPlayerOptions.Controls.Add(this.cbGameMode);
      this.grpPlayerOptions.Controls.Add(this.lblGameMode);
      this.grpPlayerOptions.Location = new System.Drawing.Point(20, 167);
      this.grpPlayerOptions.Name = "grpPlayerOptions";
      this.grpPlayerOptions.Size = new System.Drawing.Size(361, 212);
      this.grpPlayerOptions.TabIndex = 3;
      this.grpPlayerOptions.TabStop = false;
      this.grpPlayerOptions.Text = "Player options";
      // 
      // chkWhitelist
      // 
      this.chkWhitelist.AutoSize = true;
      this.chkWhitelist.Location = new System.Drawing.Point(22, 182);
      this.chkWhitelist.Name = "chkWhitelist";
      this.chkWhitelist.Size = new System.Drawing.Size(113, 17);
      this.chkWhitelist.TabIndex = 17;
      this.chkWhitelist.Text = "Whitelisted server.";
      this.chkWhitelist.UseVisualStyleBackColor = true;
      // 
      // lblViewDistanceInfo
      // 
      this.lblViewDistanceInfo.AutoSize = true;
      this.lblViewDistanceInfo.Location = new System.Drawing.Point(185, 158);
      this.lblViewDistanceInfo.Name = "lblViewDistanceInfo";
      this.lblViewDistanceInfo.Size = new System.Drawing.Size(128, 13);
      this.lblViewDistanceInfo.TabIndex = 16;
      this.lblViewDistanceInfo.Text = "(chunk radius from player)";
      // 
      // nudViewDistance
      // 
      this.nudViewDistance.Location = new System.Drawing.Point(121, 156);
      this.nudViewDistance.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
      this.nudViewDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudViewDistance.Name = "nudViewDistance";
      this.nudViewDistance.Size = new System.Drawing.Size(58, 20);
      this.nudViewDistance.TabIndex = 15;
      this.nudViewDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // lblViewDistance
      // 
      this.lblViewDistance.AutoSize = true;
      this.lblViewDistance.Location = new System.Drawing.Point(19, 158);
      this.lblViewDistance.Name = "lblViewDistance";
      this.lblViewDistance.Size = new System.Drawing.Size(76, 13);
      this.lblViewDistance.TabIndex = 14;
      this.lblViewDistance.Text = "View distance:";
      // 
      // nudMaximumPlayers
      // 
      this.nudMaximumPlayers.Location = new System.Drawing.Point(121, 130);
      this.nudMaximumPlayers.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudMaximumPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.nudMaximumPlayers.Name = "nudMaximumPlayers";
      this.nudMaximumPlayers.Size = new System.Drawing.Size(58, 20);
      this.nudMaximumPlayers.TabIndex = 13;
      this.nudMaximumPlayers.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // lblMaxPlayerSlots
      // 
      this.lblMaxPlayerSlots.AutoSize = true;
      this.lblMaxPlayerSlots.Location = new System.Drawing.Point(19, 132);
      this.lblMaxPlayerSlots.Name = "lblMaxPlayerSlots";
      this.lblMaxPlayerSlots.Size = new System.Drawing.Size(85, 13);
      this.lblMaxPlayerSlots.TabIndex = 11;
      this.lblMaxPlayerSlots.Text = "Max player slots:";
      // 
      // chkPvP
      // 
      this.chkPvP.AutoSize = true;
      this.chkPvP.Checked = true;
      this.chkPvP.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkPvP.Location = new System.Drawing.Point(22, 107);
      this.chkPvP.Name = "chkPvP";
      this.chkPvP.Size = new System.Drawing.Size(178, 17);
      this.chkPvP.TabIndex = 10;
      this.chkPvP.Text = "Enable Player vs. Player combat";
      this.chkPvP.UseVisualStyleBackColor = true;
      // 
      // chkHardcore
      // 
      this.chkHardcore.AutoSize = true;
      this.chkHardcore.Location = new System.Drawing.Point(22, 84);
      this.chkHardcore.Name = "chkHardcore";
      this.chkHardcore.Size = new System.Drawing.Size(183, 17);
      this.chkHardcore.TabIndex = 9;
      this.chkHardcore.Text = "Hardcore mode (ignores difficulty)";
      this.chkHardcore.UseVisualStyleBackColor = true;
      // 
      // cbDifficulty
      // 
      this.cbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDifficulty.FormattingEnabled = true;
      this.cbDifficulty.Location = new System.Drawing.Point(121, 52);
      this.cbDifficulty.Name = "cbDifficulty";
      this.cbDifficulty.Size = new System.Drawing.Size(214, 21);
      this.cbDifficulty.TabIndex = 6;
      // 
      // lblDifficulty
      // 
      this.lblDifficulty.AutoSize = true;
      this.lblDifficulty.Location = new System.Drawing.Point(19, 55);
      this.lblDifficulty.Name = "lblDifficulty";
      this.lblDifficulty.Size = new System.Drawing.Size(50, 13);
      this.lblDifficulty.TabIndex = 5;
      this.lblDifficulty.Text = "Difficulty:";
      // 
      // cbGameMode
      // 
      this.cbGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbGameMode.FormattingEnabled = true;
      this.cbGameMode.Location = new System.Drawing.Point(121, 24);
      this.cbGameMode.Name = "cbGameMode";
      this.cbGameMode.Size = new System.Drawing.Size(214, 21);
      this.cbGameMode.TabIndex = 4;
      // 
      // lblGameMode
      // 
      this.lblGameMode.AutoSize = true;
      this.lblGameMode.Location = new System.Drawing.Point(19, 28);
      this.lblGameMode.Name = "lblGameMode";
      this.lblGameMode.Size = new System.Drawing.Size(67, 13);
      this.lblGameMode.TabIndex = 0;
      this.lblGameMode.Text = "Game mode:";
      // 
      // grpWorldOptions
      // 
      this.grpWorldOptions.Controls.Add(this.chkEnableCommandBlock);
      this.grpWorldOptions.Controls.Add(this.chkSpawnMonsters);
      this.grpWorldOptions.Controls.Add(this.chkSpawnAnimals);
      this.grpWorldOptions.Controls.Add(this.chkSpawnNPCs);
      this.grpWorldOptions.Controls.Add(this.chkGenerateStructures);
      this.grpWorldOptions.Location = new System.Drawing.Point(387, 226);
      this.grpWorldOptions.Name = "grpWorldOptions";
      this.grpWorldOptions.Size = new System.Drawing.Size(361, 153);
      this.grpWorldOptions.TabIndex = 2;
      this.grpWorldOptions.TabStop = false;
      this.grpWorldOptions.Text = "World options";
      // 
      // chkEnableCommandBlock
      // 
      this.chkEnableCommandBlock.AutoSize = true;
      this.chkEnableCommandBlock.Location = new System.Drawing.Point(22, 117);
      this.chkEnableCommandBlock.Name = "chkEnableCommandBlock";
      this.chkEnableCommandBlock.Size = new System.Drawing.Size(309, 17);
      this.chkEnableCommandBlock.TabIndex = 5;
      this.chkEnableCommandBlock.Text = "Enable command block. Warning! May be dangerous doing!";
      this.chkEnableCommandBlock.UseVisualStyleBackColor = true;
      // 
      // chkSpawnMonsters
      // 
      this.chkSpawnMonsters.AutoSize = true;
      this.chkSpawnMonsters.Location = new System.Drawing.Point(22, 94);
      this.chkSpawnMonsters.Name = "chkSpawnMonsters";
      this.chkSpawnMonsters.Size = new System.Drawing.Size(215, 17);
      this.chkSpawnMonsters.TabIndex = 4;
      this.chkSpawnMonsters.Text = "Spawn monsters (skellies, zomblers etc.)";
      this.chkSpawnMonsters.UseVisualStyleBackColor = true;
      // 
      // chkSpawnAnimals
      // 
      this.chkSpawnAnimals.AutoSize = true;
      this.chkSpawnAnimals.Location = new System.Drawing.Point(22, 71);
      this.chkSpawnAnimals.Name = "chkSpawnAnimals";
      this.chkSpawnAnimals.Size = new System.Drawing.Size(226, 17);
      this.chkSpawnAnimals.TabIndex = 3;
      this.chkSpawnAnimals.Text = "Spawn animals (sheep, bacon and moohs)";
      this.chkSpawnAnimals.UseVisualStyleBackColor = true;
      // 
      // chkSpawnNPCs
      // 
      this.chkSpawnNPCs.AutoSize = true;
      this.chkSpawnNPCs.Location = new System.Drawing.Point(22, 48);
      this.chkSpawnNPCs.Name = "chkSpawnNPCs";
      this.chkSpawnNPCs.Size = new System.Drawing.Size(139, 17);
      this.chkSpawnNPCs.TabIndex = 2;
      this.chkSpawnNPCs.Text = "Spawn NPCs (villagers!)";
      this.chkSpawnNPCs.UseVisualStyleBackColor = true;
      // 
      // chkGenerateStructures
      // 
      this.chkGenerateStructures.AutoSize = true;
      this.chkGenerateStructures.Location = new System.Drawing.Point(22, 25);
      this.chkGenerateStructures.Name = "chkGenerateStructures";
      this.chkGenerateStructures.Size = new System.Drawing.Size(226, 17);
      this.chkGenerateStructures.TabIndex = 1;
      this.chkGenerateStructures.Text = "Generate structures (villages, temples etc.)";
      this.chkGenerateStructures.UseVisualStyleBackColor = true;
      // 
      // grpWorldGeneration
      // 
      this.grpWorldGeneration.Controls.Add(this.lblSpawnProtectionInfo);
      this.grpWorldGeneration.Controls.Add(this.nudSpawnProtection);
      this.grpWorldGeneration.Controls.Add(this.lblSpawnProtection);
      this.grpWorldGeneration.Controls.Add(this.chkAllowNether);
      this.grpWorldGeneration.Controls.Add(this.txtLevelSeed);
      this.grpWorldGeneration.Controls.Add(this.lblLevelSeed);
      this.grpWorldGeneration.Controls.Add(this.txtGeneratorSettings);
      this.grpWorldGeneration.Controls.Add(this.lblGeneratorSettings);
      this.grpWorldGeneration.Controls.Add(this.cbLevelType);
      this.grpWorldGeneration.Controls.Add(this.lblLevelType);
      this.grpWorldGeneration.Controls.Add(this.txtLevelName);
      this.grpWorldGeneration.Controls.Add(this.lblLevelName);
      this.grpWorldGeneration.Location = new System.Drawing.Point(387, 20);
      this.grpWorldGeneration.Name = "grpWorldGeneration";
      this.grpWorldGeneration.Size = new System.Drawing.Size(361, 200);
      this.grpWorldGeneration.TabIndex = 1;
      this.grpWorldGeneration.TabStop = false;
      this.grpWorldGeneration.Text = "World generation";
      // 
      // lblSpawnProtectionInfo
      // 
      this.lblSpawnProtectionInfo.AutoSize = true;
      this.lblSpawnProtectionInfo.Location = new System.Drawing.Point(185, 165);
      this.lblSpawnProtectionInfo.Name = "lblSpawnProtectionInfo";
      this.lblSpawnProtectionInfo.Size = new System.Drawing.Size(164, 13);
      this.lblSpawnProtectionInfo.TabIndex = 13;
      this.lblSpawnProtectionInfo.Text = "(number of blocks around spawn)";
      // 
      // nudSpawnProtection
      // 
      this.nudSpawnProtection.Location = new System.Drawing.Point(121, 163);
      this.nudSpawnProtection.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.nudSpawnProtection.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
      this.nudSpawnProtection.Name = "nudSpawnProtection";
      this.nudSpawnProtection.Size = new System.Drawing.Size(58, 20);
      this.nudSpawnProtection.TabIndex = 12;
      this.nudSpawnProtection.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
      // 
      // lblSpawnProtection
      // 
      this.lblSpawnProtection.AutoSize = true;
      this.lblSpawnProtection.Location = new System.Drawing.Point(19, 165);
      this.lblSpawnProtection.Name = "lblSpawnProtection";
      this.lblSpawnProtection.Size = new System.Drawing.Size(93, 13);
      this.lblSpawnProtection.TabIndex = 9;
      this.lblSpawnProtection.Text = "Spawn protection:";
      // 
      // chkAllowNether
      // 
      this.chkAllowNether.AutoSize = true;
      this.chkAllowNether.Checked = true;
      this.chkAllowNether.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAllowNether.Location = new System.Drawing.Point(22, 137);
      this.chkAllowNether.Name = "chkAllowNether";
      this.chkAllowNether.Size = new System.Drawing.Size(157, 17);
      this.chkAllowNether.TabIndex = 8;
      this.chkAllowNether.Text = "Allow the Nether dimension.";
      this.chkAllowNether.UseVisualStyleBackColor = true;
      // 
      // txtLevelSeed
      // 
      this.txtLevelSeed.Location = new System.Drawing.Point(121, 106);
      this.txtLevelSeed.Name = "txtLevelSeed";
      this.txtLevelSeed.Size = new System.Drawing.Size(214, 20);
      this.txtLevelSeed.TabIndex = 7;
      // 
      // lblLevelSeed
      // 
      this.lblLevelSeed.AutoSize = true;
      this.lblLevelSeed.Location = new System.Drawing.Point(19, 108);
      this.lblLevelSeed.Name = "lblLevelSeed";
      this.lblLevelSeed.Size = new System.Drawing.Size(62, 13);
      this.lblLevelSeed.TabIndex = 6;
      this.lblLevelSeed.Text = "Level seed:";
      // 
      // txtGeneratorSettings
      // 
      this.txtGeneratorSettings.Location = new System.Drawing.Point(121, 77);
      this.txtGeneratorSettings.Name = "txtGeneratorSettings";
      this.txtGeneratorSettings.Size = new System.Drawing.Size(214, 20);
      this.txtGeneratorSettings.TabIndex = 5;
      // 
      // lblGeneratorSettings
      // 
      this.lblGeneratorSettings.AutoSize = true;
      this.lblGeneratorSettings.Location = new System.Drawing.Point(19, 79);
      this.lblGeneratorSettings.Name = "lblGeneratorSettings";
      this.lblGeneratorSettings.Size = new System.Drawing.Size(96, 13);
      this.lblGeneratorSettings.TabIndex = 4;
      this.lblGeneratorSettings.Text = "Generator settings:";
      // 
      // cbLevelType
      // 
      this.cbLevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbLevelType.FormattingEnabled = true;
      this.cbLevelType.Location = new System.Drawing.Point(121, 50);
      this.cbLevelType.Name = "cbLevelType";
      this.cbLevelType.Size = new System.Drawing.Size(214, 21);
      this.cbLevelType.TabIndex = 3;
      // 
      // lblLevelType
      // 
      this.lblLevelType.AutoSize = true;
      this.lblLevelType.Location = new System.Drawing.Point(19, 54);
      this.lblLevelType.Name = "lblLevelType";
      this.lblLevelType.Size = new System.Drawing.Size(59, 13);
      this.lblLevelType.TabIndex = 2;
      this.lblLevelType.Text = "Level type:";
      // 
      // txtLevelName
      // 
      this.txtLevelName.Location = new System.Drawing.Point(121, 25);
      this.txtLevelName.Name = "txtLevelName";
      this.txtLevelName.Size = new System.Drawing.Size(214, 20);
      this.txtLevelName.TabIndex = 1;
      this.txtLevelName.Text = "world";
      // 
      // lblLevelName
      // 
      this.lblLevelName.AutoSize = true;
      this.lblLevelName.Location = new System.Drawing.Point(19, 27);
      this.lblLevelName.Name = "lblLevelName";
      this.lblLevelName.Size = new System.Drawing.Size(65, 13);
      this.lblLevelName.TabIndex = 0;
      this.lblLevelName.Text = "Level name:";
      // 
      // grpServer
      // 
      this.grpServer.Controls.Add(this.chkOnlineMode);
      this.grpServer.Controls.Add(this.nudServerPort);
      this.grpServer.Controls.Add(this.lblPort);
      this.grpServer.Controls.Add(this.lblBindToUPInfo);
      this.grpServer.Controls.Add(this.txtBindToIP);
      this.grpServer.Controls.Add(this.lblBindToIP);
      this.grpServer.Location = new System.Drawing.Point(20, 20);
      this.grpServer.Name = "grpServer";
      this.grpServer.Size = new System.Drawing.Size(361, 141);
      this.grpServer.TabIndex = 0;
      this.grpServer.TabStop = false;
      this.grpServer.Text = "Server";
      // 
      // chkOnlineMode
      // 
      this.chkOnlineMode.AutoSize = true;
      this.chkOnlineMode.Checked = true;
      this.chkOnlineMode.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOnlineMode.Location = new System.Drawing.Point(20, 96);
      this.chkOnlineMode.Name = "chkOnlineMode";
      this.chkOnlineMode.Size = new System.Drawing.Size(88, 17);
      this.chkOnlineMode.TabIndex = 5;
      this.chkOnlineMode.Text = "Online mode.";
      this.chkOnlineMode.UseVisualStyleBackColor = true;
      // 
      // nudServerPort
      // 
      this.nudServerPort.Location = new System.Drawing.Point(121, 72);
      this.nudServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.nudServerPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
      this.nudServerPort.Name = "nudServerPort";
      this.nudServerPort.Size = new System.Drawing.Size(64, 20);
      this.nudServerPort.TabIndex = 4;
      this.nudServerPort.Value = new decimal(new int[] {
            25565,
            0,
            0,
            0});
      // 
      // lblPort
      // 
      this.lblPort.AutoSize = true;
      this.lblPort.Location = new System.Drawing.Point(17, 72);
      this.lblPort.Name = "lblPort";
      this.lblPort.Size = new System.Drawing.Size(29, 13);
      this.lblPort.TabIndex = 3;
      this.lblPort.Text = "Port:";
      // 
      // lblBindToUPInfo
      // 
      this.lblBindToUPInfo.AutoSize = true;
      this.lblBindToUPInfo.Location = new System.Drawing.Point(17, 50);
      this.lblBindToUPInfo.Name = "lblBindToUPInfo";
      this.lblBindToUPInfo.Size = new System.Drawing.Size(252, 13);
      this.lblBindToUPInfo.TabIndex = 2;
      this.lblBindToUPInfo.Text = "Leave empty unless you must bind to an external IP.";
      // 
      // txtBindToIP
      // 
      this.txtBindToIP.Location = new System.Drawing.Point(121, 27);
      this.txtBindToIP.Name = "txtBindToIP";
      this.txtBindToIP.Size = new System.Drawing.Size(117, 20);
      this.txtBindToIP.TabIndex = 1;
      // 
      // lblBindToIP
      // 
      this.lblBindToIP.AutoSize = true;
      this.lblBindToIP.Location = new System.Drawing.Point(17, 29);
      this.lblBindToIP.Name = "lblBindToIP";
      this.lblBindToIP.Size = new System.Drawing.Size(56, 13);
      this.lblBindToIP.TabIndex = 0;
      this.lblBindToIP.Text = "Bind to IP:";
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.grpWarningMessages);
      this.tabPage3.Controls.Add(this.chkEnableWarningMessages);
      this.tabPage3.Controls.Add(this.grpScheduleEdit);
      this.tabPage3.Controls.Add(this.btnNewSchedule);
      this.tabPage3.Controls.Add(this.lstSchedules);
      this.tabPage3.Controls.Add(this.lblScheduleList);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(765, 489);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Schedule";
      // 
      // grpWarningMessages
      // 
      this.grpWarningMessages.Controls.Add(this.txtWarningBackup1);
      this.grpWarningMessages.Controls.Add(this.lblBackup1);
      this.grpWarningMessages.Controls.Add(this.txtWarningRestart1);
      this.grpWarningMessages.Controls.Add(this.lblRestart1);
      this.grpWarningMessages.Controls.Add(this.chkWarning1Min);
      this.grpWarningMessages.Controls.Add(this.txtWarningBackup5);
      this.grpWarningMessages.Controls.Add(this.lblBackup5);
      this.grpWarningMessages.Controls.Add(this.txtWarningRestart5);
      this.grpWarningMessages.Controls.Add(this.lblRestart5);
      this.grpWarningMessages.Controls.Add(this.chkWarning5Mins);
      this.grpWarningMessages.Controls.Add(this.txtWarningBackup10);
      this.grpWarningMessages.Controls.Add(this.lblBackup10);
      this.grpWarningMessages.Controls.Add(this.txtWarningRestart10);
      this.grpWarningMessages.Controls.Add(this.lblRestart10);
      this.grpWarningMessages.Controls.Add(this.chkWarning10Mins);
      this.grpWarningMessages.Controls.Add(this.txtWarningPrompt);
      this.grpWarningMessages.Controls.Add(this.lblWarningPrompt);
      this.grpWarningMessages.Location = new System.Drawing.Point(40, 182);
      this.grpWarningMessages.Name = "grpWarningMessages";
      this.grpWarningMessages.Size = new System.Drawing.Size(695, 285);
      this.grpWarningMessages.TabIndex = 6;
      this.grpWarningMessages.TabStop = false;
      this.grpWarningMessages.Text = "Warning messages";
      this.grpWarningMessages.Visible = false;
      // 
      // txtWarningBackup1
      // 
      this.txtWarningBackup1.Location = new System.Drawing.Point(91, 248);
      this.txtWarningBackup1.Name = "txtWarningBackup1";
      this.txtWarningBackup1.Size = new System.Drawing.Size(584, 20);
      this.txtWarningBackup1.TabIndex = 16;
      this.txtWarningBackup1.Text = "Scheduled server maintenance in 1 minute!";
      // 
      // lblBackup1
      // 
      this.lblBackup1.AutoSize = true;
      this.lblBackup1.Location = new System.Drawing.Point(38, 251);
      this.lblBackup1.Name = "lblBackup1";
      this.lblBackup1.Size = new System.Drawing.Size(47, 13);
      this.lblBackup1.TabIndex = 15;
      this.lblBackup1.Text = "Backup:";
      // 
      // txtWarningRestart1
      // 
      this.txtWarningRestart1.Location = new System.Drawing.Point(91, 222);
      this.txtWarningRestart1.Name = "txtWarningRestart1";
      this.txtWarningRestart1.Size = new System.Drawing.Size(584, 20);
      this.txtWarningRestart1.TabIndex = 14;
      this.txtWarningRestart1.Text = "Scheduled server restart in 1 minute!";
      // 
      // lblRestart1
      // 
      this.lblRestart1.AutoSize = true;
      this.lblRestart1.Location = new System.Drawing.Point(38, 225);
      this.lblRestart1.Name = "lblRestart1";
      this.lblRestart1.Size = new System.Drawing.Size(44, 13);
      this.lblRestart1.TabIndex = 13;
      this.lblRestart1.Text = "Restart:";
      // 
      // chkWarning1Min
      // 
      this.chkWarning1Min.AutoSize = true;
      this.chkWarning1Min.Location = new System.Drawing.Point(18, 199);
      this.chkWarning1Min.Name = "chkWarning1Min";
      this.chkWarning1Min.Size = new System.Drawing.Size(249, 17);
      this.chkWarning1Min.TabIndex = 12;
      this.chkWarning1Min.Text = "Warn players 1 minute before scheduled event:";
      this.chkWarning1Min.UseVisualStyleBackColor = true;
      this.chkWarning1Min.CheckedChanged += new System.EventHandler(this.chkWarning1Min_CheckedChanged);
      // 
      // txtWarningBackup5
      // 
      this.txtWarningBackup5.Location = new System.Drawing.Point(91, 173);
      this.txtWarningBackup5.Name = "txtWarningBackup5";
      this.txtWarningBackup5.Size = new System.Drawing.Size(584, 20);
      this.txtWarningBackup5.TabIndex = 11;
      this.txtWarningBackup5.Text = "Scheduled server maintenance in 5 minutes!";
      // 
      // lblBackup5
      // 
      this.lblBackup5.AutoSize = true;
      this.lblBackup5.Location = new System.Drawing.Point(38, 176);
      this.lblBackup5.Name = "lblBackup5";
      this.lblBackup5.Size = new System.Drawing.Size(47, 13);
      this.lblBackup5.TabIndex = 10;
      this.lblBackup5.Text = "Backup:";
      // 
      // txtWarningRestart5
      // 
      this.txtWarningRestart5.Location = new System.Drawing.Point(91, 147);
      this.txtWarningRestart5.Name = "txtWarningRestart5";
      this.txtWarningRestart5.Size = new System.Drawing.Size(584, 20);
      this.txtWarningRestart5.TabIndex = 9;
      this.txtWarningRestart5.Text = "Scheduled server restart in 5 minutes!";
      // 
      // lblRestart5
      // 
      this.lblRestart5.AutoSize = true;
      this.lblRestart5.Location = new System.Drawing.Point(38, 150);
      this.lblRestart5.Name = "lblRestart5";
      this.lblRestart5.Size = new System.Drawing.Size(44, 13);
      this.lblRestart5.TabIndex = 8;
      this.lblRestart5.Text = "Restart:";
      // 
      // chkWarning5Mins
      // 
      this.chkWarning5Mins.AutoSize = true;
      this.chkWarning5Mins.Location = new System.Drawing.Point(18, 124);
      this.chkWarning5Mins.Name = "chkWarning5Mins";
      this.chkWarning5Mins.Size = new System.Drawing.Size(254, 17);
      this.chkWarning5Mins.TabIndex = 7;
      this.chkWarning5Mins.Text = "Warn players 5 minutes before scheduled event:";
      this.chkWarning5Mins.UseVisualStyleBackColor = true;
      this.chkWarning5Mins.CheckedChanged += new System.EventHandler(this.chkWarning5Mins_CheckedChanged);
      // 
      // txtWarningBackup10
      // 
      this.txtWarningBackup10.Location = new System.Drawing.Point(91, 98);
      this.txtWarningBackup10.Name = "txtWarningBackup10";
      this.txtWarningBackup10.Size = new System.Drawing.Size(584, 20);
      this.txtWarningBackup10.TabIndex = 6;
      this.txtWarningBackup10.Text = "Scheduled server maintenance in 10 minutes!";
      // 
      // lblBackup10
      // 
      this.lblBackup10.AutoSize = true;
      this.lblBackup10.Location = new System.Drawing.Point(38, 101);
      this.lblBackup10.Name = "lblBackup10";
      this.lblBackup10.Size = new System.Drawing.Size(47, 13);
      this.lblBackup10.TabIndex = 5;
      this.lblBackup10.Text = "Backup:";
      // 
      // txtWarningRestart10
      // 
      this.txtWarningRestart10.Location = new System.Drawing.Point(91, 72);
      this.txtWarningRestart10.Name = "txtWarningRestart10";
      this.txtWarningRestart10.Size = new System.Drawing.Size(584, 20);
      this.txtWarningRestart10.TabIndex = 4;
      this.txtWarningRestart10.Text = "Scheduled server restart in 10 minutes!";
      // 
      // lblRestart10
      // 
      this.lblRestart10.AutoSize = true;
      this.lblRestart10.Location = new System.Drawing.Point(38, 75);
      this.lblRestart10.Name = "lblRestart10";
      this.lblRestart10.Size = new System.Drawing.Size(44, 13);
      this.lblRestart10.TabIndex = 3;
      this.lblRestart10.Text = "Restart:";
      // 
      // chkWarning10Mins
      // 
      this.chkWarning10Mins.AutoSize = true;
      this.chkWarning10Mins.Location = new System.Drawing.Point(18, 49);
      this.chkWarning10Mins.Name = "chkWarning10Mins";
      this.chkWarning10Mins.Size = new System.Drawing.Size(260, 17);
      this.chkWarning10Mins.TabIndex = 2;
      this.chkWarning10Mins.Text = "Warn players 10 minutes before scheduled event:";
      this.chkWarning10Mins.UseVisualStyleBackColor = true;
      this.chkWarning10Mins.CheckedChanged += new System.EventHandler(this.chkWarning10Mins_CheckedChanged);
      // 
      // txtWarningPrompt
      // 
      this.txtWarningPrompt.Location = new System.Drawing.Point(78, 22);
      this.txtWarningPrompt.Name = "txtWarningPrompt";
      this.txtWarningPrompt.Size = new System.Drawing.Size(100, 20);
      this.txtWarningPrompt.TabIndex = 1;
      this.txtWarningPrompt.Text = "[Server]";
      // 
      // lblWarningPrompt
      // 
      this.lblWarningPrompt.AutoSize = true;
      this.lblWarningPrompt.Location = new System.Drawing.Point(15, 25);
      this.lblWarningPrompt.Name = "lblWarningPrompt";
      this.lblWarningPrompt.Size = new System.Drawing.Size(43, 13);
      this.lblWarningPrompt.TabIndex = 0;
      this.lblWarningPrompt.Text = "Prompt:";
      // 
      // chkEnableWarningMessages
      // 
      this.chkEnableWarningMessages.AutoSize = true;
      this.chkEnableWarningMessages.Location = new System.Drawing.Point(21, 159);
      this.chkEnableWarningMessages.Name = "chkEnableWarningMessages";
      this.chkEnableWarningMessages.Size = new System.Drawing.Size(149, 17);
      this.chkEnableWarningMessages.TabIndex = 5;
      this.chkEnableWarningMessages.Text = "Enable warning messages";
      this.chkEnableWarningMessages.UseVisualStyleBackColor = true;
      this.chkEnableWarningMessages.CheckedChanged += new System.EventHandler(this.chkEnableWarningMessages_CheckedChanged);
      // 
      // grpScheduleEdit
      // 
      this.grpScheduleEdit.Controls.Add(this.btnScheduleCancel);
      this.grpScheduleEdit.Controls.Add(this.btnScheduleSave);
      this.grpScheduleEdit.Controls.Add(this.btnBrowse);
      this.grpScheduleEdit.Controls.Add(this.btnRemoveSchedule);
      this.grpScheduleEdit.Controls.Add(this.txtBackupPath);
      this.grpScheduleEdit.Controls.Add(this.lblScheduleBackupPath);
      this.grpScheduleEdit.Controls.Add(this.chkScheduleBackup);
      this.grpScheduleEdit.Controls.Add(this.cbScheduleMinute);
      this.grpScheduleEdit.Controls.Add(this.cbScheduleHour);
      this.grpScheduleEdit.Controls.Add(this.lblScheduleTime);
      this.grpScheduleEdit.Location = new System.Drawing.Point(21, 137);
      this.grpScheduleEdit.Name = "grpScheduleEdit";
      this.grpScheduleEdit.Size = new System.Drawing.Size(575, 179);
      this.grpScheduleEdit.TabIndex = 4;
      this.grpScheduleEdit.TabStop = false;
      this.grpScheduleEdit.Text = "Edit schedule";
      this.grpScheduleEdit.Visible = false;
      // 
      // btnScheduleCancel
      // 
      this.btnScheduleCancel.Location = new System.Drawing.Point(476, 142);
      this.btnScheduleCancel.Name = "btnScheduleCancel";
      this.btnScheduleCancel.Size = new System.Drawing.Size(75, 23);
      this.btnScheduleCancel.TabIndex = 8;
      this.btnScheduleCancel.Text = "C&ancel";
      this.btnScheduleCancel.UseVisualStyleBackColor = true;
      this.btnScheduleCancel.Click += new System.EventHandler(this.btnScheduleCancel_Click);
      // 
      // btnScheduleSave
      // 
      this.btnScheduleSave.Location = new System.Drawing.Point(314, 142);
      this.btnScheduleSave.Name = "btnScheduleSave";
      this.btnScheduleSave.Size = new System.Drawing.Size(75, 23);
      this.btnScheduleSave.TabIndex = 7;
      this.btnScheduleSave.Text = "&Save";
      this.btnScheduleSave.UseVisualStyleBackColor = true;
      this.btnScheduleSave.Click += new System.EventHandler(this.btnScheduleSave_Click);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(476, 102);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 6;
      this.btnBrowse.Text = "&Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // btnRemoveSchedule
      // 
      this.btnRemoveSchedule.Location = new System.Drawing.Point(395, 142);
      this.btnRemoveSchedule.Name = "btnRemoveSchedule";
      this.btnRemoveSchedule.Size = new System.Drawing.Size(75, 23);
      this.btnRemoveSchedule.TabIndex = 3;
      this.btnRemoveSchedule.Text = "&Remove";
      this.btnRemoveSchedule.UseVisualStyleBackColor = true;
      this.btnRemoveSchedule.Click += new System.EventHandler(this.btnRemoveSchedule_Click);
      // 
      // txtBackupPath
      // 
      this.txtBackupPath.Location = new System.Drawing.Point(50, 105);
      this.txtBackupPath.Name = "txtBackupPath";
      this.txtBackupPath.ReadOnly = true;
      this.txtBackupPath.Size = new System.Drawing.Size(420, 20);
      this.txtBackupPath.TabIndex = 5;
      // 
      // lblScheduleBackupPath
      // 
      this.lblScheduleBackupPath.AutoSize = true;
      this.lblScheduleBackupPath.Location = new System.Drawing.Point(47, 86);
      this.lblScheduleBackupPath.Name = "lblScheduleBackupPath";
      this.lblScheduleBackupPath.Size = new System.Drawing.Size(121, 13);
      this.lblScheduleBackupPath.TabIndex = 4;
      this.lblScheduleBackupPath.Text = "Path to backup storage:";
      // 
      // chkScheduleBackup
      // 
      this.chkScheduleBackup.AutoSize = true;
      this.chkScheduleBackup.Location = new System.Drawing.Point(23, 63);
      this.chkScheduleBackup.Name = "chkScheduleBackup";
      this.chkScheduleBackup.Size = new System.Drawing.Size(113, 17);
      this.chkScheduleBackup.TabIndex = 3;
      this.chkScheduleBackup.Text = "Perform a backup:";
      this.chkScheduleBackup.UseVisualStyleBackColor = true;
      this.chkScheduleBackup.CheckedChanged += new System.EventHandler(this.chkScheduleBackup_CheckedChanged);
      // 
      // cbScheduleMinute
      // 
      this.cbScheduleMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbScheduleMinute.FormattingEnabled = true;
      this.cbScheduleMinute.Location = new System.Drawing.Point(159, 25);
      this.cbScheduleMinute.Name = "cbScheduleMinute";
      this.cbScheduleMinute.Size = new System.Drawing.Size(50, 21);
      this.cbScheduleMinute.TabIndex = 2;
      // 
      // cbScheduleHour
      // 
      this.cbScheduleHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbScheduleHour.FormattingEnabled = true;
      this.cbScheduleHour.Location = new System.Drawing.Point(103, 25);
      this.cbScheduleHour.Name = "cbScheduleHour";
      this.cbScheduleHour.Size = new System.Drawing.Size(50, 21);
      this.cbScheduleHour.TabIndex = 1;
      this.cbScheduleHour.SelectedIndexChanged += new System.EventHandler(this.cbScheduleHour_SelectedIndexChanged);
      // 
      // lblScheduleTime
      // 
      this.lblScheduleTime.AutoSize = true;
      this.lblScheduleTime.Location = new System.Drawing.Point(20, 28);
      this.lblScheduleTime.Name = "lblScheduleTime";
      this.lblScheduleTime.Size = new System.Drawing.Size(77, 13);
      this.lblScheduleTime.TabIndex = 0;
      this.lblScheduleTime.Text = "Schedule time:";
      // 
      // btnNewSchedule
      // 
      this.btnNewSchedule.Location = new System.Drawing.Point(497, 36);
      this.btnNewSchedule.Name = "btnNewSchedule";
      this.btnNewSchedule.Size = new System.Drawing.Size(75, 23);
      this.btnNewSchedule.TabIndex = 2;
      this.btnNewSchedule.Text = "&New";
      this.btnNewSchedule.UseVisualStyleBackColor = true;
      this.btnNewSchedule.Click += new System.EventHandler(this.btnNewSchedule_Click);
      // 
      // lstSchedules
      // 
      this.lstSchedules.FormattingEnabled = true;
      this.lstSchedules.Location = new System.Drawing.Point(21, 36);
      this.lstSchedules.Name = "lstSchedules";
      this.lstSchedules.Size = new System.Drawing.Size(470, 95);
      this.lstSchedules.TabIndex = 1;
      this.lstSchedules.SelectedIndexChanged += new System.EventHandler(this.lstSchedules_SelectedIndexChanged);
      // 
      // lblScheduleList
      // 
      this.lblScheduleList.AutoSize = true;
      this.lblScheduleList.Location = new System.Drawing.Point(18, 20);
      this.lblScheduleList.Name = "lblScheduleList";
      this.lblScheduleList.Size = new System.Drawing.Size(60, 13);
      this.lblScheduleList.TabIndex = 0;
      this.lblScheduleList.Text = "Schedules:";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(629, 537);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(710, 537);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // ConfigDialog
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(797, 572);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configuration";
      this.Load += new System.EventHandler(this.ConfigDialog_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.grpMemory.ResumeLayout(false);
      this.grpMemory.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
      this.grpServerPath.ResumeLayout(false);
      this.grpServerPath.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.grpMOTD.ResumeLayout(false);
      this.grpMOTD.PerformLayout();
      this.grpPlayerOptions.ResumeLayout(false);
      this.grpPlayerOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudViewDistance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPlayers)).EndInit();
      this.grpWorldOptions.ResumeLayout(false);
      this.grpWorldOptions.PerformLayout();
      this.grpWorldGeneration.ResumeLayout(false);
      this.grpWorldGeneration.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSpawnProtection)).EndInit();
      this.grpServer.ResumeLayout(false);
      this.grpServer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.grpWarningMessages.ResumeLayout(false);
      this.grpWarningMessages.PerformLayout();
      this.grpScheduleEdit.ResumeLayout(false);
      this.grpScheduleEdit.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TextBox txtServerName;
    private System.Windows.Forms.Label lblServerName;
    private System.Windows.Forms.Label lblServerPath;
    private System.Windows.Forms.TextBox txtServerJar;
    private System.Windows.Forms.Label lblServerJar;
    private System.Windows.Forms.TextBox txtServerPath;
    private System.Windows.Forms.Label lblMemorySize;
    private System.Windows.Forms.CheckBox chkAutoStartServer;
    private System.Windows.Forms.Button btnSelectServer;
    private System.Windows.Forms.Label lblMemoryInfo;
    private System.Windows.Forms.NumericUpDown nudMemory;
    private System.Windows.Forms.GroupBox grpServer;
    private System.Windows.Forms.Label lblBindToUPInfo;
    private System.Windows.Forms.TextBox txtBindToIP;
    private System.Windows.Forms.Label lblBindToIP;
    private System.Windows.Forms.NumericUpDown nudServerPort;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.CheckBox chkOnlineMode;
    private System.Windows.Forms.GroupBox grpWorldGeneration;
    private System.Windows.Forms.TextBox txtLevelName;
    private System.Windows.Forms.Label lblLevelName;
    private System.Windows.Forms.ComboBox cbLevelType;
    private System.Windows.Forms.Label lblLevelType;
    private System.Windows.Forms.TextBox txtGeneratorSettings;
    private System.Windows.Forms.Label lblGeneratorSettings;
    private System.Windows.Forms.TextBox txtLevelSeed;
    private System.Windows.Forms.Label lblLevelSeed;
    private System.Windows.Forms.CheckBox chkAllowNether;
    private System.Windows.Forms.Label lblSpawnProtection;
    private System.Windows.Forms.NumericUpDown nudSpawnProtection;
    private System.Windows.Forms.Label lblSpawnProtectionInfo;
    private System.Windows.Forms.GroupBox grpWorldOptions;
    private System.Windows.Forms.CheckBox chkGenerateStructures;
    private System.Windows.Forms.CheckBox chkSpawnNPCs;
    private System.Windows.Forms.CheckBox chkSpawnAnimals;
    private System.Windows.Forms.CheckBox chkSpawnMonsters;
    private System.Windows.Forms.CheckBox chkEnableCommandBlock;
    private System.Windows.Forms.GroupBox grpPlayerOptions;
    private System.Windows.Forms.Label lblGameMode;
    private System.Windows.Forms.ComboBox cbGameMode;
    private System.Windows.Forms.ComboBox cbDifficulty;
    private System.Windows.Forms.Label lblDifficulty;
    private System.Windows.Forms.CheckBox chkHardcore;
    private System.Windows.Forms.CheckBox chkPvP;
    private System.Windows.Forms.Label lblMaxPlayerSlots;
    private System.Windows.Forms.NumericUpDown nudMaximumPlayers;
    private System.Windows.Forms.Label lblViewDistance;
    private System.Windows.Forms.Label lblViewDistanceInfo;
    private System.Windows.Forms.NumericUpDown nudViewDistance;
    private System.Windows.Forms.CheckBox chkWhitelist;
    private System.Windows.Forms.GroupBox grpMOTD;
    private System.Windows.Forms.TextBox txtMOTD2;
    private System.Windows.Forms.TextBox txtMOTD1;
    private System.Windows.Forms.GroupBox grpMemory;
    private System.Windows.Forms.GroupBox grpServerPath;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblScheduleList;
    private System.Windows.Forms.ListBox lstSchedules;
    private System.Windows.Forms.GroupBox grpScheduleEdit;
    private System.Windows.Forms.Button btnRemoveSchedule;
    private System.Windows.Forms.Button btnNewSchedule;
    private System.Windows.Forms.Label lblScheduleTime;
    private System.Windows.Forms.ComboBox cbScheduleMinute;
    private System.Windows.Forms.ComboBox cbScheduleHour;
    private System.Windows.Forms.CheckBox chkScheduleBackup;
    private System.Windows.Forms.Label lblScheduleBackupPath;
    private System.Windows.Forms.TextBox txtBackupPath;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Button btnScheduleCancel;
    private System.Windows.Forms.Button btnScheduleSave;
    private System.Windows.Forms.GroupBox grpWarningMessages;
    private System.Windows.Forms.CheckBox chkEnableWarningMessages;
    private System.Windows.Forms.TextBox txtWarningBackup1;
    private System.Windows.Forms.Label lblBackup1;
    private System.Windows.Forms.TextBox txtWarningRestart1;
    private System.Windows.Forms.Label lblRestart1;
    private System.Windows.Forms.CheckBox chkWarning1Min;
    private System.Windows.Forms.TextBox txtWarningBackup5;
    private System.Windows.Forms.Label lblBackup5;
    private System.Windows.Forms.TextBox txtWarningRestart5;
    private System.Windows.Forms.Label lblRestart5;
    private System.Windows.Forms.CheckBox chkWarning5Mins;
    private System.Windows.Forms.TextBox txtWarningBackup10;
    private System.Windows.Forms.Label lblBackup10;
    private System.Windows.Forms.TextBox txtWarningRestart10;
    private System.Windows.Forms.Label lblRestart10;
    private System.Windows.Forms.CheckBox chkWarning10Mins;
    private System.Windows.Forms.TextBox txtWarningPrompt;
    private System.Windows.Forms.Label lblWarningPrompt;
  }
}