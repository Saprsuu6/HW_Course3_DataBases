using Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Admin.Categories
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Category category;
        private ObservableCollection<Category> categories;
        private RelayCommand command;
        private WorkWithBaseCategories workWithBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            category = new Category();
            workWithBase = new WorkWithBaseCategories();
            FillList();
        }

        private void FillList()
        {
            try
            {
                List<Category> categories = workWithBase.GetAllCategories();
                Categories = new ObservableCollection<Category>(categories);
            }
            catch (Exception ex)
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

        public RelayCommand CommandAddCategory
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        Category category = this.category.Clone();

                        workWithBase.AddNewCategory(category);

                        List<Category> categories = workWithBase.GetAllCategories();
                        Categories = new ObservableCollection<Category>(categories);

                        Category = new Category();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandRemoveCategory
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.RemoveCategory(category);
                        Categories.Remove(category);

                        Category = new Category();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandUpdateCategory
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.UpdateCategory(category);

                        Category = new Category();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
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
                        List<Category> categories = workWithBase.GetCategoriesByName(category.Name.ToLower());
                        Categories = new ObservableCollection<Category>(categories);

                        Category = new Category();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandShowAllCategories
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Category> categories = workWithBase.GetAllCategories();
                        Categories = new ObservableCollection<Category>(categories);

                        Category = new Category();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand CommandClearFields
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Category = new Category();
                });
            }
        }

        private bool CanCkick()
        {
            if (category.Name != null && category.Name.Trim() != "")
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
