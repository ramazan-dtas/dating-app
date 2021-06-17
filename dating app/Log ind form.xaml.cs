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
    /// Interaction logic for Log_ind_form.xaml
    /// </summary>
    public partial class Log_ind_form : Window
    {
        public Log_ind_form()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=SKAB2-PC-02;Initial Catalog=datingApp;Integrated Security=True";

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Brugernavn.Text == "" && Adgangskode.Text == "" && mail.Text == "")
            {
                MessageBox.Show("Udfyld alle felterne");
                this.Hide();
                this.Show();
            }
            
            else
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    //checks if username  is in database
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Account where Username = '" + Brugernavn.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Brugernavn findes. Vælg en ny Brugernavn");
                    }

                    else
                    {
                        //save in the database
                        
                        SqlCommand comd = new SqlCommand("insert into Account(Username, Password, Email) values('" + Brugernavn.Text.ToString() + "','" + Adgangskode.Text.ToString() + "','" + mail.Text.ToString() + "')", con);
                        comd.ExecuteNonQuery();
                        con.Close();
                        Brugernavn.Text = "";
                        MessageBox.Show("Konto oprettet!!!");
                        this.Hide();
                        MainWindow tilbage = new MainWindow();
                        tilbage.Show();
                    }
                }
                MainWindow main = new MainWindow();
                main.Show();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow tilbage = new MainWindow();
            tilbage.Show();
            this.Hide();
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}