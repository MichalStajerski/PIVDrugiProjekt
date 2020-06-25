using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace projektv2
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string text;
        private string textt;

        public LoginWindow()
        {
            InitializeComponent();
        }


 

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

       

        private void LoginButoon_Click(object sender, RoutedEventArgs e)
        {
             
        string connectionString = "Data Source=DESKTOP-IURIS93\\MSSQL;Initial Catalog = Bank;User ID=sa;Password=yxofton1;Connect Timeout = 30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            
            string password = ChangeToString.SecureStringToString(LoginPasswordBox.SecurePassword);
            

            SqlConnection  loginconnection = new SqlConnection(connectionString);
            try
            {
                if(loginconnection.State == ConnectionState.Closed)
                {
                    loginconnection.Open();
                    string query = "SELECT COUNT(1) FROM Klient WHERE Imię=@Imię AND Nazwisko=@Nazwisko AND Hasło=@Hasło";
                    SqlCommand cma = new SqlCommand(query, loginconnection);
                    cma.CommandType = CommandType.Text;
                    cma.Parameters.AddWithValue("@Imię",LoginNameBox.Text);
                    cma.Parameters.AddWithValue("@Nazwisko",LoginSurnameBox.Text);
                    cma.Parameters.AddWithValue("@Hasło",password);

                    int check = Convert.ToInt32(cma.ExecuteScalar());
                    if(check == 1)
                    {
                        text = LoginNameBox.Text;
                        textt = LoginSurnameBox.Text;

                        AccountWindow aw = new AccountWindow(text,textt);
                        aw.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wpisano niepoprawne dane");
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                loginconnection.Close();
            }
        }
    }
}
