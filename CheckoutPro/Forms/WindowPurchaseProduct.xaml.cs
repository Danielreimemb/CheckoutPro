using CheckoutPro.Class;
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
    /// Interaktionslogik für WindowPurchaseProduct.xaml
    /// </summary>
    public partial class WindowPurchaseProduct : Window
    {
        public static WindowPurchaseProduct windowPurchaseProductinstance;

        public WindowPurchaseProduct()
        {
            InitializeComponent();

            windowPurchaseProductinstance = this;
        }

        bool firstdigit = false;

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "1x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x","") + "1x";
            }

            UpdateSumme();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "2x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "2x";
            }

            UpdateSumme();

        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "3x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "3x";
            }
            UpdateSumme();

        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "4x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "4x";
            }
            UpdateSumme();

        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "5x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "5x";
            }
            UpdateSumme();

        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "6x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "6x";
            }
            UpdateSumme();

        }
        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "7x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "7x";
            }
            UpdateSumme();


        }
        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "8x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "8x";
            }
            UpdateSumme();

        }
        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "9x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "9x";
            }

        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {

            if (firstdigit == false)
            {
                TextBoxValueProduct.Text = "0x";
                firstdigit = true;
            }
            else
            {
                TextBoxValueProduct.Text = TextBoxValueProduct.Text.Replace("x", "") + "0x";
            }
            UpdateSumme();

        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            TextBoxValueProduct.Text = "0";
            firstdigit = false;
            UpdateSumme();

        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            // Check ob Product schonmal verwendet wurde ??


            ClassQuittung classQuittung = new ClassQuittung();
            classQuittung.Anzahl = TextBoxValueProduct.Text;
            classQuittung.Name = "Name";
            classQuittung.Preis = "Preis";
            classQuittung.Summe = "Summe";


            MainWindow.mainWindowInstance.DataGridPurchase.Items.Add(classQuittung);
            this.Close();



        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateSumme()
        {

            // TODO Problem
            int ValueProduct = Convert.ToInt16(TextBoxValueProduct.Text.Replace("x"," "));
            double Preis = Convert.ToDouble(TextBlockProductPreis);
            double Summe = Preis * ValueProduct;
            TextBlockProductPreisSumme.Text = Summe.ToString();

        }
    }
}
