using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Subtheme;
using WinTests.Models.Theme;
using WinTests.Services.PageNavigation;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class ThemePageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;

        private int frameContainerHash;

        public ThemePageViewModel(int frameContainerHash) : base()
        {
            this.navigationService = App.Resolve<IPageNavigationService>();
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
            var subTheme = item as SubThemeViewModel;

            if (subTheme is not null)
            {
                subTheme.ThemeTitle = SelectedTheme.Title;

                var page = new SubThemePageView
                {
                    ViewModel = new SubThemePageViewModel(frameContainerHash)
                    {
                        SelectedSubTheme = subTheme,
                    },
                };

                navigationService.NavigateTo(page, frameContainerHash);
            }
        }

        private void OnTestTappedCommand(object item)
        {
            var subTheme = item as SubThemeViewModel;

            if (subTheme is not null)
            {
                subTheme.ThemeTitle = SelectedTheme.Title;

                var page = new TestsPageView
                {
                    ViewModel = new TestsPageViewModel(frameContainerHash)
                    {
                        SelectedSubTheme = subTheme,
                    },
                };

                navigationService.NavigateTo(page, frameContainerHash);
            }
        }
    }
}
