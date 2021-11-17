using System.Collections.Generic;
using WinTests.Enums;
using WinTests.Models.Test;

namespace WinTests.Models.Subtheme
{
    public class SubthemeModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string TestTitle { get; set; }

        public IEnumerable<TestModel> Tests { get; set; }

        public ESubThemeState SubThemeState { get; set; }

        public int CorrectAnswersCount { get; set; }
    }
}
