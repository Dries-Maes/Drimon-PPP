using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    [Serializable]
    internal class Schotel
    {
        private List<int> productIDLijst = new List<int>();
        //Eventueel library van maken om aantal van producten toe te voegen (eerste unieke waarde = product, 2de waarde aantal)

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
        public List<Product> Ingredienten { get; set; }

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
            Naam = "null";
            Actief = false;
            Voorraad = 0;
            DatumAanmaak = DateTime.Now;
        }

        public void Maakschotel()
        {
            Schotel werkschotel = new Schotel();
            Data.GetSchotel();
            Data.AddSchotel(werkschotel);
            List<Product> editlist = new List<Product>();
        }
    }
}