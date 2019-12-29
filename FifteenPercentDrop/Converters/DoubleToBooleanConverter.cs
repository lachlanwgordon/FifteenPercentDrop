using System;
using System.Globalization;
using Xamarin.Forms;


namespace FifteenPercentDrop.Converters
{
    [ValueConversion(typeof(double), typeof(bool))]
    public class DoubleToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double == false)
            {
                return default(bool);
            }

            var input = (double)value;

            return input > 38;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool == false)
            {
                return default(bool);
            }

            var input = (bool)value;

            return input ? 40 : 35;
        }
    }
}