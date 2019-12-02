using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        public WindowOrder()
        {
            InitializeComponent();

            label2.Content = "Заказ № " + WindowLogin.orderNumber; 
            Basket.StartForm(basketBox, basketTotalPriceBox);

            nameField.Text = WindowLogin.customer.Name;
            surnameField.Text = WindowLogin.customer.Surname;
            emailField.Text = WindowLogin.customer.Email;
            phoneField.Text = WindowLogin.customer.Phone;
            cityField.Text = WindowLogin.customer.City;
            streetField.Text = WindowLogin.customer.Street;
            cardField.Text = WindowLogin.customer.Card;
        }

        private void basketBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Basket.RemoveItem(basketBox, basketTotalPriceBox);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заказ оформлен. Ожидайте звонка курьера.");
            Close();
        }
    }

    public static class DtHelper
    {
        public static DateTime myTimeStart
        {
            get { return DateTime.Today.AddDays(+1); }
        }

        public static DateTime myTimeEnd
        {
            get { return DateTime.Today.AddDays(+14); }
        }
    }
}
