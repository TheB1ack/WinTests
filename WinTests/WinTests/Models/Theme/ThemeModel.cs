using System.Collections.Generic;
using WinTests.Models.Subtheme;

namespace WinTests.Models.Theme
{
    public class ThemeModel
    {
        public string Title { get; set; }

        public IEnumerable<SubThemeModel> SubThemes { get; set; }
    }
}
