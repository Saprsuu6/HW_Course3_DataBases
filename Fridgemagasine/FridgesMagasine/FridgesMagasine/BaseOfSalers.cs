using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesMagasine
{
    internal class BaseOfSalers
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private DataSet dataSet;

        public BaseOfSalers()
        {
            sqlConnection = new SqlConnection();
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();

            sqlConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Magasine"].ToString());
        }

        private DataSet Load()
        {
            string querry = "Select * from Salers";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);
            adapter.SelectCommand = sqlCommand;

            adapter.Fill(dataSet);
            var commandBuilder = new SqlCommandBuilder(adapter);
            return dataSet;
        }

        public async Task<DataSet> LoadAllSalers()
        {
            return await Task.Run(() => Load());
        }

        private void Update()
        {
            if (dataSet.Tables[0].Rows.Count == 0)
                throw new ApplicationException("Nothing to update");

            try
            {
                adapter.Update(dataSet.Tables[0]);
            }
            catch (Exception)
            {
                throw new ApplicationException("Couldn't update base, try again");
            }
        }

        public async Task UpdateBaseAsync()
        {
            await Task.Run(() => Update());
        }

        public void WriteXML()
        {
            using (Stream stream = File.Open("salers.xml", FileMode.Create))
            {
                dataSet.WriteXml(stream);
            }
        }

        ~BaseOfSalers()
        {
            WriteXML();
        }
    }
}
