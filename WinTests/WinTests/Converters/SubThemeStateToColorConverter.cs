using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WinTests.Enums;

namespace WinTests.Converters
{
    public class SubThemeStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (ETestStateState)value switch
            {
                ETestStateState.None => Brushes.White,
                ETestStateState.Passed => new SolidColorBrush(Color.FromRgb(222, 255, 219)),
                ETestStateState.Failed => new SolidColorBrush(Color.FromRgb(255, 219, 219)),
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
