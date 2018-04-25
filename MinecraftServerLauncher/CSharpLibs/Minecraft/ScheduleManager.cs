using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  class ScheduleManager : IDisposable
  {

    #region ===== Events =====

    #region Event: ScheduledBackup

    public delegate void ScheduledBackupEventHandler(int serverHostID);

    public event ScheduledBackupEventHandler ScheduledBackup;

    protected void OnScheduledBackup(int serverHostID)
    {
      ScheduledBackup?.Invoke(serverHostID);
    }

    #endregion

    #region Event: ScheduledRestart

    public delegate void ScheduledRestartEventHandler(int serverHostID);

    public event ScheduledRestartEventHandler ScheduledRestart;

    protected void OnScheduledRestart(int serverHostID)
    {
      ScheduledRestart?.Invoke(serverHostID);
    }

    #endregion

    #endregion

    #region ===== Scheduling Structures =====

    private struct ScheduleEntry
    {
      public int ServerHostID;
      public int EventHour;
      public int EventMinute;
      public int EventSecond;
      public bool Backup; // Is this a backup event?
      public bool Triggered; // Determines whether the scheduled event has triggered
      public int ResetIndex; // Will hold the index of the schedule entry to reset

      public ScheduleEntry(int serverHostID, int eventHour, int eventMinute, bool backup)
      {
        ServerHostID = serverHostID;
        EventHour = eventHour;
        EventMinute = eventMinute;
        EventSecond = 0;
        Backup = backup;
        Triggered = false;
        ResetIndex = -1;
      }

      public ScheduleEntry(int serverHostID, int eventHour, int eventMinute, bool backup, int resetIndex)
      {
        ServerHostID = serverHostID;
        EventHour = eventHour;
        EventMinute = eventMinute;
        EventSecond = 10;
        Backup = backup;
        Triggered = false;
        ResetIndex = resetIndex;
      }
    }

    private ScheduleEntry[] mvarSchedules = new ScheduleEntry[0];

    #endregion

    #region ===== Schedule Monitoring Thread =====

    private Thread MonitorThread = null;

    private volatile bool Running = false;

    #region Method: MonitorSchedules

    private void MonitorSchedules()
    {
      Running = true;

      while (Running)
      {
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;
        int currentSecond = DateTime.Now.Second;

        // Loop through all the schedule entries, to see if one matches
        for (int s = 0; s < mvarSchedules.Length; s++)
        {
          if (mvarSchedules[s].EventHour == currentHour && mvarSchedules[s].EventMinute == currentMinute)
          {
            // We've found (at least) one that matches - check the seconds...
            if (mvarSchedules[s].EventSecond == currentSecond)
            {
              // This is some kind of event we have to handle
              // So ... is this a backup/restart event? or a reset thingie?
              if (mvarSchedules[s].ResetIndex == -1)
              {
                // Might be an event we have to raise ...
                if (!mvarSchedules[s].Triggered)
                {
                  mvarSchedules[s].Triggered = true;
                  switch (mvarSchedules[s].Backup)
                  {
                    case true:
                      OnScheduledBackup(mvarSchedules[s].ServerHostID);
                      break;
                    default:
                      OnScheduledRestart(mvarSchedules[s].ServerHostID);
                      break;
                  }
                }
              }
              else
              {
                int resetIndex = mvarSchedules[s].ResetIndex;

                // Ensure that we have a valid schedule entry index
                if (resetIndex >= 0 && resetIndex < mvarSchedules.Length)
                {
                  // Check that the two schedule entry profiles match (ignoring the seconds!)
                  if (
                    mvarSchedules[resetIndex].ServerHostID == mvarSchedules[s].ServerHostID &&
                    mvarSchedules[resetIndex].EventHour == mvarSchedules[s].EventHour &&
                    mvarSchedules[resetIndex].EventMinute == mvarSchedules[s].EventMinute &&
                    mvarSchedules[resetIndex].Backup == mvarSchedules[s].Backup
                    )
                  {
                    // Was this event triggered
                    if (mvarSchedules[resetIndex].Triggered)
                    { // Yes: reset it
                      mvarSchedules[resetIndex].Triggered = false;
                    }
                  }

                }

              }

            }
          }
        }

        // Wait for a bit...
        Thread.Sleep(5); // 5ms

      }
    }

    #endregion

    #region Method: StartMonitor

    private void StartMonitor()
    {
      MonitorThread = new Thread(new ThreadStart(MonitorSchedules));
      MonitorThread.Start();

      while (!MonitorThread.IsAlive)
        Thread.Sleep(5);
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: Add

    public void Add(ScheduleProfile schedule)
    {
      Add(schedule.ServerHostID, schedule.EventHour, schedule.EventMinute, schedule.Backup);
    }

    public void Add(int serverHostID, DateTime schedule, bool backup)
    {
      Add(serverHostID, schedule.Hour, schedule.Minute, backup);
    }

    public void Add(int serverHostID, int hour, int minute, bool backup)
    {
      int index = -1;

      for (int s = 0; s < mvarSchedules.Length; s++)
      {
        if (
          mvarSchedules[s].ResetIndex == -1 && 
          mvarSchedules[s].ServerHostID == serverHostID && 
          mvarSchedules[s].EventHour == hour && 
          mvarSchedules[s].EventMinute == minute && 
          mvarSchedules[s].Backup == backup
          )
        {
          index = s;
          break;
        }
      }

      if (index == -1)
      {
        Array.Resize(ref mvarSchedules, mvarSchedules.Length + 1);
        mvarSchedules[mvarSchedules.Length - 1] = new ScheduleEntry(serverHostID, hour, minute, backup);
        int resetIndex = mvarSchedules.Length - 1;
        Array.Resize(ref mvarSchedules, mvarSchedules.Length + 1);
        mvarSchedules[mvarSchedules.Length - 1] = new ScheduleEntry(serverHostID, hour, minute, backup, resetIndex);
      }

    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public ScheduleManager()
    {
      StartMonitor();
    }

    #endregion

    #region ===== Disposal =====

    private bool mvarDisposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!mvarDisposed)
      {
        if (disposing)
        {
          //TODO: Add a thread shutdown call here!!
          Running = false;

          while (MonitorThread.IsAlive)
            Thread.Sleep(5);
        }

        MonitorThread = null;

        mvarSchedules = new ScheduleEntry[0];

        mvarDisposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }

    #endregion

  }
}
