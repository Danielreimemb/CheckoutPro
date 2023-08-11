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
        private void SearchPrinter()
        {

        }

        private void PrinterSettings()
        {

        }

        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintTestFile);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void PrintTestFile(object sender, PrintPageEventArgs e)
        {
            string textToPrint = "Ihr Text hier";

            using (Font font = new Font("Arial", 12))
            using (SolidBrush brush = new SolidBrush(System.Drawing.Color.Black))
            {
                float yPos = e.MarginBounds.Top;
                e.Graphics.DrawString(textToPrint, font, brush, e.MarginBounds.Left, yPos, new StringFormat());

                yPos += font.GetHeight(e.Graphics);
            }
        }
    }
}
