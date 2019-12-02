using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_E_SHOP
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            emailTextBox.Text = "Почта";
            emailTextBox.Foreground = Brushes.Gray;
            passwordTextBox.Password = "Пароль";//?
            passwordTextBox.Foreground = Brushes.Gray;
        }

        public static Client customer = new Client();
        public static int orderNumber;

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = emailTextBox.Text;
            string userPass = passwordTextBox.Password.ToString();

            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE AND `pass` = @uP", db.getConnection());
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = userEmail;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPass;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                string connStr = "server=localhost;port=3306;username=root;password=;database=e-shop";
                string sql = "SELECT * FROM `users` WHERE `email` = @uE AND `pass` = @uP";
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand sqlCom = new MySqlCommand(sql, connection);
                sqlCom.Parameters.Add("@uE", MySqlDbType.VarChar).Value = userEmail;
                sqlCom.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPass;
                connection.Open();
                sqlCom.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                var myData = dt.Select();

                for (int i = 0; i < myData.Length; i++)
                {
                    for (int j = 0; j < myData[i].ItemArray.Length; j++)
                    {
                        switch (j)
                        {
                            case 0: customer.Id = Convert.ToInt32(myData[i].ItemArray[j]); break;
                            case 1: customer.Email = myData[i].ItemArray[j].ToString(); break;
                            case 2: customer.Password = myData[i].ItemArray[j].ToString(); break;
                            case 3: customer.Name = myData[i].ItemArray[j].ToString(); break;
                            case 4: customer.Surname = myData[i].ItemArray[j].ToString(); break;
                            case 5: customer.Phone = myData[i].ItemArray[j].ToString(); break;
                            case 6: customer.Card = myData[i].ItemArray[j].ToString(); break;
                            case 7: customer.City = myData[i].ItemArray[j].ToString(); break;
                            case 8: customer.Street = myData[i].ItemArray[j].ToString(); break;
                        }
                    }
                }
                Random rnd = new Random();
                orderNumber = rnd.Next(10000, 99999);
                this.Hide();
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            else
            {
                MessageBox.Show("Логин или пароль был введен неверно!");
            }
        }

        private void emailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                emailTextBox.Text = "Почта";
                emailTextBox.Foreground = Brushes.Gray;
            }
        }

        private void emailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text == "Почта")
            {
                emailTextBox.Text = "";
                emailTextBox.Foreground = Brushes.Black;
            }
        }

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Password == "")
            {
                passwordTextBox.Password = "Почта";
                passwordTextBox.Foreground = Brushes.Gray;
            }
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Password == "Пароль")
            {
                passwordTextBox.Password = "";
                passwordTextBox.Foreground = Brushes.Black;
            }
        }

        private void registrationLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Hide();
            WindowRegistration wr1 = new WindowRegistration();
            wr1.Show();
        }

        private void registrationLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            registrationLabel.Foreground = Brushes.LimeGreen;
        }

        private void registrationLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            registrationLabel.Foreground = Brushes.Black;
        }

        private void loginButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void loginButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
