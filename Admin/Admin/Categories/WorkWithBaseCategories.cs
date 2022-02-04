using Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Categories
{
    internal class WorkWithBaseCategories : IDisposable
    {
        private SqlConnection sqlConnection;

        public WorkWithBaseCategories()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }

        public void AddNewCategory(Category category)
        {
            if (category.Name == null)
                throw new ApplicationException("Category was not added.");

            string querry = $"Insert into Categories(Name) " +
                $"values(N'{category.Name}')";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Category was not added.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void RemoveCategory(Category category)
        {
            if (category.Id == 0 || category.Name == null)
                throw new ApplicationException("Category was not added.");

            string querry = $"delete from Categories where Id={category.Id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Category was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateCategory(Category category)
        {
            if (category.Id == 0 || category.Name == null)
                throw new ApplicationException("Category was not changed.");

            string querry = $"Update Categories " +
                $"set Categories.[Name]=N'{category.Name}'" +
                $" where Categories.[Id]='{category.Id}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Category was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Category> GetCategoriesByName(string name)
        {
            string querry = $"select * from Categories where [Name]=N'{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No categories.");
            }

            ReadCategories(sqlDataReader, categories);
            sqlDataReader.Close();
            sqlConnection.Close();

            return categories;
        }

        public List<Category> GetAllCategories()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Categories", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No categories.");
            }

            ReadCategories(sqlDataReader, categories);
            sqlConnection.Close();
            sqlConnection.Close();

            return categories;
        }

        private void ReadCategories(SqlDataReader sqlDataReader, List<Category> categories)
        {
            while (sqlDataReader.Read())
            {
                categories.Add(new Category()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                });
            }
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
