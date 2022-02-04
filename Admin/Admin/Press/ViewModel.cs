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

namespace Admin.Press
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Pres press;
        private ObservableCollection<Pres> presses;
        private RelayCommand command;
        private WorkWithBasePress workWithBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            press = new Pres();
            workWithBase = new WorkWithBasePress();
            FillList();
        }

        private void FillList()
        {
            try
            {
                List<Pres> press = workWithBase.GetAllPresses();
                Presses = new ObservableCollection<Pres>(press);
            }
            catch (Exception ex)
            {
                Presses = new ObservableCollection<Pres>();
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

        public ObservableCollection<Pres> Presses
        {
            get { return presses; }
            set
            {
                presses = value;
                OnPropertyChanged(nameof(Presses));
            }
        }

        public RelayCommand CommandAddPress
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        Pres press = this.press.Clone();

                        workWithBase.AddNewPress(press);

                        List<Pres> presses = workWithBase.GetAllPresses();
                        Presses = new ObservableCollection<Pres>(presses);

                        Press = new Pres();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandRemovePress
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.RemovePress(press);
                        Presses.Remove(press);

                        Press = new Pres();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandUpdatePress
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        workWithBase.UpdatePress(press);

                        Press = new Pres();
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
                        List<Pres> presses = workWithBase.GetPressesByName(press.Name.ToLower());
                        Presses = new ObservableCollection<Pres>(presses);

                        Press = new Pres();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanCkick());
            }
        }

        public RelayCommand CommandShowAllPresses
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    try
                    {
                        List<Pres> presses = workWithBase.GetAllPresses();
                        Presses = new ObservableCollection<Pres>(presses);

                        Press = new Pres();
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
                    Press = new Pres();
                });
            }
        }

        private bool CanCkick()
        {
            if (press.Name != null && press.Name.Trim() != "")
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
