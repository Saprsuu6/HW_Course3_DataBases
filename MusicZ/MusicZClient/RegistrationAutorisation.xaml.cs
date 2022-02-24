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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicZClient
{
    /// <summary>
    /// Interaction logic for RegistrationAutorisation.xaml
    /// </summary>
    public partial class RegistrationAutorisation : Window
    {
        public RegistrationAutorisation()
        {
            InitializeComponent();
            ViewModels.ViewModelAR.enter += new EventHandler<EventArgs>(Enter);
            ViewModels.ViewModelClient.close += new EventHandler<EventArgs>(CoseWindow);
        }

        private void CoseWindow(object sender, EventArgs e)
        {
            Owner.Close();
        }

        private void Enter(object sender, EventArgs e)
        {
            Owner.Effect = null; 
            Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Owner.Close();
        }
    }
}
