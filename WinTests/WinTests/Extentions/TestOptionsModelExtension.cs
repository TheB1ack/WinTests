using WinTests.Models.TestOptions;

namespace WinTests.Extentions
{
    public static class TestOptionsModelExtension
    {
        public static TestOptionViewModel ToViewModel(this TestOptionModel model)
        {
            TestOptionViewModel viewModel = null;

            if (model != null)
            {
                viewModel = new TestOptionViewModel
                {
                    Id = model.Id,
                    IsCorrect = model.IsCorrect,
                    OptionType = model.OptionType,
                    Title = model.Title,
                };
            }

            return viewModel;
        }
    }
}
