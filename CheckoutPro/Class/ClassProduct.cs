using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutPro.Class
{
    internal class ClassProduct
    {
        public class Produkt
        {

            public Produkt()
            {
            }

            public Produkt(string v1, string v2, string v3, double v4)
            {
                this.Name = v1;
                this.Gruppe = v2;
                this.Farbe = v3;
                this.Preis = v4;
            }

            public string Name { get; set; }
            public double Preis { get; set; }
            public string Farbe { get; set; }
            public string Gruppe { get; set; }


        }
    }
}
