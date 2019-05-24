using System;
using System.Globalization;
using System.Windows.Data;

namespace ES.AscomAlpaca.Client.Demo.Desktop.Converters
{
    public class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var dec = System.Convert.ToDouble(value);
                return CoordinatesConverter.DecimalToDMS(dec);
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var dec = System.Convert.ToString(value);
                return CoordinatesConverter.DMSToDecimal(dec);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}