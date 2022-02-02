using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetables
{
    class WorkWithBase : IDisposable
    {
        private SqlConnection sqlConnection;
        private string connectionString;

        public WorkWithBase()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FruitsAndVegetables;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddNewProduct(Product product)
        {
            if (product.Name == null || product.Type == null || product.Color == null || product.Calories == 0)
                throw new ApplicationException("Product was not added.");

            string querry = $"Insert into Products(Name, Type, Color, Calories) " +
                $"values('{product.Name}', '{product.Type}', '{product.Color}', {product.Calories})";

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

        public ObservableCollection<Product> GetAllProducts()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Products", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No products.");
            }

            ReadProducts(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        public void DeleteProduct(Product product)
        {
            if (product.Name == null || product.Type == null || product.Color == null || product.Calories == 0)
                throw new ApplicationException("Product was not added.");

            string querry = $"delete from Products where Name='{product.Name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Product was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product.Name == null || product.Type == null || product.Color == null || product.Calories == 0)
                throw new ApplicationException("Product was not changed.");

            string querry = $"Update Products " +
                $"set Products.[Name]='{product.Name}', Products.[Type]='{product.Type}', Color='{product.Color}', Calories='{product.Calories}'" +
                $" where Products.[Name]='{product.Name}';";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Product was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public ObservableCollection<Product> FindByName(string name)
        {
            string querry = $"select * from Products where [Name]='{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No products.");
            }

            ReadProducts(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        public ObservableCollection<Product> FindByType(string type)
        {
            string querry = $"select * from Products where [Type]='{type}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No products.");
            }

            ReadProducts(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        public ObservableCollection<Product> FindByColor(string color)
        {
            string querry = $"select * from Products where [Color]='{color}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No products.");
            }

            ReadProducts(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        public ObservableCollection<Product> FindByCalories(int calories)
        {
            string querry = $"select * from Products where [Calories]={calories}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No products.");
            }

            ReadProducts(sqlDataReader, products);
            sqlDataReader.Close();
            sqlConnection.Close();

            return products;
        }

        private ObservableCollection<Product> ReadProducts(SqlDataReader sqlDataReader, ObservableCollection<Product> products)
        {
            while (sqlDataReader.Read())
            {
                products.Add(new Product()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Type = sqlDataReader.GetString(2),
                    Color = sqlDataReader.GetString(3),
                    Calories = sqlDataReader.GetInt32(4)
                });
            }

            return products;
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}
