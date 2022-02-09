using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Client
{
    internal class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Name: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Price: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class SailerConverter : IValueConverter
    {
        private BaseOfSailers sailers;

        public SailerConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            sailers = new BaseOfSailers();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Sailer sailer = sailers.GetSailerById((int)value);
            return "Sailer: " + sailer.Name + " " + sailer.Surename;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
