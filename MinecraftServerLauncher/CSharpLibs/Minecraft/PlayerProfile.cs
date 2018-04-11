using System;

namespace CSharpLibs.Minecraft
{

  /// <summary>
  /// Contains the details for a single player's profile.
  /// </summary>
  public struct PlayerProfile
  {
    public DateTime LoginTime;
    public string Name;
    public string UUID;
    public byte[] IP;

    public PlayerProfile(DateTime loginTime, string name, string uuid, byte[] ip)
    {
      LoginTime = loginTime;
      Name = name.Trim();
      UUID = uuid.Trim();
      IP = new byte[ip.Length];
      Array.Copy(ip, 0, IP, 0, ip.Length);
    }

  }
}
