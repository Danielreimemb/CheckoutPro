using CheckoutPro.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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


        #region MainWindow Header Buttons

        private void ButtonHeaderSettings_Click(object sender, EventArgs e)
        {
            //Settings
        }
        private void ButtonHeaderInfo_Click(object sender, RoutedEventArgs e)
        {
            //Info
        }
        private void ButtonHeaderUser_Click(object sender, RoutedEventArgs e)
        {
            //User
        }
        private void ButtonExitApplication_Click(object sender, RoutedEventArgs e)
        {
            // Funktion Fehlt noch
        }


        #endregion

        #region MainWindow Produkte Buttons über Listbox

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            

            Produkt produkt = new Produkt();
            produkt.Name = "Produkt";
            produkt.Preis = 10.0;
            produkt.Farbe = "#1976d2";
            produkt.Gruppe = "Gruppe 1";

            ListboxMainWindowProducts.Items.Add(produkt);

            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ListboxMainWindowProducts.SelectedItem != null)
            {
                ListboxMainWindowProducts.Items.Remove(ListboxMainWindowProducts.SelectedItem);
            }
        }

        #endregion

        #region MainWindow Zusammenfassung Buttons über Zusammenfassung DataGrid

        private void ButtonPrintLabel_Click(object sender, RoutedEventArgs e)
        {
            WindowPrintSettings windowPrintSettings = new WindowPrintSettings();
            windowPrintSettings.Show();
        }

        private void ButtonDeleteEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCalculator_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "calc.exe";
            psi.UseShellExecute = true;
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }



        #endregion

        #region MainWindow Background Worker


        private void ListboxMainWindowProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListboxMainWindowProducts.SelectedItem != null)
            {
                WindowPurchaseProduct windowPurchaseProduct = new WindowPurchaseProduct();
                windowPurchaseProduct.Show();

                Produkt produkt = ListboxMainWindowProducts.SelectedItem as Produkt;

                //MessageBox.Show(produkt.Name + produkt.Preis.ToString() + produkt.Gruppe);

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Wollen Sie das Programm beenden?", "My Application", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

                System.Windows.Forms.Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }


        #endregion


        // -- Methods --
        #region Methods

        private void InitialStartup()
        {

        }



        private void SaveProductstoFile()
        {
            // CSV File 
            // Anzahl;ProductName;Preis;Gruppe
            // Path is Root
            // Name is Store




        }

        private void LoadProductsfromFile()
        {
            // CSV File 
            // Anzahl;ProductName;Preis;Gruppe
            // Path is Root
            // Name is Store


        }


































        #endregion

    }
}
