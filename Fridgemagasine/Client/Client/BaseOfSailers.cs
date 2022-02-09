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
    internal class BaseOfSailers
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;

        public DataSet DataSet { get; set; }

        public BaseOfSailers()
        {
            sqlConnection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["Magasine"].ConnectionString);

            DataSet = new DataSet();
            LoadAllSalers();
        }

        public List<Sailer> GetAllSailers()
        {
            if (DataSet.Tables[0].Rows.Count == 0)
                throw new ApplicationException("No sailers.");

            DataTable dataTable = DataSet.Tables[0];
            List<Sailer> sailers = new List<Sailer>();

            foreach (DataRow row in dataTable.Rows)
            {
                sailers.Add(new Sailer()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = Convert.ToString(row["Name"]),
                    Surename = Convert.ToString(row["Surename"]),
                });
            }

            return sailers;
        }

        public Sailer GetSailerById(int id)
        {
            var array = from row in DataSet.Tables[0].AsEnumerable()
                         where row.Field<int>("Id") == id
                         select row;

            Sailer sailer = new Sailer();
            foreach (DataRow row in array)
            {
                sailer.Id = Convert.ToInt32(row["Id"]);
                sailer.Name = Convert.ToString(row["Name"]);
                sailer.Surename = Convert.ToString(row["Surename"]);
            }

            return sailer;
        }

        private void LoadAllSalers()
        {
            string querry = "Select * from Salers";

            adapter = new SqlDataAdapter(querry, sqlConnection);
            adapter.Fill(DataSet);
            var commandBuilder = new SqlCommandBuilder(adapter);
        }
    }
}
