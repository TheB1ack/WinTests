using System.Collections.Generic;
using WinTests.Enums;

namespace WinTests.Models.Test
{
    public class TestModel
    {
        public ETestType TestType { get; set; }

        public IEnumerable<string> Options { get; set; }

        public IEnumerable<int> Answers { get; set; }

        public string Question { get; set; }
    }
}
