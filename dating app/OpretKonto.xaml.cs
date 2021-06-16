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
using System.Data.SqlClient;
using System.Data;

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

        
        //public string conString = "Data Source=SKAB2-PC-02;Initial Catalog=datingApp;Integrated Security=True";
        SqlConnection con = new SqlConnection("Data Source=SKAB2-PC-02;Initial Catalog=datingApp;Integrated Security=True");
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brugernavn.Text == "" && Adgangskode.Text == "")
            {
                MessageBox.Show("Udfyld alle felterne");
            }
            else
            {
                //check name before save
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Account where values('" + Brugernavn.Text + "','" + Adgangskode.Text + "') ",con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    MessageBox.Show("velkommen " + Brugernavn.Text);
                }   
            }
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