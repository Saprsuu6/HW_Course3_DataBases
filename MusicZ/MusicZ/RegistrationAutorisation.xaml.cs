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
using System.Windows.Shapes;

namespace MusicZ
{
    /// <summary>
    /// Interaction logic for RegistrationAutorisation.xaml
    /// </summary>
    public partial class RegistrationAutorisation : Window
    {
        public RegistrationAutorisation()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Owner.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Effect = null;
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Owner.Effect = null;
            Hide();
        }
    }
}
