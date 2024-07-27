using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckoutPro.Class
{
    //internal class ClassProduct
    //{
        
    //}

    public class ClassProduct
    {

        public ClassProduct() { }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
        public double Preis { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public string Group { get; set; }
        public bool PrintPriceonLabel {  get; set; }

    }
}
