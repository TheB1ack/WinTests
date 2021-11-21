using System.Windows.Controls;

namespace WinTests.Services.PageNavigation
{
    public interface IPageNavigationService
    {
        void NavigateTo(Page page, Frame frame, object parameter = null);

        void NavigateTo(Page page, int id, object parameter = null);

        void GoBack(int id);

        void GoBack();

        void Clear(int id);

        public void GoBackToRoot(int id);

        public void GoBackToRoot();
    }
}
