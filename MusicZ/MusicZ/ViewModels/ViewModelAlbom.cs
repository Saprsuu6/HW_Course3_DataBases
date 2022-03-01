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
    class ViewModelAlbom : INotifyPropertyChanged
    {
        private Context context;
        private Albom albom;
        private ObservableCollection<Albom> alboms;
        private RelayCommand command;

        public static event EventHandler<EventArgs> updateChecks = null;
        public static event EventHandler<EventArgs> updateAlboms = null;

        public ViewModelAlbom()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            Albom = new Albom();
            Alboms = new ObservableCollection<Albom>(WorkWithAlboms.GetAllAlboms(context));
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

        public RelayCommand Add
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    Albom albom = new Albom()
                    {
                        Name = this.albom.Name,
                        BandName = this.albom.BandName,
                        Publisher = this.albom.Publisher,
                        AmountTracks = this.albom.AmountTracks,
                        Quantity = this.albom.Quantity,
                        Genre = this.albom.Genre,
                        YearOfPublish = this.albom.YearOfPublish,
                        YearOfAdding = DateTime.Now,
                        CostPrice = this.albom.CostPrice,
                        PriceForSale = this.albom.PriceForSale,
                        Discount = this.albom.Discount
                    };

                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        await Task.Run(() => WorkWithAlboms.AddAlbom(context, albom));
                        MessageBox.Show("Albom was succesfully added.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Alboms.Insert(0, albom);
                        updateAlboms.Invoke(this, EventArgs.Empty);
                        updateChecks.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Albom was not succesfully added.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
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
                        await Task.Run(() => WorkWithAlboms.RemoveAlbom(context, albom));
                        MessageBox.Show("Albom was removed removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Alboms.Remove(albom);
                        updateAlboms.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Albom was not removed removed.", "Message",
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
                        await Task.Run(() => WorkWithAlboms.UpdateAlbom(context, albom));
                        MessageBox.Show("Albom was updated updated.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Albom was not succesfully updated.", "Message",
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
                        Alboms = new ObservableCollection<Albom>
                        (await Task.Run(() => WorkWithAlboms.GetAlboms(context, albom)));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Alboms was not finded.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand AllAlboms
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    Alboms = new ObservableCollection<Albom>(WorkWithAlboms.GetAllAlboms(context));
                    MessageBox.Show("Alboms was succesfully loaded.", "Message",
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
                    Albom = new Albom();
                });
            }
        }

        private bool CanOnClick()
        {
            if (albom != null && Reg.CheckNameSurename(albom.Name)
                && Reg.CheckNameSurename(albom.BandName)
                && Reg.CheckNameSurename(albom.Publisher)
                && Reg.CheckNumber(albom.AmountTracks.ToString())
                && Reg.CheckNameSurename(albom.Genre)
                && Reg.CheckNumber(albom.YearOfPublish.ToString())
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
