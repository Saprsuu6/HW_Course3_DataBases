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
    class ViewModelClient : INotifyPropertyChanged
    {
        private Context context;
        private Client client;
        private ObservableCollection<Client> clients;
        private RelayCommand command;

        public static event EventHandler<EventArgs> updateChecks = null;
        public static event EventHandler<EventArgs> updateClients = null;

        public ViewModelClient()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            Client = new Client();
            Clients = new ObservableCollection<Client>(WorkWithClients.GetAllClients(context));
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
                        await Task.Run(() => WorkWithClients.RemoveClient(context, client));
                        MessageBox.Show("Client was succesfully removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Clients.Remove(client);
                        updateClients.Invoke(this, EventArgs.Empty);
                        updateChecks.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Client was not succesfully removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand Upadate
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        await Task.Run(() => WorkWithClients.UpdateClient(context, client));
                        MessageBox.Show("Client was succesfully updated.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Client was not succesfully updated.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
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
                        Clients = new ObservableCollection<Client>
                        (await Task.Run(() => WorkWithClients.GetClients(context, client)));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Client was not finded.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand AllClients
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    clients = new ObservableCollection<Client>(WorkWithClients.GetAllClients(context));
                    MessageBox.Show("Clients was succesfully loaded.", "Message",
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
                });
            }
        }

        private bool CanOnClick()
        {
            if (client != null && Reg.CheckNameSurename(client.Name)
                && Reg.CheckNameSurename(client.Surename)
                && Reg.CheckNumberPhone(client.Phone)
                && Reg.CheckPassword(client.Password))
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
