using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Subtheme;
using WinTests.Services;

namespace WinTests.ViewModels
{
    public class SubThemePageViewModel : BaseViewModel
    {
        private int frameContainerHash;
        private readonly IPageNavigationService navigationService;
        public SubThemePageViewModel(IPageNavigationService navigationService, int frameContainerHash) : base()
        {
            this.navigationService = navigationService;
            this.frameContainerHash = frameContainerHash;
        }

        private SubthemeViewModel selectedSubTheme;
        public SubthemeViewModel SelectedSubTheme
        {
            get => selectedSubTheme;
            set => SetProperty(ref selectedSubTheme, value);
        }

        private ICommand goBackTappedCommand;
        public ICommand GoBackTappedCommand => goBackTappedCommand ??= new CustomCommand(OnGoBackTappedCommand);

        private ICommand goToTestsTappedCommand;
        public ICommand GoToTestsTappedCommand => goToTestsTappedCommand ??= new CustomCommand(OnGoToTestsTappedCommand);

        private void OnGoBackTappedCommand(object item)
        {
            navigationService.GoBack(frameContainerHash);
        }

        private void OnGoToTestsTappedCommand(object item)
        {
           //navigate to tests
        }

    }
}
