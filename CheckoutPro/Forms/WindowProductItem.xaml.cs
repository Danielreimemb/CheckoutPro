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
using System.Windows.Shapes;
using static CheckoutPro.Class.ClassProduct;

namespace CheckoutPro.Forms
{
    /// <summary>
    /// Interaktionslogik für WindowProductItem.xaml
    /// </summary>
    public partial class WindowProductItem : Window
    {
        public static WindowProductItem windowProductItemInstance;

        public WindowProductItem()
        {
            InitializeComponent();

            windowProductItemInstance = this;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Produkt produkt = new Produkt();
            produkt.Name = TextBoxName.Text;
            produkt.Preis = TextBoxPreis.Text;
            produkt.BackgroundColor = ColorpickerItemBackgroundColor.SelectedColor.ToString();
            produkt.Group = ComboBoxGruppe.Text;

            MainWindow.mainWindowInstance.ListboxMainWindowProducts.Items.Add(produkt);
            this.Close();
        }
    }
}
