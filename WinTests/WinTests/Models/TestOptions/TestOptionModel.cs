using WinTests.Enums;

namespace WinTests.Models.TestOptions
{
    public class TestOptionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCorrect { get; set; }

        public ETestType OptionType { get; set; }
    }
}
