using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    [Serializable]
    internal class Product
    {

        public int ID { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public bool Actief { get; set; }
        public Product(string naam, decimal prijs, int voorraad = 0)
        {
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;
            Actief = true;
            ID = Data.GetProduct().Count + 1;

        }
        
    }
}