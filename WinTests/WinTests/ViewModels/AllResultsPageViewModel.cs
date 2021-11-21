using System.Collections.ObjectModel;
using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Theme;
using WinTests.Services.PageNavigation;

namespace WinTests.ViewModels
{
    public class AllResultsPageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;

        public AllResultsPageViewModel() : base()
        {
            navigationService = App.Resolve<IPageNavigationService>();
        }

        private ObservableCollection<ThemeViewModel> themesCollection = new();
        public ObservableCollection<ThemeViewModel> ThemesCollection
        {
            get => themesCollection;
            set => SetProperty(ref themesCollection, value);
        }

        private ICommand goBackTappedCommand;
        public ICommand GoBackTappedCommand => goBackTappedCommand ??= new CustomCommand(OnGoBackTappedCommand);

        private void OnGoBackTappedCommand(object item)
        {
            navigationService.GoBack();
        }
    }
}
