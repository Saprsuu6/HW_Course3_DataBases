using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksInLibrary.Themes
{
    internal class DBThemes
    {
        private LibraryDataContext dataBase;

        public DBThemes()
        {
            dataBase = new LibraryDataContext();
        }

        public List<Theme> GetAllThemes()
        {
            List<Theme> themes = (from theme in dataBase.Themes
                                  select theme).ToList();

            if (themes.Count == 0)
                throw new ApplicationException("No themes");

            return themes;
        }

        public void AddTheme(Theme theme)
        {
            if (theme.Name == null || theme.Name.Trim() == "")
                throw new ApplicationException("Fill categorie's info.");

            try
            {
                dataBase.Themes.InsertOnSubmit(theme);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Theme was not succesfully addaed. Try again");
            }
        }

        private void RemoveBooksWithThemeId(int id)
        {
            var books = (from book in dataBase.Books
                         where book.IdTheme == id
                         select book).ToList();

            try
            {
                foreach (Book book in books)
                    dataBase.Books.DeleteOnSubmit(book);

                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book with this theme was not succesfully removed. Try again");
            }
        }

        public void RemoveTheme(Theme theme)
        {
            if (theme.Name == null || theme.Name.Trim() == "")
                throw new ApplicationException("Please select category.");

            RemoveBooksWithThemeId(theme.Id);

            try
            {
                dataBase.Themes.DeleteOnSubmit(theme);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Theme was not succesfully removed. Try again");
            }
        }

        public void UpdateTheme(Theme theme)
        {
            if (theme.Name == null || theme.Name.Trim() == "")
                throw new ApplicationException("Please select category.");

            Theme concreteTheme =
                dataBase.Themes.FirstOrDefault(temp => temp.Id == theme.Id);

            concreteTheme = theme;

            try
            {
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Theme was not succesfully updated. Try again");
            }
        }

        public List<Theme> FindThemes(Theme theme)
        {
            if (theme.Name == null || theme.Name.Trim() == "")
                throw new ApplicationException("Fill categorie's info.");

            List<Theme> themes = (from concreteTheme in dataBase.Themes
                                  where concreteTheme.Name.Contains(theme.Name)
                                  select concreteTheme).ToList();

            if (themes.Count == 0)
                throw new ApplicationException("No themes");

            return themes;
        }
    }
}
