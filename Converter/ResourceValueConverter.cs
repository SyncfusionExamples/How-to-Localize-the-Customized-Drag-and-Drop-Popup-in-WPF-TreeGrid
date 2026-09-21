using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SfTreeGrid_CustomDrag
{
    public class ResourceValueConverter : IValueConverter
    {
        public object Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            if (value is null)
            {
                return string.Empty;
            }

            string resourceKey = value.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(resourceKey))
            {
                return string.Empty;
            }

            string? localizedValue = Resource1.ResourceManager.GetString(
                    resourceKey,
                    culture);
            
            return localizedValue ?? resourceKey;
        }

        public object ConvertBack(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
