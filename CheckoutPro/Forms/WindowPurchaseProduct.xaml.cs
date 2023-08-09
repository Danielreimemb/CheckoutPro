using CheckoutPro.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class WindowPurchaseProduct : Window
    {
        public static WindowPurchaseProduct windowPurchaseProductinstance;
        public int ProductNumber;
        public double ProductPrice;

        bool firstdigit = false;



        public WindowPurchaseProduct()
        {
            InitializeComponent();

            windowPurchaseProductinstance = this;
        }

        

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

            MethodInputChanged();


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

            MethodInputChanged();


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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();

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

            MethodInputChanged();
        }

















        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            TextBoxValueProduct.Text = "0x";
            firstdigit = false;
            MethodInputChanged();

        }








        private void MethodInputChanged()
        {
            int ProductNumber = Convert.ToInt16(TextBoxValueProduct.Text.Replace("x", ""));
            double SummeProdukte = ProductPrice * ProductNumber;
            TextBlockProductPreisSumme.Text = SummeProdukte.ToString() + "€";

        }






        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            // Check ob Product schonmal verwendet wurde ??

            //("C", CultureInfo.CurrentCulture)




            double aSumme = 0.0;
            double aPreis = 0.0;



            ClassQuittung classQuittung = new ClassQuittung();
            classQuittung.Anzahl = TextBoxValueProduct.Text;
            classQuittung.Name = TextBlockProductName.Text;
            classQuittung.Preis = aPreis.ToString("C", CultureInfo.CurrentCulture);
            classQuittung.Summe = aSumme.ToString("C", CultureInfo.CurrentCulture);


            MainWindow.mainWindowInstance.DataGridPurchase.Items.Add(classQuittung);
            this.Close();

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
