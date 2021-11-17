using System.Windows.Controls;
using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Subtheme;
using WinTests.Models.Theme;
using WinTests.Services;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class ThemePageViewModel : BaseViewModel
    {
        private int frameContainerHash;
        private readonly IPageNavigationService navigationService;
        public ThemePageViewModel(IPageNavigationService navigationService, int frameContainerHash) : base()
        {
            this.navigationService = navigationService;
            this.frameContainerHash = frameContainerHash;
        }

        private ThemeViewModel selectedTheme;
        public ThemeViewModel SelectedTheme
        {
            get => selectedTheme;
            set => SetProperty(ref selectedTheme, value);
        }

        private ICommand subThemeTappedCommand;
        public ICommand SubThemeTappedCommand => subThemeTappedCommand ??= new CustomCommand(OnSubThemeTappedCommand);

        private ICommand testTappedCommand;
        public ICommand TestTappedCommand => testTappedCommand ??= new CustomCommand(OnTestTappedCommand);

        private void OnSubThemeTappedCommand(object item)
        {
            var subTheme = item as SubthemeViewModel;

            if (subTheme is not null)
            {
                var page = new SubThemePageView
                {
                    ViewModel = new SubThemePageViewModel(navigationService, frameContainerHash)
                    {
                        SelectedSubTheme = subTheme,
                    },
                };

                navigationService.NavigateTo(page, frameContainerHash);
            }
        }

        private void OnTestTappedCommand(object item)
        {
            var subTheme = item as SubthemeViewModel;
        }
    }
}
