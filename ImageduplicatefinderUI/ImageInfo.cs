using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageduplicatefinderUI
{
  public class ImageInfo
  {
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public long FileSize { get; set; }
    public DateTime LastWriteTime { get; set; }
    public DateTime CreationTime { get; set; }

    private BitmapImage _imageSource;
    public BitmapImage ImageSource => _imageSource;

    public ImageInfo()
    {
    }

    public ImageInfo(string filePath)
    {
      FilePath = filePath;
      FileName = Path.GetFileName(filePath);
      FileSize = new FileInfo(filePath).Length;
      var info = new FileInfo(filePath);
      LastWriteTime = info.LastWriteTime;
      CreationTime = info.CreationTime;
      _imageSource = LoadImage(filePath);
    }

    private BitmapImage LoadImage(string filePath)
    {
      try
      {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.EndInit();
        bitmap.Freeze();
        return bitmap;
      }
      catch (Exception exception)
      {
        Debug.WriteLine($"Erreur chargement image {filePath} : {exception.Message}");
        return null;
      }
    }
  }
}
