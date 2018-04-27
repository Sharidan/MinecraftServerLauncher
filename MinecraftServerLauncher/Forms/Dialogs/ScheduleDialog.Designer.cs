namespace MinecraftServerLauncher
{
  partial class ScheduleDialog
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
      this.lstSchedules = new System.Windows.Forms.ListBox();
      this.grpEdit = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.ddHour = new System.Windows.Forms.ComboBox();
      this.ddMinute = new System.Windows.Forms.ComboBox();
      this.chkBackup = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtBackupPath = new System.Windows.Forms.TextBox();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNew = new System.Windows.Forms.Button();
      this.grpEdit.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Schedules:";
      // 
      // lstSchedules
      // 
      this.lstSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lstSchedules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.lstSchedules.FormattingEnabled = true;
      this.lstSchedules.Location = new System.Drawing.Point(24, 37);
      this.lstSchedules.Name = "lstSchedules";
      this.lstSchedules.Size = new System.Drawing.Size(499, 199);
      this.lstSchedules.TabIndex = 1;
      // 
      // grpEdit
      // 
      this.grpEdit.Controls.Add(this.btnCancel);
      this.grpEdit.Controls.Add(this.btnRemove);
      this.grpEdit.Controls.Add(this.btnSave);
      this.grpEdit.Controls.Add(this.btnBrowse);
      this.grpEdit.Controls.Add(this.txtBackupPath);
      this.grpEdit.Controls.Add(this.label3);
      this.grpEdit.Controls.Add(this.chkBackup);
      this.grpEdit.Controls.Add(this.ddMinute);
      this.grpEdit.Controls.Add(this.ddHour);
      this.grpEdit.Controls.Add(this.label2);
      this.grpEdit.Location = new System.Drawing.Point(24, 242);
      this.grpEdit.Name = "grpEdit";
      this.grpEdit.Size = new System.Drawing.Size(499, 205);
      this.grpEdit.TabIndex = 2;
      this.grpEdit.TabStop = false;
      this.grpEdit.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(77, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Schedule time:";
      // 
      // ddHour
      // 
      this.ddHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddHour.FormattingEnabled = true;
      this.ddHour.Location = new System.Drawing.Point(100, 25);
      this.ddHour.Name = "ddHour";
      this.ddHour.Size = new System.Drawing.Size(48, 21);
      this.ddHour.TabIndex = 1;
      // 
      // ddMinute
      // 
      this.ddMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ddMinute.FormattingEnabled = true;
      this.ddMinute.Location = new System.Drawing.Point(154, 25);
      this.ddMinute.Name = "ddMinute";
      this.ddMinute.Size = new System.Drawing.Size(48, 21);
      this.ddMinute.TabIndex = 2;
      // 
      // chkBackup
      // 
      this.chkBackup.AutoSize = true;
      this.chkBackup.Location = new System.Drawing.Point(20, 61);
      this.chkBackup.Name = "chkBackup";
      this.chkBackup.Size = new System.Drawing.Size(113, 17);
      this.chkBackup.TabIndex = 3;
      this.chkBackup.Text = "Perform a backup:";
      this.chkBackup.UseVisualStyleBackColor = true;
      this.chkBackup.CheckedChanged += new System.EventHandler(this.chkBackup_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 81);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Path to backup storage:";
      // 
      // txtBackupPath
      // 
      this.txtBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtBackupPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtBackupPath.ForeColor = System.Drawing.Color.White;
      this.txtBackupPath.Location = new System.Drawing.Point(43, 97);
      this.txtBackupPath.Name = "txtBackupPath";
      this.txtBackupPath.ReadOnly = true;
      this.txtBackupPath.Size = new System.Drawing.Size(425, 20);
      this.txtBackupPath.TabIndex = 5;
      // 
      // btnBrowse
      // 
      this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnBrowse.Location = new System.Drawing.Point(393, 123);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 6;
      this.btnBrowse.Text = "Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // btnSave
      // 
      this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnSave.Location = new System.Drawing.Point(231, 160);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 7;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnRemove.Location = new System.Drawing.Point(312, 160);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 23);
      this.btnRemove.TabIndex = 8;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnCancel.Location = new System.Drawing.Point(393, 160);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnNew
      // 
      this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnNew.Location = new System.Drawing.Point(448, 8);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(75, 23);
      this.btnNew.TabIndex = 3;
      this.btnNew.Text = "New";
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // ScheduleDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(551, 470);
      this.Controls.Add(this.grpEdit);
      this.Controls.Add(this.lstSchedules);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnNew);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ScheduleDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Schedules ...";
      this.Load += new System.EventHandler(this.ScheduleDialog_Load);
      this.grpEdit.ResumeLayout(false);
      this.grpEdit.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lstSchedules;
    private System.Windows.Forms.GroupBox grpEdit;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.TextBox txtBackupPath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkBackup;
    private System.Windows.Forms.ComboBox ddMinute;
    private System.Windows.Forms.ComboBox ddHour;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnNew;
  }
}