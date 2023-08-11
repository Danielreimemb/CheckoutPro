using CheckoutPro.Class;
using CheckoutPro.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
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
using System.Xml.Linq;
using static CheckoutPro.Class.ClassProduct;
using static CheckoutPro.Class.ClassMethodsPrinter;

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
            WindowSettings windowSettings = new WindowSettings();
            windowSettings.Show();
        }
        private void ButtonHeaderInfo_Click(object sender, RoutedEventArgs e)
        {
            WindowSoftwareInfo windowSoftwareInfo = new WindowSoftwareInfo();
            windowSoftwareInfo.Show();
        }
        private void ButtonHeaderUser_Click(object sender, RoutedEventArgs e)
        {
            WindowUserInfo windowUserInfo = new WindowUserInfo();
            windowUserInfo.Show();
        }
        private void ButtonExitApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion

        #region MainWindow Produkte Buttons über Listbox

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

            WindowProductItem.windowProductItemInstance.TextblockHeader.Text = "Element hinzufügen";           
        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleButtonEditProduct.IsChecked == true)
            {
                ProgressBarBottomMainWindow.Value = 100;
                ProgressBarBottomMainWindow.Foreground = Brushes.Orange;
                TextBlockLogOutputMainwindow.Text = "Produkte Bearbeiten Aktiv";
            }
            else
            {
                ProgressBarBottomMainWindow.Value = 0;
                ProgressBarBottomMainWindow.Foreground = Brushes.Gray;
                TextBlockLogOutputMainwindow.Text = "OK";

            }

        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ToggleButtonDeleteProduct.IsChecked == true)
            {
                ProgressBarBottomMainWindow.Value = 100;
                ProgressBarBottomMainWindow.Foreground = Brushes.Red;
                TextBlockLogOutputMainwindow.Text = "Produkte Löschen Aktiv";

            }
            else
            {
                ProgressBarBottomMainWindow.Value = 0;
                ProgressBarBottomMainWindow.Foreground = Brushes.Gray;
                TextBlockLogOutputMainwindow.Text = "OK";

            }
        }

        private void ButtonSaveProducts_Click(object sender, RoutedEventArgs e)
        {
            SaveProductstoFile();
            //System.Windows.Forms.MessageBox.Show("Gespeichert!!!");
        }

        #endregion

        #region MainWindow Zusammenfassung Buttons über Zusammenfassung DataGrid

        private void ButtonPrintLabel_Click(object sender, RoutedEventArgs e)
        {
            //WindowPrintSettings windowPrintSettings = new WindowPrintSettings();
            //windowPrintSettings.Show();

            ClassMethodsPrinter classMethodsPrinter = new ClassMethodsPrinter();
            classMethodsPrinter.Print();

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
                if(ToggleButtonDeleteProduct.IsChecked == false && ToggleButtonEditProduct.IsChecked == false)
                {
                    WindowPurchaseProduct windowPurchaseProduct = new WindowPurchaseProduct();
                    windowPurchaseProduct.Show();

                    Produkt produkt = ListboxMainWindowProducts.SelectedItem as Produkt;

                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductName.Text = produkt.Name;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductBeschreibung.Text = produkt.Desc;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreis.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreisSumme.Text = produkt.Preis.ToString();

                    WindowPurchaseProduct.windowPurchaseProductinstance.ProductPrice = produkt.Preis;
                }

                if (ToggleButtonEditProduct.IsChecked == true && ToggleButtonDeleteProduct.IsChecked == true)
                {
                    ToggleButtonDeleteProduct.IsChecked = false;
                    ToggleButtonEditProduct.IsChecked = true;
                }

                if (ToggleButtonEditProduct.IsChecked == true)
                {
                    WindowProductItem productItem = new WindowProductItem();
                    productItem.Show();


                    Produkt produkt = ListboxMainWindowProducts.SelectedItem as Produkt;





                    WindowProductItem.windowProductItemInstance.TextblockHeader.Text = "Element bearbeiten";
                    WindowProductItem.windowProductItemInstance.TextBoxName.Text = produkt.Name;
                    WindowProductItem.windowProductItemInstance.TextBoxDesc.Text = produkt.Desc;
                    WindowProductItem.windowProductItemInstance.TextBoxIcon.Text = produkt.Icon;
                    WindowProductItem.windowProductItemInstance.TextBoxPreis.Text = produkt.Preis.ToString();
                    //WindowProductItem.windowProductItemInstance.ColorpickerItemBackgroundColor.SelectedColor = Convert.brush;

                    // TODO: Hier Fehlen noch Eigenschaften
                    // TODO: Hier muss die Farbe von einem String in eine Brush convertiert werden.

                }


                if (ToggleButtonDeleteProduct.IsChecked == true)
                {
                    if (System.Windows.Forms.MessageBox.Show("Wollen Sie den Artikel löschen?", "Löschen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ListboxMainWindowProducts.Items.Remove(ListboxMainWindowProducts.SelectedItem);
                    }
                }
                
                ListboxMainWindowProducts.SelectedItem = null;
            }
        }




        private string FormatPurchaselLine(string ProductName, string ProductPrice, string ProductCount)
        {
            // FormatPurchaselLine("Produktname", "3,00€", "22x");

            string s1 = ProductCount.PadRight(4);
            string s2 = ProductName.PadRight(24);
            string s3 = ProductPrice.PadLeft(8);

            string result = s1 + s2 + s3;

            return result;
        }

        private void FormatPurchaseList()
        {
            //foreach (DataGridRow row in DataGridPurchase)
            //{

            //}


        }













        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Wollen Sie das Programm beenden?", "Checkout Pro", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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
