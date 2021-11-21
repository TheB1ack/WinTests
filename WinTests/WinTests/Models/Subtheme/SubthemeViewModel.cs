using System.Collections.ObjectModel;
using WinTests.Enums;
using WinTests.Models.Tests;
using WinTests.ViewModels;

namespace WinTests.Models.Subtheme
{
    public class SubThemeViewModel : BaseViewModel
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        
        private string content;
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

        private string testTitle;
        public string TestTitle
        {
            get => testTitle;
            set => SetProperty(ref testTitle, value);
        }

        private string themeTitle;
        public string ThemeTitle
        {
            get => themeTitle;
            set => SetProperty(ref themeTitle, value);
        }

        private ObservableCollection<TestViewModel> tests;
        public ObservableCollection<TestViewModel> Tests
        {
            get => tests;
            set => SetProperty(ref tests, value);
        }

        public int TestsCount => Tests?.Count ?? 0;

        private ETestStateState subThemeState;
        public ETestStateState SubThemeState
        {
            get => subThemeState;
            set => SetProperty(ref subThemeState, value);
        }

        private int correctAnswersCount;
        public int CorrectAnswersCount
        {
            get => correctAnswersCount;
            set => SetProperty(ref correctAnswersCount, value);
        }
    }
}
