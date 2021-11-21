using WinTests.Models.Theme;

namespace WinTests.Extentions
{
    public static class ThemeModelExtension
    {
        public static ThemeViewModel ToViewModel(this ThemeModel model)
        {
            ThemeViewModel viewModel = null;

            if (model != null)
            {
                viewModel = new ThemeViewModel
                {
                    Title = model.Title,
                };
            }

            return viewModel;
        }
    }
}
