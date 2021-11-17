using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WinTests.Enums;

namespace WinTests.Converters
{
    public class SubThemeStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (ESubThemeState)value switch
            {
                ESubThemeState.None => Brushes.White,
                ESubThemeState.Passed => new SolidColorBrush(Color.FromRgb(222, 255, 219)),
                ESubThemeState.Failed => new SolidColorBrush(Color.FromRgb(255, 219, 219)),
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
