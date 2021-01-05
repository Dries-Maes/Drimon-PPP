using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    
    [Serializable]
    public class Klant
    {
        
        private int PID = 1;

        public int ID { get; set; }
        public DateTime DatumAanmaak { get; set; }
        public string VoorNaam { get; set; }
        public string AchterNaam { get; set; }
        public string Straat { get; set; }
        public string HuisBusNummer { get; set; }
        public int Postcode { get; set; }
        public string Telefoonnummer { get; set; }
        public bool Actief { get; set; }



        public Klant(string voornaam, string achternaam = null)
        {
            DatumAanmaak = DateTime.Now;
            VoorNaam = voornaam;
            AchterNaam = achternaam;
            Actief = true;


            ID = PID++;
        }
        
    }
}
