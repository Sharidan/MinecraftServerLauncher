using CSharpLibs.Minecraft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
  public partial class ScheduleDialog : Form
  {

    /*
     * For handling the creation of new schedule profiles, there will be a single instance
     * of .ServerHostID containing the value -2. These instances are ONLY occurring within
     * this single window, for the sole purpose of being able to detect new schedules profile
     * being created.
     * 
     */

    #region ===== Internal Helper Methods =====

    private string LastOpenPath = "";
    
    #region Method: PadZero

    private string PadZero(int value)
    {
      string result = value.ToString();
      if (result.Length == 1)
      {
        result = "0" + result;
      }

      return result;
    }

    #endregion

    #region Method: UpdateLastOpenPath

    private void UpdateLastOpenPath(string path)
    {
      if (path.Length > 0)
      {
        if (path[path.Length - 1] != '\\')
        {
          LastOpenPath = path + '\\';
        }
        else
        {
          LastOpenPath = path;
        }
      }
    }

    #endregion

    #endregion

    #region ===== Schedule Profile Editing =====

    private ScheduleProfile TempSchedule = new ScheduleProfile(-1, 0, 0);

    #region Method: CloseScheduleEditor

    private void CloseScheduleEditor()
    {
      lstSchedules.Enabled = true;
      grpEdit.Visible = false;
      btnNew.Visible = true;
    }

    #endregion

    #region Method: CreateNewSchedule

    private void CreateNewSchedule()
    {
      int minInternal = DateTime.Now.Minute / 15;

      TempSchedule = new ScheduleProfile(
        -2, // Indicates that this is a new schedule profile!
        DateTime.Now.Hour,
        minInternal
        );
    }

    #endregion

    #region Method: EditSchedule

    private void EditSchedule()
    {
      // Lock the list of schedules by disabling the ListBox
      lstSchedules.Enabled = false;

      ddHour.SelectedIndex = TempSchedule.EventHour;

      // Calculate the minute index
      int minInterval = TempSchedule.EventMinute / 15;

      ddMinute.SelectedIndex = minInterval;

      //  Set the checkbox and the browse button enabled/disabled according to profile
      chkBackup.Checked = TempSchedule.Backup;
      btnBrowse.Enabled = TempSchedule.Backup;

      if (TempSchedule.Backup)
      {
        txtBackupPath.Text = TempSchedule.BackupPath;
      }
      else
      {
        txtBackupPath.Text = "";
      }

      // In the following: TempSchedule.ServerHostID == -2 indicates a new profile
      // which allows us to disable the Remove button.

      // this setup....
      if (TempSchedule.ServerHostID == -2)
      {
        btnRemove.Enabled = false;
      }
      else
      {
        btnRemove.Enabled = true;
      }
      // can also be written:
      // btnRemove.Enabled = (TempSchedule.ServerHostID == -2);

      btnNew.Visible = false;
      grpEdit.Visible = true;
    }

    #endregion

    #region Method: PopulateComboBoxes

    private void PopulateComboBoxes()
    {
      ddHour.Items.Clear();
      for (int h = 0; h < 24; h++)
      {
        ddHour.Items.Add(PadZero(h));
      }

      ddMinute.Items.Clear();
      ddMinute.Items.Add(PadZero(0));
      ddMinute.Items.Add(PadZero(15));
      ddMinute.Items.Add(PadZero(30));
      ddMinute.Items.Add(PadZero(45));
    }

    #endregion

    #region Method: PopulateScheduleListBox

    private void PopulateScheduleListBox()
    {
      lstSchedules.Items.Clear();

      for (int s = 0; s < mvarScheduleProfiles.Length; s++)
      {
        if (mvarScheduleProfiles[s].Backup)
        {
          lstSchedules.Items.Add(PadZero(mvarScheduleProfiles[s].EventHour) + ":" + PadZero(mvarScheduleProfiles[s].EventMinute) + " Backup => " + mvarScheduleProfiles[s].BackupPath);
        }
        else
        {
          lstSchedules.Items.Add(PadZero(mvarScheduleProfiles[s].EventHour) + ":" + PadZero(mvarScheduleProfiles[s].EventMinute) + " Restart");
        }
      }
    }

    #endregion

    #region Method: SortScheduleProfiles

    /*
     * This is one way of implementing this kind of sorting
     * using plain loops and simple methods.
     * There are tons of newer and better ways of implementing
     * a sorting function which are preferrable over this
     * implementation any day.
     * 
     */

    private void SortScheduleProfiles()
    {
      int[] hours = new int[0];
      int[] minutes = new int[0];
      bool found = false;

      for (int s = 0; s < mvarScheduleProfiles.Length; s++)
      {
        found = false;
        for (int h = 0; h < hours.Length; h++)
        {
          if (hours[h] == mvarScheduleProfiles[s].EventHour)
          {
            found = true;
            break;
          }
        }
        if (!found)
        {
          Array.Resize(ref hours, hours.Length + 1);
          hours[hours.Length - 1] = mvarScheduleProfiles[s].EventHour;
        }

        found = false;
        for (int m = 0; m < minutes.Length; m++)
        {
          if (minutes[m] == mvarScheduleProfiles[s].EventMinute)
          {
            found = true;
            break;
          }
        }

        if (!found)
        {
          Array.Resize(ref minutes, minutes.Length + 1);
          minutes[minutes.Length - 1] = mvarScheduleProfiles[s].EventMinute;
        }
      }

      Array.Sort(hours);
      Array.Sort(minutes);

      ScheduleProfile[] temp = new ScheduleProfile[mvarScheduleProfiles.Length];
      int targetIndex = -1;

      for (int h = 0; h < hours.Length; h++)
      {
        for (int m = 0; m < minutes.Length; m++)
        {

          for (int s = 0; s < mvarScheduleProfiles.Length; s++)
          {
            if (mvarScheduleProfiles[s].EventHour == hours[h] && mvarScheduleProfiles[s].EventMinute == minutes[m])
            {
              // We found a schedule entry that matches the hours : minutes combination
              // so, we'll add this entry to the new list and tag the old one as done ...

              targetIndex++;

              temp[targetIndex] = new ScheduleProfile(mvarScheduleProfiles[s]);
              mvarScheduleProfiles[s].EventHour = -1;

              break;
            }
          }

        }
      }

      Array.Copy(temp, 0, mvarScheduleProfiles, 0, temp.Length);

      temp = new ScheduleProfile[0];

      // The quick and easy way of performing the sort:
      // jobun44's solution using Linq :)
      // mvarScheduleProfiles = mvarScheduleProfiles.OrderBy(x => x.EventHour * 60 + x.EventMinute).ToArray();
      // Using the Linq method should be overall faster than the oldschool implementation above
    }

    #endregion

    #endregion

    #region ===== Properties =====

    #region Property: ScheduleProfiles

    private ScheduleProfile[] mvarScheduleProfiles = new ScheduleProfile[0];

    public ScheduleProfile[] ScheduleProfiles
    {
      get { return mvarScheduleProfiles; }
      set
      {
        mvarScheduleProfiles = value;
        SortScheduleProfiles();
      }
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: SetMinecraftServerPath

    public void SetMinecraftServerPath(string path)
    {
      UpdateLastOpenPath(path);
    }

    #endregion

    #endregion

    #region ===== Control Events =====

    private void lstSchedules_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lstSchedules.SelectedIndex > -1)
      {
        // An entry was selected
        TempSchedule = new ScheduleProfile(mvarScheduleProfiles[lstSchedules.SelectedIndex]);
        EditSchedule();
      }
      else
      {
        // No entries are selected
        grpEdit.Visible = false;
        btnNew.Visible = true;
      }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      CreateNewSchedule();
      EditSchedule();
    }

    private void chkBackup_CheckedChanged(object sender, EventArgs e)
    {
      // Enable/disable the "Browse" button according to the checkbox.
      btnBrowse.Enabled = chkBackup.Checked;
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dialog = new FolderBrowserDialog();
      dialog.Description = "Select the path to where you would like to store backups:";
      dialog.ShowNewFolderButton = true; // Allow the user to create new folders
      dialog.SelectedPath = LastOpenPath;

      if (dialog.ShowDialog(this) == DialogResult.OK)
      {
        UpdateLastOpenPath(dialog.SelectedPath);

        txtBackupPath.Text = LastOpenPath;
      }

      dialog.Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (chkBackup.Checked)
      {
        string path = txtBackupPath.Text.Trim();

        if (path.Length == 0)
        {
          MessageBox.Show(
            "Please specify where you would like to store backups for this server instance.",
            "No backup storage path specified!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation
            );
          btnBrowse.Focus();
          // Exit out
          return;
        }
      }

      TempSchedule.EventHour = ddHour.SelectedIndex;
      TempSchedule.EventMinute = ddMinute.SelectedIndex * 15;
      TempSchedule.Backup = chkBackup.Checked;
      if (TempSchedule.Backup)
      {
        TempSchedule.BackupPath = txtBackupPath.Text;
      }
      // If this is a new schedule profile...
      if (TempSchedule.ServerHostID == -2)
      { // Set it to unassigned for now
        TempSchedule.ServerHostID = -1;
      }

      if (lstSchedules.SelectedIndex > -1)
      {
        // Replace the old one
        mvarScheduleProfiles[lstSchedules.SelectedIndex] = new ScheduleProfile(TempSchedule);
      }
      else
      {
        // Add as a new profile :)
        Array.Resize(ref mvarScheduleProfiles, mvarScheduleProfiles.Length + 1);
        mvarScheduleProfiles[mvarScheduleProfiles.Length - 1] = TempSchedule;
      }

      SortScheduleProfiles();

      PopulateScheduleListBox();

      CloseScheduleEditor();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      lstSchedules.SelectedIndex = -1;

      CloseScheduleEditor();
    }

    #endregion

    #region ===== Form Events =====

    private void ScheduleDialog_Load(object sender, EventArgs e)
    {
      PopulateComboBoxes();
    }

    private void ScheduleDialog_Shown(object sender, EventArgs e)
    {
      grpEdit.Visible = false;
      btnNew.Left = lstSchedules.Left;
      btnNew.Top = lstSchedules.Top + lstSchedules.Height + 7;

      PopulateScheduleListBox();
    }

    #endregion

    #region ===== Constructor =====

    public ScheduleDialog()
    {
      InitializeComponent();

      this.Shown += ScheduleDialog_Shown;

      lstSchedules.SelectedIndexChanged += lstSchedules_SelectedIndexChanged;
    }

    #endregion

  }
}
