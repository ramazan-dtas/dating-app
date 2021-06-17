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

namespace dating_app
{
    /// <summary>
    /// Interaction logic for user_screen.xaml
    /// </summary>
    public partial class user_screen : Window
    {
        public user_screen()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=SKAB2-PC-02;Initial Catalog=datingApp;Integrated Security=True";

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            Welcome.Text = "Velkommen " + Application.Current.Resources["curUser"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string delete = "delete from Account where Username='" + Application.Current.Resources["curUser"].ToString() +"'";
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Slettet");
            this.Close();
            con.Close();
        }
    }
}