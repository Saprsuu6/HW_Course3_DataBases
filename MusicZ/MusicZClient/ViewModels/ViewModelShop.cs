using MusicZClient.Command;
using MusicZClient.Models;
using MusicZClient.Regular;
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
        private bool popularByYear;
        private bool popularByMonth;
        private bool popularByWeek;
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
            popularByYear = true;
        }

        private void UpdateClient(object sender, EventArgs e)
        {
            client = sender as Client;
            Alboms = GetAlboms();
        }

        private void CheckForRegularClient()
        {
            List<Check> checks = WorkWithChecks.GetClientChecks(context, client);

            int amount = 0;
            foreach (Check check in checks)
                amount += check.AmountAlboms;

            if (checks.Count + amount > 10)
                client.IsRegularClient = true;

            WorkWithClients.UpdateClient(context, client);
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

        public bool PopularByYear
        {
            get { return popularByYear; }
            set { popularByYear = value; }
        }

        public bool PopularByMonth
        {
            get { return popularByMonth; }
            set { popularByMonth = value; }
        }

        public bool PopularByWeek
        {
            get { return popularByWeek; }
            set { popularByWeek = value; }
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
                            throw new ApplicationException("Select albom.");

                        if (amount <= 0 || amount > Albom.Quantity)
                            throw new ApplicationException("Select correct amount of good.");

                        if (Albom.Quantity == 0)
                            throw new ApplicationException("No alboms.");

                        if (Albom.ReservedByClient != null && Albom.ReservedByClient.Id != client.Id)
                            throw new ApplicationException("Reserved.");

                        Check check = new Check()
                        {
                            Date = DateTime.Now,
                            Id_Albom = albom,
                            Id_Client = client
                        };

                        Albom.Quantity -= amount;
                        check.AmountAlboms += amount;

                        await Task.Run(() =>
                        {
                            WorkWithAlboms.UpdateAlbom(context, albom);
                            WorkWithChecks.AddCheck(context, check);
                        });

                        MessageBox.Show("Operaton was succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                        updateChecks.Invoke(client, EventArgs.Empty);
                        CheckForRegularClient();
                        Alboms = GetAlboms();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message",
                               MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand Reserve
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        if (albom == null)
                            throw new ApplicationException("Select albom.");

                        if (Albom.Quantity == 0)
                            throw new ApplicationException("No alboms.");

                        if (Albom.ReservedByClient != null && Albom.ReservedByClient.Id != client.Id)
                            throw new ApplicationException("Reserved.");

                        Albom.ReservedByClient = client;
                        await Task.Run(() => WorkWithAlboms.UpdateAlbom(context, albom));

                        MessageBox.Show("Operaton was succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand Find
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Albom> alboms = await Task.Run(() => WorkWithAlboms.FindAlboms(context, albom));

                        if (alboms.Count == 0)
                            throw new Exception("No alboms");

                        Alboms = new ObservableCollection<Albom>(alboms);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Operaton was not succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand AllAlboms
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Albom> alboms = await Task.Run(() => WorkWithAlboms.GetAllAlboms(context));

                        if (alboms.Count == 0)
                            throw new Exception("No alboms");

                        Alboms = new ObservableCollection<Albom>(alboms);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Operaton was not succesfully.", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand News
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        List<Albom> alboms = await Task.Run(() => WorkWithAlboms.GetNews(context));

                        if (alboms.Count == 0)
                            throw new Exception("No alboms");

                        Alboms = new ObservableCollection<Albom>(alboms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        public RelayCommand Popular
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    try
                    {
                        string condition = "";

                        if (popularByYear) condition = "year";
                        else if (popularByYear) condition = "month";
                        else if (popularByYear) condition = "week";

                        MessageBox.Show("Loading...", "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                        List<Albom> alboms = await Task.Run(() => WorkWithAlboms.PopularAlboms(context, condition));

                        if (alboms.Count == 0)
                            throw new Exception("No alboms");

                        Alboms = new ObservableCollection<Albom>(alboms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

        private bool CanOnClick()
        {
            if (albom != null && Reg.CheckNameSurename(albom.Name)
                && Reg.CheckNameSurename(albom.BandName)
                && Reg.CheckNameSurename(albom.Genre))
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
