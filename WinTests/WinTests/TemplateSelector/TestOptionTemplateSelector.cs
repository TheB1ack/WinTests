using System.Windows;
using System.Windows.Controls;
using WinTests.Enums;
using WinTests.Models.TestOptions;

namespace WinTests.TemplateSelector
{
    public class TestOptionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MultipleChoice { get; set; }

        public DataTemplate SingleChoice { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var test = item as TestOptionViewModel;

            return test.OptionType switch
            {
                ETestType.Single => SingleChoice,
                ETestType.Several => MultipleChoice,
                _ => SingleChoice,
            };
        }
    }
}
