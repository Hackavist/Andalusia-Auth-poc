using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PHR_MVVM.Converters.TimeLineItemConverters
{
    class CardTitleColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var colorTitle = value as string;

            switch (colorTitle)
            {
                case "Diagnose":
                case "DiagnoseICD":
                    return (Color)ColorConverters.FromHex("#045dad");

                case "Lab":
                    return (Color)ColorConverters.FromHex("#c1b967");

                case "Rad":
                    return (Color)ColorConverters.FromHex("#696969");

                case "Medication":
                    return (Color)ColorConverters.FromHex("#fa0000");

                case "Operation":
                    return (Color)ColorConverters.FromHex("#04ad6c");

                case "Procedure":
                    return (Color)ColorConverters.FromHex("#d198fc");

                default:
                    break;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
