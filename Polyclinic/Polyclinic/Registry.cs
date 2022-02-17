using Polyclinic.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    internal partial class Registry : Form
    {
        private Models.Polyclinic polyclinic;

        public Registry(Models.Polyclinic polyclinic)
        {
            InitializeComponent();
            this.polyclinic = polyclinic;
        }

        private void SingUp(Patient patient)
        {
            polyclinic.Patients.Add(patient);
            polyclinic.SaveChanges();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (PatientName.Text.Trim() != "" && PatientSurename.Text.Trim() != ""
                && PatientPatronimic.Text.Trim() != "" && PatientAddress.Text.Trim() != ""
                && PatientName.Text.ToLower() != "admin")
            {
                MessageBox.Show("Loading...");

                Patient patient = new Patient()
                {
                    Name = PatientName.Text,
                    Surename = PatientSurename.Text,
                    Patronimic = PatientPatronimic.Text,
                    Bithday = PatientBirthday.Value.ToShortDateString(),
                    Address = PatientAddress.Text
                };

                try
                {
                    await Task.Run(() => SingUp(patient));

                    Client client = new Client(polyclinic, patient);
                    client.Show();
                    Owner = client;
                    Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("You was not succesfully sinde up.");
                }
            }
            else
                MessageBox.Show("Set info.");
        }

        private Patient GetPatient(string name, string surename, string patronimic)
        {
            var patient = from p in polyclinic.Patients
                          where p.Name == name &&
                          p.Surename == surename &&
                          p.Patronimic == patronimic
                          select p;

            return patient.ToList()[0];
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (PatientName.Text.Trim() != "" && PatientSurename.Text.Trim() != ""
                && PatientPatronimic.Text.Trim() != "")
            {
                MessageBox.Show("Loading...");

                try
                {
                    Patient patient = await Task.Run(() => GetPatient(
                        PatientName.Text,
                        PatientSurename.Text,
                        PatientPatronimic.Text));

                    MessageBox.Show("You was succesfully loged in.");

                    if (patient.Name.Trim() == "admin")
                    {
                        Admin admin = new Admin(polyclinic);
                        admin.Show();
                        Owner = admin;
                        Hide();
                    }
                    else
                    {
                        Client client = new Client(polyclinic, patient);
                        client.Show();
                        Owner = client;
                        Hide();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You was not succesfully loged in.");
                }
            }
            else
                MessageBox.Show("Set info.");
        }
    }
}
