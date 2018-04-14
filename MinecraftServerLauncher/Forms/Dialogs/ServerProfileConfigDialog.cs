using CSharpLibs.Minecraft;
using System;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
  public partial class ServerProfileConfigDialog : Form
  {

    #region ===== Properties =====

    public ServerProfile Profile { get; set; } = new ServerProfile("", "", "", 256);

    #endregion

    #region ===== Control Events =====

    private void btnSelect_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Minecraft Server Jar|*.jar";
      dialog.CheckPathExists = true;
      dialog.CheckFileExists = true;
      dialog.Title = "Select the Minecraft server jar you would like to use";

      if (dialog.ShowDialog(this) == DialogResult.OK)
      {
        string filePathName = dialog.FileName;

        txtServerPath.Text = filePathName.Substring(0, filePathName.LastIndexOf('\\') + 1);
        txtServerJar.Text = filePathName.Substring(filePathName.LastIndexOf('\\') + 1, filePathName.Length - (filePathName.LastIndexOf('\\') + 1));
      }

      dialog.Dispose();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
      if (
        txtServerName.Text.Trim().Length > 0 &&
        txtServerPath.Text.Trim().Length > 0 &&
        txtServerJar.Text.Trim().Length > 0
        )
      {
        Profile = new ServerProfile(
          txtServerName.Text.Trim(),
          txtServerPath.Text.Trim(),
          txtServerJar.Text.Trim(),
          (int)nudMemory.Value
          );

        // Finally set the dialog result to OK (which forces the form closed automatically)
        this.DialogResult = DialogResult.OK;
      }
      else if (txtServerName.Text.Trim().Length == 0)
      {
        MessageBox.Show(
          "You have not provided a name for this server profile!\n\nPlease specify a name and try again.",
          "No server name specified!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation
          );
        txtServerName.Focus();
      }
      else if (txtServerPath.Text.Trim().Length == 0 || txtServerJar.Text.Trim().Length == 0)
      {
        MessageBox.Show(
          "You have not selected a Minecraft server jar!\n\nPlease select the Minecraft server jar you would like to use for this server profile.",
          "No server jar selected!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation
          );
        btnSelect.Focus();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    #endregion

    #region ===== Form Events =====

    private void ServerProfileConfigDialog_Load(object sender, EventArgs e)
    {

    }

    private void ServerProfileConfigDialog_Shown(object sender, EventArgs e)
    {
      // Populate the form with the custom property data

      txtServerName.Text = Profile.Name;
      txtServerPath.Text = Profile.Path;
      txtServerJar.Text = Profile.Jar;

      nudMemory.Value = Profile.MemorySize;
    }

    #endregion

    #region ===== Constructor =====

    public ServerProfileConfigDialog()
    {
      InitializeComponent();

      this.Shown += ServerProfileConfigDialog_Shown;
    }

    #endregion

  }
}
