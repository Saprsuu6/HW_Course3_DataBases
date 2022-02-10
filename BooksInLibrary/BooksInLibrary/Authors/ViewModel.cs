using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BooksInLibrary.Authors
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Author author;
        private ObservableCollection<Author> authors;
        private RelayCommand command;
        private DBAuthors dataBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            author = new Author();
            dataBase = new DBAuthors();

            FillList();
        }

        private async void FillList()
        {
            try
            {
                List<Author> authors = await Task.Run(() => dataBase.GetAllAuthors());
                Authors = new ObservableCollection<Author>(authors);
            }
            catch (Exception)
            {
                Authors = new ObservableCollection<Author>();
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

        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set
            {
                authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public RelayCommand AddAuthor
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        Author author = this.author.Clone();
                        await Task.Run(() => dataBase.AddAuthor(author));

                        List<Author> authors = await Task.Run(() => dataBase.GetAllAuthors());
                        Authors = new ObservableCollection<Author>(authors);

                        Author = new Author();

                        MessageBox.Show("Author was succesfully added.", "",
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

        public RelayCommand RemoveAuthor
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.RemoveAuthor(author));

                        Authors.Remove(author);

                        Author = new Author();

                        MessageBox.Show("Author was succesfully removed.", "",
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

        public RelayCommand UpdateAuthor
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.UpdateAuthor(author));

                        Author = new Author();

                        MessageBox.Show("Author was succesfully updated.", "",
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

        public RelayCommand FindAuthors
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Author> authors = await Task.Run(() => dataBase.FindAuthors(author));
                        Authors = new ObservableCollection<Author>(authors);
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
                    Author = new Author();
                });
            }
        }

        public RelayCommand RefreshBase
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Author> authors = await Task.Run(() => dataBase.GetAllAuthors());
                    Authors = new ObservableCollection<Author>(authors);
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
