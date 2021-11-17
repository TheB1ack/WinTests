using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WinTests.Controls;
using WinTests.Models.Subtheme;
using WinTests.Models.Theme;
using WinTests.Services;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageNavigationService navigationService;
        public MainWindowViewModel(IPageNavigationService navigationService) : base()
        {
            this.navigationService = navigationService;

            var subtheme = new SubthemeViewModel
            {
                Title = "Subtheme title",
                TestTitle = "Testtitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nisl nisi scelerisque eu ultrices. Integer feugiat scelerisque varius morbi enim nunc. Enim nulla aliquet porttitor lacus. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Enim diam vulputate ut pharetra sit amet aliquam. Aliquet lectus proin nibh nisl condimentum id venenatis. Non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. At erat pellentesque adipiscing commodo. Pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Mi eget mauris pharetra et. Aliquet porttitor lacus luctus accumsan tortor posuere ac. Interdum velit euismod in pellentesque massa placerat duis ultricies. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Lobortis mattis aliquam faucibus purus in massa tempor nec feugiat. Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum. Non nisi est sit amet facilisis magna etiam tempor. Elementum sagittis vitae et leo duis. Nulla facilisi etiam dignissim diam.",
            };

            var list = new List<SubthemeViewModel>();
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);
            list.Add(subtheme);

            var collection = new ObservableCollection<ThemeViewModel>();

            collection.Add(new ThemeViewModel
            {
                Title = "Theme 1",
                SubThemes = new ObservableCollection<SubthemeViewModel>(list),
            });

            collection.Add(new ThemeViewModel
            {
                Title = "Theme 2",
                SubThemes = new ObservableCollection<SubthemeViewModel>(list),
            });

            collection.Add(new ThemeViewModel
            {
                Title = "Theme 3",
                SubThemes = new ObservableCollection<SubthemeViewModel>(list),
            });

            ThemesCollection = collection;
        }

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
            set =>SetProperty(ref themesCollection, value);
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

                value.IsSelected = true;

                SetProperty(ref selectedItem, value);

                ItemSelected();
            }
        }

        private ICommand allResultsCommand;
        public ICommand AllResultsCommand => allResultsCommand ??= new CustomCommand(OnAllResultsCommand);

        public void OnLoaded()
        {
            if (ThemesCollection?.Any() ?? false)
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
                        ViewModel = new ThemePageViewModel(navigationService, FrameContainer.GetHashCode())
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
            //navigate to all results page
        }
    }
}
