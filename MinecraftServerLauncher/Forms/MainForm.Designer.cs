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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(131, 227);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(64, 64);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Visible = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label1.Location = new System.Drawing.Point(213, 250);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "MOTD: blah blah";
      this.label1.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label2.Location = new System.Drawing.Point(213, 227);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(157, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Config custom name: this server";
      this.label2.Visible = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label3.Location = new System.Drawing.Point(213, 278);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(127, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Connect at: [port-number]";
      this.label3.Visible = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label4.Location = new System.Drawing.Point(449, 227);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(95, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Status: shut down.";
      this.label4.Visible = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label5.Location = new System.Drawing.Point(449, 250);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(76, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "Players: 0 / 10";
      this.label5.Visible = false;
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(258, 348);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 9;
      this.btnAdd.Text = "&Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Location = new System.Drawing.Point(339, 348);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(75, 23);
      this.btnEdit.TabIndex = 10;
      this.btnEdit.Text = "&Edit";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(420, 348);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 23);
      this.btnRemove.TabIndex = 11;
      this.btnRemove.Text = "&Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(258, 377);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 12;
      this.btnStart.Text = "&Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(339, 377);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 23);
      this.btnStop.TabIndex = 13;
      this.btnStop.Text = "&Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(713, 412);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Minecraft Server Launcher";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
  }
}

