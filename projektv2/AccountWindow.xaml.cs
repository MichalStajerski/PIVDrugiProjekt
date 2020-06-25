using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projektv2
{
    /// <summary>
    /// Logika interakcji dla klasy AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {

      
        public AccountWindow()
        {
            InitializeComponent();
        
        }

        public AccountWindow(string text, string textt) : this()
        {
            AccountNameLabel.Content = text;
            AccountSurnameLabel.Content = textt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mww = new MainWindow();
            mww.Show();
            this.Close();
        }


 
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-IURIS93\\MSSQL;Initial Catalog = Bank;User ID=sa;Password=yxofton1;Connect Timeout = 30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";




            SqlConnection accountconnection = new SqlConnection(connectionString);

            accountconnection.Open();

            int a =Convert.ToInt32(AccountPaymentBox.Text);

            var query = "UPDATE Klient SET Gotówka=+@Gotówka WHERE Imię=@Imię AND Nazwisko=@Nazwisko";
            SqlCommand cmn = new SqlCommand(query, accountconnection);
            cmn.Parameters.AddWithValue("Imię",AccountNameLabel.Content);
            cmn.Parameters.AddWithValue("Nazwisko",AccountSurnameLabel.Content);
            cmn.Parameters.AddWithValue("Gotówka", a);



            int n = cmn.ExecuteNonQuery();



            if (n != 0)
            {
                MessageBox.Show("Wpłacono pieniądze!");
            }
            else
            {
                MessageBox.Show("Błąd");
            }


        }
    }
}
