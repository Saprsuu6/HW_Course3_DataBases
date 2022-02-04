using Admin.Models;
using Admin.Themes;
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
    internal class ThemeConverter : IValueConverter
    {
        private WorkWithBaseThemes workWithBase;

        public ThemeConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            workWithBase = new WorkWithBaseThemes();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Theme theme = workWithBase.GetById((int)value);
            return "Theme: " + theme.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
