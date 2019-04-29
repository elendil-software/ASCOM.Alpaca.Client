using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Converters
{
	internal static class CoordinatesConverter
    {
        private static Match ParseDMSValue(string dmsCoordinate)
        {
            dmsCoordinate = dmsCoordinate.Trim();

            var exp = new Regex("^([-+]?)([0-9]{1,3})([\\D]?)([0-9]{1,2})([\\D]?)([0-9.]{1,5})([\\D]?)$");
            var match = exp.Match(dmsCoordinate);

            if (match.Success)
            {
                return match;
            }
            else
            {
                throw new FormatException("Unable to parse " + dmsCoordinate);
            }
        }
        
		public static double DMSToDecimal(string dmsCoordinate)
        {
            var match = ParseDMSValue(dmsCoordinate);

            var dec = double.Parse(match.Groups[2].ToString());
            dec += double.Parse(match.Groups[4].ToString()) / 60.0f;
            dec += double.Parse(match.Groups[6].ToString(), CultureInfo.InvariantCulture) / 3600.0f;

            if (match.Groups[1].ToString() == "-")
            {
                dec *= -1;
            }

            return dec;
        }
        
        public static string DecimalToDMS(double decimalCoordinate)
        {
            var d = decimalCoordinate >= 0 ? Math.Floor(decimalCoordinate) : Math.Ceiling(decimalCoordinate);
            var tmp = (decimalCoordinate - d) * 60;
            var m = tmp >= 0 ? Math.Floor(tmp) : Math.Ceiling(tmp);
            var s = Math.Round((tmp - m) * 60, 2);

            return $"{d}° {Math.Abs(m)}' {Math.Abs(s).ToString(CultureInfo.InvariantCulture)}\"";
        }
        
        public static double HMSToDecimal(string hmsCoordinate)
        {
            hmsCoordinate = hmsCoordinate.Trim();

            var match = ParseHMSValue(hmsCoordinate);

            var ra = double.Parse(match.Groups[1].ToString());
            ra += double.Parse(match.Groups[3].ToString())/60.0d;
            ra += double.Parse(match.Groups[5].ToString(), CultureInfo.InvariantCulture)/3600.0d;

            return ra;
        }
        
        public static string DecimalToHMS(double decimalCoordinate)
        {
            var h = Math.Floor(decimalCoordinate);
            var tmpM = (decimalCoordinate - h)*60;
            var m = Math.Floor(tmpM);
            var s = Math.Round((tmpM - m)*60, 2);

            return $"{h}:{m}:{s.ToString(CultureInfo.InvariantCulture)}";
        }
        
        public static Match ParseHMSValue(string hmsCoordinate)
        {
            var exp = new Regex("^([0-9]{1,2})(.)([0-9]{1,2})(.)([0-9.]{1,5})(.?)$");
            var match = exp.Match(hmsCoordinate);

            if (match.Success)
            {
                return match;
            }
            else
            {
                throw new FormatException("Unable to parse " + hmsCoordinate);
            }
        }
    }
}