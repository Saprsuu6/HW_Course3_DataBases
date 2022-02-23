using MusicZ.Command;
using MusicZ.Models;
using MusicZ.Regular;
using MusicZ.WorkWithBases;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicZ.ViewModels
{
    internal class ViewModelAR : INotifyPropertyChanged
    {
        private Context context;
        private Stuff stuff;
        private RelayCommand command;

        public ViewModelAR()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            context = new Context();
            Stuff = new Stuff();
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

        public RelayCommand SingUp
        {
            get
            {
                return command = new RelayCommand(async obj =>
                {
                    MessageBox.Show("Loading...", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    Stuff stuff = new Stuff()
                    {
                        Name = this.stuff.Name,
                        Surename = this.stuff.Surename,
                        Password = this.stuff.Password,
                        Phone= this.stuff.Phone,
                    };

                    try
                    {
                        await Task.Run(() => WorkWithStuffs.AddStuff(context, stuff));
                        MessageBox.Show("You was succesfully registred.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
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
                        Stuff stuff = await Task.Run
                        (() => WorkWithStuffs.GetStuff(context, this.stuff));
                        MessageBox.Show("You was succesfully loged in.", "Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
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
