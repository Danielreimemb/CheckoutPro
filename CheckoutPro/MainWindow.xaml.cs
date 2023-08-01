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
using static CheckoutPro.Class.ClassProduct;

namespace CheckoutPro
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {

            Produkt produkt = new Produkt();
            produkt.Name = "neues Produkt";
            produkt.Preis = 10.0;
            produkt.Farbe = "#1976d2";
            produkt.Gruppe = "Gruppe 1";

            ListboxMainWindowProducts.Items.Add(produkt);

        }

        private void ListboxMainWindowProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListboxMainWindowProducts.SelectedItem != null)
            {
                Produkt produkt = ListboxMainWindowProducts.SelectedItem as Produkt;


                MessageBox.Show(produkt.Name + produkt.Preis.ToString() + produkt.Gruppe);

            }
        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ListboxMainWindowProducts.SelectedItem  != null)
            {
                ListboxMainWindowProducts.Items.Remove(ListboxMainWindowProducts.SelectedItem);
            }
        }
    }
}
