using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    class Bestelling
    {
        private int PID = 1;
        public int ID { get; set; }
        public DateTime DatumAanmaak { get; set; }
        public bool Afgerond { get; set; } //standaard waarde constructor? 
        public List<(int ID, decimal Prijs, int Aantal)> Schotels { get; set; }
        public List<(int ID, decimal Prijs, int Aantal)> Producten { get; set; }
        public int KlantID { get; set; }

        public Bestelling(int klantID)
        {
            Afgerond = false;
            KlantID = klantID;
            DatumAanmaak = DateTime.Now;

            ID = PID++;
        }

    }
}
