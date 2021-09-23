using System;
using System.Windows.Data;
using System.Windows.Media;
using lm_km.core;

namespace lm_km.ui
{
    internal class KeynoteStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)

        {
            KeynoteStateTypes state = (KeynoteStateTypes)value;
            switch (state)
            {
                case KeynoteStateTypes.None:
                    return null;

                case KeynoteStateTypes.Edit:
                    return new SolidColorBrush(Colors.DeepSkyBlue);

                case KeynoteStateTypes.Add:
                    return new SolidColorBrush(Colors.LawnGreen);

                case KeynoteStateTypes.Delete:
                    return new SolidColorBrush(Colors.IndianRed);

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)

        {
            return null;
        }
    }
}