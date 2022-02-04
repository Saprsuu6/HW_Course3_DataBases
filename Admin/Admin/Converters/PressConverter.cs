using Admin.Models;
using Admin.Press;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Admin.Converters
{
    internal class PressConverter : IValueConverter
    {
        private WorkWithBasePress workWithBase;

        public PressConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            workWithBase = new WorkWithBasePress();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Pres press = workWithBase.GetById((int)value);
            return "Press: " + press.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
