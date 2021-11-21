using System.Windows.Controls;
using Unity;
using WinTests.ViewModels;

namespace WinTests.Views
{
    public partial class AllResultsPageView : Page
    {
        [Dependency]
        public AllResultsPageViewModel ViewModel
        {
            get => DataContext as AllResultsPageViewModel;
            set
            {
                DataContext = value;
            }
        }

        public AllResultsPageView()
        {
            InitializeComponent();
        }
    }
}
