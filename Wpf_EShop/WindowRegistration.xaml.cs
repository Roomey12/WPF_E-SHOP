using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            NameField.Text = "Имя";
            NameField.Foreground = Brushes.Gray;
            SurnameField.Text = "Фамилия";
            SurnameField.Foreground = Brushes.Gray;
            PhoneField.Text = "Номер телефона";
            PhoneField.Foreground = Brushes.Gray;
            CardField.Text = "Номер карты";
            CardField.Foreground = Brushes.Gray;
            CityField.Text = "Город";
            CityField.Foreground = Brushes.Gray;
            StreetField.Text = "Улица";
            StreetField.Foreground = Brushes.Gray;
            EmailField.Text = "Почта";
            EmailField.Foreground = Brushes.Gray;
            PassField.Password = "Пароль";
            PassField.Foreground = Brushes.Gray;
        }

        private void loginLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            loginLabel.Foreground = Brushes.LimeGreen;
        }

        private void loginLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            loginLabel.Foreground = Brushes.Black;
        }

        private void NameField_LostFocus(object sender, RoutedEventArgs e)
        {
            RegularCheck(NameField);
            if (NameField.Text == "")
            {
                NameField.Text = "Имя";
                NameField.Foreground = Brushes.Gray;
            }
        }

        private void NameField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameField.Text == "Имя")
            {
                NameField.Text = "";
                NameField.Foreground = Brushes.Black;
            }
        }

        private void PhoneField_LostFocus(object sender, RoutedEventArgs e)
        {
            if(PhoneField.Text.Length > 0)
            {
                Regex regex = new Regex(@"^\d[\d\(\)\ -]{8,14}\d$");
                Match match = regex.Match(PhoneField.Text);
                if (!match.Success)
                {
                    MessageBox.Show("Значение должно состоять только из чисел и иметь длину от 8 до 14 символов!");
                    PhoneField.Text = "";
                }
            }

            if (PhoneField.Text == "")
            {
                PhoneField.Text = "Номер телефона";
                PhoneField.Foreground = Brushes.Gray;
            }
        }

        private void PhoneField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneField.Text == "Номер телефона")
            {
                PhoneField.Text = "";
                PhoneField.Foreground = Brushes.Black;
            }
        }

        private void CityField_LostFocus(object sender, RoutedEventArgs e)
        {
            RegularCheck(CityField);
            if (CityField.Text == "")
            {
                CityField.Text = "Город";
                CityField.Foreground = Brushes.Gray;
            }
        }

        private void CityField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CityField.Text == "Город")
            {
                CityField.Text = "";
                CityField.Foreground = Brushes.Black;
            }
        }

        private void EmailField_LostFocus(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            //Переменная pattern задает регулярное выражение для проверки адреса электронной почты. 
            //Данное выражение предлагает нам Microsoft на страницах msdn.
            if(EmailField.Text.Length > 0)
            {
                if (Regex.IsMatch(EmailField.Text, pattern, RegexOptions.IgnoreCase) == false)
                {
                    MessageBox.Show("Введен некоректный email. Попробуйте снова!");
                    EmailField.Text = "";
                }
            }
            if (EmailField.Text == "")
            {
                EmailField.Text = "Почта";
                EmailField.Foreground = Brushes.Gray;
            }
        }

        private void EmailField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailField.Text == "Почта")
            {
                EmailField.Text = "";
                EmailField.Foreground = Brushes.Black;
            }
        }

        private void SurnameField_LostFocus(object sender, RoutedEventArgs e)
        {
            RegularCheck(SurnameField);
            if (SurnameField.Text == "")
            {
                SurnameField.Text = "Фамилия";
                SurnameField.Foreground = Brushes.Gray;
            }
        }

        private void SurnameField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameField.Text == "Фамилия")
            {
                SurnameField.Text = "";
                SurnameField.Foreground = Brushes.Black;
            }
        }

        private void CardField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CardField.Text.Length > 0)
            {
                try
                {
                    long ab = Convert.ToInt64(CardField.Text);
                }
                catch (FormatException)
                {

                    MessageBox.Show("Значение должно состоять из цифр и иметь длину 16 символов.");
                }
            }

            if (CardField.Text == "")
            {
                CardField.Text = "Номер карты";
                CardField.Foreground = Brushes.Gray;
            }
        }

        private void CardField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CardField.Text == "Номер карты")
            {
                CardField.Text = "";
                CardField.Foreground = Brushes.Black;
            }
        }

        private void StreetField_LostFocus(object sender, RoutedEventArgs e)
        {
            RegularCheck(StreetField);
            if (StreetField.Text == "")
            {
                StreetField.Text = "Улица";
                StreetField.Foreground = Brushes.Gray;
            }
        }

        private void StreetField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StreetField.Text == "Улица")
            {
                StreetField.Text = "";
                StreetField.Foreground = Brushes.Black;
            }
        }

        private void PassField_LostFocus(object sender, RoutedEventArgs e)
        {
            if(PassField.Password.Length < 6)
            {
                MessageBox.Show("Пароль должен состоять как минимум из 6 символов!");
                PassField.Password = "";
            }
            if (PassField.Password == "")
            {
                PassField.Password = "Имя";
                PassField.Foreground = Brushes.Gray;
            }
        }

        private void PassField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PassField.Password == "Имя")
            {
                PassField.Password = "";
                PassField.Foreground = Brushes.Black;
            }
        }

        private void regButton_MouseEnter(object sender, MouseEventArgs e)
        {
            regButton.Background = Brushes.LimeGreen;
        }

        private void loginLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Hide();
            WindowLogin wl = new WindowLogin();
            wl.Show();
        }




        public bool isUserExists()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE", db.getConnection());
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = EmailField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Аккаунт с такой почтой уже зарегистрирован.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            string prmAlert = "Введите: \n";
            if (NameField.Text == "Имя")
            {
                prmAlert += "\tимя, \n";
            }
            if (SurnameField.Text == "Фамилия")
            {
                prmAlert += "\tфамилию, \n";
            }
            if (PhoneField.Text == "Номер телефона")
            {
                prmAlert += "\tномер телефона, \n";
            }
            if (CardField.Text == "Номер карты")
            {
                prmAlert += "\tномер карты, \n";
            }
            if (StreetField.Text == "Улица")
            {
                prmAlert += "\tулицу, \n";
            }
            if (EmailField.Text == "Почта")
            {
                prmAlert += "\tпочту, \n";
            }
            if (PassField.Password == "Пароль")
            {
                prmAlert += "\tпароль. \n";
            }
            if (CityField.Text == "Город")
            {
                prmAlert += "\tгород, \n";
                MessageBox.Show(prmAlert);
                return;
            }

            if (isUserExists()) { return; }

            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`email`, `pass`, `name`, `surname`, `phone`, `card`, `city`, `street`) " +
                "VALUES (@email, @pass, @name, @surname, @phone, @card, @city, @street)", db.getConnection());
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = EmailField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassField.Password;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@phone", MySqlDbType.Int64).Value = PhoneField.Text;
            command.Parameters.Add("@card", MySqlDbType.Int64).Value = CardField.Text;
            command.Parameters.Add("@city", MySqlDbType.VarChar).Value = CityField.Text;
            command.Parameters.Add("@street", MySqlDbType.VarChar).Value = StreetField.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был успешно создан!");
                Hide();
                MainWindow mw5 = new MainWindow();
                mw5.Show();
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан.");
            }

            db.closeConnection();
        }

        private void RegularCheck(TextBox Field)
        {
            if(Field.Text.Length > 0)
            {
                Regex regex = new Regex(@"^[А-ЯЁ][а-яё]+$");
                Match match = regex.Match(Field.Text);
                if (!match.Success)
                {
                    MessageBox.Show("Значение должно начинаться с большой буквы и состоять только из букв русского алфавита!");
                    Field.Text = "";
                }
            }
        }
    }
}
