using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Models;

namespace Admin
{
    class WorkWithBaseAuthors : IDisposable
    {
        private SqlConnection sqlConnection;

        public WorkWithBaseAuthors()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }

        public void AddNewAutor(Author author)
        {
            if (author.Name == null || author.Surename == null)
                throw new ApplicationException("Author was not added.");

            string querry = $"Insert into Authors(FirstName, LastName) " +
                $"values(N'{author.Name}', N'{author.Surename}')";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Product was not added.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void RemoveAuthor(Author author)
        {
            if (author.Id == 0 || author.Name == null || author.Surename == null)
                throw new ApplicationException("Product was not added.");

            string querry = $"delete from Authors where Id={author.Id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Author was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateAuthor(Author author)
        {
            if (author.Id == 0 || author.Name == null || author.Surename == null)
                throw new ApplicationException("Product was not changed.");

            string querry = $"Update Authors " +
                $"set Authors.[FirstName]=N'{author.Name}', Authors.[LastName]=N'{author.Surename}'" +
                $" where Authors.[Id]='{author.Id}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Author was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Author> GetAuthorsByName(string name)
        {
            string querry = $"select * from Authors where [FirstName]=N'{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Author> authors = new List<Author>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No authors.");
            }

            ReadAuthors(sqlDataReader, authors);
            sqlDataReader.Close();
            sqlConnection.Close();

            return authors;
        }

        public List<Author> GetAuthorBySurename(string surename)
        {
            string querry = $"select * from Authors where [LastName]=N'{surename}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Author> authors = new List<Author>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No authors.");
            }

            ReadAuthors(sqlDataReader, authors);
            sqlDataReader.Close();
            sqlConnection.Close();

            return authors;
        }

        public List<Author> GetAllAutors()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Authors", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Author> products = new List<Author>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No authors.");
            }

            ReadAuthors(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        private void ReadAuthors(SqlDataReader sqlDataReader, List<Author> authors)
        {
            while (sqlDataReader.Read())
            {
                authors.Add(new Author()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Surename = sqlDataReader.GetString(2),
                });
            }
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
