using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Admin.Authors
{
    class ViewModel : INotifyPropertyChanged
    {
        private Author author;
        private ObservableCollection<Author> authors;
        private RelayCommand command;
        private WorkWithBaseAuthors workWithBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            author = new Author();
            workWithBase = new WorkWithBaseAuthors();
            FillList();
        }

        private void FillList()
        {
            try
            {
                List<Author> authors = workWithBase.GetAllAutors();
                Authors = new ObservableCollection<Author>(authors);
            }
            catch (Exception ex)
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

        public RelayCommand CommandAddAuthor
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        Author author = this.author.Clone();

                        workWithBase.AddNewAutor(author);

                        List<Author> authors = workWithBase.GetAllAutors();
                        Authors = new ObservableCollection<Author>(authors);

                        Author = new Author();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandRemoveAuthor
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.RemoveAuthor(author);
                        Authors.Remove(author);

                        Author = new Author();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandUpdateAuthor
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.UpdateAuthor(author);

                        Author = new Author();
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
                    Author = new Author();
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
                        List<Author> authors = workWithBase.GetAuthorsByName(author.Name.ToLower());
                        Authors = new ObservableCollection<Author>(authors);

                        Author = new Author();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => author.Name != null && author.Name.Trim() != "");
            }
        }

        public RelayCommand CommandFindBySurename
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Author> authors = workWithBase.GetAuthorBySurename(author.Surename.ToLower());
                        Authors = new ObservableCollection<Author>(authors);

                        Author = new Author();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => author.Surename != null && author.Surename.Trim() != "");
            }
        }

        public RelayCommand CommandShowAllAuthors
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Author> authors = workWithBase.GetAllAutors();
                        Authors = new ObservableCollection<Author>(authors);

                        Author = new Author(); // это нужно делать везде после вызова матода OnPropertyChanged 
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
            if (author.Name != null && author.Name.Trim() != ""
                 && author.Surename != null && author.Surename.Trim() != "")
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
