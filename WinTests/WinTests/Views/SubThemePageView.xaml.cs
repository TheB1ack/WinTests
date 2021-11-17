using System.Windows.Controls;
using Unity;
using WinTests.ViewModels;

namespace WinTests.Views
{
    public partial class SubThemePageView : Page
    {
        [Dependency]
        public SubThemePageViewModel ViewModel
        {
            get => DataContext as SubThemePageViewModel;
            set
            {
                DataContext = value;
            }
        }

        public SubThemePageView()
        {
            InitializeComponent();
        }
    }
}
