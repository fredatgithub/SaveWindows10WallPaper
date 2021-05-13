using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Timers;

namespace WindowsServiceCopyPictures
{
  public partial class ServiceCopyPictures : ServiceBase
  {
    private int eventId = 1;
    public ServiceCopyPictures()
    {
      InitializeComponent();
      eventLog1 = new EventLog();
      if (!EventLog.SourceExists("ServiceGetPictures"))
      {
        EventLog.CreateEventSource("ServiceGetPictures", "MyNewLog");
      }

      eventLog1.Source = "ServiceGetPictures";
      eventLog1.Log = "MyNewLog";
    }

    protected override void OnStart(string[] args)
    {
      eventLog1.WriteEntry("Starting Service to copy pictures.");
      // Set up a timer that triggers every minute.
      Timer timer = new Timer
      {
        Interval = 60000 * 60 // 60 seconds * 60 = 1 hour // * 24 = 24 hours
      };

      timer.Elapsed += new ElapsedEventHandler(OnTimer);
      timer.Start();
    }

    public void OnTimer(object sender, ElapsedEventArgs e)
    {
      eventLog1.WriteEntry("Checking if new pictures have been downloaded for the service ServiceCopyPictures", EventLogEntryType.Information, eventId++);
      List<string> files = new List<string>();
      int counter = 0;
      string userName = Environment.UserName;
      string myPicturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      string appDatafolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      // remove domain if any
      if (userName.Contains("\\"))
      {
        userName = userName.Split('\\')[1];
      }

      string imagePath = myPicturesFolder;
      if (Directory.Exists($@"{myPicturesFolder}\fond_ecran"))
      {
        imagePath = $@"{myPicturesFolder}\fond_ecran";
      }

      // C:\Users\userName\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets
      if (!Directory.Exists($@"{appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"))
      {
        return;
      }

      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"{appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"), 100_000))
      {
        files.Add(file);
        FileInfo fileInfo = new FileInfo(file);
        eventLog1.WriteEntry($@"FOUND PICTURE {file} OF SIZE {fileInfo.Length} BYTES IN {appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", EventLogEntryType.Information, eventId++);
      }

      eventLog1.WriteEntry($@"There are {files.Count} picture files (bigger than 100 kb) found in {appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", EventLogEntryType.Information, eventId++);

      try
      {
        const bool doNotOverwrite = false;
        for (int i = 0; i < files.Count; i++)
        {
          string source = files[i];
          string destination = Path.Combine(imagePath, Path.GetFileName(source)) + ".jpg";
          if (!File.Exists(destination) && IsPictureLandscape(source, "jpg")) // and picture is landscape
          {
            File.Copy(source, destination, doNotOverwrite);
            eventLog1.WriteEntry($"Copying one picture from: {source} to destination: {destination} for the service ServiceCopyPictures", EventLogEntryType.Information, eventId++);
            counter++;
            // copying pic to source git
            string destinationGitPath = $@"C:\Users\{userName}\Source\Repos\SaveWindows10WallPaper\SaveWindows10WallPaper\images";
            string destinationGit = Path.Combine(destinationGitPath, Path.GetFileName(source)) + ".jpg";
            if (!File.Exists(destinationGit) && IsPictureLandscape(source, "jpg")) // and picture is landscape
            {
              File.Copy(source, destinationGit, doNotOverwrite);
            }
          }
          else
          {
            eventLog1.WriteEntry($"Picture already exists on destination: {destination} for the service ServiceCopyPictures", EventLogEntryType.Information, eventId++);
          }
        }
      }
      catch (Exception)
      {
        // do nothing and continue with the next file
      }
    }

    private List<string> GetFilesFileteredBySize(DirectoryInfo directoryInfo, long sizeGreaterOrEqualTo)
    {
      List<string> result = new List<string>();
      foreach (FileInfo fileInfo in directoryInfo.GetFiles())
      {
        if (fileInfo.Length >= sizeGreaterOrEqualTo)
        {
          result.Add(fileInfo.FullName);
        }
      }

      return result;
    }

    protected override void OnStop()
    {
      eventLog1.WriteEntry("OnStop service ServiceCopyPictures.");
    }

    protected override void OnContinue()
    {
      eventLog1.WriteEntry("OnContinue service ServiceCopyPictures.");
    }

    public enum ServiceState
    {
      SERVICE_STOPPED = 0x00000001,
      SERVICE_START_PENDING = 0x00000002,
      SERVICE_STOP_PENDING = 0x00000003,
      SERVICE_RUNNING = 0x00000004,
      SERVICE_CONTINUE_PENDING = 0x00000005,
      SERVICE_PAUSE_PENDING = 0x00000006,
      SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct ServiceStatus
    {
      public int dwServiceType;
      public ServiceState dwCurrentState;
      public int dwControlsAccepted;
      public int dwWin32ExitCode;
      public int dwServiceSpecificExitCode;
      public int dwCheckPoint;
      public int dwWaitHint;
    }

    public static bool IsPictureLandscape(string fileName, string pictureExtension)
    {
      try
      {
        if (File.Exists(fileName))
        {
          Bitmap image = new Bitmap(fileName);
          return image.Width > image.Height;
        }
        else if (File.Exists($"{fileName}.{pictureExtension}"))
        {
          Bitmap image = new Bitmap($"{fileName}.{pictureExtension}");
          return image.Width > image.Height;
        }

        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
