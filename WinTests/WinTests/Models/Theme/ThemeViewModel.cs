using System.Collections.ObjectModel;
using System.Windows.Controls;
using WinTests.Models.Subtheme;
using WinTests.ViewModels;

namespace WinTests.Models.Theme
{
    public class ThemeViewModel : BaseViewModel
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private ObservableCollection<SubthemeViewModel> subThemes;
        public ObservableCollection<SubthemeViewModel> SubThemes 
        { 
            get => subThemes; 
            set => SetProperty(ref subThemes, value);
        }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }

        private Page page;
        public Page Page
        {
            get => page;
            set => SetProperty(ref page, value);
        }
    }
}
