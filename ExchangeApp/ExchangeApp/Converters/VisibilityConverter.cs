using System;
using System.Globalization;
using Xamarin.Forms;

namespace ExchangeApp.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return IsVisible(value);
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        internal static bool IsVisible(object value)
        {
            return ObjectVisibility.IsObjectVisible(value);
        }
    }
}