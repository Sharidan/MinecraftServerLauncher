namespace MinecraftServerLauncher
{
  partial class MainForm
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
      this.lblPathInfo = new System.Windows.Forms.Label();
      this.txtMinecraftServerPath = new System.Windows.Forms.TextBox();
      this.btnOpen = new System.Windows.Forms.Button();
      this.lblMemoryInfo = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.btnSave = new System.Windows.Forms.Button();
      this.grpServerControl = new System.Windows.Forms.GroupBox();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.btnServerInfo = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.grpServerControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblPathInfo
      // 
      this.lblPathInfo.AutoSize = true;
      this.lblPathInfo.Location = new System.Drawing.Point(25, 26);
      this.lblPathInfo.Name = "lblPathInfo";
      this.lblPathInfo.Size = new System.Drawing.Size(123, 13);
      this.lblPathInfo.TabIndex = 0;
      this.lblPathInfo.Text = "Path to Minecraft server:";
      // 
      // txtMinecraftServerPath
      // 
      this.txtMinecraftServerPath.Location = new System.Drawing.Point(28, 42);
      this.txtMinecraftServerPath.Name = "txtMinecraftServerPath";
      this.txtMinecraftServerPath.Size = new System.Drawing.Size(458, 20);
      this.txtMinecraftServerPath.TabIndex = 1;
      this.txtMinecraftServerPath.TextChanged += new System.EventHandler(this.txtMinecraftServerPath_TextChanged);
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(500, 40);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 2;
      this.btnOpen.Text = "&Open";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // lblMemoryInfo
      // 
      this.lblMemoryInfo.AutoSize = true;
      this.lblMemoryInfo.Location = new System.Drawing.Point(25, 81);
      this.lblMemoryInfo.Name = "lblMemoryInfo";
      this.lblMemoryInfo.Size = new System.Drawing.Size(47, 13);
      this.lblMemoryInfo.TabIndex = 3;
      this.lblMemoryInfo.Text = "&Memory:";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(90, 79);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(81, 20);
      this.numericUpDown1.TabIndex = 4;
      this.numericUpDown1.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(28, 136);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 5;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // grpServerControl
      // 
      this.grpServerControl.Controls.Add(this.btnStop);
      this.grpServerControl.Controls.Add(this.btnStart);
      this.grpServerControl.Location = new System.Drawing.Point(28, 183);
      this.grpServerControl.Name = "grpServerControl";
      this.grpServerControl.Size = new System.Drawing.Size(547, 154);
      this.grpServerControl.TabIndex = 6;
      this.grpServerControl.TabStop = false;
      this.grpServerControl.Text = "Server control";
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(26, 37);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 0;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(107, 37);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 23);
      this.btnStop.TabIndex = 1;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // btnServerInfo
      // 
      this.btnServerInfo.Location = new System.Drawing.Point(148, 136);
      this.btnServerInfo.Name = "btnServerInfo";
      this.btnServerInfo.Size = new System.Drawing.Size(75, 23);
      this.btnServerInfo.TabIndex = 7;
      this.btnServerInfo.Text = "&Info";
      this.btnServerInfo.UseVisualStyleBackColor = true;
      this.btnServerInfo.Click += new System.EventHandler(this.btnServerInfo_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(607, 373);
      this.Controls.Add(this.btnServerInfo);
      this.Controls.Add(this.grpServerControl);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.lblMemoryInfo);
      this.Controls.Add(this.btnOpen);
      this.Controls.Add(this.txtMinecraftServerPath);
      this.Controls.Add(this.lblPathInfo);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Minecraft Server Launcher";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.grpServerControl.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblPathInfo;
    private System.Windows.Forms.TextBox txtMinecraftServerPath;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Label lblMemoryInfo;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.GroupBox grpServerControl;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnServerInfo;
  }
}

