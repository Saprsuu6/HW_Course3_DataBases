namespace Polyclinic
{
    partial class Registry
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
            this.label1 = new System.Windows.Forms.Label();
            this.PatientName = new System.Windows.Forms.TextBox();
            this.PatientSurename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PatientPatronimic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PatientBirthday = new System.Windows.Forms.DateTimePicker();
            this.PatientAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // PatientName
            // 
            this.PatientName.Location = new System.Drawing.Point(15, 25);
            this.PatientName.Name = "PatientName";
            this.PatientName.Size = new System.Drawing.Size(200, 20);
            this.PatientName.TabIndex = 1;
            // 
            // PatientSurename
            // 
            this.PatientSurename.Location = new System.Drawing.Point(15, 71);
            this.PatientSurename.Name = "PatientSurename";
            this.PatientSurename.Size = new System.Drawing.Size(200, 20);
            this.PatientSurename.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surename:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sing up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PatientPatronimic
            // 
            this.PatientPatronimic.Location = new System.Drawing.Point(15, 117);
            this.PatientPatronimic.Name = "PatientPatronimic";
            this.PatientPatronimic.Size = new System.Drawing.Size(200, 20);
            this.PatientPatronimic.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Patronimic:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Birthday:";
            // 
            // PatientBirthday
            // 
            this.PatientBirthday.Location = new System.Drawing.Point(15, 162);
            this.PatientBirthday.Name = "PatientBirthday";
            this.PatientBirthday.Size = new System.Drawing.Size(200, 20);
            this.PatientBirthday.TabIndex = 8;
            // 
            // PatientAddress
            // 
            this.PatientAddress.Location = new System.Drawing.Point(15, 206);
            this.PatientAddress.Name = "PatientAddress";
            this.PatientAddress.Size = new System.Drawing.Size(200, 20);
            this.PatientAddress.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Adress:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Log in";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 302);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PatientAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PatientBirthday);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PatientPatronimic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PatientSurename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PatientName);
            this.Controls.Add(this.label1);
            this.Name = "Registry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PatientName;
        private System.Windows.Forms.TextBox PatientSurename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PatientPatronimic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker PatientBirthday;
        private System.Windows.Forms.TextBox PatientAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
    }
}

