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

namespace Admin.Themes
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Theme theme;
        private ObservableCollection<Theme> themes;
        private RelayCommand command;
        private WorkWithBaseThemes workWithBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            theme = new Theme();
            workWithBase = new WorkWithBaseThemes();
            FillList();
        }

        private void FillList()
        {
            try
            {
                List<Theme> themes = workWithBase.GetAllThemees();
                Themes = new ObservableCollection<Theme>(themes);
            }
            catch (Exception ex)
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

        public RelayCommand CommandAddTheme
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        Theme theme = this.theme.Clone();

                        workWithBase.AddNewTheme(theme);

                        List<Theme> themes = workWithBase.GetAllThemees();
                        Themes = new ObservableCollection<Theme>(themes);

                        Theme = new Theme();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandRemoveTheme
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.RemoveTheme(theme);
                        Themes.Remove(theme);

                        Theme = new Theme();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandUpdateTheme
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.UpdateTheme(theme);

                        Theme = new Theme();
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
                        List<Theme> themes = workWithBase.GetThemeesByName(theme.Name.ToLower());
                        Themes = new ObservableCollection<Theme>(themes);

                        Theme = new Theme();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandShowAllThemes
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Theme> themes = workWithBase.GetAllThemees();
                        Themes = new ObservableCollection<Theme>(themes);

                        Theme = new Theme();
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
                    Theme = new Theme();
                });
            }
        }

        private bool CanCkick()
        {
            if (theme.Name != null && theme.Name.Trim() != "")
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
