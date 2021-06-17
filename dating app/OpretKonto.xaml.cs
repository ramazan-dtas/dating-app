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

        
        SqlConnection con = new SqlConnection("Data Source=SKAB2-PC-02;Initial Catalog=datingApp;Integrated Security=True");
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brugernavn.Text == "" && Adgangskode.Text == "")
            {
                MessageBox.Show("Udfyld alle felterne");
            }
            else
            {

                string brugernavn = Brugernavn.Text;
                string password = Adgangskode.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Account where Username='" + brugernavn + "'  and Password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    Application.Current.Resources["curUser"] = dataSet.Tables[0].Rows[0]["Username"].ToString();
                    MessageBox.Show("Du er nu logget ind " + dataSet.Tables[0].Rows[0]["Username"].ToString());
                    this.Close();
                    user_screen user = new user_screen();
                    user.Show();
                }
                else
                {
                    MessageBox.Show("Sorry! Please enter existing emailid/password.");
                }
                con.Close();

            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow tilbage = new MainWindow();
            tilbage.Show();
            this.Hide();
        }

        private void Brugernavn_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }
    }
}