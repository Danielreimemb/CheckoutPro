using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckoutPro.Class
{
    internal class ClassProduct
    {
        public class Produkt
        {

            public Produkt()
            {
            }

            public Produkt(string v1, string v2, string v3, string v4)
            {
                this.ID = v1;
                this.Name = v1;
                this.Desc = v1;
                this.Icon = v1;
                this.Preis = v4;
                this.BackgroundColor = v3;
                this.BorderColor = v4;
                this.Group = v2;
            }

            public string ID { get; set; }
            public string Name { get; set; }
            public string Desc { get; set; }
            public string Icon { get; set; }
            public string Preis { get; set; }
            public string BackgroundColor { get; set; }
            public string BorderColor { get; set; }
            public string Group { get; set; }




            public int PreisEuro { get; set; }
            public int PreisCent { get; set; }
            public double PreisDouble { get; set; }


        }
    }
}
