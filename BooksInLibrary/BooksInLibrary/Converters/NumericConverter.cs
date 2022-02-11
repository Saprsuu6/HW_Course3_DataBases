using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BooksInLibrary.Converters
{
    internal class NumericConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Trim() == "")
                return 0;
            try
            {
                value = int.Parse((string)value);
            }
            catch (Exception)
            {
                return 0;
            }

            return value;
        }
    }
}
