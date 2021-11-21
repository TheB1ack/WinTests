using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Theme;
using WinTests.Services.PageNavigation;
using WinTests.Services.ThemeRepository;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;
        private readonly IThemeRepositoryService themeRepositoryService;

        public MainPageViewModel(
            IPageNavigationService navigationService,
            IThemeRepositoryService themeRepositoryService)
            : base()
        {
            this.navigationService = navigationService;
            this.themeRepositoryService = themeRepositoryService;

            GetThemesCollectionAsync();
        }

        public int MainFrameHash {get; set;}

        public Frame FrameContainer { get; set; }

        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set => SetProperty(ref currentPage, value);
        }

        private ObservableCollection<ThemeViewModel> themesCollection = new();
        public ObservableCollection<ThemeViewModel> ThemesCollection
        {
            get => themesCollection;
            set => SetProperty(ref themesCollection, value);
        }

        private ThemeViewModel selectedItem;
        public ThemeViewModel SelectedItem
        {
            get => selectedItem;
            set
        {
                if (selectedItem is not null)
                {
                    selectedItem.IsSelected = false;
                }

                if (value != null)
                {
                    value.IsSelected = true;

                    SetProperty(ref selectedItem, value);

                    ItemSelected();
                }
            }
        }

        private ICommand allResultsCommand;
        public ICommand AllResultsCommand => allResultsCommand ??= new CustomCommand(OnAllResultsCommand);

        public void OnLoaded()
        {
            if (ThemesCollection?.Any() ?? false && SelectedItem == null)
            {
                SelectedItem = ThemesCollection[0];
            }
        }

        private void ItemSelected()
        {
            if (SelectedItem is not null)
            {
                if (SelectedItem.Page == null)
                {
                    SelectedItem.Page = new ThemePageView
                    {
                        ViewModel = new ThemePageViewModel(FrameContainer.GetHashCode())
                        {
                            SelectedTheme = SelectedItem,
                        },
                    };
                }

                navigationService.Clear(FrameContainer.GetHashCode());
                navigationService.NavigateTo(SelectedItem.Page, FrameContainer);
            }
        }

        private void OnAllResultsCommand(object parametr)
        {
            var page = App.Resolve<AllResultsPageView>();

            page.ViewModel.ThemesCollection = ThemesCollection;

            navigationService.NavigateTo(page, MainFrameHash);
        }

        private async Task GetThemesCollectionAsync()
        {
            var collection = await themeRepositoryService.GetThemesCollectionAsync();

            if (collection != null)
            {
                ThemesCollection = new ObservableCollection<ThemeViewModel>(collection);
            }
        }
    }
}
