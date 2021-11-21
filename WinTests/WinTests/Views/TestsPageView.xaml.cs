using System.Windows.Controls;
using Unity;
using WinTests.ViewModels;

namespace WinTests.Views
{
    public partial class TestsPageView : Page
    {
        [Dependency]
        public TestsPageViewModel ViewModel
        {
            get => DataContext as TestsPageViewModel;
            set
            {
                DataContext = value;
            }
        }

        public TestsPageView()
        {
            InitializeComponent();
        }
    }
}