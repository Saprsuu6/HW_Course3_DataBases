using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Sailer sailer;
        private Fridge fridge;
        private Bueyr bueyr;
        private ObservableCollection<Sailer> sailers;
        private ObservableCollection<Fridge> fridges;
        private BaseOfFridges baseOfFridges;
        private BaseOfSailers baseOfSailers;
        private BaseOfBuyers baseOfBuyers;
        private RelayCommand command;

        public ViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            fridge = new Fridge();
            sailer = new Sailer();
            bueyr = new Bueyr();
            baseOfFridges = new BaseOfFridges();
            baseOfSailers = new BaseOfSailers();
            baseOfBuyers = new BaseOfBuyers();

            FillFridges();
            FillSailers();
        }

        private async void FillSailers()
        {
            try
            {
                List<Sailer> sailers = await Task.Run(() => baseOfSailers.GetAllSailers());
                Sailers = new ObservableCollection<Sailer>(sailers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void FillFridges()
        {
            try
            {

                List<Fridge> fridges = await Task.Run(() => baseOfFridges.GetAllFridges());
                Fridges = new ObservableCollection<Fridge>(fridges);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public Bueyr Bueyr
        {
            get { return bueyr; }
            set
            {
                bueyr = value;
                OnPropertyChanged(nameof(Bueyr));
            }
        }

        public Sailer Sailer
        {
            get { return sailer; }
            set
            {
                sailer = value;
                OnPropertyChanged(nameof(Sailer));
            }
        }

        public Fridge Fridge
        {
            get { return fridge; }
            set
            {
                fridge = value;
                bueyr.Id_Fridge = fridge.Id;
                OnPropertyChanged(nameof(Fridge));
            }
        }

        public ObservableCollection<Sailer> Sailers
        {
            get { return sailers; }
            set
            {
                sailers = value;
                OnPropertyChanged(nameof(Sailers));
            }
        }

        public ObservableCollection<Fridge> Fridges
        {
            get { return fridges; }
            set
            {
                fridges = value;
                OnPropertyChanged(nameof(Fridges));
            }
        }

        public RelayCommand ClearFields
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Bueyr = new Bueyr();
                    Fridge = new Fridge();
                }, obj => CanClear());
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
                        Sailer sailer = baseOfSailers.GetSailerById(fridge.Id_Saler);

                        Check check = new Check()
                        {
                            Date = DateTime.UtcNow,
                            ClientName = bueyr.Name,
                            ClientSurename = bueyr.Surename,
                            SellerName = sailer.Name,
                            SellerSurename = sailer.Surename,
                            FridgeName = fridge.Name,
                            FridgePrice = fridge.Price
                        };

                        Task t1 = Task.Run(() => baseOfBuyers.AddPersonToBase(bueyr.Clone()));
                        Task t2 = Task.Run(() => check.SaveInXml());
                        await Task.WhenAll(t1, t2);

                        MessageBox.Show("Buying was succesfully.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        MessageBox.Show("You are client of our magasine.", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Buying was unsuccesfully. Please try again", "",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanBuy());
            }
        }

        public RelayCommand Find
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    List<Fridge> fridges1 =
                    await Task.Run(() => baseOfFridges.GetFridgesByPrice(fridge.Price));
                    List<Fridge> fridges2 = 
                    await Task.Run(() => baseOfFridges.GetFridgesByName(fridge.Name));

                    Fridges.Clear();
                    
                    foreach (Fridge fridge in fridges1)
                        Fridges.Add(fridge);

                    foreach (Fridge fridge in fridges2)
                        Fridges.Add(fridge);
                }, obj => CanFind());
            }
        }

        private bool CanFind()
        {
            if (fridge.Name != null && fridge.Name.Trim() != "" ||
                    fridge.Price != 0)
                return true;

            return false;
        }

        private bool CanBuy()
        {
            if (fridge.Name != null && fridge.Name.Trim() != "" &&
                bueyr.Name != null && bueyr.Name.Trim() != "")
                return true;

            return false;
        }

        private bool CanClear()
        {
            if ((bueyr.Name != null && bueyr.Name.Trim() != ""
                && bueyr.Surename != null && bueyr.Surename.Trim() != "")
                || (fridge.Name != null && fridge.Name.Trim() != ""
                && fridge.Price != 0))
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
