using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    [Serializable]
    class Bestelling
    {
        private List<(int ID, decimal Prijs, int Aantal)> schotels = new List<(int ID, decimal Prijs, int Aantal)>();
        private List<(int ID, decimal Prijs, int Aantal)> producten = new List<(int ID, decimal Prijs, int Aantal)>();
        public List<(int ID, decimal Prijs, int Aantal)> Schotels
        {
            get { return schotels; }
            set { schotels = value; }
        }

        public List<(int ID, decimal Prijs, int Aantal)> Producten
        {
            get { return producten; }
            set { producten = value; }
        }
        
        public int ID { get; set; }
        public DateTime DatumAanmaak { get; set; }
        
        
        public bool Afgerond { get; set; } 
        public  int KlantID { get; set; }

        public Bestelling(int klantID)
        {
           
            Afgerond = false;
            KlantID = klantID;
            DatumAanmaak = DateTime.Now;

            if (Data.GetBestelling().Count == 0)
            {
                ID = 1;
            }
            else {
                ID = Data.GetBestelling()[Data.GetBestelling().Count-1].ID + 1; // indien bestelling 1/-/3/4 -> next=5 // indien 1/2/3/-/ next = 4!! ok of niet?
            }

            
        }
        public string IsAfgerond()
        {
            if (Afgerond)
            {
                return "----Status: Afgerond";
            }
            else
            {
                return "Status: Open";
            }
      
        }

    }
}
