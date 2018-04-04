using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibs.ConfigTools
{
  class INIFile
  {

    #region ===== Structures =====

    private struct KeyPair
    {
      public string Name;
      public string Value;

      public KeyPair(string name, string value)
      {
        Name = name.Trim();
        Value = value.Trim();
      }
    }

    private struct INIGroup
    {
      public string Name;
      public KeyPair[] Keys;

      public INIGroup(string name)
      {
        Name = name.Trim();
        Keys = new KeyPair[0];
      }
    }

    private INIGroup[] mvarGroups = new INIGroup[0];

    private string[] Comments = new string[0];

    #endregion

    #region ===== Internal Helper Method =====

    private void ArrayRemove<T>(ref T[] array, int RemoveIndex)
    {
      if (RemoveIndex >= 0 && RemoveIndex < array.Length)
      {
        T[] Temp = new T[array.Length - 1];
        Array.Copy(array, 0, Temp, 0, RemoveIndex);
        Array.Copy(array, RemoveIndex + 1, Temp, RemoveIndex, array.Length - RemoveIndex - 1);
        array = new T[Temp.Length];
        Array.Copy(Temp, 0, array, 0, Temp.Length);
      }
    }

    private int GetGroupIndex(string groupName)
    {
      for (int g = 0; g < mvarGroups.Length; g++)
      {
        if (mvarGroups[g].Name.ToLower() == groupName.Trim().ToLower())
        {
          return g;
        }
      }
      if (groupName == "" && MinecraftServerProperties)
      {
        return 0;
      }

      return -1;
    }

    private int GetKeyIndex(int groupIndex, string keyName)
    {
      if (groupIndex >= 0 && groupIndex < mvarGroups.Length)
      {
        for (int k = 0; k < mvarGroups[groupIndex].Keys.Length; k++)
        {
          if (mvarGroups[groupIndex].Keys[k].Name.ToLower() == keyName.Trim().ToLower())
          {
            return k;
          }
        }
      }

      return -1;
    }

    private void UpdatePath(string filePathName)
    {
      if (filePathName.Length > 0)
      {
        if (filePathName[1] == ':')
        {
          Path = filePathName.Substring(0, filePathName.LastIndexOf('\\') + 1);
          FileName = filePathName.Substring(filePathName.LastIndexOf('\\') + 1, filePathName.Length - (filePathName.LastIndexOf('\\') + 1));
        }
      }
    }

    #endregion

    #region ===== Properties =====

    /// <summary>
    /// The path to the current INI file.
    /// </summary>
    public string Path { get; set; } = "";

    /// <summary>
    /// The name of the current INI file.
    /// </summary>
    public string FileName { get; set; } = "";

    /// <summary>
    /// The fully qualified path and name of the current INI file.
    /// </summary>
    public string FilePathName
    {
      get
      {
        return Path + FileName;
      }
      set
      {
        if (value.Length > 0)
        {
          UpdatePath(value);
        }
      }
    }

    /// <summary>
    /// Determines whether the INI file is a Minecraft server.properties file.
    /// </summary>
    public bool MinecraftServerProperties { get; set; } = false;

    #endregion

    #region ===== Public Methods =====

    /// <summary>
    /// Retrieves the value of the specified key within the specified group.
    /// </summary>
    /// <param name="groupName">The group to find.</param>
    /// <param name="keyName">The key to find within the group.</param>
    /// <returns>Returns the value of the specified key within the specified group.</returns>
    public string GetValue(string groupName, string keyName)
    {
      int groupIndex = GetGroupIndex(groupName);
      if (groupIndex > -1)
      {
        int keyIndex = GetKeyIndex(groupIndex, keyName);
        if (keyIndex > -1)
        {
          return mvarGroups[groupIndex].Keys[keyIndex].Value;
        }
      }

      return "";
    }

    /// <summary>
    /// Creates or updates the value of the specified key within the specified group.
    /// </summary>
    /// <param name="groupName">The group to find or create.</param>
    /// <param name="keyName">The key within the group, to find or create.</param>
    /// <param name="keyValue">The value to update or create.</param>
    public void SetValue(string groupName, string keyName, string keyValue)
    {
      int groupIndex = GetGroupIndex(groupName);

      if (groupIndex == -1)
      {
        Array.Resize(ref mvarGroups, mvarGroups.Length + 1);
        mvarGroups[mvarGroups.Length - 1] = new INIGroup(groupName);
        groupIndex = mvarGroups.Length - 1;
      }

      if (groupIndex > -1)
      {
        int keyIndex = GetKeyIndex(groupIndex, keyName);

        if (keyIndex > -1)
        {
          mvarGroups[groupIndex].Keys[keyIndex].Value = keyValue.Trim();
        }
        else
        {
          Array.Resize(ref mvarGroups[groupIndex].Keys, mvarGroups[groupIndex].Keys.Length + 1);
          mvarGroups[groupIndex].Keys[mvarGroups[groupIndex].Keys.Length - 1] = new KeyPair(keyName, keyValue);
        }
      }
    }

    /// <summary>
    /// Fetches a list of all existing group names.
    /// </summary>
    /// <returns>Returns a list of all existing group names.</returns>
    public string[] GetGroups()
    {
      string[] result = new string[mvarGroups.Length];

      for (int g = 0; g < mvarGroups.Length; g++)
      {
        result[g] = mvarGroups[g].Name;
      }

      return result;
    }

    /// <summary>
    /// Fetches a list of key names within the specified group.
    /// </summary>
    /// <param name="groupName">The group to fetch key names from.</param>
    /// <returns>Returns a list of key names within the specified group.</returns>
    public string[] GetGroupKeys(string groupName)
    {
      string[] result = new string[0];
      int groupIndex = GetGroupIndex(groupName);

      if (groupIndex > -1)
      {
        result = new string[mvarGroups[groupIndex].Keys.Length];

        for (int k = 0; k < mvarGroups[groupIndex].Keys.Length; k++)
        {
          result[k] = mvarGroups[groupIndex].Keys[k].Name;
        }
      }

      return result;
    }

    /// <summary>
    /// Removes the specified key within the specified group.
    /// </summary>
    /// <param name="groupName">The group to find.</param>
    /// <param name="keyName">The key to remove.</param>
    public void RemoveKey(string groupName, string keyName)
    {
      int groupIndex = GetGroupIndex(groupName);

      if (groupIndex > -1)
      {
        int keyIndex = GetKeyIndex(groupIndex, keyName);

        if (keyIndex > -1)
        {
          ArrayRemove(ref mvarGroups[groupIndex].Keys, keyIndex);
        }
      }
    }

    /// <summary>
    /// Removes a group and all keys within this group.
    /// </summary>
    /// <param name="groupName">The name of the group to remove.</param>
    public void RemoveGroup(string groupName)
    {
      int groupIndex = GetGroupIndex(groupName);

      if (groupIndex > -1)
      {
        ArrayRemove(ref mvarGroups, groupIndex);
      }
    }

    #endregion

    #region ===== File I/O =====

    #region Public Method: Load

    private void ParseINI(string data)
    {
      string[] lines = data.Replace("\r", "").Split('\n');
      int groupIndex = -1;

      mvarGroups = new INIGroup[0];

      for (int l = 0; l < lines.Length; l++)
      {
        string line = lines[l].Replace('\t', ' ').Trim();

        if (line.Length > 0)
        {
          if (MinecraftServerProperties && line[0] == '#')
          {
            // Here we need to store the already written comments!
            Array.Resize(ref Comments, Comments.Length + 1);
            Comments[Comments.Length - 1] = line.Trim();
          }
          else if (line[0] != '#' && line[0] != ';')
          {
            
            if (line.IndexOf('[') > -1 && line.IndexOf(']') > -1)
            {
              line = line.Substring(0, line.IndexOf(']'));
              line = line.Replace("[", "").Trim();

              Array.Resize(ref mvarGroups, mvarGroups.Length + 1);
              mvarGroups[mvarGroups.Length - 1] = new INIGroup(line);
              groupIndex = mvarGroups.Length - 1;
            }
            else if (line.IndexOf('=') > -1)
            {
              if (groupIndex == -1 && MinecraftServerProperties)
              {
                Array.Resize(ref mvarGroups, mvarGroups.Length + 1);
                mvarGroups[mvarGroups.Length - 1] = new INIGroup("$$MINECRAFT$$");
                groupIndex = mvarGroups.Length - 1;
              }
              if (groupIndex > -1)
              {
                string keyName = line.Substring(0, line.IndexOf('=')).Trim();
                string keyValue = "";

                if (line.IndexOf('=') < line.Length - 1)
                {
                  keyValue = line.Substring(line.IndexOf('=') + 1, line.Length - (line.IndexOf('=') + 1));
                }

                Array.Resize(ref mvarGroups[groupIndex].Keys, mvarGroups[groupIndex].Keys.Length + 1);
                mvarGroups[groupIndex].Keys[mvarGroups[groupIndex].Keys.Length - 1] = new KeyPair(keyName, keyValue);
              }
            }
          }
        }
      }
    }

    public void Load()
    {
      if (FilePathName.Length > 0)
      {
        if (File.Exists(FilePathName))
        {
          string data = "";

          try
          {
            data = File.ReadAllText(FilePathName);
          }
          catch
          {
            data = "";
          }

          if (data.Length > 0)
          {
            ParseINI(data);
          }

        }
      }
    }

    public void Load(string filePathName)
    {
      UpdatePath(filePathName);
      Load();
    }

    #endregion

    #region Public Method: Save

    private string BuildINI()
    {
      const string crlf = "\r\n";
      string result = "";

      for (int g = 0; g < mvarGroups.Length; g++)
      {
        if (MinecraftServerProperties && mvarGroups[g].Name == "$$MINECRAFT$$")
        {
          for (int c = 0; c < Comments.Length; c++)
          {
            result += Comments[c] + crlf;
          }
        }
        else
        {
          result += "[" + mvarGroups[g].Name + "]" + crlf;
        }

        for (int k = 0; k < mvarGroups[g].Keys.Length; k++)
        {
          result += mvarGroups[g].Keys[k].Name + "=" + mvarGroups[g].Keys[k].Value + crlf;
        }

        result += crlf;
      }

      return result;
    }

    public void Save()
    {
      if (FilePathName.Length > 0)
      {
        if (!Directory.Exists(Path))
        {
          try
          {
            Directory.CreateDirectory(Path);
          }
          catch { }
        }

        if (Directory.Exists(Path))
        {
          if (File.Exists(FilePathName))
          {
            try
            {
              File.Delete(FilePathName);
            }
            catch { }
          }
          if (!File.Exists(FilePathName))
          {
            try
            {
              File.WriteAllText(FilePathName, BuildINI());
            }
            catch { }
          }
        }
      }
    }

    public void Save(string filePathName)
    {
      UpdatePath(filePathName);
      Save();
    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public INIFile()
    {
      mvarGroups = new INIGroup[0];
    }

    public INIFile(string filePathName)
    {
      mvarGroups = new INIGroup[0];
      Load(filePathName);
    }

    #endregion

  }
}
