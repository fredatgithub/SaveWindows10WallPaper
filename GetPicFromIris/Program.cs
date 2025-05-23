using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GetPicFromIris
{
  internal class Program
  {
    static void Main()
    {
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


      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    public static string Pluralize(int count)
    {
      return count > 1 ? "s" : string.Empty;
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
