using System;
using System.IO;

/* 
 * File   : INIFile.cs
 * Created: 4. April 2018
 * Author : Robert Bülow - ("sharidandk" on Twitch.com)
 * Web    : www.sharidan.dk
 *          www.futte.dk
 * 
 * License: CC BY 4.0
 *          https://creativecommons.org/licenses/by/4.0/
 * This license covers this source code file only.
 * 
 * Initial namespace: CSharpLibs.ConfigTools
 * Feel free to change the namespace to fit your needs.
 * 
 * Initially created to handle INI files for creating, saving and loading
 * configuration options for applications. Later during the day a special
 * case property was added to accommodate the lack of grouping in the
 * Minecraft server.properties file.
 * 
 * Updated: 6. April 2018
 * Changes:
 * 
 * Changed the overall way that groupless INI files such as the Minecraft
 * server.properties files are handled. This change was made to better
 * accommodate the intent of having this class be for general purpose
 * INI file handling.
 * 
 * - .MinecraftServerProperties renamed to: .VirtualGrouping
 * - Added internal constant with a virtual group name.
 * - Added a few extra method overloads to better support Virtual Grouping.
 * - General documentation additions.
 * - General code cleanup to finalize this class.
 * 
 * Updated: 11. April 2018
 * Bugfix:
 * 
 * - Fixed VirtualGrouping not working correctly.
 */

namespace CSharpLibs.ConfigTools
{
  class INIFile
  {

    #region ===== Structures =====

    /// <summary>
    /// Contains one key and value pair.
    /// </summary>
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

    /// <summary>
    /// Contains a full INI group (or section) and all declared keys and values within the group.
    /// </summary>
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

    /// <summary>
    /// Holds the list of declared groups within the INI file. Each group has it's own list of key/value pairs.
    /// </summary>
    private INIGroup[] mvarGroups = new INIGroup[0];

    /// <summary>
    /// Internal buffer for comments. Only used when .VirtualGrouping = true
    /// </summary>
    private string[] Comments = new string[0];

    #endregion

    #region ===== Internal Helper Method =====

    #region Method: ArrayRemove

    /// <summary>
    /// Removes the specified entry at RemoveIndex from the referenced array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">The array to remove an entry from.</param>
    /// <param name="RemoveIndex">The index at which to remove the entry.</param>
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

    #endregion

    #region Method: GetGroupIndex

    /// <summary>
    /// Searches through all declared groups looking for a group with a matching name.
    /// </summary>
    /// <param name="groupName">The group name to search for.</param>
    /// <returns>Returns the index number of the first found group that matches, otherwise -1.</returns>
    private int GetGroupIndex(string groupName)
    {
      for (int g = 0; g < mvarGroups.Length; g++)
      {
        if (mvarGroups[g].Name.ToLower() == groupName.Trim().ToLower())
        {
          return g;
        }
      }
      if (groupName == "" && mvarVirtualGrouping)
      {
        return 0;
      }

      return -1;
    }

    #endregion

    #region Method: GetKeyIndex

    /// <summary>
    /// Searches through all keys within the specified group, for a key matching the specified name.
    /// </summary>
    /// <param name="groupIndex">The index number of the group to search.</param>
    /// <param name="keyName">The name of the key to find.</param>
    /// <returns>Returns the index number of the found key, otherwise -1.</returns>
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

    #endregion

    #region Method: UpdatePath

    /// <summary>
    /// Updates the .Path and .FileName properties via the passed fully qualified filePathName.
    /// </summary>
    /// <param name="filePathName">The fully qualified path and name of a specific file.</param>
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

    #endregion

    #region ===== Properties =====

    #region Property: Path

    /// <summary>
    /// The path to the current INI file.
    /// </summary>
    public string Path { get; set; } = "";

    #endregion

    #region Property: FileName

    /// <summary>
    /// The name of the current INI file.
    /// </summary>
    public string FileName { get; set; } = "";

    #endregion

    #region Property: FilePathName

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

    #endregion

    #region Property: VirtualGrouping

    /// <summary>
    /// Const: Contains the chosen virtual group name for INI files without groups.
    /// </summary>
    private const string VirtualGroupName = "$$VIRTUAL$$";

