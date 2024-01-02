using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptoInfo.Converters
{
    public class _24HConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                string temp = stringValue.Replace(".", ",");
                if (double.TryParse(temp, out double doubleValue))
                {
                    double roundedValue = Math.Round(doubleValue, 2);
                    return roundedValue;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
