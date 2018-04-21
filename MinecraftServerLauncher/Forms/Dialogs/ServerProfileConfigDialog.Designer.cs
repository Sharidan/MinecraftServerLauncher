namespace MinecraftServerLauncher
{
  partial class ServerProfileConfigDialog
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtServerName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtServerPath = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtServerJar = new System.Windows.Forms.TextBox();
      this.btnSelect = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.nudMemory = new System.Windows.Forms.NumericUpDown();
      this.btnAccept = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnProperties = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label1.Location = new System.Drawing.Point(26, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server &name:";
      // 
      // txtServerName
      // 
      this.txtServerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtServerName.ForeColor = System.Drawing.Color.White;
      this.txtServerName.Location = new System.Drawing.Point(112, 23);
      this.txtServerName.Name = "txtServerName";
      this.txtServerName.Size = new System.Drawing.Size(357, 20);
      this.txtServerName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label2.Location = new System.Drawing.Point(26, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Server &path:";
      // 
      // txtServerPath
      // 
      this.txtServerPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtServerPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtServerPath.ForeColor = System.Drawing.Color.White;
      this.txtServerPath.Location = new System.Drawing.Point(112, 56);
      this.txtServerPath.Name = "txtServerPath";
      this.txtServerPath.ReadOnly = true;
      this.txtServerPath.Size = new System.Drawing.Size(357, 20);
      this.txtServerPath.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label3.Location = new System.Drawing.Point(26, 84);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Server &jar:";
      // 
      // txtServerJar
      // 
      this.txtServerJar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtServerJar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtServerJar.ForeColor = System.Drawing.Color.White;
      this.txtServerJar.Location = new System.Drawing.Point(112, 82);
      this.txtServerJar.Name = "txtServerJar";
      this.txtServerJar.ReadOnly = true;
      this.txtServerJar.Size = new System.Drawing.Size(357, 20);
      this.txtServerJar.TabIndex = 5;
      // 
      // btnSelect
      // 
      this.btnSelect.Location = new System.Drawing.Point(394, 108);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new System.Drawing.Size(75, 23);
      this.btnSelect.TabIndex = 6;
      this.btnSelect.Text = "&Select";
      this.btnSelect.UseVisualStyleBackColor = true;
      this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label4.Location = new System.Drawing.Point(26, 147);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "&Memory:";
      // 
      // nudMemory
      // 
      this.nudMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.nudMemory.ForeColor = System.Drawing.Color.White;
      this.nudMemory.Location = new System.Drawing.Point(112, 145);
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
      this.nudMemory.Size = new System.Drawing.Size(81, 20);
      this.nudMemory.TabIndex = 8;
      this.nudMemory.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
      // 
      // btnAccept
      // 
      this.btnAccept.Location = new System.Drawing.Point(313, 195);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(75, 23);
      this.btnAccept.TabIndex = 9;
      this.btnAccept.Text = "&Accept";
      this.btnAccept.UseVisualStyleBackColor = true;
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(394, 195);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 10;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnProperties
      // 
      this.btnProperties.Location = new System.Drawing.Point(112, 195);
      this.btnProperties.Name = "btnProperties";
      this.btnProperties.Size = new System.Drawing.Size(75, 23);
      this.btnProperties.TabIndex = 11;
      this.btnProperties.Text = "&Properties";
      this.btnProperties.UseVisualStyleBackColor = true;
      this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label5.Location = new System.Drawing.Point(26, 200);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(73, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Server config:";
      // 
      // ServerProfileConfigDialog
      // 
      this.AcceptButton = this.btnAccept;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(509, 241);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnProperties);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnAccept);
      this.Controls.Add(this.nudMemory);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnSelect);
      this.Controls.Add(this.txtServerJar);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtServerPath);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtServerName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ServerProfileConfigDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Server profile ...";
      this.Load += new System.EventHandler(this.ServerProfileConfigDialog_Load);
      ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtServerName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtServerPath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtServerJar;
    private System.Windows.Forms.Button btnSelect;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown nudMemory;
    private System.Windows.Forms.Button btnAccept;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnProperties;
    private System.Windows.Forms.Label label5;
  }
}