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

namespace CheckoutPro.Forms
{
    /// <summary>
    /// Interaktionslogik für WindowPurchaseProduct.xaml
    /// </summary>
    public partial class WindowPurchaseProduct : Window
    {
        public WindowPurchaseProduct()
        {
            InitializeComponent();
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
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            TextBoxValueProduct.Text = "0";
            firstdigit = false;

        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
