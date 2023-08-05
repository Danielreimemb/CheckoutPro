using CheckoutPro.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            NormalStartup();
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
            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

            // Neues Produkt

            Produkt produkt = new Produkt();
            produkt.Name = "Produkt";
            produkt.Preis = 10.0;
            produkt.Farbe = "#1976d2";
            produkt.Gruppe = "Gruppe 1";

            ListboxMainWindowProducts.Items.Add(produkt);

            

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

        private void ButtonSaveProducts_Click(object sender, RoutedEventArgs e)
        {
            SaveProductstoFile();
            System.Windows.Forms.MessageBox.Show("Gespeichert!!!");
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

        private void NormalStartup()
        {
            LoadProductsfromFile();
        }




        private void SaveProductstoFile()
        {
            StreamWriter myOutputStream = new StreamWriter("Database.csv");
            foreach (Produkt produkt in ListboxMainWindowProducts.Items)
            {
                myOutputStream.WriteLine(produkt.Name + ";" +produkt.Gruppe + ";"+produkt.Farbe + ";" + produkt.Preis);
            }
            myOutputStream.Close();
        }

        private void LoadProductsfromFile()
        {
            string curFile = @"Database.csv";
            if (File.Exists(curFile))
            {
                StreamReader myInputStream = new StreamReader("Database.csv");
                while (!myInputStream.EndOfStream)
                {
                    string line = myInputStream.ReadLine();
                    string[] values = line.Split(';');
                    Produkt produkt = new Produkt(values[0], values[1], values[2], Convert.ToDouble(values[3]));
                    ListboxMainWindowProducts.Items.Add(produkt);
                }
                myInputStream.Close();
            }
            else 
            {
                System.Windows.Forms.MessageBox.Show("Datenbank konnte nicht gefunden werden");
            }


                

        }


































        #endregion

        
    }
}
