using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace BooksInLibrary.Books
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Book book;
        private Theme theme;
        private Category category;
        private Author author;
        private Press press;
        private ObservableCollection<Book> books;
        private ObservableCollection<Theme> themes;
        private ObservableCollection<Category> categories;
        private ObservableCollection<Author> authors;
        private ObservableCollection<Press> presses;
        private RelayCommand command;
        private DBBooks dataBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            book = new Book();
            theme = new Theme();
            category = new Category();
            author = new Author();
            press = new Press();
            dataBase = new DBBooks();

            FillList();
        }

        private async void FillList()
        {
            try
            {
                List<Book> books = await Task.Run(() => dataBase.GetAllBooks());
                Books = new ObservableCollection<Book>(books);

                List<Author> authors = await Task.Run(() => dataBase.GetAllAuthors());
                Authors = new ObservableCollection<Author>(authors);
                Author = authors[0];

                List<Press> presses = await Task.Run(() => dataBase.GetAllPressess());
                Presses = new ObservableCollection<Press>(presses);
                Press = presses[0];

                List<Category> categories = await Task.Run(() => dataBase.GetAllCategories());
                Categories = new ObservableCollection<Category>(categories);
                Category = categories[0];

                List<Theme> themes = await Task.Run(() => dataBase.GetAllThemes());
                Themes = new ObservableCollection<Theme>(themes);
                Theme = themes[0];
            }
            catch (Exception)
            {
                Books = new ObservableCollection<Book>();
            }
        }

        public async void SetObjects(Book book)
        {
            await Task.Run(() => Theme = dataBase.GetThemeById(book.IdTheme));
            await Task.Run(() => Category = dataBase.GetCategoryById(book.IdCategory));
            await Task.Run(() => Author = dataBase.GetAuthorById(book.IdAuthor));
            await Task.Run(() => Press = dataBase.GetPressById(book.IdPress));
        }

        public Book Book
        {
            get { return book; }
            set
            {
                book = value;

                if (book != null && book.Id != 0)
                    SetObjects(book);
                
                OnPropertyChanged(nameof(Book));
            }
        }

        public Author Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public Press Press
        {
            get { return press; }
            set
            {
                press = value;
                OnPropertyChanged(nameof(Press));
            }
        }

        public Theme Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set
            {
                authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public ObservableCollection<Press> Presses
        {
            get { return presses; }
            set
            {
                presses = value;
                OnPropertyChanged(nameof(Presses));
            }
        }

        public ObservableCollection<Theme> Themes
        {
            get { return themes; }
            set
            {
                themes = value;
                OnPropertyChanged(nameof(Themes));
            }
        }

        public RelayCommand AddBook
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        this.book.IdPress = press.Id;
                        this.book.IdAuthor = author.Id;
                        this.book.IdCategory = category.Id;
                        this.book.IdTheme = theme.Id;

                        Book book = this.book.Clone();
                        await Task.Run(() => dataBase.AddBook(book));

                        List<Book> books = await Task.Run(() => dataBase.GetAllBooks());
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();

                        MessageBox.Show("Book was succesfully added.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand RemoveBook
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.RemoveBook(book));

                        Books.Remove(book);

                        Book = new Book();

                        MessageBox.Show("Book was succesfully removed.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand UpdateBook
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        book.IdPress = press.Id;
                        book.IdAuthor = author.Id;
                        book.IdCategory = category.Id;
                        book.IdTheme = theme.Id;

                        await Task.Run(() => dataBase.UpdateBook(book));

                        List<Book> books = await Task.Run(() => dataBase.GetAllBooks());
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();

                        MessageBox.Show("Book was succesfully updated.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand FindBooks
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        book.IdPress = press.Id;
                        book.IdAuthor = author.Id;
                        book.IdCategory = category.Id;
                        book.IdTheme = theme.Id;

                        List<Book> books = await Task.Run(() => dataBase.FindAuthors(book));
                        Books = new ObservableCollection<Book>(books);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand ClearFields
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Book = new Book();
                });
            }
        }

        public RelayCommand RefreshBase
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Book> books = await Task.Run(() => dataBase.GetAllBooks());
                    Books = new ObservableCollection<Book>(books);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
