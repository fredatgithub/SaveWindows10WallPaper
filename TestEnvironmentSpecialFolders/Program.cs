using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestEnvironmentSpecialFolders
{
  class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display($"Environment.SpecialFolder.MyComputer :           {Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.MyPictures :           {Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.SendTo :               {Environment.GetFolderPath(Environment.SpecialFolder.SendTo)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.ProgramFilesX86 :      {Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Programs :             {Environment.GetFolderPath(Environment.SpecialFolder.Programs)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Recent :               {Environment.GetFolderPath(Environment.SpecialFolder.Recent)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Resources :            {Environment.GetFolderPath(Environment.SpecialFolder.Resources)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.StartMenu :            {Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.System :               {Environment.GetFolderPath(Environment.SpecialFolder.System)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.SystemX86 :            {Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Templates :            {Environment.GetFolderPath(Environment.SpecialFolder.Templates)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.UserProfile :          {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Windows :              {Environment.GetFolderPath(Environment.SpecialFolder.Windows)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Startup :              {Environment.GetFolderPath(Environment.SpecialFolder.Startup)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.MyDocuments :          {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.MyComputer :           {Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.History :              {Environment.GetFolderPath(Environment.SpecialFolder.History)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.InternetCache :        {Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.LocalApplicationData : {Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.LocalizedResources :   {Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.DesktopDirectory :     {Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.Desktop :              {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.CommonStartMenu :      {Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.AdminTools :           {Environment.GetFolderPath(Environment.SpecialFolder.AdminTools)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.ApplicationData :      {Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.CDBurning :            {Environment.GetFolderPath(Environment.SpecialFolder.CDBurning)}");
      display(string.Empty);
      display($"Environment.SpecialFolder.CommonApplicationData :{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}");
      display(string.Empty);
      //display($"EnvironmentVariableTarget.User : {EnvironmentVariableTarget.User.ToString()}");
      display($"Environment.SpecialFolder.CommonProgramFiles : {Environment.SpecialFolder.CommonProgramFiles}");
      display($"Environment.SpecialFolder.ProgramFiles : {Environment.SpecialFolder.ProgramFiles}");
      display($"Environment.SpecialFolder.CommonAdminTools : {Environment.SpecialFolder.CommonAdminTools}");
      display($"Environment.SpecialFolder.CommonDesktopDirectory : {Environment.SpecialFolder.CommonDesktopDirectory}");
      display($"Environment.SpecialFolder.CommonDocuments : {Environment.SpecialFolder.CommonDocuments}");
      //display($"Environment.SpecialFolder. : {Environment.SpecialFolder.}");
      /* enum restantes à montrer
        CommonAdminTools
        CommonDesktopDirectory
        CommonDocuments
        CommonMusic
        CommonOemLinks
        CommonPictures
        CommonProgramFiles
        CommonProgramFilesX86
        CommonPrograms
        CommonStartup
        CommonTemplates
        CommonVideos
        Cookies
        Favorites
        Fonts
        MyMusic
        MyVideos
        NetworkShortcuts
        PrinterShortcuts
        ProgramFiles
       * */

      foreach (var item in GetEnumList<Environment.SpecialFolder>())
      {
        display($"{item}");
      }

      //display($"The picture: {picture} is landscape: {IsPictureLandscape(picture)}");
      display("Press any key to exit:");
      Console.ReadKey();
    }

    public static bool IsPictureLandscape(string fileName)
    {
      Bitmap image = new Bitmap(fileName);
      return image.Width > image.Height;
    }

    private static List<T> GetEnumList<T>()
    {
      return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }
  }
}
