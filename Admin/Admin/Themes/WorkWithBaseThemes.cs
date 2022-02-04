using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Models;

namespace Admin.Themes
{
    internal class WorkWithBaseThemes : IDisposable
    {
        private SqlConnection sqlConnection;

        public WorkWithBaseThemes()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }

        public void AddNewTheme(Theme themes)
        {
            if (themes.Name == null)
                throw new ApplicationException("Theme was not added.");

            string querry = $"Insert into Themes(Name) " +
                $"values(N'{themes.Name}')";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Theme was not added.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void RemoveTheme(Theme themes)
        {
            if (themes.Id == 0 || themes.Name == null)
                throw new ApplicationException("Theme was not added.");

            string querry = $"delete from Themes where Id={themes.Id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Theme was not removed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateTheme(Theme themes)
        {
            if (themes.Id == 0 || themes.Name == null)
                throw new ApplicationException("Theme was not changed.");

            string querry = $"Update Themes " +
                $"set Themes.[Name]=N'{themes.Name}'" +
                $" where Themes.[Id]='{themes.Id}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new ApplicationException("Theme was not changed.");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Theme> GetThemeesByName(string name)
        {
            string querry = $"select * from Themes where [Name]=N'{name}'";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Theme> themes = new List<Theme>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No themes.");
            }

            ReadThemes(sqlDataReader, themes);
            sqlDataReader.Close();
            sqlConnection.Close();

            return themes;
        }

        public Theme GetById(int id)
        {
            string querry = $"select * from Themes where Themes.[Id]={id}";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Theme theme = null;

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No themes.");
            }

            while (sqlDataReader.Read())
            {
                theme = new Theme()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                };
            }

            sqlConnection.Close();
            sqlConnection.Close();

            return theme;
        }

        public List<Theme> GetAllThemees()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from Themes", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Theme> themes = new List<Theme>();

            if (!sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                throw new ApplicationException("No themes.");
            }

            ReadThemes(sqlDataReader, themes);
            sqlConnection.Close();
            sqlConnection.Close();

            return themes;
        }

        private void ReadThemes(SqlDataReader sqlDataReader, List<Theme> themes)
        {
            while (sqlDataReader.Read())
            {
                themes.Add(new Theme()
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