    private bool mvarVirtualGrouping = false;
    /// <summary>
    /// Determines whether the INI file has no groups and therefore virtual grouping is required. When set to true; creates one single virtual group in which all key/value pairs are kept.
    /// </summary>
    public bool VirtualGrouping
    {
      get { return mvarVirtualGrouping; }
      set { mvarVirtualGrouping = value; }
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: GetGroupKeys

    /// <summary>
    /// Fetches a list of key names within the specified group.
    /// </summary>
    /// <param name="groupIndex">The index number of the group to fetch key names from.</param>
    /// <returns>Returns a list of key names within the specified group.</returns>
    public string[] GetGroupKeys(int groupIndex)
    {
      string[] result = new string[0];

      if (groupIndex >= 0 && groupIndex < mvarGroups.Length)
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
    /// Fetches a list of key names within the specified group.
    /// </summary>
    /// <param name="groupName">The name of the group to fetch key names from.</param>
    /// <returns>Returns a list of key names within the specified group.</returns>
    public string[] GetGroupKeys(string groupName)
    {
      return GetGroupKeys(GetGroupIndex(groupName));
    }

    #endregion

    #region Method: GetGroups

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

    #endregion

    #region Method: GetValue

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
    /// While in VirtualGrouping mode: retrieves the value of the specified key.
    /// </summary>
    /// <param name="keyName">The name of the key to find.</param>
    /// <returns>Returns the value of the specified key.</returns>
    public string GetValue(string keyName)
    {
      if (mvarVirtualGrouping)
      {
        return GetValue(VirtualGroupName, keyName);
      }
      else
      {
        throw new Exception("Only available in VirtualGrouping mode!");
      }
    }

    #endregion

    #region Method: RemoveGroup

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

    #region Method: RemoveKey

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
    /// While in VirtualGrouping mode: Removes the specified key.
    /// </summary>
    /// <param name="keyName">The key to remove.</param>
    public void RemoveKey(string keyName)
    {
      if (mvarVirtualGrouping)
      {
        RemoveKey(VirtualGroupName, keyName);
      }
      else
      {
        throw new Exception("Only available in VirtualGrouping mode!");
      }
    }

    #endregion

    #region Method: SetValue

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
    /// While in VirtualGrouping mode: creates or updates the value of the specified key.
    /// </summary>
    /// <param name="keyName">The name of the key to create or update.</param>
    /// <param name="keyValue">The value to create or update.</param>
    public void SetValue(string keyName, string keyValue)
    {
      if (mvarVirtualGrouping)
      {
        SetValue(VirtualGroupName, keyName, keyValue);
      }
      else
      {
        throw new Exception("Only available in VirtualGrouping mode!");
      }
    }

    #endregion

    #endregion

    #region ===== File I/O =====

    #region Private Method: BuildINI

    /// <summary>
    /// Builds an INI text structure based on the defined groups, keys and values.
    /// </summary>
    /// <returns>Returns a string containing all settings in the standard INI format.</returns>
    private string BuildINI()
    {
      const string crlf = "\r\n";
      string result = "";

      for (int g = 0; g < mvarGroups.Length; g++)
      {
        if (mvarVirtualGrouping && mvarGroups[g].Name == VirtualGroupName)
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

    #endregion

    #region Private Method: ParseINI

    /// <summary>
    /// Parses through the passed text and generates groups, keys and values accordingly.
    /// </summary>
    /// <param name="data">The INI data to parse.</param>
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
          if (mvarVirtualGrouping && line[0] == '#')
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
              if (groupIndex == -1 && mvarVirtualGrouping)
              {
                Array.Resize(ref mvarGroups, mvarGroups.Length + 1);
                mvarGroups[mvarGroups.Length - 1] = new INIGroup(VirtualGroupName);
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

    #endregion

    #region Public Method: Load

    /// <summary>
    /// Clears the contents of the INI structure.
    /// </summary>
    public void Clear()
    {
      mvarGroups = new INIGroup[0];
    }

    /// <summary>
    /// Attempts to load the via properties specified file from disk.
    /// </summary>
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

    /// <summary>
    /// Attempts to load the specified INI file from disk.
    /// </summary>
    /// <param name="filePathName">The fully qualified path to the INI file to load.</param>
    public void Load(string filePathName)
    {
      Load(filePathName, false);
    }

    /// <summary>
    /// Attempts to load the specified INI file from disk, with or without virtual grouping.
    /// </summary>
    /// <param name="filePathName">The fully qualified path to the INI file to load.</param>
    /// <param name="virtualGrouping">Determines whether to utilize virtual grouping for the INI content.</param>
    public void Load(string filePathName, bool virtualGrouping)
    {
      UpdatePath(filePathName);
      mvarVirtualGrouping = virtualGrouping;
      Load();
    }

    #endregion

    #region Public Method: Save

    /// <summary>
    /// Attempts to save the current content to disk.
    /// </summary>
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

    /// <summary>
    /// Attempts to save the current contents to disk in the specified file.
    /// </summary>
    /// <param name="filePathName">The fully qualified path to the INI file to save the current content to.</param>
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

    public INIFile(string filePathName, bool virtualGrouping)
    {
      mvarGroups = new INIGroup[0];
      Load(filePathName, virtualGrouping);
    }

    #endregion

  }
}
