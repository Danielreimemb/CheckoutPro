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
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindowInstance;


        public MainWindow()
        {
            InitializeComponent();
            NormalStartup();
            mainWindowInstance = this;
        }


        #region MainWindow Header Buttons

        private void ButtonHeaderSettings_Click(object sender, EventArgs e)
        {
            //Settings
            WindowSettings windowSettings = new WindowSettings();
            windowSettings.Show();

        }
        private void ButtonHeaderInfo_Click(object sender, RoutedEventArgs e)
        {
            //Info
            WindowSoftwareInfo windowSoftwareInfo = new WindowSoftwareInfo();
            windowSoftwareInfo.Show();
        }
        private void ButtonHeaderUser_Click(object sender, RoutedEventArgs e)
        {
            //User
            WindowUserInfo windowUserInfo = new WindowUserInfo();
            windowUserInfo.Show();
        }
        private void ButtonExitApplication_Click(object sender, RoutedEventArgs e)
        {
            // Funktion Fehlt noch
            this.Close();
        }


        #endregion

        #region MainWindow Produkte Buttons über Listbox

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

            WindowProductItem.windowProductItemInstance.TextblockHeader.Text = "Element hinzufügen";

            //// Neues Produkt

            //Produkt produkt = new Produkt();
            //produkt.Name = "Produkt";
            //produkt.Preis = 10.0;
            //produkt.Farbe = "#1976d2";
            //produkt.Gruppe = "Gruppe 1";

            //ListboxMainWindowProducts.Items.Add(produkt);

            

        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

            WindowProductItem.windowProductItemInstance.TextblockHeader.Text = "Element bearbeiten";

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
            if(DataGridPurchase.SelectedItem != null)
            {
                DataGridPurchase.Items.Remove(DataGridPurchase.SelectedItem);
            }
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

                int AnzahlfromPurchaseProductWindow = 1;


                WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductName.Text = produkt.Name;
                WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductBeschreibung.Text = produkt.Desc;
                WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreis.Text = produkt.Preis.ToString();
                WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreisSumme.Text = produkt.Preis.ToString();

                WindowPurchaseProduct.windowPurchaseProductinstance.ProductPrice = produkt.Preis;

                //TextBoxCurrentPurchase.Text += AnzahlfromPurchaseProductWindow.ToString() + "x " + produkt.Name.ToString() + " " + produkt.Preis.ToString() + "\r";


                ListboxMainWindowProducts.SelectedItem = null;
            }
        }




        private string FormatPurchaselLine(string ProductName, string ProductPrice, string ProductCount)
        {
            // Product Name = asdflnbsaödfmäasdf
            // Product Price = 3,45€
            // Product Count = 12x





            int QuittungsTextmaxlenght = 36;

            // 2x TextTextTextTextTextText    3,00€
            // 123456789012345678901234567890123456


            // 2x TextTextTextTextTextTextTextTextT
            // TextTextTextTextTextTextTextTextText
            //                                3,00€
            //
            //


            // 6 Zeichen für Preis frei
            // 3 Zeichen für Anzahl / 4 Zeichen
            


            if(ProductCount.Length == 2)
            {
                int VerfügbareLängeZeile = QuittungsTextmaxlenght - 3;
                int VerwendeteLängePreis = ProductPrice.Length + 1;
                int VerfügbareLängeName = VerfügbareLängeZeile - VerwendeteLängePreis;

                if (ProductName.Length <= VerfügbareLängeName) //Name passt in Zeile
                {
                    


                    return ProductCount + " " + ProductName + "{0,8}" + ProductPrice;
                }


            }










            if(ProductCount.Length == 3)
            {
                int VerfügbareLängeText = QuittungsTextmaxlenght - 4;
            }




                



            return "";
        }



        private string FormatPurchaseQuittung(string text)
        {
            return "";
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
                myOutputStream.WriteLine(produkt.ID + ";" + produkt.Name + ";" + produkt.Desc + ";" + produkt.Icon + ";" + produkt.Preis.ToString() + ";" + produkt.BackgroundColor + ";" + produkt.BorderColor + ";" + produkt.Group ) ;
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
                    Produkt produkt = new Produkt(values[0], values[1], values[2], values[3], Convert.ToDouble(values[4]), values[5], values[6], values[7]);
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
