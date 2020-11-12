using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BaseTemplate.Converters
{
    public class ActiveChronicConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            if (num == 1)
                return (Color)ColorConverters.FromHex("#F7C234");
            else if (num == 2)
                return (Color)ColorConverters.FromHex("#04AD6C");
            else
                return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
