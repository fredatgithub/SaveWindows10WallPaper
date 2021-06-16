using System.ComponentModel;

namespace WindowsServiceCopyPictures
{
  [RunInstaller(true)]
  public partial class ProjectInstaller : System.Configuration.Install.Installer
  {
    public ProjectInstaller()
    {
      InitializeComponent();
    }
  }
}
