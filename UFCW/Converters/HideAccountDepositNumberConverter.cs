using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UFCW.Converters
{
    class HideAccountDepositNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value != null)
            {      
                   string str = (string)value;
                if (str.Length > 4)
                {
                    string str2 = str.Trim(); //removing extra spaces
                    string newString = new String('X', str2.Length - 4) + str2.Substring(str2.Length - 4); // creating new String which replace all digit with 'X' except last 4
                    return newString;
                }
                else
                    return str;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
