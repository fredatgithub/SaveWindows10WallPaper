using System.ServiceProcess;

namespace WindowsServiceCopyPictures
{
  static class Program
  {
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    static void Main()
    {
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[]
      {
                new ServiceCopyPictures()
      };

      ServiceBase.Run(ServicesToRun);
    }
  }
}
