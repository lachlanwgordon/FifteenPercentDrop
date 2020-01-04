using System;
using System.Globalization;
using FifteenPercentDrop.Converters;
using Xamarin.Forms;


namespace FifteenPercentDrop.Converters
{
    [ValueConversion(typeof(int), typeof(int))]
    public class InversePercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int == false)
            {
                return default(double);
            }

            var input = (int)value;

            // TODO: Put your value conversion logic here.

            return 100 - input;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}