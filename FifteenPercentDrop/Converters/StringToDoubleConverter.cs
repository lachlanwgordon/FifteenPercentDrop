using System;
using System.Globalization;
using FifteenPercentDrop.Converters;
using Xamarin.Forms;


namespace FifteenPercentDrop.Converters
{
    [ValueConversion(typeof(string), typeof(double))]
    public class StringToNullableDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double == false)
            {
                return default(string);
            }

            var input = (double?)value;

            //var parsed = Double.TryParse(input, out double result);

            return input.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string == false)
            {
                return default(double?);
            }

            var input = (string)value;

            var parsed = Double.TryParse(input, out double result);

            if (parsed)
                return result;
            return null;

        }
    }
}