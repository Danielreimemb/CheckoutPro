using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace CheckoutPro.Class
{
    internal class ClassMethodsPrinter
    {
        public static string Anzahl;
        public static string Produkt;
        public static string Preis;


        private void SearchPrinter()
        {

        }

        private void PrinterSettings()
        {

        }

        public void Print(string lAnzahl, string lProdukt, string lPreis)
        {
            Anzahl = lAnzahl;
            Produkt = lProdukt;
            Preis = lPreis;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintBon);


            pd.Print();
        }

        private static void PrintBon(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            Font font = new Font("Consolas", 12);
            Font largeFont = new Font("Consolas", 18);
            Font boldFont = new Font("Consolas", 18, FontStyle.Bold);

            SizeF anzahlSize = g.MeasureString(Anzahl, boldFont);
            SizeF produktSize = g.MeasureString(Produkt, largeFont);
            SizeF preisSize = g.MeasureString(Preis, boldFont);

            float anzahlX = (pageWidth - anzahlSize.Width) / 2;
            float produktX = (pageWidth - produktSize.Width) / 2;
            float preisX = (pageWidth - preisSize.Width) / 2;

            float lineHeight = font.GetHeight();

            float totalHeight = produktSize.Height + preisSize.Height + 2 * lineHeight;

            float startY = (pageHeight - totalHeight) * 0.05f;

            if (Anzahl != "1x")
            {
                g.DrawString(Anzahl, boldFont, System.Drawing.Brushes.Black, anzahlX, startY);
            }

            g.DrawString(Produkt, largeFont, System.Drawing.Brushes.Black, produktX, startY + (Anzahl != "1x" ? anzahlSize.Height + lineHeight : 0));
            g.DrawString(Preis, boldFont, System.Drawing.Brushes.Black, preisX, startY + (Anzahl != "1x" ? anzahlSize.Height : 0) + produktSize.Height + 2 * lineHeight);

            string currentDateAndTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            SizeF dateAndTimeSize = g.MeasureString(currentDateAndTime, font);
            float dateAndTimeX = (pageWidth - dateAndTimeSize.Width) / 2;
            g.DrawString(currentDateAndTime, font, System.Drawing.Brushes.Black, dateAndTimeX, startY + (Anzahl != "1x" ? anzahlSize.Height : 0) + produktSize.Height + preisSize.Height + 3 * lineHeight);

        }

        private static void PrintTestFile(object sender, PrintPageEventArgs e)
        {
            string Anzahl = "2x";
            string Produkt = "TestName";
            string Preis = "3,00€";

            // Get the graphics object to work with
            Graphics g = e.Graphics;

            // Get the dimensions of the page
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            // Set up fonts
            Font font = new Font("Consolas", 10);
            Font largeFont = new Font("Consolas", 18);
            Font boldFont = new Font("Consolas", 18, FontStyle.Bold);

            // Calculate text dimensions
            SizeF anzahlSize = g.MeasureString(Anzahl, boldFont);
            SizeF produktSize = g.MeasureString(Produkt, largeFont);
            SizeF preisSize = g.MeasureString(Preis, boldFont);

            // Calculate starting positions
            float anzahlX = (pageWidth - anzahlSize.Width) / 2;
            float produktX = (pageWidth - produktSize.Width) / 2;
            float preisX = (pageWidth - preisSize.Width) / 2;

            // Calculate vertical spacing
            float lineHeight = font.GetHeight();

            // Calculate the total height of the content
            float totalHeight = anzahlSize.Height + produktSize.Height + preisSize.Height + 3 * lineHeight;

            // Calculate starting y position to center the content vertically
            float startY = (pageHeight - totalHeight) * 0.05f;

            // Draw the content
            g.DrawString(Anzahl, boldFont, System.Drawing.Brushes.Black, anzahlX, startY);
            g.DrawString(Produkt, largeFont, System.Drawing.Brushes.Black, produktX, startY + anzahlSize.Height + lineHeight);
            g.DrawString(Preis, boldFont, System.Drawing.Brushes.Black, preisX, startY + anzahlSize.Height + produktSize.Height + 2 * lineHeight);

            // Display current date and time
            string currentDateAndTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            SizeF dateAndTimeSize = g.MeasureString(currentDateAndTime, font);
            float dateAndTimeX = (pageWidth - dateAndTimeSize.Width) / 2;
            g.DrawString(currentDateAndTime, font, System.Drawing.Brushes.Black, dateAndTimeX, startY + anzahlSize.Height + produktSize.Height + preisSize.Height + 3 * lineHeight);
        }
    }
}
