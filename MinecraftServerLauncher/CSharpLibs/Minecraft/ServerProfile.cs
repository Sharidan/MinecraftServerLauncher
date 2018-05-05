using System.Drawing;

namespace CSharpLibs.Minecraft
{

  /// <summary>
  /// Contains the base information for a Minecraft server profile.
  /// </summary>
  public struct ServerProfile
  {
    public int ID;
    public string Name;
    public string Path;
    public string Jar;
    public int MemorySize;
    public Bitmap Icon;
    public byte Status;
    public int PlayerCount;
    public int MaxPlayers;
    public int Port;
    public string MOTD;
    public ScheduleProfile[] Schedules;
    public bool AutoStart;

    public ServerProfile(string name, string path, string jar, int memorySize, bool autoStart)
    {
      ID = -1;
      Name = name.Trim();
      Path = path.Trim();
      Jar = jar.Trim();
      MemorySize = memorySize;
      Icon = null;

      AutoStart = autoStart;

      Status = 0;

      PlayerCount = 0;
      MaxPlayers = 0;
      Port = 0;
      MOTD = "";

      // Initialize the schedule array
      Schedules = new ScheduleProfile[0];
    }

    /* 
     * Bug-fix: added another constructor which accepts an id as an argument to fix
     * ServerProfileConfigDialog overwriting the previous ID during an edit of an
     * existing profile.
     */
    public ServerProfile(int id, string name, string path, string jar, int memorySize, bool autoStart)
    {
      ID = id;
      Name = name.Trim();
      Path = path.Trim();
      Jar = jar.Trim();
      MemorySize = memorySize;
      Icon = null;

      AutoStart = autoStart;

      Status = 0;

      PlayerCount = 0;
      MaxPlayers = 0;
      Port = 0;
      MOTD = "";

      // Initialize the schedule array
      Schedules = new ScheduleProfile[0];
    }
  }
}
