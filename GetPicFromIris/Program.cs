using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
      Console.WriteLine($"There {Pluralize(files.Length, "is")} {files.Length} image{Pluralize(files.Length)} in the Iris folder");
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

      Console.WriteLine($"There {Pluralize(landscapeFiles.Length, "is")} {landscapeFiles.Length} landscape image{Pluralize(landscapeFiles.Length)} in the Iris folder");

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

    bool AreImagesVisuallySimilar(string path1, string path2)
    {
      const int targetWidth = 256;
      const int targetHeight = 256;

      using (Bitmap img1 = ResizeImage(new Bitmap(path1), targetWidth, targetHeight))
      using (Bitmap img2 = ResizeImage(new Bitmap(path2), targetWidth, targetHeight))
      {
        return CompareBitmaps(img1, img2);
      }
    }

    Bitmap ResizeImage(Bitmap image, int width, int height)
    {
      Bitmap dest = new Bitmap(width, height);
      using (Graphics g = Graphics.FromImage(dest))
      {
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(image, 0, 0, width, height);
      }
      return dest;
    }

    bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
    {
      for (int y = 0; y < bmp1.Height; y++)
      {
        for (int x = 0; x < bmp1.Width; x++)
        {
          if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
            return false;
        }
      }
      return true;
    }

    public static string Pluralize(int number, string irregularNoun = "")
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
        case "has":
          return number > 1 ? "have" : "has";
        case "The":
          return "The"; // CAPITAL, useful because of French plural
        case "the":
          return "the"; // lower case, useful because of French plural
        default:
          return number > 1 ? "s" : string.Empty;
      }
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
