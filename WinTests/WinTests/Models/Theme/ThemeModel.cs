using System.Collections.Generic;
using WinTests.Models.Subtheme;

namespace WinTests.Models.Theme
{
    public class ThemeModel
    {
        public string Title { get; set; }

        public IEnumerable<SubthemeModel> SubThemes { get; set; }
    }
}
