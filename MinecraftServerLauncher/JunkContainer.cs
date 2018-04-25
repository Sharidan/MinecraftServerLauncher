using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerLauncher
{
  class JunkContainer
  {

    #region ===== Control Events =====

    private void btnAdd_Click(object sender, EventArgs e)
    {
      ServerProfileConfigDialog dialog = new ServerProfileConfigDialog();

      if (dialog.ShowDialog(this) == DialogResult.OK)
      {
        Config.Add(dialog.Profile);
        Config.Save();
        CheckServerProfiles();
      }

      dialog.Dispose();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1)
        {
          if (mvarServerHosts[index].Running)
          {
            MessageBox.Show(
              "\"" + Config.Profiles[profileSelectionIndex].Name + "\" is currently running!\n\nPlease shut down the server before changing the configuration.",
              "Please shut down server!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation
              );
          }
          else
          {
            ServerProfileConfigDialog dialog = new ServerProfileConfigDialog();
            dialog.Profile = Config.Profiles[profileSelectionIndex];

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
              Config.Profiles[profileSelectionIndex] = dialog.Profile;
              Config.Save();
              CheckServerProfiles();
            }

            dialog.Dispose();
          }

        }
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {

    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1)
        {
          mvarServerHosts[index].Start();
          btnStart.Enabled = false;
        }
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      if (profileSelectionIndex > -1)
      {
        int index = GetServerHostIndex(Config.Profiles[profileSelectionIndex].ID);
        if (index > -1 && mvarServerHosts[index].Running)
        {
          mvarServerHosts[index].Stop();
          btnStop.Enabled = false;
        }
      }
    }

    #endregion



  }
}
