using System.Globalization;
using System.Windows.Data;

namespace CryptoInfo.ViewModels
{
    public class RoundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                string temp = stringValue.Replace(".", ",");
                if (double.TryParse(temp, out double doubleValue))
                {
                    double roundedValue = Math.Round(doubleValue, 3);
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
