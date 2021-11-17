using System.Windows;
using Unity;
using WinTests.ViewModels;

namespace WinTests
{
    public partial class MainWindow : Window
    {
        [Dependency]
        public MainWindowViewModel ViewModel
        {
            get => DataContext as MainWindowViewModel;
            set
            {
                DataContext = value;

                ViewModel.FrameContainer = frameContainer;
            }
        }

        public MainWindow()
        {
            this.Loaded += OnLoaded;

            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnLoaded();
        }
    }
}
