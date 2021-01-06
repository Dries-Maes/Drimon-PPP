using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    [Serializable]
    class Schotel
    {

        private List<int> productID = new List<int>();

        public List<int> ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public int ID { get; set; }
        public string Naam { get; set; }
        
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public bool Actief { get; set; }
        public Schotel(string naam, decimal prijs, int voorraad = 0)
        {
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;
            Actief = true;

            ID = Data.GetSchotel().Count + 1;
        }

        
        
    }
}
