using System.Windows.Controls;
using WinTests.Services.PageNavigation;
using WinTests.Views;

namespace WinTests.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;

        private MainPageView mainPageView;

        public MainWindowViewModel(IPageNavigationService navigationService) : base()
        {
            this.navigationService = navigationService;
        }

        private Frame frameContainer;
        public Frame FrameContainer 
        { 
            get => frameContainer; 
            set
            {
                frameContainer = value;

                NavigateToMainPage();
            } 
        }

        private void NavigateToMainPage()
        {
            mainPageView = App.Resolve<MainPageView>();

            frameContainer.Content = mainPageView;
            mainPageView.ViewModel.MainFrameHash = FrameContainer.GetHashCode();

            navigationService.NavigateTo(mainPageView, FrameContainer);
        }

    }
}
