using Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Admin.Press
{
    internal class WorkWithBasePress : IDisposable
    {
        private SqlConnection sqlConnection;

        public WorkWithBasePress()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }

        public void AddNewPress(Pres press)
        {
            if (press.Name == null)
                throw new ApplicationException("Press was not added.");

            string querry = $"Insert into Press(Name) " +
                $"values(N'{press.Name}')";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Press was not added.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void RemovePress(Pres press)
        {
            if (press.Id == 0 || press.Name == null)
                throw new ApplicationException("Press was not added.");

            string querry = $"delete from Press where Id={press.Id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Press was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdatePress(Pres press)
        {
            if (press.Id == 0 || press.Name == null)
                throw new ApplicationException("Press was not changed.");

            string querry = $"Update Press " +
                $"set Press.[Name]=N'{press.Name}'" +
                $" where Press.[Id]='{press.Id}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Press was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Pres> GetPressesByName(string name)
        {
            string querry = $"select * from Press where [Name]=N'{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Pres> presses = new List<Pres>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No presses.");
            }

            ReadPresses(sqlDataReader, presses);
            sqlDataReader.Close();
            sqlConnection.Close();

            return presses;
        }

        public List<Pres> GetAllPresses()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Press", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Pres> presses = new List<Pres>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No presses.");
            }

            ReadPresses(sqlDataReader, presses);
            sqlConnection.Close();
            sqlConnection.Close();

            return presses;
        }

        private void ReadPresses(SqlDataReader sqlDataReader, List<Pres> presses)
        {
            while (sqlDataReader.Read())
            {
                presses.Add(new Pres()
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
