using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace GetPicFromIris
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      Display("Copy all pictures from Iris directory");
      // display the current version of the program
      Display("Version: " + GetApplicationVersion());

      // Get the path to the Iris folder
      string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

      string irisFolderPath = Path.Combine(localAppDataPath, @"Packages\MicrosoftWindows.Client.CBS_cw5n1h2txyewy\LocalCache\Microsoft\IrisService\");
      Console.WriteLine($"Iris folder path: {irisFolderPath}");
      string[] files = Directory.GetFiles(irisFolderPath, "*.jpg", SearchOption.AllDirectories);
      Console.WriteLine($"There are {files.Length} image{Pluralize(files.Length)} in the Iris folder");
      // Check if there are any files in the folder
      if (files.Length == 0)
      {
        Console.WriteLine("No images found in the Iris folder.");
        return;
      }

      // Keep only landscape images
      string[] landscapeFiles = files.Where(file =>
      {
        return IsPictureLandscape(file, "jpg");
      }).ToArray();

      Console.WriteLine($"There are {landscapeFiles.Length} landscape image{Pluralize(landscapeFiles.Length)} in the Iris folder");

      if (landscapeFiles.Length == 0)
      {
        Console.WriteLine("No landscape images found.");
        return;
      }

      // remove duplicates images based on the hash file
      // get the list of MD5 hashes for the files
      string[] md5Hashes = new string[landscapeFiles.Length];
      var dico = new Dictionary<string, string>();
      for (int i = 0; i < landscapeFiles.Length; i++)
      {
        using (var md5 = MD5.Create())
        {
          using (var stream = File.OpenRead(landscapeFiles[i]))
          {
            md5Hashes[i] = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            dico.Add(landscapeFiles[i], md5Hashes[i]);
          }
        }
      }

      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    public static string Pluralize(int count)
    {
      return count > 1 ? "s" : string.Empty;
    }

    private static string GetApplicationVersion()
    {
      return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    private static string GetMD5Hash(string sourcePath)
    {
      var result = string.Empty;
      using (var md5 = MD5.Create())
      {
        using (var stream = File.OpenRead(sourcePath))
        {
          result = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
        }
      }

      return result;
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
