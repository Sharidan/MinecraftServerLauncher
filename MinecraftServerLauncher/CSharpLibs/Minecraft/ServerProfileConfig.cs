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

        mvarProfiles.Add(new ServerProfile(name, serverPath, serverJar, memory));
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
