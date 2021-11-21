using WinTests.Models.Subtheme;

namespace WinTests.Extentions
{
    public static class SubthemeModelExtension
    {
        public static SubThemeViewModel ToViewModel(this SubThemeModel model)
        {
            SubThemeViewModel viewModel = null;

            if (model != null)
            {
                viewModel = new SubThemeViewModel
                {
                    SubThemeState = model.SubThemeState,
                    Content = model.Content,
                    TestTitle = model.TestTitle,
                    Title = model.Title,
                    CorrectAnswersCount = model.CorrectAnswersCount,
                };
            }

            return viewModel;
        }
    }
}
