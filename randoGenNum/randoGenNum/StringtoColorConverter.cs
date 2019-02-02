using System;
using System.Globalization;
using Xamarin.Forms;

namespace randoGenNum
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valueAsString = value.ToString();
                switch (valueAsString)
                {
                    case (""):
                    {
                        return Color.Default;
                    }
                    case ("Red"):
                    {
                        return Color.Red;
                    }
                    case ("Transparent"):
                    {
                        return Color.Transparent;
                    }
                    default:
                    {
                        return Color.FromHex(value.ToString());
                    }
                }
            }

            return Color.Transparent;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Transparent;
        }
    }


}
