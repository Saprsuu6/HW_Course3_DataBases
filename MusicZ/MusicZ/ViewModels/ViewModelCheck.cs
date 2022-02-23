using MusicZ.Command;
using MusicZ.Models;
using MusicZ.Regular;
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
            Client = new Client();
            Stuff = new Stuff();
            Check = new Check();
            Albom = new Albom();

            Clients = new ObservableCollection<Client>(WorkWithClients.GetAllClients(context));
            if (clients.Count > 0) Client = clients[0];
            Stuffs = new ObservableCollection<Stuff>(WorkWithStuffs.GetAllStuff(context));
            if (stuffs.Count > 0) Stuff = stuffs[0];
            Checks = new ObservableCollection<Check>(WorkWithChecks.GetAllChecks(context));
            Alboms = new ObservableCollection<Albom>(WorkWithAlboms.GetAllAlboms(context));
            if (alboms.Count > 0) Albom = alboms[0];

            ViewModelAlbom.updateAlboms += new EventHandler<EventArgs>(UpdateAlboms);
            ViewModelClient.updateClients += new EventHandler<EventArgs>(UpdateClients);
            ViewModelStuff.updateStuffs += new EventHandler<EventArgs>(UpdateStuffs);

            ViewModelAlbom.updateChecks += new EventHandler<EventArgs>(UpdateChecks);
            ViewModelClient.updateChecks += new EventHandler<EventArgs>(UpdateChecks);
            ViewModelStuff.updateChecks += new EventHandler<EventArgs>(UpdateChecks);
        }

        private void UpdateChecks(object sender, EventArgs e)
        {
            Checks = new ObservableCollection<Check>(WorkWithChecks.GetAllChecks(context));
        }

        private void UpdateStuffs(object sender, EventArgs e)
        {
            Stuffs = new ObservableCollection<Stuff>(WorkWithStuffs.GetAllStuff(context));
            if (stuffs.Count > 0) stuff = stuffs[0];
        }

        private void UpdateClients(object sender, EventArgs e)
        {
            Clients = new ObservableCollection<Client>(WorkWithClients.GetAllClients(context));
            if (clients.Count > 0) client = clients[0];
        }

        private void UpdateAlboms(object sender, EventArgs e)
        {
            Alboms = new ObservableCollection<Albom>(WorkWithAlboms.GetAllAlboms(context));
            if (alboms.Count > 0) albom = alboms[0];
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
            if (IsEmptyStuff() && IsEmptyClient() && IsEmptyAlbom())
                return true;

            return false;
        }

        private bool IsEmptyStuff()
        {
            if (stuff != null && Reg.CheckNameSurename(stuff.Name)
                && Reg.CheckNameSurename(stuff.Surename)
                && Reg.CheckNumberPhone(stuff.Phone)
                && Reg.CheckPassword(stuff.Password)
                && Reg.CheckNumber(stuff.ProcentFromsale.ToString()))
                return true;

            return false;
        }

        private bool IsEmptyClient()
        {
            if (client != null && Reg.CheckNameSurename(client.Name)
                && Reg.CheckNameSurename(client.Surename)
                && Reg.CheckNumberPhone(client.Phone)
                && Reg.CheckPassword(client.Password))
                return true;

            return false;
        }

        private bool IsEmptyAlbom()
        {
            if (albom != null && Reg.CheckNameSurename(albom.Name)
                && Reg.CheckNameSurename(albom.BandName)
                && Reg.CheckNameSurename(albom.Publisher)
                && Reg.CheckNumber(albom.AmountTracks.ToString())
                && Reg.CheckNameSurename(albom.Genre)
                && Reg.CheckNumber(albom.YearOfPublish.ToString())
                && Reg.CheckNumber(albom.YearOfAdding.ToString())
                && Reg.CheckNumber(albom.CostPrice.ToString())
                && Reg.CheckNumber(albom.PriceForSale.ToString())
                && Reg.CheckNumber(albom.Discount.ToString()))
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
