using BooksInLibrary.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace BooksInLibrary.Converters
{
    internal class BookIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Id: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Name: " + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookPagesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Pages: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookYearPressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Year press: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookThemeConverter : IValueConverter
    {
        private LibraryDataContext dataBase;

        public BookThemeConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            dataBase = new LibraryDataContext();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theme = from concreteTheme in dataBase.Themes
                        where concreteTheme.Id == (int)value
                        select concreteTheme;

            return "Theme: " + theme.ToArray()[0].Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookCategoryConverter : IValueConverter
    {
        private LibraryDataContext dataBase;

        public BookCategoryConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            dataBase = new LibraryDataContext();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var category = from concreteCategory in dataBase.Categories
                           where concreteCategory.Id == (int)value
                           select concreteCategory;

            return "Category: " + category.ToArray()[0].Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookAuthorConverter : IValueConverter
    {
        private LibraryDataContext dataBase;

        public BookAuthorConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            dataBase = new LibraryDataContext();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var author = from concreteAuthor in dataBase.Authors
                         where concreteAuthor.Id == (int)value
                         select concreteAuthor;

            return "Author: " + author.ToArray()[0].Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookPressConverter : IValueConverter
    {
        private LibraryDataContext dataBase;

        public BookPressConverter()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            dataBase = new LibraryDataContext();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var press = from concretePress in dataBase.Presses
                        where concretePress.Id == (int)value
                        select concretePress;

            return "Press: " + press.ToArray()[0].Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookCommentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Comment: " + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class BookQuantityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Quantity: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
