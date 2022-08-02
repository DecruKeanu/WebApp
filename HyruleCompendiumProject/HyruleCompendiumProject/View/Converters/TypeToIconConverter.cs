using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;
namespace HyruleCompendiumProject.View.Converters
{
    public sealed class TypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = value as string;
            string typeLowerCase = type.ToLower();
            return new BitmapImage(new Uri($@"/Resources/Images/Icons/{type}.png", UriKind.RelativeOrAbsolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
