using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class BaseOfFridges
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter = null;

        public DataSet DataSet { get; set; }

        public BaseOfFridges()
        {
            sqlConnection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["Magasine"].ConnectionString);

            DataSet = new DataSet();
            LoadAllFridges();
        }

        public List<Fridge> GetAllFridges()
        {
            if (DataSet.Tables[0].Rows.Count == 0)
                throw new ApplicationException("No sailers.");

            DataTable dataTable = DataSet.Tables[0];
            List<Fridge> fridges = new List<Fridge>();

            foreach (DataRow row in dataTable.Rows)
            {
                fridges.Add(new Fridge()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = Convert.ToString(row["Name"]),
                    Price = Convert.ToInt32(row["Price"]),
                    Id_Saler = Convert.ToInt32(row["Id_Saler"]),
                });
            }

            return fridges;
        }

        public List<Fridge> GetFridgesByName(string name)
        {
            if (DataSet.Tables[0].Rows.Count == 0)
                throw new ApplicationException("No sailers.");

            DataTable dataTable = DataSet.Tables[0];
            List<Fridge> fridges = new List<Fridge>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (name == Convert.ToString(row["Name"]))
                {
                    fridges.Add(new Fridge()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        Price = Convert.ToInt32(row["Price"]),
                        Id_Saler = Convert.ToInt32(row["Id_Saler"]),
                    });
                }
            }

            return fridges;
        }

        public List<Fridge> GetFridgesByPrice(int price)
        {
            if (DataSet.Tables[0].Rows.Count == 0)
                throw new ApplicationException("No sailers.");

            DataTable dataTable = DataSet.Tables[0];
            List<Fridge> fridges = new List<Fridge>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (price == Convert.ToInt32(row["Price"]))
                {
                    fridges.Add(new Fridge()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        Price = Convert.ToInt32(row["Price"]),
                        Id_Saler = Convert.ToInt32(row["Id_Saler"]),
                    });
                }
            }

            return fridges;
        }

        private void LoadAllFridges()
        {
            string querry = "Select * from Fridges";

            adapter = new SqlDataAdapter(querry, sqlConnection);
            adapter.Fill(DataSet);
            var commandBuilder = new SqlCommandBuilder(adapter);
        }
    }
}
