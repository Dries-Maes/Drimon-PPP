using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    [Serializable]
    internal class Schotel
    {
        private List<int> productIDLijst = new List<int>();
        //Eventueel dictionary van maken om aantal van producten toe te voegen (eerste unieke waarde = product, 2de waarde aantal)
        //private Dictionary<int, int> IDlijst = new Dictionary<int, int>();

        public List<int> ProductIDLijst
        {
            get { return productIDLijst; }
            set { productIDLijst = value; }
        }

        public int ID { get; set; }
        public string Naam { get; set; }

        public DateTime DatumAanmaak { get; set; }

        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public bool Actief { get; set; }

        public Schotel(string naam, decimal prijs, int voorraad = 0)
        {
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;
            Actief = true;
            DatumAanmaak = DateTime.Now;

            ID = Data.GetSchotel().Count + 1;
        }

        public Schotel()
        {
            Naam = "null"; //ID HANDLING ?
            Actief = false;
            Voorraad = 0;
            DatumAanmaak = DateTime.Now;
        }
    }
}