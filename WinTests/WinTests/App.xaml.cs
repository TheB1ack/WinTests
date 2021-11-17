using System.Windows;
using Unity;
using WinTests.Services;

namespace WinTests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IPageNavigationService, PageNavigationService>();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
