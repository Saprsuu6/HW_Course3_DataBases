using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksInLibrary.Books
{
    internal class DBBooks
    {
        private LibraryDataContext dataBase;

        public DBBooks()
        {
            dataBase = new LibraryDataContext();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = (from book in dataBase.Books
                                select book).ToList();

            if (books.Count == 0)
                throw new ApplicationException("No books");

            return books;
        }

        public void AddBook(Book book)
        {
            if (book.Name == null || book.Name.Trim() == "" || book.Pages == 0
                || book.YearPress == 0 || book.Quantity == 0
                || book.IdAuthor == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdTheme == 0)
                throw new ApplicationException("Fill book's info.");

            try
            {
                dataBase.Books.InsertOnSubmit(book);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book was not succesfully addaed. Try again");
            }
        }

        public void RemoveBook(Book book)
        {
            if (book.Name == null || book.Name.Trim() == "" || book.Pages == 0
                || book.YearPress == 0 || book.Quantity == 0
                || book.IdAuthor == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdTheme == 0)
                throw new ApplicationException("Please select book.");

            try
            {
                dataBase.Books.DeleteOnSubmit(book);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book was not succesfully removed. Try again");
            }
        }

        public void UpdateBook(Book book)
        {
            if (book.Name == null || book.Name.Trim() == "" || book.Pages == 0
                || book.YearPress == 0 || book.Quantity == 0
                || book.IdAuthor == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdTheme == 0)
                throw new ApplicationException("Please select book.");

            Book concreteBook =
                dataBase.Books.FirstOrDefault(temp => temp.Id == book.Id);

            concreteBook = book;

            try
            {
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book was not succesfully updated. Try again");
            }
        }

        public List<Book> FindAuthors(Book book)
        {
            if (book.Name == null || book.Name.Trim() == "" || book.Pages == 0
                || book.YearPress == 0 || book.Quantity == 0
                || book.IdAuthor == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdTheme == 0)
                throw new ApplicationException("Fill book's info.");

            List<Book> books = (from concreteBook in dataBase.Books
                                where concreteBook.Name.Contains(book.Name) ||
                                concreteBook.Pages == book.Pages ||
                                concreteBook.YearPress == book.YearPress ||
                                concreteBook.Quantity == book.Quantity ||
                                concreteBook.Comment.Contains(book.Comment) ||
                                concreteBook.IdAuthor == book.IdAuthor ||
                                concreteBook.IdPress == book.IdPress ||
                                concreteBook.IdCategory == book.IdCategory ||
                                concreteBook.IdTheme == book.IdTheme
                                select concreteBook).ToList();

            if (books.Count == 0)
                throw new ApplicationException("No books");

            return books;
        }

        public List<Theme> GetAllThemes()
        {
            List<Theme> themes = (from theme in dataBase.Themes
                                  select theme).ToList();

            return themes;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = (from category in dataBase.Categories
                                         select category).ToList();

            return categories;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = (from author in dataBase.Authors
                                    select author).ToList();

            return authors;
        }

        public List<Press> GetAllPressess()
        {
            List<Press> presses = (from press in dataBase.Presses
                                   select press).ToList();

            return presses;
        }

        public Theme GetThemeById(int id)
        {
            var theme = from concreteTheme in dataBase.Themes
                        where concreteTheme.Id == id
                        select concreteTheme;

            return theme.ToList()[0];
        }

        public Category GetCategoryById(int id)
        {
            var categories = from concreteCategory in dataBase.Categories
                             where concreteCategory.Id == id
                             select concreteCategory;

            return categories.ToList()[0];
        }

        public Author GetAuthorById(int id)
        {
            var author = from concreteAuthor in dataBase.Authors
                         where concreteAuthor.Id == id
                         select concreteAuthor;

            return author.ToList()[0];
        }

        public Press GetPressById(int id)
        {
            var press = from concretePress in dataBase.Presses
                        where concretePress.Id == id
                        select concretePress;

            return press.ToList()[0];
        }
    }
}
