using MusicZ.Command;
using MusicZ.Models;
using MusicZ.WorkWithBases;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicZ.ViewModels
{
    class ViewModelCheck : INotifyPropertyChanged
    {
        private Context context;
        private Client client;
        private Stuff stuff;
        private Check check;
        private Albom albom;
        private ObservableCollection<Client> clients;
        private ObservableCollection<Stuff> stuffs;
        private ObservableCollection<Check> checks;
        private ObservableCollection<Albom> alboms;
        private RelayCommand command;

        public ViewModelCheck()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            client = new Client();
            stuff = new Stuff();
            check = new Check();
            albom = new Albom();

            clients = new ObservableCollection<Client>(WorkWithClients.GetAllClients(context));
            client = clients[0];
            stuffs = new ObservableCollection<Stuff>(WorkWithStuffs.GetAllStuff(context));
            stuff = stuffs[0];
            checks = new ObservableCollection<Check>(WorkWithChecks.GetAllChecks(context));
            check = checks[0];
            alboms = new ObservableCollection<Albom>(WorkWithAlboms.GetAllAlboms(context));
            albom = alboms[0];
        }

        public Albom Albom
        {
            get { return albom; }
            set
            {
                albom = value;
                OnPropertyChanged(nameof(Albom));
            }
        }

        public ObservableCollection<Albom> Alboms
        {
            get { return alboms; }
            set
            {
                alboms = value;
                OnPropertyChanged(nameof(Alboms));
            }
        }

        public Check Check
        {
            get { return check; }
            set
            {
                check = value;
                OnPropertyChanged(nameof(Check));
            }
        }

        public ObservableCollection<Check> Checks
        {
            get { return checks; }
            set
            {
                checks = value;
                OnPropertyChanged(nameof(Checks));
            }
        }

        public Stuff Stuff
        {
            get { return stuff; }
            set
            {
                stuff = value;
                OnPropertyChanged(nameof(Stuff));
            }
        }

        public ObservableCollection<Stuff> Stuffs
        {
            get { return stuffs; }
            set
            {
                stuffs = value;
                OnPropertyChanged(nameof(Stuffs));
            }
        }

        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public RelayCommand Add
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    if (albom.AmountTracks == 0)
                        MessageBox.Show("No alboms.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    Check check = new Check()
                    {
                        Id_Client = client,
                        Id_Stuff = stuff,
                        Id_Albom = albom,
                        Date = DateTime.Now
                    };

                    albom.AmountTracks--;

                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        await Task.Run(() => WorkWithChecks.AddCheck(context, check));
                        MessageBox.Show("Check was succesfully added.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Checks.Insert(0, check);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Check was not succesfully added.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnclick());
            }
        }

        public RelayCommand Remove
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        await Task.Run(() =>
                        {
                            WorkWithChecks.RemoveCheck(context, check);
                        });
                        MessageBox.Show("Check was succesfully removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Checks.Remove(check);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Check was not succesfully removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnclick());
            }
        }

        public RelayCommand Find
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        Checks = new ObservableCollection<Check>
                        (await Task.Run(() => WorkWithChecks.GetChecks(context, check)));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Check was not finded.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnclick());
            }
        }

        public RelayCommand AllChecks
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Checks = new ObservableCollection<Check>(WorkWithChecks.GetAllChecks(context));
                    MessageBox.Show("Checks was succesfully loaded.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
        }

        public RelayCommand ClearFields
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Client = new Client();
                    Stuff = new Stuff();
                    Albom = new Albom();
                });
            }
        }

        private bool CanOnclick()
        {
            if (stuff != null && client != null && albom != null)
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
