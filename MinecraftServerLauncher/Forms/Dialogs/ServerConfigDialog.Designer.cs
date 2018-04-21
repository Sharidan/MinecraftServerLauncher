namespace MinecraftServerLauncher
{
  partial class ServerConfigDialog
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
      this.grpServer = new System.Windows.Forms.GroupBox();
      this.nudServerPort = new System.Windows.Forms.NumericUpDown();
      this.chkOnlineMode = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtServerBindIP = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.grpWorldGen = new System.Windows.Forms.GroupBox();
      this.label11 = new System.Windows.Forms.Label();
      this.nudSpawnProtection = new System.Windows.Forms.NumericUpDown();
      this.label10 = new System.Windows.Forms.Label();
      this.chkAllowNether = new System.Windows.Forms.CheckBox();
      this.txtLevelSeed = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtGeneratorSettings = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.ddLevelType = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtLevelName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.grpPlayerOptions = new System.Windows.Forms.GroupBox();
      this.chkWhitelist = new System.Windows.Forms.CheckBox();
      this.label14 = new System.Windows.Forms.Label();
      this.nudViewDistance = new System.Windows.Forms.NumericUpDown();
      this.label13 = new System.Windows.Forms.Label();
      this.nudMaximumPlayers = new System.Windows.Forms.NumericUpDown();
      this.label12 = new System.Windows.Forms.Label();
      this.chkPvP = new System.Windows.Forms.CheckBox();
      this.chkHardcore = new System.Windows.Forms.CheckBox();
      this.ddDifficulty = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.ddGameMode = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.grpWorldOptions = new System.Windows.Forms.GroupBox();
      this.chkSpawnMonsters = new System.Windows.Forms.CheckBox();
      this.chkSpawnAnimals = new System.Windows.Forms.CheckBox();
      this.chkSpawnNPCs = new System.Windows.Forms.CheckBox();
      this.chkGenerateStructures = new System.Windows.Forms.CheckBox();
      this.grpMOTD = new System.Windows.Forms.GroupBox();
      this.txtMOTD = new System.Windows.Forms.TextBox();
      this.btnAccept = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkEnableCommandBlock = new System.Windows.Forms.CheckBox();
      this.grpServer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
      this.grpWorldGen.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSpawnProtection)).BeginInit();
      this.grpPlayerOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudViewDistance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPlayers)).BeginInit();
      this.grpWorldOptions.SuspendLayout();
      this.grpMOTD.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpServer
      // 
      this.grpServer.Controls.Add(this.nudServerPort);
      this.grpServer.Controls.Add(this.chkOnlineMode);
      this.grpServer.Controls.Add(this.label3);
      this.grpServer.Controls.Add(this.label2);
      this.grpServer.Controls.Add(this.txtServerBindIP);
      this.grpServer.Controls.Add(this.label1);
      this.grpServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grpServer.Location = new System.Drawing.Point(12, 12);
      this.grpServer.Name = "grpServer";
      this.grpServer.Size = new System.Drawing.Size(361, 141);
      this.grpServer.TabIndex = 0;
      this.grpServer.TabStop = false;
      this.grpServer.Text = "Server";
      // 
      // nudServerPort
      // 
      this.nudServerPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.nudServerPort.ForeColor = System.Drawing.Color.White;
      this.nudServerPort.Location = new System.Drawing.Point(82, 72);
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
      this.nudServerPort.Size = new System.Drawing.Size(97, 20);
      this.nudServerPort.TabIndex = 12;
      this.nudServerPort.Value = new decimal(new int[] {
            25565,
            0,
            0,
            0});
      // 
      // chkOnlineMode
      // 
      this.chkOnlineMode.AutoSize = true;
      this.chkOnlineMode.Checked = true;
      this.chkOnlineMode.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOnlineMode.ForeColor = System.Drawing.Color.White;
      this.chkOnlineMode.Location = new System.Drawing.Point(20, 96);
      this.chkOnlineMode.Name = "chkOnlineMode";
      this.chkOnlineMode.Size = new System.Drawing.Size(85, 17);
      this.chkOnlineMode.TabIndex = 5;
      this.chkOnlineMode.Text = "Online mode";
      this.chkOnlineMode.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(17, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Port:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(17, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(252, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Leave empty unless you must bind to an external IP.";
      // 
      // txtServerBindIP
      // 
      this.txtServerBindIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtServerBindIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtServerBindIP.ForeColor = System.Drawing.Color.White;
      this.txtServerBindIP.Location = new System.Drawing.Point(82, 27);
      this.txtServerBindIP.Name = "txtServerBindIP";
      this.txtServerBindIP.Size = new System.Drawing.Size(116, 20);
      this.txtServerBindIP.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(17, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Bind to IP: ";
      // 
      // grpWorldGen
      // 
      this.grpWorldGen.Controls.Add(this.label11);
      this.grpWorldGen.Controls.Add(this.nudSpawnProtection);
      this.grpWorldGen.Controls.Add(this.label10);
      this.grpWorldGen.Controls.Add(this.chkAllowNether);
      this.grpWorldGen.Controls.Add(this.txtLevelSeed);
      this.grpWorldGen.Controls.Add(this.label7);
      this.grpWorldGen.Controls.Add(this.txtGeneratorSettings);
      this.grpWorldGen.Controls.Add(this.label6);
      this.grpWorldGen.Controls.Add(this.ddLevelType);
      this.grpWorldGen.Controls.Add(this.label5);
      this.grpWorldGen.Controls.Add(this.txtLevelName);
      this.grpWorldGen.Controls.Add(this.label4);
      this.grpWorldGen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grpWorldGen.Location = new System.Drawing.Point(379, 12);
      this.grpWorldGen.Name = "grpWorldGen";
      this.grpWorldGen.Size = new System.Drawing.Size(361, 200);
      this.grpWorldGen.TabIndex = 1;
      this.grpWorldGen.TabStop = false;
      this.grpWorldGen.Text = "World generation";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(185, 165);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(164, 13);
      this.label11.TabIndex = 12;
      this.label11.Text = "(number of blocks around spawn)";
      // 
      // nudSpawnProtection
      // 
      this.nudSpawnProtection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.nudSpawnProtection.ForeColor = System.Drawing.Color.White;
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
      this.nudSpawnProtection.TabIndex = 11;
      this.nudSpawnProtection.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(19, 165);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(93, 13);
      this.label10.TabIndex = 10;
      this.label10.Text = "Spawn protection:";
      // 
      // chkAllowNether
      // 
      this.chkAllowNether.AutoSize = true;
      this.chkAllowNether.Checked = true;
      this.chkAllowNether.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAllowNether.Location = new System.Drawing.Point(22, 137);
      this.chkAllowNether.Name = "chkAllowNether";
      this.chkAllowNether.Size = new System.Drawing.Size(157, 17);
      this.chkAllowNether.TabIndex = 9;
      this.chkAllowNether.Text = "Allow the Nether dimension.";
      this.chkAllowNether.UseVisualStyleBackColor = true;
      // 
      // txtLevelSeed
      // 
      this.txtLevelSeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtLevelSeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtLevelSeed.ForeColor = System.Drawing.Color.White;
      this.txtLevelSeed.Location = new System.Drawing.Point(121, 106);
      this.txtLevelSeed.Name = "txtLevelSeed";
      this.txtLevelSeed.Size = new System.Drawing.Size(214, 20);
      this.txtLevelSeed.TabIndex = 8;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(19, 108);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(62, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "Level seed:";
      // 
      // txtGeneratorSettings
      // 
      this.txtGeneratorSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtGeneratorSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtGeneratorSettings.ForeColor = System.Drawing.Color.White;
      this.txtGeneratorSettings.Location = new System.Drawing.Point(121, 77);
      this.txtGeneratorSettings.Name = "txtGeneratorSettings";
      this.txtGeneratorSettings.Size = new System.Drawing.Size(214, 20);
      this.txtGeneratorSettings.TabIndex = 6;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(19, 79);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(96, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "Generator settings:";
      // 
      // ddLevelType
      // 
      this.ddLevelType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ddLevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddLevelType.ForeColor = System.Drawing.Color.White;
      this.ddLevelType.FormattingEnabled = true;
      this.ddLevelType.Location = new System.Drawing.Point(121, 50);
      this.ddLevelType.Name = "ddLevelType";
      this.ddLevelType.Size = new System.Drawing.Size(214, 21);
      this.ddLevelType.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(19, 54);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(59, 13);
      this.label5.TabIndex = 3;
      this.label5.Text = "Level type:";
      // 
      // txtLevelName
      // 
      this.txtLevelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtLevelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtLevelName.ForeColor = System.Drawing.Color.White;
      this.txtLevelName.Location = new System.Drawing.Point(121, 25);
      this.txtLevelName.Name = "txtLevelName";
      this.txtLevelName.Size = new System.Drawing.Size(214, 20);
      this.txtLevelName.TabIndex = 2;
      this.txtLevelName.Text = "world";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(19, 27);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Level name:";
      // 
      // grpPlayerOptions
      // 
      this.grpPlayerOptions.Controls.Add(this.chkWhitelist);
      this.grpPlayerOptions.Controls.Add(this.label14);
      this.grpPlayerOptions.Controls.Add(this.nudViewDistance);
      this.grpPlayerOptions.Controls.Add(this.label13);
      this.grpPlayerOptions.Controls.Add(this.nudMaximumPlayers);
      this.grpPlayerOptions.Controls.Add(this.label12);
      this.grpPlayerOptions.Controls.Add(this.chkPvP);
      this.grpPlayerOptions.Controls.Add(this.chkHardcore);
      this.grpPlayerOptions.Controls.Add(this.ddDifficulty);
      this.grpPlayerOptions.Controls.Add(this.label9);
      this.grpPlayerOptions.Controls.Add(this.ddGameMode);
      this.grpPlayerOptions.Controls.Add(this.label8);
      this.grpPlayerOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grpPlayerOptions.Location = new System.Drawing.Point(12, 159);
      this.grpPlayerOptions.Name = "grpPlayerOptions";
      this.grpPlayerOptions.Size = new System.Drawing.Size(361, 212);
      this.grpPlayerOptions.TabIndex = 2;
      this.grpPlayerOptions.TabStop = false;
      this.grpPlayerOptions.Text = "Player options";
      // 
      // chkWhitelist
      // 
      this.chkWhitelist.AutoSize = true;
      this.chkWhitelist.Location = new System.Drawing.Point(22, 182);
      this.chkWhitelist.Name = "chkWhitelist";
      this.chkWhitelist.Size = new System.Drawing.Size(113, 17);
      this.chkWhitelist.TabIndex = 16;
      this.chkWhitelist.Text = "Whitelisted server.";
      this.chkWhitelist.UseVisualStyleBackColor = true;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(185, 158);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(128, 13);
      this.label14.TabIndex = 15;
      this.label14.Text = "(chunk radius from player)";
      // 
      // nudViewDistance
      // 
      this.nudViewDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.nudViewDistance.ForeColor = System.Drawing.Color.White;
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
      this.nudViewDistance.TabIndex = 14;
      this.nudViewDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(19, 158);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(76, 13);
      this.label13.TabIndex = 13;
      this.label13.Text = "View distance:";
      // 
      // nudMaximumPlayers
      // 
      this.nudMaximumPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.nudMaximumPlayers.ForeColor = System.Drawing.Color.White;
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
      this.nudMaximumPlayers.TabIndex = 12;
      this.nudMaximumPlayers.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(19, 132);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(85, 13);
      this.label12.TabIndex = 11;
      this.label12.Text = "Max player slots:";
      // 
      // chkPvP
      // 
      this.chkPvP.AutoSize = true;
      this.chkPvP.Checked = true;
      this.chkPvP.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkPvP.Location = new System.Drawing.Point(22, 107);
      this.chkPvP.Name = "chkPvP";
      this.chkPvP.Size = new System.Drawing.Size(178, 17);
      this.chkPvP.TabIndex = 9;
      this.chkPvP.Text = "Enable Player vs. Player combat";
      this.chkPvP.UseVisualStyleBackColor = true;
      // 
      // chkHardcore
      // 
      this.chkHardcore.AutoSize = true;
      this.chkHardcore.Location = new System.Drawing.Point(22, 84);
      this.chkHardcore.Name = "chkHardcore";
      this.chkHardcore.Size = new System.Drawing.Size(183, 17);
      this.chkHardcore.TabIndex = 8;
      this.chkHardcore.Text = "Hardcore mode (ignores difficulty)";
      this.chkHardcore.UseVisualStyleBackColor = true;
      // 
      // ddDifficulty
      // 
      this.ddDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ddDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddDifficulty.ForeColor = System.Drawing.Color.White;
      this.ddDifficulty.FormattingEnabled = true;
      this.ddDifficulty.Location = new System.Drawing.Point(121, 52);
      this.ddDifficulty.Name = "ddDifficulty";
      this.ddDifficulty.Size = new System.Drawing.Size(214, 21);
      this.ddDifficulty.TabIndex = 7;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(19, 55);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(50, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Difficulty:";
      // 
      // ddGameMode
      // 
      this.ddGameMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ddGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddGameMode.ForeColor = System.Drawing.Color.White;
      this.ddGameMode.FormattingEnabled = true;
      this.ddGameMode.Location = new System.Drawing.Point(121, 24);
      this.ddGameMode.Name = "ddGameMode";
      this.ddGameMode.Size = new System.Drawing.Size(214, 21);
      this.ddGameMode.TabIndex = 5;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(19, 28);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(67, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "Game mode:";
      // 
      // grpWorldOptions
      // 
      this.grpWorldOptions.Controls.Add(this.chkEnableCommandBlock);
      this.grpWorldOptions.Controls.Add(this.chkSpawnMonsters);
      this.grpWorldOptions.Controls.Add(this.chkSpawnAnimals);
      this.grpWorldOptions.Controls.Add(this.chkSpawnNPCs);
      this.grpWorldOptions.Controls.Add(this.chkGenerateStructures);
      this.grpWorldOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grpWorldOptions.Location = new System.Drawing.Point(379, 218);
      this.grpWorldOptions.Name = "grpWorldOptions";
      this.grpWorldOptions.Size = new System.Drawing.Size(361, 153);
      this.grpWorldOptions.TabIndex = 3;
      this.grpWorldOptions.TabStop = false;
      this.grpWorldOptions.Text = "World options";
      // 
      // chkSpawnMonsters
      // 
      this.chkSpawnMonsters.AutoSize = true;
      this.chkSpawnMonsters.Location = new System.Drawing.Point(22, 97);
      this.chkSpawnMonsters.Name = "chkSpawnMonsters";
      this.chkSpawnMonsters.Size = new System.Drawing.Size(215, 17);
      this.chkSpawnMonsters.TabIndex = 3;
      this.chkSpawnMonsters.Text = "Spawn monsters (skellies, zomblers etc.)";
      this.chkSpawnMonsters.UseVisualStyleBackColor = true;
      // 
      // chkSpawnAnimals
      // 
      this.chkSpawnAnimals.AutoSize = true;
      this.chkSpawnAnimals.Location = new System.Drawing.Point(22, 71);
      this.chkSpawnAnimals.Name = "chkSpawnAnimals";
      this.chkSpawnAnimals.Size = new System.Drawing.Size(226, 17);
      this.chkSpawnAnimals.TabIndex = 2;
      this.chkSpawnAnimals.Text = "Spawn animals (sheep, bacon and moohs)";
      this.chkSpawnAnimals.UseVisualStyleBackColor = true;
      // 
      // chkSpawnNPCs
      // 
      this.chkSpawnNPCs.AutoSize = true;
      this.chkSpawnNPCs.Location = new System.Drawing.Point(22, 48);
      this.chkSpawnNPCs.Name = "chkSpawnNPCs";
      this.chkSpawnNPCs.Size = new System.Drawing.Size(139, 17);
      this.chkSpawnNPCs.TabIndex = 1;
      this.chkSpawnNPCs.Text = "Spawn NPCs (villagers!)";
      this.chkSpawnNPCs.UseVisualStyleBackColor = true;
      // 
      // chkGenerateStructures
      // 
      this.chkGenerateStructures.AutoSize = true;
      this.chkGenerateStructures.Location = new System.Drawing.Point(22, 25);
      this.chkGenerateStructures.Name = "chkGenerateStructures";
      this.chkGenerateStructures.Size = new System.Drawing.Size(226, 17);
      this.chkGenerateStructures.TabIndex = 0;
      this.chkGenerateStructures.Text = "Generate structures (villages, temples etc.)";
      this.chkGenerateStructures.UseVisualStyleBackColor = true;
      // 
      // grpMOTD
      // 
      this.grpMOTD.Controls.Add(this.txtMOTD);
      this.grpMOTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grpMOTD.Location = new System.Drawing.Point(12, 377);
      this.grpMOTD.Name = "grpMOTD";
      this.grpMOTD.Size = new System.Drawing.Size(728, 62);
      this.grpMOTD.TabIndex = 4;
      this.grpMOTD.TabStop = false;
      this.grpMOTD.Text = "Message of the day";
      // 
      // txtMOTD
      // 
      this.txtMOTD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtMOTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMOTD.ForeColor = System.Drawing.Color.White;
      this.txtMOTD.Location = new System.Drawing.Point(20, 24);
      this.txtMOTD.Name = "txtMOTD";
      this.txtMOTD.Size = new System.Drawing.Size(682, 20);
      this.txtMOTD.TabIndex = 9;
      // 
      // btnAccept
      // 
      this.btnAccept.Location = new System.Drawing.Point(584, 454);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(75, 23);
      this.btnAccept.TabIndex = 5;
      this.btnAccept.Text = "&Accept";
      this.btnAccept.UseVisualStyleBackColor = true;
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(665, 454);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // chkEnableCommandBlock
      // 
      this.chkEnableCommandBlock.AutoSize = true;
      this.chkEnableCommandBlock.Location = new System.Drawing.Point(22, 120);
      this.chkEnableCommandBlock.Name = "chkEnableCommandBlock";
      this.chkEnableCommandBlock.Size = new System.Drawing.Size(309, 17);
      this.chkEnableCommandBlock.TabIndex = 4;
      this.chkEnableCommandBlock.Text = "Enable command block. Warning! May be dangerous doing!";
      this.chkEnableCommandBlock.UseVisualStyleBackColor = true;
      // 
      // ServerConfigDialog
      // 
      this.AcceptButton = this.btnAccept;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(752, 492);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnAccept);
      this.Controls.Add(this.grpMOTD);
      this.Controls.Add(this.grpWorldOptions);
      this.Controls.Add(this.grpPlayerOptions);
      this.Controls.Add(this.grpWorldGen);
      this.Controls.Add(this.grpServer);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ServerConfigDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Server configuration";
      this.Load += new System.EventHandler(this.ServerConfigDialog_Load);
      this.grpServer.ResumeLayout(false);
      this.grpServer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
      this.grpWorldGen.ResumeLayout(false);
      this.grpWorldGen.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSpawnProtection)).EndInit();
      this.grpPlayerOptions.ResumeLayout(false);
      this.grpPlayerOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudViewDistance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPlayers)).EndInit();
      this.grpWorldOptions.ResumeLayout(false);
      this.grpWorldOptions.PerformLayout();
      this.grpMOTD.ResumeLayout(false);
      this.grpMOTD.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grpServer;
    private System.Windows.Forms.CheckBox chkOnlineMode;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtServerBindIP;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox grpWorldGen;
    private System.Windows.Forms.TextBox txtGeneratorSettings;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox ddLevelType;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtLevelName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtLevelSeed;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox grpPlayerOptions;
    private System.Windows.Forms.ComboBox ddDifficulty;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox ddGameMode;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.CheckBox chkHardcore;
    private System.Windows.Forms.CheckBox chkAllowNether;
    private System.Windows.Forms.CheckBox chkPvP;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown nudSpawnProtection;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.NumericUpDown nudViewDistance;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.NumericUpDown nudMaximumPlayers;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.CheckBox chkWhitelist;
    private System.Windows.Forms.GroupBox grpWorldOptions;
    private System.Windows.Forms.NumericUpDown nudServerPort;
    private System.Windows.Forms.CheckBox chkSpawnMonsters;
    private System.Windows.Forms.CheckBox chkSpawnAnimals;
    private System.Windows.Forms.CheckBox chkSpawnNPCs;
    private System.Windows.Forms.CheckBox chkGenerateStructures;
    private System.Windows.Forms.GroupBox grpMOTD;
    private System.Windows.Forms.TextBox txtMOTD;
    private System.Windows.Forms.Button btnAccept;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkEnableCommandBlock;
  }
}