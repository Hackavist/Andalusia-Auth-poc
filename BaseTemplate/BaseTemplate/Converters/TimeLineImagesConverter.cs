using System;
using System.Globalization;
using Xamarin.Forms;

namespace PHR_MVVM.Converters.TimeLineItemConverters
{
    class TimeLineImagesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string CategoryImgSource = value as string;
            return CategoryImgSource == "diagnoseicd.png" ? "diagnose.png" : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
