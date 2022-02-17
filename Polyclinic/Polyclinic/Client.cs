using Polyclinic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    internal partial class Client : Form
    {
        private Models.Polyclinic polyclinic;
        private Patient patient;

        public Client(Models.Polyclinic polyclinic, Patient patient)
        {
            InitializeComponent();
            this.polyclinic = polyclinic;
            this.patient = patient;
        }

        private List<Doctor> GetDoctors()
        {
            return (from doctor in polyclinic.Doctors
                    select doctor).ToList();
        }

        private async void LoadDoctors()
        {
            Doctors.DataSource = await Task.Run(() => GetDoctors());
        }

        private void Client_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Loading...");
            LoadDoctors();
        }

        private async void Entry(Doctor doctor)
        {
            try
            {
                await Task.Run(() =>
                {
                    patient.Doctors.Add(doctor);
                    doctor.Patients.Add(patient);
                    polyclinic.SaveChanges();
                });

                MessageBox.Show("You was succesfully entered.");

                string check = $"Patinent:\n\tName: {patient.Name}" +
                    $"\n\tSurename: {patient.Surename}" +
                    $"\n\tPatronimic: {patient.Patronimic}" +
                    $"\n\tBirthday: {patient.Bithday}" +
                    $"\n\tAddress: {patient.Address}" +
                    $"\nDoctor:Name: {doctor.Name}" +
                    $"\n\tSurename: {doctor.Surename}" +
                    $"\n\tPatronimic: {doctor.Patronimic}" +
                    $"\n\tSpeciality: {doctor.Spciality}" +
                    $"\nPrice: {int.Parse(doctor.PriceOfEntry) * int.Parse(doctor.Procent)}";

                Check.Text = check;
            }
            catch (Exception)
            {
                MessageBox.Show("You was not succesfully entered.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Doctors.SelectedItem == null)
                MessageBox.Show("Select doctor.");
            else
            {
                DialogResult result = MessageBox.Show("Do you want to pay for that.", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Doctor doctor = Doctors.SelectedItem as Doctor;
                    Entry(doctor);
                }
            }
        }
    }
}
