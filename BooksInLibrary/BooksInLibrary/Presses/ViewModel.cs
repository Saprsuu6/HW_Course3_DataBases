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

namespace BooksInLibrary.Presses
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Press press;
        private ObservableCollection<Press> presses;
        private RelayCommand command;
        private DBPresses dataBase;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            press = new Press();
            dataBase = new DBPresses();

            FillList();
        }

        private async void FillList()
        {
            try
            {
                List<Press> presses = await Task.Run(() => dataBase.GetAllPresses());
                Presses = new ObservableCollection<Press>(presses);
            }
            catch (Exception)
            {
                Presses = new ObservableCollection<Press>();
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

        public ObservableCollection<Press> Presses
        {
            get { return presses; }
            set
            {
                presses = value;
                OnPropertyChanged(nameof(Presses));
            }
        }

        public RelayCommand AddPress
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        Press press = this.press.Clone();
                        await Task.Run(() => dataBase.AddPress(press));

                        List<Press> presses = await Task.Run(() => dataBase.GetAllPresses());
                        Presses = new ObservableCollection<Press>(presses);

                        Press = new Press();

                        MessageBox.Show("Press was succesfully added.", "",
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

        public RelayCommand RemovePress
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.RemovePress(press));

                        Presses.Remove(press);

                        Press = new Press();

                        MessageBox.Show("Press was succesfully removed.", "",
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

        public RelayCommand UpdatePress
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        await Task.Run(() => dataBase.UpdatePress(press));

                        Press = new Press();

                        MessageBox.Show("Press was succesfully updated.", "",
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

        public RelayCommand FindPresses
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Press> presses = await Task.Run(() => dataBase.FindPresses(press));
                        Presses = new ObservableCollection<Press>(presses);
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
                    Press = new Press();
                });
            }
        }

        public RelayCommand RefreshBase
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Press> presses = await Task.Run(() => dataBase.GetAllPresses());
                    Presses = new ObservableCollection<Press>(presses);

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
