using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Admin.Models;
using Admin.Press;

namespace Admin.Books
{
    class ViewModel : INotifyPropertyChanged
    {
        private Book book;
        private Theme theme;
        private Category category;
        private Author author;
        private Pres press;
        private ObservableCollection<Book> books;
        private ObservableCollection<Theme> themes;
        private ObservableCollection<Category> categories;
        private ObservableCollection<Author> authors;
        private ObservableCollection<Pres> presses;
        private RelayCommand command;
        private WorkWithBaseBooks workWithBaseBooks;
        private WorkWithBasePress workWithBasePress;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            book = new Book();
            theme = new Theme();
            category = new Category();
            author = new Author();
            press = new Pres();
            workWithBaseBooks = new WorkWithBaseBooks();
            workWithBasePress = new WorkWithBasePress();
            FillList();
        }

        private void FillList()
        {
            try
            {
                List<Book> book = workWithBaseBooks.GetAllBooks();
                Books = new ObservableCollection<Book>(book);

                List<Theme> themes = workWithBaseBooks.GetAllThemes();
                Themes = new ObservableCollection<Theme>(themes);

                List<Category> categories = workWithBaseBooks.GetAllCategories();
                Categories = new ObservableCollection<Category>(categories);

                List<Author> authors = workWithBaseBooks.GetAllAuthors();
                Authors = new ObservableCollection<Author>(authors);

                List<Pres> presses = workWithBaseBooks.GetAllPresses();
                Presses = new ObservableCollection<Pres>(presses);
            }
            catch (Exception ex)
            {
                Books = new ObservableCollection<Book>();
                Themes = new ObservableCollection<Theme>();
                Categories = new ObservableCollection<Category>();
                Authors = new ObservableCollection<Author>();
                Presses = new ObservableCollection<Pres>();
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

        public Pres Press
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

        public Book Book
        {
            get { return book; }
            set
            {
                book = value;

                //Pres press = workWithBasePress.GetById(book.IdPress);
                //Press = press;

                OnPropertyChanged(nameof(Book));
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

        public ObservableCollection<Pres> Presses
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

        public RelayCommand CommandAddBook
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        Book book = this.book.Clone();

                        book.IdPress = press.Id;
                        book.IdAuthor = author.Id;
                        book.IdCategory = category.Id;
                        book.IdTheme = theme.Id;

                        workWithBaseBooks.AddNewBook(book);

                        List<Book> books = workWithBaseBooks.GetAllBooks();
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandRemoveBook
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBaseBooks.RemoveBook(book);
                        Books.Remove(book);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandUpdateBook
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        book.IdPress = press.Id;
                        book.IdAuthor = author.Id;
                        book.IdCategory = category.Id;
                        book.IdTheme = theme.Id;

                        workWithBaseBooks.UpdateBook(book);

                        List<Book> books = workWithBaseBooks.GetAllBooks();
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandClearFields
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Book = new Book();
                });
            }
        }

        public RelayCommand CommandFindByName
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByName(book.Name.ToLower());
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => book.Name != null && book.Name.Trim() != "");
            }
        }

        public RelayCommand CommandFindByPages
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByPages(book.Pages);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => book.Pages != 0);
            }
        }

        public RelayCommand CommandFindByYearPress
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByYearPress(book.YearPress);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => book.YearPress != 0);
            }
        }

        public RelayCommand CommandFindByIdTheme
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByIdTheme(theme.Id);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand CommandFindByIdCategory
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByIdCategory(category.Id);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand CommandFindByIdAutor
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByIdAuthor(author.Id);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand CommandFindByIdPress
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByIdPress(press.Id);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand CommandFindByQuantity
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetBooksByQuantity(book.Quantity);
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => book.Quantity != 0);
            }
        }

        public RelayCommand CommandShowAllBooks
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Book> books = workWithBaseBooks.GetAllBooks();
                        Books = new ObservableCollection<Book>(books);

                        Book = new Book(); // это нужно делать везде после вызова матода OnPropertyChanged 
                        //т. к. все объекты на которые есть активные ссылки в дизайнере удаляются
                        //и от этого ошибки выполнения
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        private bool CanCkick()
        {
            if (book.Name != null && book.Name.Trim() != ""
                 && book.Pages != 0 && book.YearPress != 0
                 && press.Id != 0 && author.Id != 0
                 && category.Id != 0 && theme.Id != 0
                 && book.Quantity != 0)
                return true;

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
