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
      this.btnAdd = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.btnEdit = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.btnRemove = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.btnStart = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.btnStop = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.btnSchedule = new MinecraftServerLauncher.UserControls.FlatButton.FlatButton();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnAdd.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnAdd.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnAdd.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnAdd.EnabledForeColor = System.Drawing.Color.Black;
      this.btnAdd.Location = new System.Drawing.Point(238, 351);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Load += new System.EventHandler(this.btnAdd_Load);
      // 
      // btnEdit
      // 
      this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnEdit.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnEdit.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnEdit.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnEdit.EnabledForeColor = System.Drawing.Color.Black;
      this.btnEdit.Location = new System.Drawing.Point(319, 351);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(75, 23);
      this.btnEdit.TabIndex = 1;
      this.btnEdit.Load += new System.EventHandler(this.btnEdit_Load);
      // 
      // btnRemove
      // 
      this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnRemove.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnRemove.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnRemove.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnRemove.EnabledForeColor = System.Drawing.Color.Black;
      this.btnRemove.Location = new System.Drawing.Point(400, 351);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 23);
      this.btnRemove.TabIndex = 2;
      this.btnRemove.Load += new System.EventHandler(this.btnRemove_Load);
      // 
      // btnStart
      // 
      this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnStart.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnStart.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnStart.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnStart.EnabledForeColor = System.Drawing.Color.Black;
      this.btnStart.Location = new System.Drawing.Point(238, 380);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 3;
      this.btnStart.Load += new System.EventHandler(this.btnStart_Load);
      // 
      // btnStop
      // 
      this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnStop.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnStop.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnStop.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnStop.EnabledForeColor = System.Drawing.Color.Black;
      this.btnStop.Location = new System.Drawing.Point(400, 380);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 23);
      this.btnStop.TabIndex = 4;
      this.btnStop.Load += new System.EventHandler(this.btnStop_Load);
      // 
      // btnSchedule
      // 
      this.btnSchedule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnSchedule.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
      this.btnSchedule.DisabledForeColor = System.Drawing.Color.Gray;
      this.btnSchedule.EnabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnSchedule.EnabledForeColor = System.Drawing.Color.Black;
      this.btnSchedule.Location = new System.Drawing.Point(319, 380);
      this.btnSchedule.Name = "btnSchedule";
      this.btnSchedule.Size = new System.Drawing.Size(75, 23);
      this.btnSchedule.TabIndex = 5;
      this.btnSchedule.Load += new System.EventHandler(this.btnSchedule_Load);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(713, 412);
      this.Controls.Add(this.btnSchedule);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnAdd);
      this.ForeColor = System.Drawing.Color.Gray;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Minecraft Server Launcher";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private UserControls.FlatButton.FlatButton btnAdd;
    private UserControls.FlatButton.FlatButton btnEdit;
    private UserControls.FlatButton.FlatButton btnRemove;
    private UserControls.FlatButton.FlatButton btnStart;
    private UserControls.FlatButton.FlatButton btnStop;
    private UserControls.FlatButton.FlatButton btnSchedule;
  }
}

