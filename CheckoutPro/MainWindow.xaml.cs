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
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace CheckoutPro
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindowInstance;

        public List<ClassProduct> classProducts {  get; set; }
        public List<ClassQuittung> classQuittungs { get; set; }






        public MainWindow()
        {
            InitializeComponent();
            mainWindowInstance = this;

            classProducts = new List<ClassProduct>();
            classQuittungs = new List<ClassQuittung>();

            ListboxMainWindowProducts.ItemsSource = classProducts;
            DataGridPurchase.ItemsSource = classQuittungs;

            NormalStartup();
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










        private void ButtonReloadProducts_Click(object sender, RoutedEventArgs e)
        {

        }















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
                ToggleButtonDeleteProduct.IsChecked = false;


                RectangleInfoManipulation.Fill = Brushes.Yellow;
                SymbolInfoManipulation.Symbol = FluentIcons.Common.Symbol.Delete;
                TextblockInfoManipulation.Text = "Bearbeitung Aktiv";
                HeaderHint.Visibility = Visibility.Visible;
            }
            else
            {
                HeaderHint.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if(ToggleButtonDeleteProduct.IsChecked == true)
            {
                ToggleButtonEditProduct.IsChecked = false;

                RectangleInfoManipulation.Fill = Brushes.Red;
                SymbolInfoManipulation.Symbol = FluentIcons.Common.Symbol.Delete;
                TextblockInfoManipulation.Text = "Löschen Aktiv";
                HeaderHint.Visibility = Visibility.Visible;
            }
            else
            {
                HeaderHint.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonSaveProducts_Click(object sender, RoutedEventArgs e)
        {
            SaveProductstoFile();
            //System.Windows.Forms.MessageBox.Show("Gespeichert!!!");
            //TextBlockLogOutputMainwindow.Text = "Gespeichert";

        }

        #endregion

        #region MainWindow Zusammenfassung Buttons über Zusammenfassung DataGrid

        private void ButtonPrintLabel_Click(object sender, RoutedEventArgs e)
        {
            
            foreach(ClassQuittung classQuittung in DataGridPurchase.Items)
            {
                //System.Windows.MessageBox.Show(classQuittung.Anzahl + classQuittung.Name + classQuittung.Preis);
                ClassMethodsPrinter classMethodsPrinter = new ClassMethodsPrinter();
                //classMethodsPrinter.Print("2x","Super Geiles Produkt","3,00€");
                classMethodsPrinter.Print(classQuittung.Anzahl,classQuittung.Name,classQuittung.Preis);
            }

            classQuittungs.Clear();
            DataGridPurchase.Items.Refresh();
            UpdateSumme();



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

                    ClassProduct produkt = ListboxMainWindowProducts.SelectedItem as ClassProduct;

                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductName.Text = produkt.Name;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductBeschreibung.Text = produkt.Desc;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreis.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreisSumme.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);

                    WindowPurchaseProduct.windowPurchaseProductinstance.ProductPrice = produkt.Preis;
                }

                if (ToggleButtonEditProduct.IsChecked == true && ToggleButtonDeleteProduct.IsChecked == true)
                {
                    ToggleButtonDeleteProduct.IsChecked = false;
                    ToggleButtonEditProduct.IsChecked = true;
                }

                if(ToggleButtonDeleteProduct.IsChecked == true)
                {
                    if (System.Windows.Forms.MessageBox.Show("Wollen Sie den Artikel löschen?", "Löschen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ClassProduct product = ListboxMainWindowProducts.SelectedItem as ClassProduct;

                        classProducts.Remove(product);
                        ListboxMainWindowProducts.Items.Refresh();
                        GroupListBox();
                    }
                }


                if (ToggleButtonEditProduct.IsChecked == true)
                {
                    WindowProductItem productItem = new WindowProductItem();
                    productItem.Show();

                    ClassProduct produkt = ListboxMainWindowProducts.SelectedItem as ClassProduct;

                    WindowProductItem.windowProductItemInstance.TextblockHeader.Text = "Element bearbeiten";
                    WindowProductItem.windowProductItemInstance.TextBoxName.Text = produkt.Name;
                    WindowProductItem.windowProductItemInstance.TextBoxDesc.Text = produkt.Desc;
                    WindowProductItem.windowProductItemInstance.TextBoxIcon.Text = produkt.Icon;
                    WindowProductItem.windowProductItemInstance.TextBoxPreis.Text = produkt.Preis.ToString();
                    WindowProductItem.windowProductItemInstance.ComboBoxGruppe.Text = produkt.Group.ToString();
                }



                ListboxMainWindowProducts.SelectedItem = null;
            }
        }




        private string FormatPurchasel(string ProductName, string ProductPrice, string ProductCount)
        {
            // FormatPurchaselLine("Produktname", "3,00€", "22x");

            string s1 = ProductCount.PadRight(4);
            string s2 = ProductName.PadRight(24);
            string s3 = ProductPrice.PadLeft(8);

            string result = s1 + s2 + s3;

            return result;
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
            foreach (ClassProduct produkt in ListboxMainWindowProducts.Items)
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
                    ClassProduct product = new ClassProduct();
                    product.ID = values[0];
                    product.Name = values[1];
                    product.Desc = values[2];
                    product.Icon = values[3];
                    product.Preis = Convert.ToDouble(values[4]);
                    product.BackgroundColor = values[5];
                    product.BorderColor = values[6];
                    product.Group = values[7];


                    classProducts.Add(product);
                    ListboxMainWindowProducts.Items.Refresh();
                    GroupListBox();


                }
                myInputStream.Close();
            }
            else 
            {
                System.Windows.Forms.MessageBox.Show("Datenbank konnte nicht gefunden werden");
            }
        }

        public void GroupListBox()
        {
            ListboxMainWindowProducts.Items.GroupDescriptions.Clear();
            ListboxMainWindowProducts.Items.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
        }

        public void UpdateSumme()
        {
            double SummeProducts = 0;
            foreach (ClassQuittung quittung in DataGridPurchase.Items)
            {


                SummeProducts = Convert.ToDouble(quittung.Summe.Replace("€","")) + SummeProducts;

            }
            TextBlockSummePurchase.Text = SummeProducts.ToString("C", CultureInfo.CurrentCulture);


        }


        #endregion

        private void ButtonDataGridDeleteItem_Click(object sender, RoutedEventArgs e)
        {

            DataGridPurchase.Items.Refresh();
            UpdateSumme();
        }

        private void ButtonClearQuittung_Click(object sender, RoutedEventArgs e)
        {
            classQuittungs.Clear();
            DataGridPurchase.Items.Refresh();
            UpdateSumme();
        }


    }
}
