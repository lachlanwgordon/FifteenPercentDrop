using System;
using System.Globalization;
using FifteenPercentDrop.Converters;
using Xamarin.Forms;


namespace FifteenPercentDrop.Converters
{
    [ValueConversion(typeof(string), typeof(double))]
    public class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string == false)
            {
                return default(double);
            }

            var input = (string)value;
            var param = (object)parameter;

            // TODO: Put your value conversion logic here.

            return default(double);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}