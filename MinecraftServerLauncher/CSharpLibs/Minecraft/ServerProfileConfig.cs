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

    #region ===== File I/O =====

    private int FixInt(string value)
    {
      int result = 0;

      if (!int.TryParse(value, out result))
      {
        return 0;
      }

      return result;
    }

    private void LoadConfig()
    {
      string fileName = Path + "ServerProfile.cfg";

      configINI.Load(fileName);

      // For now we'll ignore the profile count

      MinecraftPath = configINI.GetValue("Profile1", "MinecraftPath");
      MinecraftJar = configINI.GetValue("Profile1", "Jar");
      MemorySize = FixInt(configINI.GetValue("Profile1", "Memory"));
    }

    private void SaveConfig()
    {
      string fileName = Path + "ServerProfile.cfg";

      configINI.SetValue("Profiles", "Count", "1");

      configINI.SetValue("Profile1", "MinecraftPath", MinecraftPath);
      configINI.SetValue("Profile1", "Jar", MinecraftJar);
      configINI.SetValue("Profile1", "Memory", MemorySize.ToString());

      configINI.Save(fileName);
    }

    #endregion

    #region ===== Properties =====

    public string MinecraftPath { get; set; } = "";

    public string MinecraftJar { get; set; } = "minecraft_server.jar";

    public int MemorySize { get; set; } = 1024;

    #endregion

    #region ===== Public Methods =====

    public void Save()
    {
      //TODO: maybe add in a check whether something has changed
      // If changes exist, then do the save, otherwise skip
      SaveConfig();
    }

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
