namespace Polyclinic
{
    partial class Client
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
            this.Doctors = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Doctors
            // 
            this.Doctors.DisplayMember = "Spciality";
            this.Doctors.FormattingEnabled = true;
            this.Doctors.Location = new System.Drawing.Point(12, 12);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(196, 264);
            this.Doctors.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select doctor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(214, 41);
            this.Check.Multiline = true;
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            this.Check.Size = new System.Drawing.Size(168, 235);
            this.Check.TabIndex = 2;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 288);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Doctors);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Doctors;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Check;
    }
}