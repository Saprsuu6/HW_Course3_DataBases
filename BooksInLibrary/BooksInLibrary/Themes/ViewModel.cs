using BooksInLibrary.Categories;
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

namespace BooksInLibrary.Themes
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Theme theme;
        private ObservableCollection<Theme> themes;
        private RelayCommand command;
        private DBThemes dataBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            theme = new Theme();
            dataBase = new DBThemes();

            FillList();
        }

        private async void FillList()
        {
            try
            {
                List<Theme> categories = await Task.Run(() => dataBase.GetAllThemes());
                Themes = new ObservableCollection<Theme>(categories);
            }
            catch (Exception)
            {
                Themes = new ObservableCollection<Theme>();
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

        public ObservableCollection<Theme> Themes
        {
            get { return themes; }
            set
            {
                themes = value;
                OnPropertyChanged(nameof(Themes));
            }
        }

        public RelayCommand AddTheme
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        Theme category = this.theme.Clone();
                        await Task.Run(() => dataBase.AddTheme(category));

                        List<Theme> categories = await Task.Run(() => dataBase.GetAllThemes());
                        Themes = new ObservableCollection<Theme>(categories);

                        Theme = new Theme();

                        MessageBox.Show("Theme was succesfully added.", "",
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

        public RelayCommand RemoveTheme
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.RemoveTheme(theme));

                        Themes.Remove(theme);

                        Theme = new Theme();

                        MessageBox.Show("Theme was succesfully removed.", "",
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

        public RelayCommand UpdateTheme
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.UpdateTheme(theme));

                        Theme = new Theme();

                        MessageBox.Show("Theme was succesfully updated.", "",
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

        public RelayCommand FindThemes
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Theme> categories = await Task.Run(() => dataBase.FindThemes(theme));
                        Themes = new ObservableCollection<Theme>(categories);
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
                    Theme = new Theme();
                });
            }
        }

        public RelayCommand RefreshBase
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Theme> categories = await Task.Run(() => dataBase.GetAllThemes());
                    Themes = new ObservableCollection<Theme>(categories);

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
