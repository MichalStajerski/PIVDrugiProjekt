using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;


namespace projektv2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
   
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string password = ChangeToString.SecureStringToString(MyPasswordBox.SecurePassword); 
          

            string connectionString = "Data Source=DESKTOP-IURIS93\\MSSQL;Initial Catalog = Bank;User ID=sa;Password=yxofton1;Connect Timeout = 30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            var query = "INSERT INTO Klient(Imię,Nazwisko,Hasło) VALUES (@Imię, @Nazwisko, @Hasło)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Imię", MyNameTextbox.Text);
            cmd.Parameters.AddWithValue("Nazwisko", MySurnameTextbox.Text);
            cmd.Parameters.AddWithValue("Hasło", password);


            int d = cmd.ExecuteNonQuery();

            
          
            if (d != 0)
            {
                MessageBox.Show("Zarejestrowano użytkownika!");
            }
            else
            {
                MessageBox.Show("Błąd");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }
    }
}
