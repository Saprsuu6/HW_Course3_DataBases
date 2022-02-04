using Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Admin.Converters
{
    internal class AuthorConverter : IValueConverter
    {
        private WorkWithBaseAuthors workWithBase;

        public AuthorConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            workWithBase = new WorkWithBaseAuthors();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Author author = workWithBase.GetById((int)value);
            return "Author: " + author.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
