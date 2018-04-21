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

    public ServerProfile(string name, string path, string jar, int memorySize)
    {
      ID = -1;
      Name = name.Trim();
      Path = path.Trim();
      Jar = jar.Trim();
      MemorySize = memorySize;
      Icon = null;

      Status = 0;

      PlayerCount = 0;
      MaxPlayers = 0;
      Port = 0;
      MOTD = "";
    }
  }
}
