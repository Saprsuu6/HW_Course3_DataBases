using MusicZClient.Command;
using MusicZClient.Models;
using MusicZClient.WorkWithBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicZClient.ViewModels
{
    internal class ViewModelShop : INotifyPropertyChanged
    {
        private int amount;
        private Context context;
        private Client client;
        private Albom albom;
        private ObservableCollection<Albom> alboms;
        private RelayCommand command;

        public static event EventHandler<EventArgs> updateChecks = null;

        public ViewModelShop()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            ViewModelAR.updateInfo += new EventHandler<EventArgs>(UpdateClient);

            context = new Context();
        }

        private void UpdateClient(object sender, EventArgs e)
        {
            client = sender as Client;
            Alboms = GetAlboms();
        }

        private ObservableCollection<Albom> GetAlboms()
        {
            List<Client> clients = WorkWithClients.GetAllClients(context);
            List<Albom> alboms = WorkWithAlboms.GetAllAlboms(context);

            if (client.IsRegularClient == true)
            {
                foreach (Albom albom in alboms)
                    albom.PriceForSale -= albom.PriceForSale * 15 / 100;
            }

            return new ObservableCollection<Albom>(alboms);
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
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

        public RelayCommand Buy
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        if (albom == null)
                            throw  new ApplicationException("Select albom.");

                        if (amount <= 0 || amount > Albom.Quantity)
                            throw new ApplicationException("Select correct amount of good.");

                        if (Albom.Quantity == 0)
                            throw new ApplicationException("No alboms.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    try
                    {
                        Check check = new Check()
                        {
                            Date = DateTime.Now,
                            Id_Albom = albom,
                            Id_Client = client
                        };

                        await Task.Run(() =>
                        {
                            Albom.Quantity -= amount;
                            WorkWithAlboms.UpdateAlbom(context, albom);
                            WorkWithChecks.AddCheck(context, check);
                        });

                        MessageBox.Show("Operaton was succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                        updateChecks.Invoke(client, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Operaton was not succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
