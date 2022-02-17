namespace Polyclinic
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DoctorPatoents = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Procent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.DoctorPriceOfEntry = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.DoctorSpeciality = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DoctorPatronimc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DoctorSurename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DoctorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Doctors = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PresonAdress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PersonBirthday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PatientPatronimic = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PatientSurename = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PatientName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Patients = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Procent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorPriceOfEntry)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 305);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DoctorPatoents);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Procent);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.DoctorPriceOfEntry);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.DoctorSpeciality);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.DoctorPatronimc);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DoctorSurename);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.DoctorName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Doctors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doctors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DoctorPatoents
            // 
            this.DoctorPatoents.DisplayMember = "Info";
            this.DoctorPatoents.FormattingEnabled = true;
            this.DoctorPatoents.Location = new System.Drawing.Point(60, 163);
            this.DoctorPatoents.Name = "DoctorPatoents";
            this.DoctorPatoents.Size = new System.Drawing.Size(124, 21);
            this.DoctorPatoents.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Patients:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Procent
            // 
            this.Procent.Location = new System.Drawing.Point(60, 137);
            this.Procent.Name = "Procent";
            this.Procent.Size = new System.Drawing.Size(124, 20);
            this.Procent.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Procent:";
            // 
            // DoctorPriceOfEntry
            // 
            this.DoctorPriceOfEntry.Location = new System.Drawing.Point(85, 111);
            this.DoctorPriceOfEntry.Name = "DoctorPriceOfEntry";
            this.DoctorPriceOfEntry.Size = new System.Drawing.Size(99, 20);
            this.DoctorPriceOfEntry.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Price of entry:";
            // 
            // DoctorSpeciality
            // 
            this.DoctorSpeciality.Location = new System.Drawing.Point(68, 85);
            this.DoctorSpeciality.Name = "DoctorSpeciality";
            this.DoctorSpeciality.Size = new System.Drawing.Size(116, 20);
            this.DoctorSpeciality.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Speciality:";
            // 
            // DoctorPatronimc
            // 
            this.DoctorPatronimc.Location = new System.Drawing.Point(71, 59);
            this.DoctorPatronimc.Name = "DoctorPatronimc";
            this.DoctorPatronimc.Size = new System.Drawing.Size(113, 20);
            this.DoctorPatronimc.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Patronimic:";
            // 
            // DoctorSurename
            // 
            this.DoctorSurename.Location = new System.Drawing.Point(71, 33);
            this.DoctorSurename.Name = "DoctorSurename";
            this.DoctorSurename.Size = new System.Drawing.Size(113, 20);
            this.DoctorSurename.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Surename:";
            // 
            // DoctorName
            // 
            this.DoctorName.Location = new System.Drawing.Point(51, 7);
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.Size = new System.Drawing.Size(133, 20);
            this.DoctorName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            // 
            // Doctors
            // 
            this.Doctors.DisplayMember = "Info";
            this.Doctors.FormattingEnabled = true;
            this.Doctors.Location = new System.Drawing.Point(190, 6);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(183, 264);
            this.Doctors.TabIndex = 16;
            this.Doctors.SelectedIndexChanged += new System.EventHandler(this.Doctors_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PresonAdress);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.PersonBirthday);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.PatientPatronimic);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.PatientSurename);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.PatientName);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.Patients);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Patients";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PresonAdress
            // 
            this.PresonAdress.Location = new System.Drawing.Point(54, 111);
            this.PresonAdress.Name = "PresonAdress";
            this.PresonAdress.Size = new System.Drawing.Size(129, 20);
            this.PresonAdress.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Adress:";
            // 
            // PersonBirthday
            // 
            this.PersonBirthday.Location = new System.Drawing.Point(67, 85);
            this.PersonBirthday.Name = "PersonBirthday";
            this.PersonBirthday.Size = new System.Drawing.Size(116, 20);
            this.PersonBirthday.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Birthday:";
            // 
            // PatientPatronimic
            // 
            this.PatientPatronimic.Location = new System.Drawing.Point(70, 59);
            this.PatientPatronimic.Name = "PatientPatronimic";
            this.PatientPatronimic.Size = new System.Drawing.Size(113, 20);
            this.PatientPatronimic.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Patronimic:";
            // 
            // PatientSurename
            // 
            this.PatientSurename.Location = new System.Drawing.Point(70, 33);
            this.PatientSurename.Name = "PatientSurename";
            this.PatientSurename.Size = new System.Drawing.Size(113, 20);
            this.PatientSurename.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Surename:";
            // 
            // PatientName
            // 
            this.PatientName.Location = new System.Drawing.Point(50, 7);
            this.PatientName.Name = "PatientName";
            this.PatientName.Size = new System.Drawing.Size(133, 20);
            this.PatientName.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Name:";
            // 
            // Patients
            // 
            this.Patients.DisplayMember = "Info";
            this.Patients.FormattingEnabled = true;
            this.Patients.Location = new System.Drawing.Point(189, 6);
            this.Patients.Name = "Patients";
            this.Patients.Size = new System.Drawing.Size(183, 264);
            this.Patients.TabIndex = 32;
            this.Patients.SelectedIndexChanged += new System.EventHandler(this.Patients_SelectedIndexChanged);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 307);
            this.Controls.Add(this.tabControl1);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Procent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorPriceOfEntry)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Procent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown DoctorPriceOfEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DoctorSpeciality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DoctorPatronimc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DoctorSurename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DoctorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Doctors;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox PresonAdress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PersonBirthday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PatientPatronimic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PatientSurename;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PatientName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox Patients;
        private System.Windows.Forms.ComboBox DoctorPatoents;
        private System.Windows.Forms.Label label14;
    }
}