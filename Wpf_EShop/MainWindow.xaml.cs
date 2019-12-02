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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_E_SHOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Basket.StartForm(basketBox, basketTotalPriceBox);
            foreach (Button item in gridMain.Children.OfType<Button>())
            {
                item.Background = Brushes.White;
            }
            foreach (Button item in stackBasket.Children.OfType<Button>())
            {
                item.Background = Brushes.White;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WindowGraphicCard win2 = new WindowGraphicCard();
            win2.Show();
            Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Basket.ClearBasket(basketBox, basketTotalPriceBox);
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WIndowMotherBoard mb = new WIndowMotherBoard();
            mb.Show();
            Close();
        }
    }
}
