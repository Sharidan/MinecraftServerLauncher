namespace CSharpLibs.Minecraft
{
  public struct ScheduleProfile
  {
    public int ServerHostID;
    public int EventHour;
    public int EventMinute;
    public bool Backup;

    public ScheduleProfile(int serverHostID, int hour, int minute, bool backup)
    {
      ServerHostID = serverHostID;
      EventHour = hour;
      EventMinute = minute;
      Backup = backup;
    }
  }
}
