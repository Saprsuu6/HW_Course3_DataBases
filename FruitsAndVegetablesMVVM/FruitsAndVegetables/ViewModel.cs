using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FruitsAndVegetables
{
    class ViewModel : INotifyPropertyChanged
    {
        private Product product;
        private WorkWithBase workWithithBase;
        private ObservableCollection<Product> products;
        private RelayCommand commandAddProduct;
        private RelayCommand commandRemoveProduct;
        private RelayCommand commandClearFields;
        private RelayCommand commandUpdateProduct;
        private RelayCommand commandFindByName;
        private RelayCommand commandFindByType;
        private RelayCommand commandFindByColor;
        private RelayCommand commandFindByCalories;
        private RelayCommand commandShowAll;

        public ViewModel()
        {
            product = new Product();
            workWithithBase = new WorkWithBase();

            try
            {
                Products = workWithithBase.GetAllProducts();
            }
            catch (Exception ex)
            {
                Products = new ObservableCollection<Product>();
            }
        }

        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool CanUpdate()
        {
            if (product.Name != "" && product.Name != null
                && product.Type != "" && product.Type != null
                && product.Color != "" && product.Color != null
                && product.Calories != 0)
                return true;

            return false;
        }

        public RelayCommand CommandAddProduct
        {
            get
            {
                return commandAddProduct = new RelayCommand(obj =>
                {
                    Product product = this.product.Clone();

                    try
                    {
                        workWithithBase.AddNewProduct(product);
                        Products.Insert(0, product);
                        Product = new Product();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanUpdate());
            }
        }

        public RelayCommand CommandRemoveProduct
        {
            get
            {
                return commandRemoveProduct = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithithBase.DeleteProduct(product);
                        Products.Remove(product);
                        Product = new Product();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanUpdate());
            }
        }

        public RelayCommand CommandClearFields
        {
            get
            {
                return commandClearFields = new RelayCommand(obj =>
                {
                    Product = new Product();
                });
            }
        }

        public RelayCommand CommandUpdateProduct
        {
            get
            {
                return commandUpdateProduct = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithithBase.UpdateProduct(product);
                        Product = new Product();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }, obj => CanUpdate());
            }
        }

        public RelayCommand CommandFindByName
        {
            get
            {
                return commandFindByName = new RelayCommand(obj =>
                {
                    try
                    {
                        Products = workWithithBase.FindByName(product.Name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }, obj => product.Name != "" && product.Name != null);
            }
        }

        public RelayCommand CommandFindByType
        {
            get
            {
                return commandFindByType = new RelayCommand(obj =>
                {
                    try
                    {
                        Products = workWithithBase.FindByType(product.Type);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }, obj => product.Type != "" && product.Type != null);
            }
        }

        public RelayCommand CommandFindByColor
        {
            get
            {
                return commandFindByColor = new RelayCommand(obj =>
                {
                    try
                    {
                        Products = workWithithBase.FindByColor(product.Color);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }, obj => product.Color != "" && product.Color != null);
            }
        }

        public RelayCommand CommandFindByCalories
        {
            get
            {
                return commandFindByCalories = new RelayCommand(obj =>
                {
                    try
                    {
                        Products = workWithithBase.FindByCalories(product.Calories);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                }, obj => product.Calories != 0);
            }
        }

        public RelayCommand CommandShowAll
        {
            get
            {
                return commandShowAll = new RelayCommand(obj =>
                {
                    try
                    {
                        Products = workWithithBase.GetAllProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
