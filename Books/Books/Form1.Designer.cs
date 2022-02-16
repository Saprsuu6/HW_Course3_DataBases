namespace Books
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
            this.label1 = new System.Windows.Forms.Label();
            this.AuthorName = new System.Windows.Forms.TextBox();
            this.AuthorSurename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Authors = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Presses = new System.Windows.Forms.ListBox();
            this.PressName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Categories = new System.Windows.Forms.ListBox();
            this.CategoryName = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Themes = new System.Windows.Forms.ListBox();
            this.NameTheme = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.Books = new System.Windows.Forms.ListBox();
            this.ComboThemes = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ComboCotegories = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboPresses = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ComboAuthors = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BooksQuantity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.BookComments = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BookYearPress = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.BookPages = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BooksQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookYearPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookPages)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // AuthorName
            // 
            this.AuthorName.Location = new System.Drawing.Point(6, 24);
            this.AuthorName.Name = "AuthorName";
            this.AuthorName.Size = new System.Drawing.Size(130, 20);
            this.AuthorName.TabIndex = 1;
            // 
            // AuthorSurename
            // 
            this.AuthorSurename.Location = new System.Drawing.Point(6, 73);
            this.AuthorSurename.Name = "AuthorSurename";
            this.AuthorSurename.Size = new System.Drawing.Size(130, 20);
            this.AuthorSurename.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surename:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 250);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Authors);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.AuthorSurename);
            this.tabPage1.Controls.Add(this.AuthorName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Authors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Romeve author";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add author";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Authors
            // 
            this.Authors.DisplayMember = "Name";
            this.Authors.FormattingEnabled = true;
            this.Authors.Location = new System.Drawing.Point(142, 8);
            this.Authors.Name = "Authors";
            this.Authors.Size = new System.Drawing.Size(447, 212);
            this.Authors.TabIndex = 4;
            this.Authors.SelectedIndexChanged += new System.EventHandler(this.Authors_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Presses);
            this.tabPage2.Controls.Add(this.PressName);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Presses";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Presses
            // 
            this.Presses.DisplayMember = "Name";
            this.Presses.FormattingEnabled = true;
            this.Presses.Location = new System.Drawing.Point(142, 6);
            this.Presses.Name = "Presses";
            this.Presses.Size = new System.Drawing.Size(447, 212);
            this.Presses.TabIndex = 12;
            this.Presses.SelectedIndexChanged += new System.EventHandler(this.Presses_SelectedIndexChanged);
            // 
            // PressName
            // 
            this.PressName.Location = new System.Drawing.Point(9, 23);
            this.PressName.Name = "PressName";
            this.PressName.Size = new System.Drawing.Size(127, 20);
            this.PressName.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Romeve press";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Add press";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Categories);
            this.tabPage3.Controls.Add(this.CategoryName);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(595, 224);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Categories";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Categories
            // 
            this.Categories.DisplayMember = "Name";
            this.Categories.FormattingEnabled = true;
            this.Categories.Location = new System.Drawing.Point(142, 7);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(450, 212);
            this.Categories.TabIndex = 17;
            this.Categories.SelectedIndexChanged += new System.EventHandler(this.Categories_SelectedIndexChanged);
            // 
            // CategoryName
            // 
            this.CategoryName.Location = new System.Drawing.Point(9, 24);
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Size = new System.Drawing.Size(127, 20);
            this.CategoryName.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Romeve category";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 49);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Add category";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Name:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Themes);
            this.tabPage4.Controls.Add(this.NameTheme);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button8);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(595, 224);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Themes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Themes
            // 
            this.Themes.DisplayMember = "Name";
            this.Themes.FormattingEnabled = true;
            this.Themes.Location = new System.Drawing.Point(142, 7);
            this.Themes.Name = "Themes";
            this.Themes.Size = new System.Drawing.Size(450, 212);
            this.Themes.TabIndex = 17;
            this.Themes.SelectedIndexChanged += new System.EventHandler(this.Themes_SelectedIndexChanged);
            // 
            // NameTheme
            // 
            this.NameTheme.Location = new System.Drawing.Point(9, 24);
            this.NameTheme.Name = "NameTheme";
            this.NameTheme.Size = new System.Drawing.Size(127, 20);
            this.NameTheme.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 78);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(130, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Romeve theme";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 49);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Add theme";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button12);
            this.tabPage5.Controls.Add(this.button11);
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Controls.Add(this.button9);
            this.tabPage5.Controls.Add(this.Books);
            this.tabPage5.Controls.Add(this.ComboThemes);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.ComboCotegories);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.ComboPresses);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.ComboAuthors);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.BooksQuantity);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.BookComments);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.BookYearPress);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.BookPages);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.BookName);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(595, 224);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Books";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(284, 98);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(101, 23);
            this.button12.TabIndex = 22;
            this.button12.Text = "Refresh";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(284, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(101, 23);
            this.button11.TabIndex = 21;
            this.button11.Text = "Find book";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(284, 44);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(101, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "Remove book";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(284, 18);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(101, 23);
            this.button9.TabIndex = 19;
            this.button9.Text = "Add book";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Books
            // 
            this.Books.DisplayMember = "Name";
            this.Books.FormattingEnabled = true;
            this.Books.Location = new System.Drawing.Point(401, 5);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(191, 212);
            this.Books.TabIndex = 18;
            this.Books.SelectedIndexChanged += new System.EventHandler(this.Books_SelectedIndexChanged);
            // 
            // ComboThemes
            // 
            this.ComboThemes.DisplayMember = "Name";
            this.ComboThemes.FormattingEnabled = true;
            this.ComboThemes.Location = new System.Drawing.Point(148, 153);
            this.ComboThemes.Name = "ComboThemes";
            this.ComboThemes.Size = new System.Drawing.Size(121, 21);
            this.ComboThemes.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Theme:";
            // 
            // ComboCotegories
            // 
            this.ComboCotegories.DisplayMember = "Name";
            this.ComboCotegories.FormattingEnabled = true;
            this.ComboCotegories.Location = new System.Drawing.Point(148, 108);
            this.ComboCotegories.Name = "ComboCotegories";
            this.ComboCotegories.Size = new System.Drawing.Size(121, 21);
            this.ComboCotegories.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Category:";
            // 
            // ComboPresses
            // 
            this.ComboPresses.DisplayMember = "Name";
            this.ComboPresses.FormattingEnabled = true;
            this.ComboPresses.Location = new System.Drawing.Point(148, 64);
            this.ComboPresses.Name = "ComboPresses";
            this.ComboPresses.Size = new System.Drawing.Size(121, 21);
            this.ComboPresses.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Press:";
            // 
            // ComboAuthors
            // 
            this.ComboAuthors.DisplayMember = "Name";
            this.ComboAuthors.FormattingEnabled = true;
            this.ComboAuthors.Location = new System.Drawing.Point(148, 20);
            this.ComboAuthors.Name = "ComboAuthors";
            this.ComboAuthors.Size = new System.Drawing.Size(121, 21);
            this.ComboAuthors.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Author:";
            // 
            // BooksQuantity
            // 
            this.BooksQuantity.Location = new System.Drawing.Point(6, 197);
            this.BooksQuantity.Name = "BooksQuantity";
            this.BooksQuantity.Size = new System.Drawing.Size(121, 20);
            this.BooksQuantity.TabIndex = 9;
            this.BooksQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Quantity:";
            // 
            // BookComments
            // 
            this.BookComments.Location = new System.Drawing.Point(6, 154);
            this.BookComments.Name = "BookComments";
            this.BookComments.Size = new System.Drawing.Size(121, 20);
            this.BookComments.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Comments:";
            // 
            // BookYearPress
            // 
            this.BookYearPress.Location = new System.Drawing.Point(6, 109);
            this.BookYearPress.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.BookYearPress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BookYearPress.Name = "BookYearPress";
            this.BookYearPress.Size = new System.Drawing.Size(121, 20);
            this.BookYearPress.TabIndex = 5;
            this.BookYearPress.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Year press:";
            // 
            // BookPages
            // 
            this.BookPages.Location = new System.Drawing.Point(6, 64);
            this.BookPages.Name = "BookPages";
            this.BookPages.Size = new System.Drawing.Size(121, 20);
            this.BookPages.TabIndex = 3;
            this.BookPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Pages:";
            // 
            // BookName
            // 
            this.BookName.Location = new System.Drawing.Point(6, 21);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(121, 20);
            this.BookName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 266);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BooksQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookYearPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookPages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AuthorName;
        private System.Windows.Forms.TextBox AuthorSurename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Authors;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PressName;
        private System.Windows.Forms.ListBox Presses;
        private System.Windows.Forms.ListBox Categories;
        private System.Windows.Forms.TextBox CategoryName;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Themes;
        private System.Windows.Forms.TextBox NameTheme;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown BooksQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BookComments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown BookYearPress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown BookPages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BookName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboThemes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ComboCotegories;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ComboPresses;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ComboAuthors;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox Books;
        private System.Windows.Forms.Button button12;
    }
}

