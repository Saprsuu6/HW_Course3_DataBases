using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicZ.Models;

namespace MusicZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Context context;

        public MainWindow()
        {
            InitializeComponent();
            //context = new Context();
            //
            //context.Clients.Add(new Client()
            //{
            //    Name = "Andry",
            //    Surename = "Saproigin",
            //    Phone = "0639450317",
            //    Password = "Lich25524",
            //    IsRegularClient = false
            //});
            //context.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Effect = new BlurEffect();
            
            var registrationAutorisation = new RegistrationAutorisation();
            registrationAutorisation.Owner = this;
            registrationAutorisation.ShowDialog();
        }
    }
}
