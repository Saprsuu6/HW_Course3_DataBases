using MusicZClient.Command;
using MusicZClient.Models;
using MusicZClient.Regular;
using MusicZClient.WorkWithBases;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicZClient.ViewModels
{
    class ViewModelClient : INotifyPropertyChanged
    {
        private DateTime birthday;
        private Context context;
        private Client client;
        private Check check;
        private ObservableCollection<Check> checks;
        private RelayCommand command;

        public static event EventHandler<EventArgs> close = null;

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public ViewModelClient()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            Check = new Check();
            context = new Context();

            ViewModelAR.updateInfo += new EventHandler<EventArgs>(UpdateCheks);
            ViewModelShop.updateChecks += new EventHandler<EventArgs> (UpdateCheks);
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

        private void UpdateCheks(object sender, EventArgs e)
        {
            Client = sender as Client;
            Checks = new ObservableCollection<Check>(WorkWithChecks.GetClientChecks(context, client));

            try
            {
                Birthday = DateTime.Parse(client.Birthday);
            }
            catch (Exception)
            {}
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

        public RelayCommand Remove
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    var result = MessageBox.Show("Do u really want to remove ur account?", "Message",
                            MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            await Task.Run(() => WorkWithClients.RemoveClient(context, client));
                            MessageBox.Show("Client was succesfully removed.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            close.Invoke(this, EventArgs.Empty);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Client was not succesfully removed.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
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

                    client.Birthday = birthday.ToShortDateString();

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
