using System.Windows;
using Unity;
using WinTests.Services.PageNavigation;
using WinTests.Services.ThemeRepository;

namespace WinTests
{
    public partial class App : Application
    {
        public static IUnityContainer container;
        public static T Resolve<T>() => (container ?? new UnityContainer()).Resolve<T>();

        protected override void OnStartup(StartupEventArgs e)
        {
            container = new UnityContainer();

            container.RegisterSingleton<IPageNavigationService, PageNavigationService>();
            container.RegisterSingleton<IThemeRepositoryService, ThemeRepositoryService>();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
