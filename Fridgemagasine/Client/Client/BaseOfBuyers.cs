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
    internal class BaseOfBuyers
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;

        public DataSet DataSet { get; set; }

        public BaseOfBuyers()
        {
            sqlConnection = new SqlConnection
                (ConfigurationManager.ConnectionStrings["Magasine"].ConnectionString);

            DataSet = new DataSet();
            LoadAllBuyers();
        }

        public void AddPersonToBase(Bueyr bueyr)
        {
            DataRow dataRow = DataSet.Tables[0].NewRow();
            dataRow["Id"] = bueyr.Id;
            dataRow["Name"] = bueyr.Name;
            dataRow["Surename"] = bueyr.Surename;
            dataRow["Id_Fridge"] = bueyr.Id_Fridge;

            DataSet.Tables[0].Rows.Add(dataRow);
            adapter.Update(DataSet.Tables[0]);
        }

        private void LoadAllBuyers()
        {
            string querry = "Select * from Buyers";

            adapter = new SqlDataAdapter(querry, sqlConnection);
            adapter.Fill(DataSet);
            var commandBuilder = new SqlCommandBuilder(adapter);
        }
    }
}
