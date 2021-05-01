using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace SaveWin10Pic24Hours
{
  class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      Console.ForegroundColor = ConsoleColor.Yellow;
      display("Save Windows 10 pictures every 24 hours version 1.0.0.0");
      while (true)
      {
        display(string.Empty);
        Console.ForegroundColor = ConsoleColor.Yellow;
        display($"Checking if there are new images to be copied on {DateTime.Now}");
        List<string> files = new List<string>();
        int counter = 0;
        //string OSVersion = Environment.OSVersion.ToString(); // 6.2 ON Win 10
        string OSVersion = GetOSInfo();
        //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        string userName = Environment.UserName;
        string userNameProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
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
          display($@"The directory {appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets does not appear to exit, are you on a Windows 10 PC ?");
          return;
        }

        foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"{appDatafolder}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"), 100000))
        {
          files.Add(file);
        }

        try
        {
          const bool doNotOverwrite = false;
          for (int i = 0; i < files.Count; i++)
          {
            string source = files[i];
            string destination = Path.Combine(imagePath, Path.GetFileName(source)) + ".jpg";
            if (!File.Exists(destination) && IsPictureLandscape(destination)) // and picture is landscape
            {
              File.Copy(source, destination, doNotOverwrite);
              counter++;
              // copying pic to source git
              string destinationGitPath = $@"C:\Users\{userName}\Source\Repos\SaveWindows10WallPaper\SaveWindows10WallPaper\images";
              string destinationGit = Path.Combine(destinationGitPath, Path.GetFileName(source)) + ".jpg";
              if (!File.Exists(destinationGit) && IsPictureLandscape(destinationGit))
              {
                File.Copy(source, destinationGit, doNotOverwrite);
              }
            }
          }
        }
        catch (Exception)
        {
          // do nothing and continue with the next file
        }

        if (counter == 0)
        {
          Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }

        display(string.Empty);
        display($"{counter} image{Plural(counter)} {Plural(counter, "have")} been copied to the picture folder on {DateTime.Now}.");
        display(string.Empty);
        Thread.Sleep(1000 * 60 * 60 * 24); // sleep 24 hours
      }
    }

    public static string Plural(int number, string irregularNoun = "")
    {
      switch (irregularNoun)
      {
        case "":
          return number > 1 ? "s" : string.Empty;
        case "al":
          return number > 1 ? "aux" : "al";
        case "au":
          return number > 1 ? "aux" : "au";
        case "eau":
          return number > 1 ? "eaux" : "eau";
        case "eu":
          return number > 1 ? "eux" : "eu";
        case "landau":
          return number > 1 ? "landaus" : "landau";
        case "sarrau":
          return number > 1 ? "sarraus" : "sarrau";
        case "bleu":
          return number > 1 ? "bleus" : "bleu";
        case "émeu":
          return number > 1 ? "émeus" : "émeu";
        case "lieu":
          return number > 1 ? "lieux" : "lieu";
        case "pneu":
          return number > 1 ? "pneus" : "pneu";
        case "aval":
          return number > 1 ? "avals" : "aval";
        case "bal":
          return number > 1 ? "bals" : "bal";
        case "chacal":
          return number > 1 ? "chacals" : "chacal";
        case "carnaval":
          return number > 1 ? "carnavals" : "carnaval";
        case "festival":
          return number > 1 ? "festivals" : "festival";
        case "récital":
          return number > 1 ? "récitals" : "récital";
        case "régal":
          return number > 1 ? "régals" : "régal";
        case "cal":
          return number > 1 ? "cals" : "cal";
        case "serval":
          return number > 1 ? "servals" : "serval";
        case "choral":
          return number > 1 ? "chorals" : "choral";
        case "narval":
          return number > 1 ? "narvals" : "narval";
        case "bail":
          return number > 1 ? "baux" : "bail";
        case "corail":
          return number > 1 ? "coraux" : "corail";
        case "émail":
          return number > 1 ? "émaux" : "émail";
        case "soupirail":
          return number > 1 ? "soupiraux" : "soupirail";
        case "travail":
          return number > 1 ? "travaux" : "travail";
        case "vantail":
          return number > 1 ? "vantaux" : "vantail";
        case "vitrail":
          return number > 1 ? "vitraux" : "vitrail";
        case "bijou":
          return number > 1 ? "bijoux" : "bijou";
        case "caillou":
          return number > 1 ? "cailloux" : "caillou";
        case "chou":
          return number > 1 ? "choux" : "chou";
        case "genou":
          return number > 1 ? "genoux" : "genou";
        case "hibou":
          return number > 1 ? "hiboux" : "hibou";
        case "joujou":
          return number > 1 ? "joujoux" : "joujou";
        case "pou":
          return number > 1 ? "poux" : "pou";
        case "est":
          return number > 1 ? "sont" : "est";

        // English
        case " is":
          return number > 1 ? "s are" : " is"; // with a space before
        case "is":
          return number > 1 ? "are" : "is"; // without a space before
        case "are":
          return number > 1 ? "are" : "is"; // without a space before
        case "has":
          return number > 1 ? "have" : "has";
        case "have":
          return number > 1 ? "have" : "has";
        case "The":
          return "The"; // CAPITAL, useful because of French plural
        case "the":
          return "the"; // lower case, useful because of French plural
        default:
          return number > 1 ? "s" : string.Empty;
      }
    }

    public static List<string> GetFilesFileteredBySize(DirectoryInfo directoryInfo, long sizeGreaterOrEqualTo)
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

    public static string GetOSInfo()
    {
      //Get Operating system information.
      OperatingSystem os = Environment.OSVersion;
      //Get version information about the os.
      Version vs = os.Version;

      //Variable to hold our return value
      string operatingSystem = "";

      if (os.Platform == PlatformID.Win32Windows)
      {
        //This is a pre-NT version of Windows
        switch (vs.Minor)
        {
          case 0:
            operatingSystem = "95";
            break;
          case 10:
            if (vs.Revision.ToString() == "2222A")
              operatingSystem = "98SE";
            else
              operatingSystem = "98";
            break;
          case 90:
            operatingSystem = "Me";
            break;
          default:
            break;
        }
      }
      else if (os.Platform == PlatformID.Win32NT)
      {
        switch (vs.Major)
        {
          case 3:
            operatingSystem = "NT 3.51";
            break;
          case 4:
            operatingSystem = "NT 4.0";
            break;
          case 5:
            if (vs.Minor == 0)
              operatingSystem = "2000";
            else
              operatingSystem = "XP";
            break;
          case 6:
            if (vs.Minor == 0)
              operatingSystem = "Vista";
            else if (vs.Minor == 1)
              operatingSystem = "7";
            else if (vs.Minor == 2)
              operatingSystem = "8";
            else
              operatingSystem = "8.1";
            break;
          case 10:
            operatingSystem = "10";
            break;
          default:
            break;
        }
      }

      //Make sure we actually got something in our OS check
      //We don't want to just return " Service Pack 2" or " 32-bit"
      //That information is useless without the OS version.
      if (operatingSystem != "")
      {
        //Got something.  Let's prepend "Windows" and get more info.
        operatingSystem = "Windows " + operatingSystem;
        //See if there's a service pack installed.
        if (os.ServicePack != "")
        {
          //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
          operatingSystem += " " + os.ServicePack;
        }
        //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
        //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
      }
      //Return the information we've gathered.
      return operatingSystem;
    }

    public static bool IsPictureLandscape(string fileName)
    {
      try
      {
        Bitmap image = new Bitmap(fileName);
        return image.Width > image.Height;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
