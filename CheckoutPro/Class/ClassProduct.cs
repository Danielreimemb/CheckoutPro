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

        public ClassProduct()
        {
        }

        //public ClassProduct(string vID, string vName, string vDesc, string vIcon, double vPreis, string vBackgroundColor, string vBorderColor, string vGroup)
        //{
        //    this.ID = vID;
        //    this.Name = vName;
        //    this.Desc = vDesc;
        //    this.Icon = vIcon;
        //    this.Preis = vPreis;
        //    this.BackgroundColor = vBackgroundColor;
        //    this.BorderColor = vBorderColor;
        //    this.Group = vGroup;
        //}

        public string ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
        public double Preis { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public string Group { get; set; }

    }
}
