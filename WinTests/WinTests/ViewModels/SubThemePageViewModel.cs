using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Subtheme;
using WinTests.Services.PageNavigation;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class SubThemePageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;

        private int frameContainerHash;

        public SubThemePageViewModel(int frameContainerHash) : base()
        {
            this.navigationService = App.Resolve<IPageNavigationService>();
            this.frameContainerHash = frameContainerHash;
        }

        private SubThemeViewModel selectedSubTheme;
        public SubThemeViewModel SelectedSubTheme
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
            var page = new TestsPageView
            {
                ViewModel = new TestsPageViewModel(frameContainerHash)
                {
                    SelectedSubTheme = SelectedSubTheme,
                },
            };

            navigationService.NavigateTo(page, frameContainerHash);
        }
    }
}
