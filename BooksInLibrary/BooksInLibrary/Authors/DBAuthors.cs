using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksInLibrary.Authors
{
    internal class DBAuthors
    {
        private LibraryDataContext dataBase;

        public DBAuthors()
        {
            dataBase = new LibraryDataContext();
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = (from author in dataBase.Authors
                                    select author).ToList();

            if (authors.Count == 0)
                throw new ApplicationException("No authors");

            return authors;
        }

        public void AddAuthor(Author author)
        {
            if (author.Name == null || author.Surename == null
                || author.Name.Trim() == "" || author.Surename.Trim() == "")
                throw new ApplicationException("Fill author's info.");

            try
            {
                dataBase.Authors.InsertOnSubmit(author);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Author was not succesfully addaed. Try again");
            }
        }

        private void RemoveBooksWithAuthorId(int id)
        {
            var books = (from book in dataBase.Books
                         where book.IdAuthor == id
                         select book).ToList();

            try
            {
                foreach (Book book in books)
                    dataBase.Books.DeleteOnSubmit(book);

                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book with this author was not succesfully removed. Try again");
            }
        }

        public void RemoveAuthor(Author author)
        {
            if (author.Name == null || author.Surename == null
                || author.Name.Trim() == "" || author.Surename.Trim() == "")
                throw new ApplicationException("Please select author.");

            RemoveBooksWithAuthorId(author.Id);

            try
            {
                dataBase.Authors.DeleteOnSubmit(author);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Author was not succesfully removed. Try again");
            }
        }

        public void UpdateAuthor(Author author)
        {
            if (author.Name == null || author.Surename == null
                || author.Name.Trim() == "" || author.Surename.Trim() == "")
                throw new ApplicationException("Please select author.");

            Author concreteAuthor =
                dataBase.Authors.FirstOrDefault(temp => temp.Id == author.Id);

            concreteAuthor = author;

            try
            {
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Author was not succesfully updated. Try again");
            }
        }

        public List<Author> FindAuthors(Author author)
        {
            if (author.Name == null || author.Surename == null
                || author.Name.Trim() == "" || author.Surename.Trim() == "")
                throw new ApplicationException("Fill author's info.");

            List<Author> authors = (from concreteAuthor in dataBase.Authors
                                    where concreteAuthor.Name.Contains(author.Name) ||
                                    concreteAuthor.Surename.Contains(author.Surename)
                                    select concreteAuthor).ToList();

            if (authors.Count == 0)
                throw new ApplicationException("No authors");

            return authors;
        }
    }
}
