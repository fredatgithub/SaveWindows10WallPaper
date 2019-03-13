using System;
using System.Collections.Generic;
using System.IO;

namespace SaveWin10Pictures
{
  class Program
  {
    static void Main(string[] args)
    {
      Action<string> display = Console.WriteLine;
      List<string> files = new List<string>();
      
      string userName = "userName";
      string imagePath = $@"C:\Users\{userName}\Pictures\fond_ecran";
      foreach (string file in GetFilesFileteredBySize(new DirectoryInfo($@"C:\Users\{userName}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"), 100000))
      {
        files.Add(file);
      }

      try
      {
        bool overwirte = false;
        for (int i = 0; i < files.Count; i++)
        {
          string source = files[i].ToString();
          string destination = Path.Combine(imagePath, source) + ".jpg";
          File.Copy(source, destination, overwirte);
        }
      }
      catch (Exception)
      {
        // do nothing and continue to next file
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
  }
}
