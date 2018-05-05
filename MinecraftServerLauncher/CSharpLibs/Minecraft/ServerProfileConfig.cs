using CSharpLibs.ConfigTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  class ServerProfileConfig
  {

    INIFile configINI = new INIFile();

    private bool Changed = false;

    #region ===== Path Handling =====

    public string Path { get; private set; } = "";

    private void InitializeConfigPath()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

      if (path.Length > 0)
      {
        if (path[path.Length - 1] != '\\')
        {
          path += '\\';
        }
      }

      path += "Minecraft Server Launcher\\";

      if (!Directory.Exists(path))
      {
        try
        {
          Directory.CreateDirectory(path);
        }
        catch { }
      }

      Path = path;
    }

    #endregion

    #region ===== Internal Helper Methods =====

    #region Method: FixInt

    /// <summary>
    /// Converts the passed string into an int value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>Returns an int value based on the string or zero if unable to convert.</returns>
    private int FixInt(string value)
    {
      int result = 0;

      if (!int.TryParse(value, out result))
      {
        return 0;
      }

      return result;
    }

    #endregion

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

    #endregion

    #region ===== File I/O =====

    #region Method: LoadConfig

    private void LoadConfig()
    {
      string fileName = Path + "ServerProfile.cfg";

      configINI.Load(fileName);

      int count = FixInt(configINI.GetValue("Profiles", "Count"));

      mvarProfiles.Clear();

      for (int p = 0; p < count; p++)
      {
        string name = configINI.GetValue("Profile" + p.ToString(), "Name");
        string serverPath = configINI.GetValue("Profile" + p.ToString(), "ServerPath");
        string serverJar = configINI.GetValue("Profile" + p.ToString(), "ServerJar");
        int memory = FixInt(configINI.GetValue("Profile" + p.ToString(), "Memory"));
        string startupMode = configINI.GetValue("Profile" + p.ToString(), "StartupMode").Trim().ToLower();
        bool autoStart = false;

        if (startupMode.Length > 0 && startupMode[0] == 'a')
        {
          autoStart = true;
        }

        ServerProfile profile = new ServerProfile(name, serverPath, serverJar, memory, autoStart);

        int scheduleCount = FixInt(configINI.GetValue("Schedule" + p.ToString(), "Count"));
        if (scheduleCount > 0)
        {
          for (int s = 0; s < scheduleCount; s++)
          {
            string timeStamp = configINI.GetValue("Schedule" + p.ToString(), "Time" + s.ToString());
            // Is this time stamp valid?
            if (timeStamp.Length == 5 && timeStamp[2] == ':')
            {
              string[] parts = timeStamp.Split(':');
              if (parts.Length == 2)
              {
                int h = FixInt(parts[0]);
                int m = FixInt(parts[1]);
                if (h >= 0 && h < 24)
                {
                  if (m == 0 || m == 15 || m == 30 || m == 45)
                  {
                    // When we reach this point, we have a valid time for the schedule
                    string scheduleType = configINI.GetValue("Schedule" + p.ToString(), "Type" + s.ToString()).Trim().ToLower();
                    string backupPath = "";

                    if (scheduleType.Length > 0 && scheduleType[0] == 'b')
                    { // If the schedule type starts with a 'b', we assume it's a backup schedule
                      backupPath = configINI.GetValue("Schedule" + p.ToString(), "Path" + s.ToString()).Trim();
                      if (backupPath.Length > 0 && backupPath[1] == ':')
                      {
                        // Set the schedule type to backup, since we got a potentially valid path
                        scheduleType = "backup";
                      }
                      else
                      {
                        // The stored path doesnt seem to be useful, so
                        // ... we'll default back to a restart schedule
                        scheduleType = "restart";
                      }
                    }
                    else
                    { // Otherwise we'll force a restart schedule
                      scheduleType = "restart";
                    }

                    // Finally store the schedule data ...
                    Array.Resize(ref profile.Schedules, profile.Schedules.Length + 1);

                    // 
                    switch (scheduleType)
                    {
                      case "backup":
                        profile.Schedules[profile.Schedules.Length - 1] = new ScheduleProfile(-1, h, m, backupPath);
                        break;
                      case "restart":
                        profile.Schedules[profile.Schedules.Length - 1] = new ScheduleProfile(-1, h, m);
                        break;
                    }
                  }
                }
              }
            }
          }
        }

        mvarProfiles.Add(profile);
      }

      Changed = false;
    }

    #endregion

    #region Method: SaveConfig

    private void SaveConfig()
    {
      string fileName = Path + "ServerProfile.cfg";

      configINI.Clear();

      // First of all: save the number of profiles
      configINI.SetValue("Profiles", "Count", mvarProfiles.Count.ToString());

      // Next up: save the individual profiles
      for (int p = 0; p < mvarProfiles.Count; p++)
      {
        configINI.SetValue("Profile" + p.ToString(), "Name", mvarProfiles[p].Name);
        configINI.SetValue("Profile" + p.ToString(), "ServerPath", mvarProfiles[p].Path);
        configINI.SetValue("Profile" + p.ToString(), "ServerJar", mvarProfiles[p].Jar);
        configINI.SetValue("Profile" + p.ToString(), "Memory", mvarProfiles[p].MemorySize.ToString());
        if (mvarProfiles[p].AutoStart)
        {
          configINI.SetValue("Profile" + p.ToString(), "StartupMode", "auto");
        }
        else
        {
          configINI.SetValue("Profile" + p.ToString(), "StartupMode", "manual");
        }

        // Save the schedules for this server profile
        // Start by removing the schedule group
        configINI.RemoveGroup("Schedule" + p.ToString());
        // Then add in the current schedule list, if it exists
        configINI.SetValue("Schedule" + p.ToString(), "Count", mvarProfiles[p].Schedules.Length.ToString());

        for (int s = 0; s < mvarProfiles[p].Schedules.Length; s++)
        {
          // Write the schedule time: Time0=04:30
          configINI.SetValue("Schedule" + p.ToString(), "Time" + s.ToString(), PadZero(mvarProfiles[p].Schedules[s].EventHour) + ":" + PadZero(mvarProfiles[p].Schedules[s].EventMinute));
          // Write the schedule type
          if (mvarProfiles[p].Schedules[s].Backup)
          {
            configINI.SetValue("Schedule" + p.ToString(), "Type" + s.ToString(), "backup");
            configINI.SetValue("Schedule" + p.ToString(), "Path" + s.ToString(), mvarProfiles[p].Schedules[s].BackupPath);
          }
          else
          {
            configINI.SetValue("Schedule" + p.ToString(), "Type" + s.ToString(), "restart");
          }
        }
      }

      configINI.Save(fileName);

      // Clear the changed flag!
      Changed = false;
    }

    #endregion

    #endregion

    #region ===== Properties =====

    #region Property: Count

    /// <summary>
    /// Returns the total number of profiles stored.
    /// </summary>
    public int Count
    {
      get { return mvarProfiles.Count; }
    }

    #endregion

    #region Property: Profiles

    private List<ServerProfile> mvarProfiles = new List<ServerProfile>();

    /// <summary>
    /// Contains the list of current server profiles.
    /// </summary>
    public List<ServerProfile> Profiles
    {
      get { return mvarProfiles; }
      set
      {
        mvarProfiles = value;
        Changed = true;
      }
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: Add

    /// <summary>
    /// Adds the passed server profile to the config list.
    /// </summary>
    /// <param name="profile">The profile to add.</param>
    public void Add(ServerProfile profile)
    {
      mvarProfiles.Add(profile);
      Changed = true;
    }

    #endregion

    #region Method: AssignID

    /// <summary>
    /// Assigns the passed ID to the specified server profile.
    /// </summary>
    /// <param name="profileIndex">The index of the server profile to assign an ID to.</param>
    /// <param name="newID">The ID to assign to this server profile.</param>
    public void AssignID(int profileIndex, int newID)
    {
      if (profileIndex >= 0 && profileIndex < mvarProfiles.Count)
      {
        ServerProfile profile = mvarProfiles[profileIndex];
        profile.ID = newID;
        mvarProfiles[profileIndex] = profile;
        Changed = true;
      }
    }

    #endregion

    #region Method: Remove

    /// <summary>
    /// Removes the specified profile from the profile list.
    /// </summary>
    /// <param name="profile">The profile to remove.</param>
    public void Remove(ServerProfile profile)
    {
      mvarProfiles.Remove(profile);
      Changed = true;
    }

    /// <summary>
    /// Removes the profile at the specified index from the profile list.
    /// </summary>
    /// <param name="profileIndex">The index number of the profile to remove.</param>
    public void Remove(int profileIndex)
    {
      if (profileIndex >= 0 && profileIndex < mvarProfiles.Count)
      {
        mvarProfiles.RemoveAt(profileIndex);
        Changed = true;
      }
    }

    #endregion

    #region Method: Save

    /// <summary>
    /// Saves any changes made to the server profiles list.
    /// </summary>
    public void Save()
    {
      if (Changed)
      {
        SaveConfig();
      }
    }

    /// <summary>
    /// Saves any changes made to the server profiles list or forces a save to disk.
    /// </summary>
    /// <param name="forceSave">Whether to force a save to disk.</param>
    public void Save(bool forceSave)
    {
      if (Changed || forceSave)
      {
        SaveConfig();
      }
    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public ServerProfileConfig()
    {
      InitializeConfigPath();

      LoadConfig();
    }

    #endregion

  }
}
