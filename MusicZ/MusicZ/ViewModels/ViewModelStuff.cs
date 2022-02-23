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
    internal class ViewModelStuff : INotifyPropertyChanged
    {
        private Context context;
        private Stuff stuff;
        private ObservableCollection<Stuff> stuffs;
        private RelayCommand command;

        public ViewModelStuff()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            stuff = new Stuff();
            stuffs = new ObservableCollection<Stuff>(WorkWithStuffs.GetAllStuff(context));
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

        public RelayCommand Add
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    Stuff stuff = new Stuff()
                    {
                        Name = this.stuff.Name,
                        Surename = this.stuff.Surename,
                        Phone = this.stuff.Phone,
                        Password = this.stuff.Password,
                        ProcentFromsale = this.stuff.ProcentFromsale,
                    };

                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    try
                    {
                        await Task.Run(() => WorkWithStuffs.AddStuff(context, stuff));
                        MessageBox.Show("Stuff was succesfully added.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        Stuffs.Insert(0, stuff);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Stuff was not succesfully added.", "Message",
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
                        await Task.Run(() => WorkWithStuffs.RemoveStuff(context, stuff));
                        MessageBox.Show("Stuff was removed removed.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Stuff was not removed removed.", "Message",
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
                        await Task.Run(() => WorkWithStuffs.UpdateStuff(context, stuff));
                        MessageBox.Show("Stuff was updated updated.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Stuff was not succesfully updated.", "Message",
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
                        Stuffs = new ObservableCollection<Stuff>
                        (await Task.Run(() => WorkWithStuffs.GetStuffs(context, stuff)));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Stuff was not finded.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }, obj => CanOnClick());
            }
        }

        public RelayCommand AllStuffs
        {
            get
            {
                return command = new RelayCommand(obj =>
                {
                    stuffs = new ObservableCollection<Stuff>(WorkWithStuffs.GetAllStuff(context));
                    MessageBox.Show("Stuffs was succesfully loaded.", "Message",
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
                    Stuff = new Stuff();
                });
            }
        }

        private bool CanOnClick()
        {
            if (stuff != null && Reg.CheckNameSurename(stuff.Name)
                && Reg.CheckNameSurename(stuff.Surename)
                && Reg.CheckNumberPhone(stuff.Phone)
                && Reg.CheckPassword(stuff.Password)
                && Reg.CheckNumber(stuff.ProcentFromsale.ToString()))
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
