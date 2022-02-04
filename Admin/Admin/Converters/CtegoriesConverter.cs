using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Admin.Categories;
using Admin.Models;

namespace Admin.Converters
{
    internal class CtegoriesConverter : IValueConverter
    {
        private WorkWithBaseCategories workWithBase;

        public CtegoriesConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            workWithBase = new WorkWithBaseCategories();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category category = workWithBase.GetById((int)value);
            return "Category: " + category.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
