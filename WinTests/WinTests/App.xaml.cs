using System.Windows;
using WinTests.Views;

namespace WinTests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
        }
    }
}
