using System.Collections.ObjectModel;
using WinTests.Enums;
using WinTests.Models.TestOptions;
using WinTests.ViewModels;

namespace WinTests.Models.Tests
{
    public class TestViewModel : BaseViewModel
    {
        private ObservableCollection<TestOptionViewModel> options;
        public ObservableCollection<TestOptionViewModel> Options
        {
            get => options;
            set => SetProperty(ref options, value);
        }

        private string question;
        public string Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        private ETestStateState testState;
        public ETestStateState TestState
        {
            get => testState;
            set => SetProperty(ref testState, value);
        }
    }
}
