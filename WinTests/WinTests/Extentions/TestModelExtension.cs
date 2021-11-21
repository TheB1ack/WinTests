using WinTests.Models.Test;
using WinTests.Models.Tests;

namespace WinTests.Extentions
{
    public static class TestModelExtension
    {
        public static TestViewModel ToViewModel(this TestModel model)
        {
            TestViewModel viewModel = null;

            if (model != null)
            {
                viewModel = new TestViewModel
                {
                    TestState = model.TestState,
                    Question = model.Question,
                };
            }

            return viewModel;
        }
    }
}
