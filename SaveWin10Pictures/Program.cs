using System;
using System.Collections.Generic;
using System.IO;

namespace SaveWin10Pictures
{
  internal class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("Checking if there are new images to be copied...");
      List<string> files = new List<string>();
      int counter = 0;
      const string userName = "user";
      string imagePath = $@"C:\Users\{userName}\Pictures\fond_ecran";
      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"C:\Users\{userName}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"), 100000))
      {
        files.Add(file);
      }

      try
      {
        const bool overwirte = false;
        for (int i = 0; i < files.Count; i++)
        {
          string source = files[i];
          string destination = Path.Combine(imagePath, source) + ".jpg";
          File.Copy(source, destination, overwirte);
          counter++;
        }
      }
      catch (Exception)
      {
        // do nothing and continue with the next file
      }

      display($"{counter} images have been copied to the picture folder.");
      display("Press any key to exit:");
      //Console.ReadKey(); // comment for batch to production
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
  }
}
