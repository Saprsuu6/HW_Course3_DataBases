using MusicZClient.Command;
using MusicZClient.Models;
using MusicZClient.Regular;
using MusicZClient.WorkWithBases;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicZClient.ViewModels
{
    internal class ViewModelAR : INotifyPropertyChanged
    {
        private DateTime birthday;
        private Context context;
        private Client client;
        private RelayCommand command;

        public static event EventHandler<EventArgs> updateInfo = null;
        public static event EventHandler<EventArgs> enter = null;

        public ViewModelAR()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            Client = new Client();
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged(nameof(Birthday));
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

        public RelayCommand SingUp
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    Client client = new Client()
                    {
                        Name = this.client.Name,
                        Surename = this.client.Surename,
                        Password = this.client.Password,
                        Phone= this.client.Phone,
                        Birthday = birthday.ToShortDateString(),
                    };

                    try
                    {
                        await Task.Run(() => WorkWithClients.AddClient(context, client));
                        MessageBox.Show("You was succesfully registred.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        updateInfo.Invoke(client, EventArgs.Empty);
                        enter.Invoke(client, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("You was not succesfully registred.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand LogIn
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        Client concreteClient = await Task.Run
                        (() => WorkWithClients.GetClient(context, client));
                        MessageBox.Show("You was succesfully loged in.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        updateInfo.Invoke(concreteClient, EventArgs.Empty);
                        enter.Invoke(client, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("You was not succesfully loged in.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
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
