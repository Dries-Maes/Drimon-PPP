using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    
    [Serializable]
    public class Klant
    {
        
       

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


            ID = Data.GetKlant().Count + 1;
        }

        public void NieuweKlant()
        {
            Console.WriteLine("Geef de voornaam in gevolgd door 'enter':");
            VoorNaam = Console.ReadLine();
            Console.WriteLine("Geef de naam in gevolgd door 'enter':");
            AchterNaam = Console.ReadLine();
            Console.WriteLine("Geef de straat in gevolgd door 'enter':");
            Straat = Console.ReadLine();
            Console.WriteLine("Geef de huis en busnummer in gevolgd door 'enter':");
            HuisBusNummer = Console.ReadLine();
            Console.WriteLine("Geef de postcode in gevolgd door 'enter':");
            Postcode = KlantMenu.MethodeCheckforInt(Console.ReadLine());
            Console.WriteLine("Geef de telefoonnummer in gevolgd door 'enter':");
            Telefoonnummer = Console.ReadLine();
           
        }
    }
}
