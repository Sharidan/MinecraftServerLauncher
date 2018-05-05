using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  class BackupManager : IDisposable
  {

    #region ===== Events =====

    #region Event: BackupCompleted

    public delegate void BackupCompletedEventHandler(int serverHostID);

    public event BackupCompletedEventHandler BackupCompleted;

    protected void OnBackupCompleted(int serverHostID)
    {
      BackupCompleted?.Invoke(serverHostID);
    }

    #endregion

    #region Event: BackupFailed

    public delegate void BackupFailedEventHandler(int serverHostID);

    public event BackupFailedEventHandler BackupFailed;

    protected void OnBackupFailed(int serverHostID)
    {
      BackupFailed?.Invoke(serverHostID);
    }

    #endregion

    #region Event: BackupStarting

    public delegate void BackupStartingEventHandler(int serverHostID);

    public event BackupStartingEventHandler BackupStarting;

    protected void OnBackupStarting(int serverHostID)
    {
      BackupStarting?.Invoke(serverHostID);
    }

    #endregion

    #endregion

    #region ===== 

    private struct BackupEntry
    {
      public int ServerHostID;
      public string ServerLevelPath;
      public string BackupPath;

      public BackupEntry(int serverHostID, string serverLevelPath, string backupPath)
      {
        ServerHostID = serverHostID;
        ServerLevelPath = serverLevelPath.Trim();
        BackupPath = backupPath.Trim();
      }
    }

    private Queue<BackupEntry> BackupQueue = new Queue<BackupEntry>();

    #endregion

    #region ===== Backup Handling =====

    #region Method: FixPath

    private string FixPath(string path)
    {
      if (path.Length > 0 && path[path.Length - 1] != '\\')
      {
        return path + '\\';
      }

      return path;
    }

    #endregion

    #region Method: GetArchiveFilePathName

    private string GetArchiveFilePathName(string backupPath)
    {
      // MSLBackup-2018-05-04-16-08.zip
      // MSLBackup-2018-05-04-16-08 (2).zip
      // ....
      // MSLBackup-2018-05-04-16-08 (100).zip
      string path = FixPath(backupPath);
      string name = "MSLBackup-";

      name += DateTime.Now.Year.ToString() + "-";
      name += PadZero(DateTime.Now.Month) + "-";
      name += PadZero(DateTime.Now.Day) + "-";
      name += PadZero(DateTime.Now.Hour) + "-";
      name += PadZero(DateTime.Now.Minute);

      if (File.Exists(path + name + ".zip"))
      {
        for (int i = 2; i <= 100; i++)
        {
          if (!File.Exists(path + name + " (" + i.ToString() + ").zip"))
          {
            return path + name + " (" + i.ToString() + ").zip";
          }
        }
      }

      return path + name + ".zip";
    }

    #endregion

    #region Method: PadZero

    private string PadZero(int value)
    {
      string result = value.ToString();
      if (result.Length == 1)
      {
        result = "0" + result;
      }

      return result;
    }

    #endregion

    #region Method: PerformBackup

    private void PerformBackup(BackupEntry entry)
    {
      OnBackupStarting(entry.ServerHostID);

      if (Directory.Exists(entry.ServerLevelPath))
      {
        string[] folders = Directory.GetDirectories(entry.ServerLevelPath);
        string[] files = Directory.GetFiles(entry.ServerLevelPath);

        if (folders.Length > 0 && files.Length > 0)
        {
          // Does the backup path exist?
          if (!Directory.Exists(entry.BackupPath))
          {
            // Nope, let's try to create it
            try
            {
              Directory.CreateDirectory(entry.BackupPath);
            }
            catch { }
          }

          // Does the backup path exist?
          if (Directory.Exists(entry.BackupPath))
          {
            // Yup, the backup path exists and we've got data to back up...
            // Fetch an available filename for the zip archive
            string zipFilePathName = GetArchiveFilePathName(entry.BackupPath);
            // Do the backup...
            ZipFile.CreateFromDirectory(entry.ServerLevelPath, zipFilePathName);
            // Finally raise the completed event.
            OnBackupCompleted(entry.ServerHostID);
            // We are done, so let's just return
            return;
          }
        }
      }

      OnBackupFailed(entry.ServerHostID);
    }

    #endregion

    #endregion

    #region ===== Backup Monitoring =====

    private Thread BackupThread = null;

    private volatile bool Running = false;

    #region Method: BackupMonitor

    private void BackupMonitor()
    {
      Running = true;

      while (Running)
      {
        BackupEntry entry = new BackupEntry(-1, "", "");

        // Check the queue to see if we need to do another backup?
        lock (BackupQueue)
        {
          // Are there any entries in the queue?
          if (BackupQueue.Count > 0)
          {
            // Yes! Grab the first one
            entry = BackupQueue.Dequeue();
          }
        }
        // Did we get a backup request from the queue?
        if (entry.ServerHostID > -1)
        {
          // Yup, let's get this done...
          PerformBackup(entry);
        }

        Thread.Sleep(10);
      }

      Running = false;
    }

    #endregion

    #region Method: StartBackupMonitor

    private void StartBackupMonitor()
    {
      BackupThread = new Thread(new ThreadStart(BackupMonitor));
      BackupThread.Start();

      while (!BackupThread.IsAlive)
        Thread.Sleep(5);
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    /// <summary>
    /// Add a new backup request to the backup queue.
    /// </summary>
    /// <param name="serverHostID">The unique Minecraft server host ID reference for the instance that needs a backup.</param>
    /// <param name="serverLevelPath">The full path to the Minecraft server's level folder.</param>
    /// <param name="backupPath">The full path to where the backup files should be stored.</param>
    public void Add(int serverHostID, string serverLevelPath, string backupPath)
    {
      lock (BackupQueue)
      {
        // Queue up this backup ...
        BackupQueue.Enqueue(new BackupEntry(serverHostID, serverLevelPath, backupPath));
      }
    }

    #endregion

    #region ===== Constructor =====

    public BackupManager()
    {
      StartBackupMonitor();
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
          Running = false;

          while (BackupThread.IsAlive)
            Thread.Sleep(5);
        }

        BackupThread = null;

        BackupQueue.Clear();
        BackupQueue = null;

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
