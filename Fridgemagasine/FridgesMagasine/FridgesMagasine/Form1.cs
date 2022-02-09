using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FridgesMagasine
{
    public partial class Form1 : Form
    {
        private BaseOfSalers salers;
        private BaseOfFridges fridges;

        public Form1()
        {
            InitializeComponent();
            salers = new BaseOfSalers();
            fridges = new BaseOfFridges();
        }

        private async Task LoadSalers()
        {
            DataSet dataSet = await salers.LoadAllSalers();
            Salers.DataSource = dataSet.Tables[0];
        }

        private async Task LoadFridgesAsync()
        {
            DataSet dataSet = await fridges.LoadAllFridges();
            Fridges.DataSource = dataSet.Tables[0];
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadSalers();
            await LoadFridgesAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await salers.UpdateBaseAsync();
                MessageBox.Show("Base was succesfully apdated.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = Salers.SelectedRows;

                foreach (var item in rows)
                    Salers.Rows.Remove((DataGridViewRow)item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No one rows.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                await fridges.UpdateBaseAsync();
                MessageBox.Show("Base was succesfully apdated.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = Fridges.SelectedRows;

                foreach (var item in rows)
                    Fridges.Rows.Remove((DataGridViewRow)item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No one rows.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
