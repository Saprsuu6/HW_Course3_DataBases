using Polyclinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    internal partial class Admin : Form
    {
        private Models.Polyclinic polyclinic;

        public Admin(Models.Polyclinic polyclinic)
        {
            InitializeComponent();
            this.polyclinic = polyclinic;
        }

        private async void FillDoctors()
        {
            List<Doctor> doctors = await Task.Run(() =>
            {
                return (from doctor in polyclinic.Doctors
                        select doctor).ToList();
            });

            Doctors.DataSource = doctors;
        }

        private async void FillPatients()
        {
            List<Patient> patients = await Task.Run(() =>
            {
                return (from patient in polyclinic.Patients
                        select patient).ToList();
            });

            Patients.DataSource = patients;
        }

        private void Admin_Load(object sender, System.EventArgs e)
        {
            MessageBox.Show("Loading...");
            FillDoctors();
            FillPatients();
        }

        private void Doctors_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Doctor doctor = Doctors.SelectedItem as Doctor;
            polyclinic.Entry(doctor).Collection("Patients").Load();

            if (doctor != null)
            {
                DoctorName.Text = doctor.Name;
                DoctorSurename.Text = doctor.Surename;
                DoctorPatronimc.Text = doctor.Patronimic;
                DoctorSpeciality.Text = doctor.Spciality;
                DoctorPriceOfEntry.Text = doctor.PriceOfEntry;
                Procent.Text = doctor.Procent;
                if (doctor.Patients.Count != 0)
                {
                    DoctorPatoents.DataSource = doctor.Patients;
                    DoctorPatoents.SelectedIndex = 0;
                }
            }
        }

        private void Patients_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Patient patient = Patients.SelectedItem as Patient;

            if (patient != null)
            {
                PatientName.Text = patient.Name;
                PatientSurename.Text = patient.Surename;
                PatientPatronimic.Text = patient.Patronimic;
                PersonBirthday.Text = patient.Bithday;
                PresonAdress.Text = patient.Address;
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Doctor doctor = Doctors.SelectedItem as Doctor;

            if (doctor != null)
            {
                doctor.Name = DoctorName.Text;
                doctor.Surename = DoctorSurename.Text;
                doctor.Patronimic = DoctorPatronimc.Text;
                doctor.Spciality = DoctorSpeciality.Text;
                doctor.PriceOfEntry = DoctorPriceOfEntry.Text;
                doctor.Procent = Procent.Text;

                polyclinic.SaveChanges();

                FillDoctors();
            }
            else
                MessageBox.Show("Select doctor");
        }

        private async void button2_Click(object sender, System.EventArgs e)
        {
            Doctor doctor = Doctors.SelectedItem as Doctor;

            if (doctor != null)
            {
                await Task.Run(() => 
                {
                    polyclinic.Doctors.Remove(doctor);
                    polyclinic.SaveChanges();
                });
            }
            else
                MessageBox.Show("Select doctor");

            FillDoctors();
        }

        private async void AddDoctor(Doctor doctor)
        {
            try
            {
                await Task.Run(() =>
                {
                    polyclinic.Doctors.Add(doctor);
                    polyclinic.SaveChanges();
                });

                FillDoctors();

                MessageBox.Show("Doctor was succesfully added.");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Doctor was not succesfully added.");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (DoctorName.Text.Trim() == "" || DoctorSurename.Text.Trim() == ""
                || DoctorPatronimc.Text.Trim() == "" || DoctorSpeciality.Text.Trim() == ""
                || DoctorPriceOfEntry.Value == 0 || Procent.Value == 0)
            {
                MessageBox.Show("Fill info");
            }
            else
            {
                Doctor doctor = new Doctor()
                {
                    Name = DoctorName.Text,
                    Surename = DoctorSurename.Text,
                    Patronimic = DoctorPatronimc.Text,
                    Spciality = DoctorSpeciality.Text,
                    PriceOfEntry = DoctorPriceOfEntry.Text,
                    Procent = Procent.Text
                };

                AddDoctor(doctor);
            }
        }
    }
}
