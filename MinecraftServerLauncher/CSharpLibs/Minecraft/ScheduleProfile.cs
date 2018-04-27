namespace CSharpLibs.Minecraft
{
  public struct ScheduleProfile
  {
    public int ServerHostID;
    public int EventHour;
    public int EventMinute;
    public bool Backup;
    public string BackupPath;

    public ScheduleProfile(int serverHostID, int hour, int minute)
    {
      ServerHostID = serverHostID;
      EventHour = hour;
      EventMinute = minute;
      Backup = false;
      BackupPath = "";
    }

    public ScheduleProfile(int serverHostID, int hour, int minute, string backupPath)
    {
      ServerHostID = serverHostID;
      EventHour = hour;
      EventMinute = minute;
      Backup = true;
      BackupPath = backupPath;
    }

    public ScheduleProfile(ScheduleProfile oldProfile)
    {
      ServerHostID = oldProfile.ServerHostID;
      EventHour = oldProfile.EventHour;
      EventMinute = oldProfile.EventMinute;
      Backup = oldProfile.Backup;
      BackupPath = oldProfile.BackupPath;
    }
  }
}
