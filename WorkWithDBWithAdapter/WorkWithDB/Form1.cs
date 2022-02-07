using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkWithDB
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet dataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Library"].ToString());

            LoadAllBooks();
        }

        private void LoadAllBooks()
        {
            string querry = "Select * from Books";

            SqlCommand sqlCommand = new SqlCommand(querry, sqlConnection);
            adapter.SelectCommand = sqlCommand;

            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            var commandBuilder = new SqlCommandBuilder(adapter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = ReadXML.Read("..//..//books.xml");
            DataTable dataTable = dataSet.Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow dataRow = this.dataSet.Tables[0].NewRow();

                dataRow["Id"] = int.Parse(row["Id"].ToString());
                dataRow["Name"] = row["Name"].ToString();
                dataRow["Pages"] = int.Parse(row["Pages"].ToString());
                dataRow["YearPress"] = int.Parse(row["Id"].ToString());
                dataRow["Id_Themes"] = int.Parse(row["Id_Themes"].ToString());
                dataRow["Id_Category"] = row["Id_Category"];
                dataRow["Id_Author"] = int.Parse(row["Id_Author"].ToString());
                dataRow["Id_Press"] = int.Parse(row["Id_Press"].ToString());
                dataRow["Comment"] = row["Comment"].ToString();
                dataRow["Quantity"] = int.Parse(row["Quantity"].ToString());

                this.dataSet.Tables[0].Rows.Add(dataRow);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dataRow = dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in dataRow)
            {
                dataGridView1.Rows.Remove(row);
            }

            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.Update(dataSet.Tables[0]);
        }
    }
}
