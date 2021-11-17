using System.Collections.Generic;
using System.Collections.ObjectModel;
using WinTests.Enums;
using WinTests.ViewModels;

namespace WinTests.Models.Tests
{
    public class TestViewModel : BaseViewModel
    {
        private ETestType testype;
        public ETestType TestType 
        { 
            get => testype;
            set => SetProperty(ref testype, value);
        }

        private List<string> options;
        public List<string> Options
        {
            get => options;
            set => SetProperty(ref options, value);
        }

        private List<int> correctAnswers;
        public List<int> CorrectAnswers
        {
            get => correctAnswers;
            set => SetProperty(ref correctAnswers, value);
        }

        private string question;
        public string Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        private List<int> userAnswers;
        public List<int> UserAnswers
        {
            get => userAnswers;
            set => SetProperty(ref userAnswers, value);
        }
    }
}
