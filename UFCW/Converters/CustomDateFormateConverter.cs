using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UFCW.Converters
{
    class CustomDateFormateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null)
            {
                string date = (string)value;
                
                return DateTimeCustmization(date);
            }
           
                return null;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public string DateTimeCustmization(string date) {

            char[] delimiterChars = { ' ', ':', '-', 'T' }; // delimiter bases on DateTime splits
            string[] DateTimeSplits = date.Split(delimiterChars);
           #region  convert the split parts of given DateTime to int as DateTime accept only int value
            int year = Int32.Parse(DateTimeSplits[0]);
            int month = Int32.Parse(DateTimeSplits[1]);
            int day = Int32.Parse(DateTimeSplits[2]);
            int hour = Int32.Parse(DateTimeSplits[3]);
            int minut = Int32.Parse(DateTimeSplits[4]);
           #endregion
            string format = "dddd , MMMM dd yyyy";          // formate according to date convert
            DateTime _DateTime = new DateTime(year, month, day, hour, minut, 00);
            string dateInDesireDateFormate = _DateTime.ToString(format);
            return dateInDesireDateFormate;

        }
    }
}
