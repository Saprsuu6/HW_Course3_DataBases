using Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Admin.Books
{
    class WorkWithBaseBooks : IDisposable
    {
        private SqlConnection sqlConnection;

        public WorkWithBaseBooks()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }

        public void AddNewBook(Book book)
        {
            if (book.Name == null || book.Pages == 0 || book.YearPress == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdAuthor == 0 || book.IdTheme == 0 
                || book.Comment == null || book.Quantity == 0)
                throw new ApplicationException("Book was not added.");

            string querry = $"Insert into Books(Name, Pages, YearPress, Id_Themes, Id_Category, Id_Author, " +
                $"Id_Press, Comment, Quantity) " +
                $"values(N'{book.Name}', {book.Pages}, {book.YearPress}, {book.IdTheme}, {book.IdCategory}," +
                $"{book.IdAuthor}, {book.IdPress}, N'{book.Comment}', {book.Quantity})";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Book was not added.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void RemoveBook(Book book)
        {
            if (book.Name == null || book.Pages == 0 || book.YearPress == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdAuthor == 0 || book.IdTheme == 0
                || book.Comment == null || book.Quantity == 0 || book.Id == 0)
                throw new ApplicationException("Book was not added.");

            string querry = $"delete from Books where Id={book.Id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Book was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateBook(Book book)
        {
            if (book.Name == null || book.Pages == 0 || book.YearPress == 0 || book.IdPress == 0
                || book.IdCategory == 0 || book.IdAuthor == 0 || book.IdTheme == 0
                || book.Comment == null || book.Quantity == 0 || book.Id == 0)
                throw new ApplicationException("Book was not added.");

            string querry = $"Update Books " +
                $"set Books.[Name]=N'{book.Name}', Pages={book.Pages}, YearPress={book.YearPress}," +
                $"Id_Themes={book.IdTheme}, Id_Category={book.IdCategory}, Id_Author={book.IdAuthor}, " +
                $"Id_Press={book.IdPress}, Comment={book.Comment}, Quantity={book.Quantity}" +
                $" where Books.[Id]='{book.Id}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Book was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Book> GetBooksByName(string name)
        {
            string querry = $"select * from Books where [Name]=N'{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> book = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, book);
            sqlDataReader.Close();
            sqlConnection.Close();

            return book;
        }

        public List<Book> GetBooksByPages(int pages)
        {
            string querry = $"select * from Books where Pages={pages}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByYearPress(int yearPress)
        {
            string querry = $"select * from Books where YearPress={yearPress}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByIdTheme(int idTheme)
        {
            string querry = $"select * from Books where Id_Themes={idTheme}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByIdCategory(int idCategory)
        {
            string querry = $"select * from Books where Id_Category={idCategory}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByIdAuthor(int idAuthor)
        {
            string querry = $"select * from Books where Id_Author={idAuthor}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByIdPress(int idPress)
        {
            string querry = $"select * from Books where Id_Press={idPress}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetBooksByQuantity(int quantity)
        {
            string querry = $"select * from Books where Quantity={quantity}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        public List<Book> GetAllBooks()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Books", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Book> books = new List<Book>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No books.");
            }

            ReadBooks(sqlDataReader, books);
            sqlDataReader.Close();
            sqlConnection.Close();

            return books;
        }

        private void ReadBooks(SqlDataReader sqlDataReader, List<Book> books)
        {
            while (sqlDataReader.Read())
            {
                books.Add(new Book()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Pages = sqlDataReader.GetInt32(2),
                    YearPress = sqlDataReader.GetInt32(3),
                    IdTheme = sqlDataReader.GetInt32(4),
                    IdCategory = sqlDataReader.GetInt32(5),
                    IdAuthor = sqlDataReader.GetInt32(6),
                    IdPress = sqlDataReader.GetInt32(7),
                    Comment = sqlDataReader.GetString(8),
                    Quantity = sqlDataReader.GetInt32(9)
                });
            }
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
