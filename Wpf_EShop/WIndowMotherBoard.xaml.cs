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
    /// Логика взаимодействия для WIndowMotherBoard.xaml
    /// </summary>
    public partial class WIndowMotherBoard : Window
    {
        public WIndowMotherBoard()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Basket.StartForm(basketBox, basketTotalPriceBox);
        }

        Basket m1 = new Basket() { Name = "MSI B450 Tomahawk Max", Price = 230, Id = 284811 };
        Basket m2 = new Basket() { Name = "MSI MAG Z390 Tomahawk", Price = 290, Id = 205515 };
        Basket m3 = new Basket() { Name = "MSI Z390-A Pro", Price = 345, Id = 297515 };
        Basket m4 = new Basket() { Name = "MSI B360M Pro-VD", Price = 399, Id = 201585 };
        Basket m5 = new Basket() { Name = "Gigabyte GA-A320M-S 2H V2", Price = 190, Id = 291459 };
        Basket m6 = new Basket() { Name = "Gigabyte B450 Aorus", Price = 245, Id = 215537 };
        Basket m7 = new Basket() { Name = "Gigabyte B450M DS3H", Price = 280, Id = 249004 };
        Basket m8 = new Basket() { Name = "Gigabyte B450 Aorus M", Price = 325, Id = 259190 };

        private void button1_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, m8);
        }

        private void basketBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Basket.RemoveItem(basketBox, basketTotalPriceBox);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            if (Basket.sas.Count == 0)
            {
                MessageBox.Show("Сначала добавьте товар в корзину!");
            }
            else
            {
                Hide();
                WindowOrder wo1 = new WindowOrder();
                wo1.Show();
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Basket.ClearBasket(basketBox, basketTotalPriceBox);
        }

        private void buttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
