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

namespace dating_app
{
    /// <summary>
    /// Interaction logic for OpretKonto.xaml
    /// </summary>
    public partial class OpretKonto : Window
    {
        public OpretKonto()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du er nu logget ind");
            MainWindow tilbage = new MainWindow();
            tilbage.Show();
            this.Hide();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow tilbage = new MainWindow();
            tilbage.Show();
            this.Hide();
        }
    }
}