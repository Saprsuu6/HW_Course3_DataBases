using Books.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public partial class Form1 : Form
    {
        private Context context = null;

        public Form1()
        {
            InitializeComponent();
            context = new Context();

            // AddToStart.FillTables(context);
        }

        private DialogResult Question(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #region GetLists
        private List<Author> GetAuthors()
        {
            return (from author in context.Authors
                    select author).ToList();
        }

        private List<Press> GetPresses()
        {
            return (from press in context.Presses
                    select press).ToList();
        }

        private List<Category> GetCategories()
        {
            return (from category in context.Categories
                    select category).ToList();
        }

        private List<Theme> GetThemes()
        {
            return (from theme in context.Themes
                    select theme).ToList();
        }

        private List<Book> GetBooks()
        {
            return (from book in context.Books
                    select book).ToList();
        }
        #endregion

        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Loading...");

            List<Author> authors = await Task.Run(() => GetAuthors());
            foreach (Author author in authors)
            {
                Authors.Items.Add(author);
                ComboAuthors.Items.Add(author);
            }
            ComboAuthors.SelectedIndex = 0;

            List<Press> presses = await Task.Run(() => GetPresses());
            foreach (Press press in presses)
            {
                Presses.Items.Add(press);
                ComboPresses.Items.Add(press);
            }
            ComboPresses.SelectedIndex = 0;

            List<Category> categories = await Task.Run(() => GetCategories());
            foreach (Category category in categories)
            {
                Categories.Items.Add(category);
                ComboCotegories.Items.Add(category);
            }
            ComboCotegories.SelectedIndex = 0;

            List<Theme> themes = await Task.Run(() => GetThemes());
            foreach (Theme theme in themes)
            {
                Themes.Items.Add(theme);
                ComboThemes.Items.Add(theme);
            }
            ComboThemes.SelectedIndex = 0;

            List<Book> books = await Task.Run(() => GetBooks());
            foreach (Book book in books)
                Books.Items.Add(book);
        }

        #region Selections
        private void Authors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Author author = Authors.SelectedItem as Author;

            if (author != null)
            {
                AuthorName.Text = author.Name;
                AuthorSurename.Text = author.Surename;
            }
        }

        private void Presses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Press press = Presses.SelectedItem as Press;

            if (press != null)
                PressName.Text = press.Name;
        }

        private void Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category category = Categories.SelectedItem as Category;

            if (category != null)
                CategoryName.Text = category.Name;
        }

        private void Themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theme theme = Themes.SelectedItem as Theme;

            if (theme != null)
                NameTheme.Text = theme.Name;
        }


        private void Books_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book book = Books.SelectedItem as Book;

            if (book != null)
            {
                BookName.Text = book.Name;
                BookPages.Value = book.Pages;
                BookYearPress.Value = book.YearPress;
                BookComments.Text = book.Comment;
                BooksQuantity.Value = book.Quantity;
                ComboAuthors.SelectedItem = book.Author;
                ComboPresses.SelectedItem = book.Press;
                ComboCotegories.SelectedItem = book.Category;
                ComboThemes.SelectedItem = book.Theme;
            }
        }
        #endregion

        #region Addings
        private async void button1_Click(object sender, EventArgs e)
        {
            Author author = new Author()
            {
                Name = AuthorName.Text,
                Surename = AuthorSurename.Text
            };

            MessageBox.Show("Adding...");

            try
            {
                await Task.Run(() =>
                {
                    context.Authors.Add(author);
                    context.SaveChangesAsync();
                });

                Authors.Items.Add(author);
                MessageBox.Show("Author was succesfully added.");
            }
            catch (Exception)
            {
                MessageBox.Show("Author was not succesfully added.");
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Press press = new Press() { Name = PressName.Text };

            MessageBox.Show("Adding...");

            try
            {
                await Task.Run(() =>
                {
                    context.Presses.Add(press);
                    context.SaveChangesAsync();
                });

                Presses.Items.Add(press);
                MessageBox.Show("Press was succesfully added.");
            }
            catch (Exception)
            {
                MessageBox.Show("Press was not succesfully added.");
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            Category category = new Category() { Name = CategoryName.Text };

            MessageBox.Show("Adding...");

            try
            {
                await Task.Run(() =>
                {
                    context.Categories.Add(category);
                    context.SaveChangesAsync();
                });

                Categories.Items.Add(category);
                MessageBox.Show("Category was succesfully added.");
            }
            catch (Exception)
            {
                MessageBox.Show("Category was not succesfully added.");
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme() { Name = NameTheme.Text };

            MessageBox.Show("Adding...");

            try
            {
                await Task.Run(() =>
                {
                    context.Themes.Add(theme);
                    context.SaveChangesAsync();
                });

                Themes.Items.Add(theme);
                MessageBox.Show("Theme was succesfully added.");
            }
            catch (Exception)
            {
                MessageBox.Show("Theme was not succesfully added.");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = BookName.Text,
                Pages = (int)BookPages.Value,
                YearPress = (int)BookYearPress.Value,
                Comment = BookComments.Text,
                Quantity = (int)BooksQuantity.Value,
                Author = ComboAuthors.SelectedItem as Author,
                Category = ComboCotegories.SelectedItem as Category,
                Press = ComboPresses.SelectedItem as Press,
                Theme = ComboThemes.SelectedItem as Theme
            };

            MessageBox.Show("Adding...");

            try
            {
                await Task.Run(() =>
                {
                    context.Books.Add(book);
                    context.SaveChangesAsync();
                });

                Books.Items.Add(book);
                MessageBox.Show("Book was succesfully added.");
            }
            catch (Exception)
            {
                MessageBox.Show("Book was not succesfully added.");
            }
        }
        #endregion

        #region Removeings
        private async void button2_Click(object sender, EventArgs e)
        {
            if (Question("Do you want delete this author?") == DialogResult.Yes)
            {
                Author author = Authors.SelectedItem as Author;

                if (author != null)
                {
                    MessageBox.Show("Removeing...");

                    try
                    {
                        await Task.Run(() =>
                        {
                            context.Authors.Remove(author);
                            context.SaveChangesAsync();
                        });

                        Authors.Items.Remove(author);
                        MessageBox.Show("Author was succesfully removed.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Author was not succesfully removed.");
                    }
                }
                else
                    MessageBox.Show("Select item.");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (Question("Do you want delete this press?") == DialogResult.Yes)
            {
                Press press = Presses.SelectedItem as Press;

                if (press != null)
                {
                    MessageBox.Show("Removeing...");

                    try
                    {
                        await Task.Run(() =>
                        {
                            context.Presses.Remove(press);
                            context.SaveChangesAsync();
                        });

                        Presses.Items.Remove(press);
                        MessageBox.Show("Press was succesfully removed.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Press was not succesfully removed.");
                    }
                }
                else
                    MessageBox.Show("Select item.");
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (Question("Do you want delete this category?") == DialogResult.Yes)
            {
                Category category = Categories.SelectedItem as Category;

                if (category != null)
                {
                    MessageBox.Show("Removeing...");

                    try
                    {
                        await Task.Run(() =>
                        {
                            context.Categories.Remove(category);
                            context.SaveChangesAsync();
                        });

                        Categories.Items.Remove(category);
                        MessageBox.Show("Category was succesfully removed.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Category was not succesfully removed.");
                    }
                }
                else
                    MessageBox.Show("Select item.");
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (Question("Do you want delete this theme?") == DialogResult.Yes)
            {
                Theme theme = Themes.SelectedItem as Theme;

                if (theme != null)
                {
                    MessageBox.Show("Removeing...");

                    try
                    {
                        await Task.Run(() =>
                        {
                            context.Themes.Remove(theme);
                            context.SaveChangesAsync();
                        });

                        Themes.Items.Remove(theme);
                        MessageBox.Show("Theme was succesfully removed.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Theme was not succesfully removed.");
                    }
                }
                else
                    MessageBox.Show("Select item.");
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            if (Question("Do you want delete this book?") == DialogResult.Yes)
            {
                Book book = Books.SelectedItem as Book;

                if (book != null)
                {
                    MessageBox.Show("Removeing...");

                    try
                    {
                        await Task.Run(() =>
                        {
                            context.Books.Remove(book);
                            context.SaveChangesAsync();
                        });

                        Books.Items.Remove(book);
                        MessageBox.Show("Books was succesfully removed.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Books was not succesfully removed.");
                    }
                }
                else
                    MessageBox.Show("Select item.");
            }
        }
        #endregion

        private List<Book> FindBooks(Book concreteBook)
        {
            return (from book in context.Books
                    where book.Author.Name == concreteBook.Author.Name
                    || book.Press.Name == concreteBook.Press.Name
                    || book.Category.Name == concreteBook.Category.Name
                    || book.Theme.Name == concreteBook.Theme.Name
                    select book).ToList();
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Author = ComboAuthors.SelectedItem as Author,
                Category = ComboCotegories.SelectedItem as Category,
                Press = ComboPresses.SelectedItem as Press,
                Theme = ComboThemes.SelectedItem as Theme
            };

            List<Book> books = await Task.Run(() => FindBooks(book));
            Books.DataSource = books;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            List<Book> books = await Task.Run(() => GetBooks());
            Books.DataSource = books;
        }
    }
}
