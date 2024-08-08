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
using System.Runtime.InteropServices;
using System.Reflection;
using static CheckoutPro.Class.ClassAppSettings;
using CheckoutPro.Class;


namespace CheckoutPro.Forms
{
    public partial class WindowSettings : Window
    {

        private const string SettingsFilePath = "settings.xml";
        private ClassAppSettings _settings;



        public WindowSettings()
        {
            InitializeComponent();

            if (_settings == null)
            {
                _settings = new ClassAppSettings();
            }

            _settings = ClassAppSettings.Load(SettingsFilePath);

            ToggleButtonPrintseperatLabels.IsChecked = _settings.PrintseperatLabels;
            ToggleButtonSaveDatabaseonClose.IsChecked = _settings.SaveDatabaseonClose;
            ToggleButtonClearPrinterHistory.IsChecked = _settings.ClearPrinterHistory;
            ToggleButtonFullscreen.IsChecked = _settings.StartFullscreen;

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
                #region Printdetails
                //else if (isOnline)
                //{
                //    ComboBoxDrucker.Items.Add(printer + "Online");
                //}
                //else if (isDefault)
                //{
                //    ComboBoxDrucker.Items.Add(printer + "Standard");
                //}
                #endregion

            }





        }

        private void ButtonSearchPrinter_Click(object sender, RoutedEventArgs e)
        {
            LoadPrinters();
        }



        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDefaultPrinter(string printerName);



        private void ButtonSetPrinterasDefault_Click(object sender, RoutedEventArgs e)
        {
            bool success = SetDefaultPrinter(ComboBoxDrucker.Text);

            if (success)
            {
                MessageBox.Show($"{ComboBoxDrucker.Text} wurde erfolgreich als Standarddrucker festgelegt.");
            }
            else
            {
                MessageBox.Show($"Fehler beim Festlegen von {ComboBoxDrucker.Text} als Standarddrucker.");
            }


        }



        private void ButtonSubmitSettings_Click(object sender, RoutedEventArgs e)
        {
            if (_settings == null)
            {
                _settings = new ClassAppSettings();
            }


            _settings.Version = "1.0.0.0";
            _settings.Key = "";
            _settings.Darkmode = false;
            _settings.PrintseperatLabels = ToggleButtonPrintseperatLabels.IsChecked ?? false;
            _settings.SaveDatabaseonClose = ToggleButtonSaveDatabaseonClose.IsChecked ?? false;
            _settings.ClearPrinterHistory = ToggleButtonClearPrinterHistory.IsChecked ?? false;
            _settings.StartFullscreen = ToggleButtonFullscreen.IsChecked ?? false;
            _settings.Basicprinter = ComboBoxDrucker.Text;

            ClassAppSettings.Save(_settings, SettingsFilePath);
            MainWindow.mainWindowInstance.UpdateSettings();


            this.Close();
        }
    }
}
