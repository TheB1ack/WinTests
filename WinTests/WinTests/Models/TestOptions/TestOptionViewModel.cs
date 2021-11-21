using WinTests.Enums;
using WinTests.ViewModels;

namespace WinTests.Models.TestOptions
{
    public class TestOptionViewModel : BaseViewModel
    {
        private int id;
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }

        private bool isCorrect;
        public bool IsCorrect
        {
            get => isCorrect;
            set => SetProperty(ref isCorrect, value);
        }

        private ETestType optionType;
        public ETestType OptionType
        {
            get => optionType;
            set => SetProperty(ref optionType, value);
        }
    }
}
