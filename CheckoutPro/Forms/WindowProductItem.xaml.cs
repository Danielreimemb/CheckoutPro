using CheckoutPro.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static CheckoutPro.Class.ClassProduct;

namespace CheckoutPro.Forms
{
    public partial class WindowProductItem : Window
    {
        public static WindowProductItem windowProductItemInstance;
        public bool EditItemactive;

        public string oID;
        public string oName;
        public string oDesc;
        public string oIcon;

        public WindowProductItem()
        {
            InitializeComponent();
            windowProductItemInstance = this;

            TextblockHeader.Text = EditItemactive ? "Element bearbeiten" : "Element hinzufügen";

            foreach (ClassProduct produkt in MainWindow.mainWindowInstance.ListboxMainWindowProducts.Items)
            {
                if (!ComboBoxGruppe.Items.Contains(produkt.Group))
                {
                    ComboBoxGruppe.Items.Add(produkt.Group);
                }

            }

            


            ComboBoxGruppe.SelectedIndex = ComboBoxGruppe.Text == "Sammlung" ? 0 : ComboBoxGruppe.SelectedIndex;










        }


        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {




            ClassProduct produkt = new ClassProduct();
            produkt.Name = TextBoxName.Text;
            produkt.Desc = TextBoxDesc.Text;
            produkt.Icon = TextBoxIcon.Text;
            produkt.Preis = Convert.ToDouble(TextBoxPreis.Text.Replace("€",""));
            produkt.BackgroundColor = ColorpickerItemBackgroundColor.SelectedColor.ToString();
            produkt.BorderColor = ColorpickerItemBorderColor.SelectedColor.ToString();
            produkt.Group = ComboBoxGruppe.Text;
            produkt.PrintPriceonLabel = ToggleButtonPrintPriceonLabel.IsChecked.Value;

            if (this.EditItemactive)
            {
                MainWindow.mainWindowInstance.classProducts.RemoveAll(p => p.Name == oName);
            }


            MainWindow.mainWindowInstance.classProducts.Add(produkt);
            MainWindow.mainWindowInstance.ListboxMainWindowProducts.Items.Refresh();
            MainWindow.mainWindowInstance.GroupListBox();









            this.Close();
        }
    }
}
