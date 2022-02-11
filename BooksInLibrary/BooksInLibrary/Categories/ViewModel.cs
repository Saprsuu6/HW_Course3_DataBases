using BooksInLibrary.Authors;
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

namespace BooksInLibrary.Categories
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Category category;
        private ObservableCollection<Category> categories;
        private RelayCommand command;
        private DBCategories dataBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            category = new Category();
            dataBase = new DBCategories();

            FillList();
        }

        private async void FillList()
        {
            try
            {
                List<Category> categories = await Task.Run(() => dataBase.GetAllCtegories());
                Categories = new ObservableCollection<Category>(categories);
            }
            catch (Exception)
            {
                Categories = new ObservableCollection<Category>();
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

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public RelayCommand AddCategory
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        Category category = this.category.Clone();
                        await Task.Run(() => dataBase.AddCategory(category));

                        List<Category> categories = await Task.Run(() => dataBase.GetAllCtegories());
                        Categories = new ObservableCollection<Category>(categories);

                        Category = new Category();

                        MessageBox.Show("Category was succesfully added.", "",
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

        public RelayCommand RemoveCategory
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.RemoveCategory(category));

                        Categories.Remove(category);

                        Category = new Category();

                        MessageBox.Show("Category was succesfully removed.", "",
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

        public RelayCommand UpdateCategory
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.UpdateCategory(category));

                        Category = new Category();

                        MessageBox.Show("Category was succesfully updated.", "",
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

        public RelayCommand FindCategories
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Category> categories = await Task.Run(() => dataBase.FindCategories(category));
                        Categories = new ObservableCollection<Category>(categories);
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
                    Category = new Category();
                });
            }
        }

        public RelayCommand RefreshBase
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Category> categories = await Task.Run(() => dataBase.GetAllCtegories());
                    Categories = new ObservableCollection<Category>(categories);

                    MessageBox.Show("Base was succesully refreshed.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
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
