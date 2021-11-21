using System.Collections.Generic;
using WinTests.Enums;
using WinTests.Models.TestOptions;

namespace WinTests.Models.Test
{
    public class TestModel
    {
        public ETestStateState TestState { get; set; }

        public IEnumerable<TestOptionModel> Options { get; set; }

        public string Question { get; set; }
    }
}
