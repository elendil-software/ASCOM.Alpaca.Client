using System;
using System.Globalization;
using System.Windows.Data;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Converters
{
    public class RightAscensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            try
            {
                return CoordinatesConverter.DecimalToHMS(System.Convert.ToDouble(value));
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
                return CoordinatesConverter.HMSToDecimal(value as string);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}