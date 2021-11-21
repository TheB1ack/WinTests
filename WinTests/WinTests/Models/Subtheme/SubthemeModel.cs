using System.Collections.Generic;
using WinTests.Enums;
using WinTests.Models.Test;

namespace WinTests.Models.Subtheme
{
    public class SubThemeModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string TestTitle { get; set; }

        public IEnumerable<TestModel> Tests { get; set; }

        public ETestStateState SubThemeState { get; set; }

        public int CorrectAnswersCount { get; set; }
    }
}
