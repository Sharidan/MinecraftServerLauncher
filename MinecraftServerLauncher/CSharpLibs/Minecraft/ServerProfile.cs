using System.Drawing;

namespace CSharpLibs.Minecraft
{

  /// <summary>
  /// Contains the base information for a Minecraft server profile.
  /// </summary>
  public struct ServerProfile
  {
    public string Name;
    public string Path;
    public string Jar;
    public int MemorySize;
    public Bitmap Icon;

    public ServerProfile(string name, string path, string jar, int memorySize)
    {
      Name = name.Trim();
      Path = path.Trim();
      Jar = jar.Trim();
      MemorySize = memorySize;
      Icon = null;
    }
  }
}
