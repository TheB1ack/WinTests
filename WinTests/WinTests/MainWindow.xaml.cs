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

                ViewModel.FrameContainer = mainFrameContainer;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
