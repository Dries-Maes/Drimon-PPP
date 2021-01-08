using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    class BestellingMenu
    {

        public static void MenuBestellingenHoofdmenu()
        {
            
            
            Console.WriteLine($"1.Bestelling toevoegen\n2.Bestelling overzicht\n3.Terug naar hoofdmenu");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    
                    break;

                case 2:
                    Console.Clear();
                    
                    break;

                case 3:
                    Menu.MenuHoofdmenu();
                    break;
            }
        }
        public static void OverzichtBestellingen (string zoekmethode = "alles", string parameter = "alles", int getal = 0)
        {
            List<Bestelling> results = Data.GetBestelling();
            switch (zoekmethode)
            {
                case "ID":
                    results = Data.GetBestelling().FindAll(x => x.KlantID == getal);
                    break;
                case "kleinerdan":
                    results = Data.GetBestelling().FindAll(x => x.totaalPrijs() < getal);
                    break;
                case "gelijkaan":
                    results = Data.GetBestelling().FindAll(x => x.totaalPrijs() == getal);
                    break;
                case "groterdan":
                    results = Data.GetBestelling().FindAll(x => x.totaalPrijs() > getal);
                    break;
                case "alles":
                    break;
            }
            
            
            //Console.WriteLine(" |ID  " + $"|Voornaam".PadRight(12) + $"|Naam".PadRight(12) + $"|Adres".PadRight(20) + $"|Postcode".PadRight(10) + $"|Telefoonnummer".PadRight(20) + $"|Aanmaakdatum ");

            foreach (var item in results)
            {
                //Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}");
            }

        }
    }
}
