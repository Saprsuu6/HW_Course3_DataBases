namespace CoppingFiles
{
    partial class Form1
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
            this.From = new System.Windows.Forms.TextBox();
            this.To = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseFrom = new System.Windows.Forms.Button();
            this.BrowseTo = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.OpneFile = new System.Windows.Forms.OpenFileDialog();
            this.Copy = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(51, 19);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(240, 20);
            this.From.TabIndex = 0;
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(51, 50);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(240, 20);
            this.To.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // BrowseFrom
            // 
            this.BrowseFrom.Location = new System.Drawing.Point(297, 17);
            this.BrowseFrom.Name = "BrowseFrom";
            this.BrowseFrom.Size = new System.Drawing.Size(80, 23);
            this.BrowseFrom.TabIndex = 4;
            this.BrowseFrom.Text = "Browse";
            this.BrowseFrom.UseVisualStyleBackColor = true;
            this.BrowseFrom.Click += new System.EventHandler(this.BrowseFrom_Click);
            // 
            // BrowseTo
            // 
            this.BrowseTo.Location = new System.Drawing.Point(297, 48);
            this.BrowseTo.Name = "BrowseTo";
            this.BrowseTo.Size = new System.Drawing.Size(80, 23);
            this.BrowseTo.TabIndex = 5;
            this.BrowseTo.Text = "Browse";
            this.BrowseTo.UseVisualStyleBackColor = true;
            this.BrowseTo.Click += new System.EventHandler(this.BrowseTo_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(15, 87);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(276, 23);
            this.Progress.TabIndex = 6;
            // 
            // OpneFile
            // 
            this.OpneFile.FileName = "openFileDialog1";
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(297, 87);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(80, 23);
            this.Copy.TabIndex = 7;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 122);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.BrowseTo);
            this.Controls.Add(this.BrowseFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox From;
        private System.Windows.Forms.MaskedTextBox To;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseFrom;
        private System.Windows.Forms.Button BrowseTo;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.OpenFileDialog OpneFile;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.FolderBrowserDialog OpenFolder;
    }
}

