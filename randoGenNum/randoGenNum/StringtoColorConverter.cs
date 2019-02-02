using System;
using System.Globalization;
using Xamarin.Forms;

namespace randoGenNum
{
    public class StringToColorConverter : IValueConverter
    {
        /* Input: Name: value     , Type: object
         *        Name: targetType, Type: Type
         *        Name: parameter , Type: object
         *        Name: culture   , Type: CultureInfo
        * Output: Color.(valid value of Color)
        *         
        * Function: Primairly focusing on the variable value, the function first decides the inputted
        * value is not null. If it is not null, it goes into switch to determine which color is to be sent
        * back. If it is null, it sends the color Transparent back.
        */
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

        /* Input: Name: value     , Type: object
         *        Name: targetType, Type: Type
         *        Name: parameter , Type: object
         *        Name: culture   , Type: CultureInfo
        * Output: Color.(valid value of Color)
        *         
        * Function: Simply returns the color transparent if this is called.
        */
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Transparent;
        }
    }


}
