using System.Windows;
using System.Windows.Controls;
using Unity;
using WinTests.ViewModels;

namespace WinTests.Views
{
    public partial class MainPageView : Page
    {
        [Dependency]
        public MainPageViewModel ViewModel
        {
            get => DataContext as MainPageViewModel;
            set
            {
                DataContext = value;

                ViewModel.FrameContainer = frameContainer;
            }
        }

        public MainPageView()
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
