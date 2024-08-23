﻿using CheckoutPro.Class;
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
using static CheckoutPro.Class.ClassAppSettings;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Xml.Serialization;

namespace CheckoutPro
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindowInstance;

        public List<ClassProduct> classProducts {  get; set; }
        public List<ClassQuittung> classQuittungs { get; set; }

        private const string SettingsFilePath = "settings.xml";
        private ClassAppSettings _settings;



        public MainWindow()
        {
            InitializeComponent();
            mainWindowInstance = this;

            _settings = ClassAppSettings.Load(SettingsFilePath);
            this.WindowState = _settings.StartFullscreen ? WindowState.Maximized : this.WindowState;

            classProducts = new List<ClassProduct>();
            classQuittungs = new List<ClassQuittung>();

            ListboxMainWindowProducts.ItemsSource = classProducts;
            DataGridPurchase.ItemsSource = classQuittungs;

            LoadProductsfromFile();
        }






        private void ButtonHeaderSettings_Click(object sender, EventArgs e)
        {
            WindowSettings windowSettings = new WindowSettings();
            windowSettings.Show();
        }

        private void ButtonExitApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProductItem productItem = new WindowProductItem();
            productItem.Show();

            WindowProductItem.windowProductItemInstance.EditItemactive = false;
        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleButtonEditProduct.IsChecked == true)
            {
                ToggleButtonDeleteProduct.IsChecked = false;
                RectangleInfoManipulation.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#fff647");
                SymbolInfoManipulation.Symbol = FluentIcons.Common.Symbol.Edit;
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
            if (ToggleButtonDeleteProduct.IsChecked == true)
            {
                ToggleButtonEditProduct.IsChecked = false;
                RectangleInfoManipulation.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff4747");
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
        }

        private void ButtonPrintLabel_Click(object sender, RoutedEventArgs e)
        {
            _settings = ClassAppSettings.Load(SettingsFilePath);



            foreach (ClassQuittung classQuittung in DataGridPurchase.Items)
            {
                ClassMethodsPrinter classMethodsPrinter = new ClassMethodsPrinter();
                classMethodsPrinter.Print(classQuittung.Anzahl,classQuittung.Name,classQuittung.Preis,classQuittung.PrintPriceonLabel, _settings.PrintseperatLabels, _settings.Print1x);
            }

            classQuittungs.Clear();
            DataGridPurchase.Items.Refresh();
            UpdateSumme();

        }

        private void ListboxMainWindowProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListboxMainWindowProducts.SelectedItem != null)
            {
                if (ToggleButtonDeleteProduct.IsChecked == false && ToggleButtonEditProduct.IsChecked == false)
                {
                    WindowPurchaseProduct windowPurchaseProduct = new WindowPurchaseProduct();
                    windowPurchaseProduct.Show();

                    ClassProduct produkt = ListboxMainWindowProducts.SelectedItem as ClassProduct;

                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductName.Text = produkt.Name;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductBeschreibung.Text = produkt.Desc;
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreis.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);
                    WindowPurchaseProduct.windowPurchaseProductinstance.TextBlockProductPreisSumme.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);
                    WindowPurchaseProduct.windowPurchaseProductinstance.PrintPriceonLabel = produkt.PrintPriceonLabel;
                    WindowPurchaseProduct.windowPurchaseProductinstance.ProductPrice = produkt.Preis;
                }

                if (ToggleButtonEditProduct.IsChecked == true && ToggleButtonDeleteProduct.IsChecked == true)
                {
                    ToggleButtonEditProduct.IsChecked = true;
                    ToggleButtonDeleteProduct.IsChecked = false;
                    
                }

                if (ToggleButtonDeleteProduct.IsChecked == true)
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
                    WindowProductItem.windowProductItemInstance.oName = produkt.Name;


                    WindowProductItem.windowProductItemInstance.TextBoxName.Text = produkt.Name;
                    WindowProductItem.windowProductItemInstance.TextBoxDesc.Text = produkt.Desc;
                    WindowProductItem.windowProductItemInstance.TextBoxIcon.Text = produkt.Icon;
                    WindowProductItem.windowProductItemInstance.TextBoxPreis.Text = produkt.Preis.ToString("C", CultureInfo.CurrentCulture);
                    WindowProductItem.windowProductItemInstance.ComboBoxGruppe.Text = produkt.Group.ToString();
                    WindowProductItem.windowProductItemInstance.ToggleButtonPrintPriceonLabel.IsChecked = produkt.PrintPriceonLabel;
                    WindowProductItem.windowProductItemInstance.EditItemactive = true;
                }

                ListboxMainWindowProducts.SelectedItem = null;
            }
        }


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


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Wollen Sie das Programm beenden?", "Checkout Pro", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                _settings = ClassAppSettings.Load(SettingsFilePath);
                if (_settings.SaveDatabaseonClose) SaveProductstoFile();
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }






        private void SaveProductstoFile()
        {
            string filePathDatabase = "Database.csv";
            if (!File.Exists(filePathDatabase))
            {
                File.Create(filePathDatabase).Dispose();
            }

            StreamWriter streamWriterDatabase = new StreamWriter(filePathDatabase);

            foreach (ClassProduct produkt in ListboxMainWindowProducts.Items)
            {
                string produktDaten = $"{produkt.ID};{produkt.Name};{produkt.Desc};{produkt.Icon};{produkt.Preis};{produkt.BackgroundColor};{produkt.BorderColor};{produkt.Group};{produkt.PrintPriceonLabel}";
                streamWriterDatabase.WriteLine(produktDaten);
            }
            streamWriterDatabase.Close();
        }

        private void LoadProductsfromFile()
        {
            string filePathDatabase = @"Database.csv";
            if (!File.Exists(filePathDatabase)) return;

            StreamReader myInputStream = new StreamReader(filePathDatabase);
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
                product.PrintPriceonLabel = values[8].Contains("True");

                classProducts.Add(product);
                ListboxMainWindowProducts.Items.Refresh();
                GroupListBox();
            }
            myInputStream.Close();
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




    }
}
