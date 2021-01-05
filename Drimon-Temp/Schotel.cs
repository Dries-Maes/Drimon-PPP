using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    class Schotel
    {
        private int PID = 1;
        public int ID { get; set; }
        public string Naam { get; set; }
        public List<Product> Producten { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }

        public Schotel(string naam, decimal prijs, int voorraad = 0)
        {
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;


            ID = PID++;
        }
    }
}
