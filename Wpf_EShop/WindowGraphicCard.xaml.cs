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
    public partial class WindowGraphicCard : Window
    {
        public WindowGraphicCard()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Basket.StartForm(basketBox, basketTotalPriceBox);
        }

        Basket g1 = new Basket() { Name = "Nvidia Geforce GTX 1050 Ti", Price = 500, Id = 198511 };
        Basket g2 = new Basket() { Name = "Nvidia Geforce GTX 1060 Ti", Price = 640, Id = 187515 };
        Basket g3 = new Basket() { Name = "Nvidia Geforce RTX 2060", Price = 710, Id = 125921 };
        Basket g4 = new Basket() { Name = "Nvidia Geforce RTX 2070", Price = 999, Id = 110818 };
        Basket g5 = new Basket() { Name = "AMD RX 470", Price = 300, Id = 158105 };
        Basket g6 = new Basket() { Name = "AMD RX 580", Price = 450, Id = 199182 };
        Basket g7 = new Basket() { Name = "AMD Radeon HD7450", Price = 840, Id = 178781 };
        Basket g8 = new Basket() { Name = "AMD Radeon HD7850", Price = 920, Id = 158299 };

        private void buttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Basket.ClearBasket(basketBox, basketTotalPriceBox);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Basket.AddToBasket(basketBox, basketTotalPriceBox, g8);
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
    }
}
