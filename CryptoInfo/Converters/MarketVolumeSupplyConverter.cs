using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoInfo.Converters
{
    public class MarketCapMarketVolumeSupplyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                string temp = stringValue.Replace(".", ",");
                if (double.TryParse(temp, out double doubleValue))
                {
                    double roundedValue = Math.Round(doubleValue, 5);

                    if (roundedValue >= 1000000 && roundedValue < 1000000000)
                    {
                        return "$ " + Math.Round((roundedValue / 1000000), 5) + " M";
                    }
                    else if (roundedValue >= 1000000000)
                    {
                        return "$ " + Math.Round((roundedValue / 1000000000), 5) + " B";
                    }
                    else
                    {
                        return roundedValue;
                    }
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
