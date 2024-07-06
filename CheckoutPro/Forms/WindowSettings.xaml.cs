using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Management;

namespace CheckoutPro.Forms
{
    /// <summary>
    /// Interaktionslogik für WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        public WindowSettings()
        {
            InitializeComponent();
            LoadPrinters();
        }

        private void LoadPrinters()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterSettings printerSettings = new PrinterSettings
                {
                    PrinterName = printer
                };

                bool isOnline = printerSettings.IsValid;
                bool isDefault = printer.Equals(new PrinterSettings().PrinterName, StringComparison.OrdinalIgnoreCase);


                if (isOnline && isDefault)
                {
                    ComboBoxDrucker.Items.Add(printer);
                    ComboBoxDrucker.SelectedItem = printer;
                }
                //else if (isOnline)
                //{
                //    ComboBoxDrucker.Items.Add(printer + "Online");
                //}
                //else if (isDefault)
                //{
                //    ComboBoxDrucker.Items.Add(printer + "Standard");
                //}


            }





        }
    }
}
