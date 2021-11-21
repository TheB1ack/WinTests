using System.Linq;
using System.Windows.Input;
using WinTests.Controls;
using WinTests.Enums;
using WinTests.Models.Subtheme;
using WinTests.Models.TestOptions;
using WinTests.Services.PageNavigation;

namespace WinTests.ViewModels
{
    public class TestsPageViewModel : BaseViewModel
    {
        private readonly IPageNavigationService navigationService;

        private TestOptionViewModel lastOption;
        private int frameContainerHash;

        public TestsPageViewModel(int frameContainerHash) : base()
        {
            this.navigationService = App.Resolve<IPageNavigationService>();
            this.frameContainerHash = frameContainerHash;

            IsTestsActive = true;
        }

        private SubThemeViewModel selectedSubTheme;
        public SubThemeViewModel SelectedSubTheme
        {
            get => selectedSubTheme;
            set => SetProperty(ref selectedSubTheme, value);
        }

        private bool isTestsActive;
        public bool IsTestsActive
        {
            get => isTestsActive;
            set => SetProperty(ref isTestsActive, value);
        }

        private ICommand finishTestCommand;
        public ICommand FinishTestCommand => finishTestCommand ??= new CustomCommand(OnFinishTestCommand);

        private ICommand goBackTappedCommand;
        public ICommand GoBackTappedCommand => goBackTappedCommand ??= new CustomCommand(OnGoBackTappedCommand);

        private ICommand goToThemeTappedCommand;
        public ICommand GoToThemeTappedCommand => goToThemeTappedCommand ??= new CustomCommand(OnGoToThemeTappedCommand);

        private ICommand radioButtonTappedCommand;
        public ICommand RadioButtonTappedCommand => radioButtonTappedCommand ??= new CustomCommand(OnRadioButtonTappedCommand);

        public override void Dispose()
        {
            if (SelectedSubTheme != null)
            {
                ClearAnswers();
            }

            base.Dispose();
        }

        private void OnGoBackTappedCommand(object item)
        {
            ClearAnswers();

            navigationService.GoBack(frameContainerHash);
        }

        private void OnGoToThemeTappedCommand(object item)
        {
            ClearAnswers();

            navigationService.GoBackToRoot(frameContainerHash);
        }

        private void OnRadioButtonTappedCommand(object item)
        {
            var option = item as TestOptionViewModel;

            if (option != null && option.OptionType == ETestType.Single)
            {
                if (lastOption != null)
                {
                    lastOption.IsSelected = false;
                }

                option.IsSelected = true;
                
                lastOption = option;
            }
        }

        private void OnFinishTestCommand(object parameter)
        {
            var correctAnswersCount = 0;

            IsTestsActive = false;

            foreach (var item in SelectedSubTheme.Tests)
            {
                var isPassed = item.Options.Count(x => x.IsCorrect != x.IsSelected) == 0;

                if (isPassed)
                {
                    item.TestState = ETestStateState.Passed;
                    correctAnswersCount++;
                }
                else
                {
                    item.TestState = ETestStateState.Failed;
                }
            }

            if (correctAnswersCount >= SelectedSubTheme.CorrectAnswersCount)
            {
                SelectedSubTheme.SubThemeState = correctAnswersCount >= SelectedSubTheme.TestsCount * 0.75 ? ETestStateState.Passed : ETestStateState.Failed;
                SelectedSubTheme.CorrectAnswersCount = correctAnswersCount;
            }
        }

        private void ClearAnswers()
        {
            foreach (var test in SelectedSubTheme.Tests)
            {
                test.TestState = ETestStateState.None;

                foreach (var option in test.Options)
                {
                    option.IsSelected = false;
                }
            }
        }
    }
}
