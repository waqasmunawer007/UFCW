using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UFCW.Converters
{
   public class ShowHideVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Link> list = new List<Link>();
            list = value as List<Link>;
            if (list.Count>0) //if there is any single Link entry available then show the visibility of Visit button 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
