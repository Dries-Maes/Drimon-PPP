using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class BestellingMenu
    {
        public static void MenuBestellingenHoofdmenu(string menukeuze = "open", int waarde = 0)
        {

            Menu.MethodeBannerLine("Alle bestellingen", "Openstaande", "Afgerond", "Filter op prijs", "Filter op ID");
            Console.WriteLine();
            OverzichtBestellingen(menukeuze, waarde);
            Console.SetCursorPosition(0, 0);
            switch (Menu.MethodeKiezer(7))
            {
                case 1:
                    Console.Clear();
                    MenuBestellingenHoofdmenu("alles", waarde);
                    break;
                

                case 2:
                    Console.Clear();
                    MenuBestellingenHoofdmenu("open", waarde);
                    break;
                case 3:

                    Console.Clear();
                    MenuBestellingenHoofdmenu("afgerond", waarde);
                    break;
                case 4:
                    Console.Clear();
                    Menu.MethodeBannerLine("Groter dan", "Kleiner dan", "Gelijk aan");

                    switch (Menu.MethodeKiezer(3))
                    {
                        case 1:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            MenuBestellingenHoofdmenu(">", waarde);
                            break;

                        case 2:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            MenuBestellingenHoofdmenu("<", waarde);
                            break;

                        case 3:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            MenuBestellingenHoofdmenu("=", waarde);
                            break;
                        case 0:
                            Console.Clear();
                            MenuBestellingenHoofdmenu(menukeuze, waarde);
                            break;
                    }
                    break;

                case 5:
                    Console.Clear();
                    Menu.MethodeBannerLine("Filter op bestelling ID", "Filter op product ID", "Filter op schotel ID", "Filter op klant ID");
                    switch (Menu.MethodeKiezer(4))
                    {
                        case 1:
                            Console.WriteLine("\n Geef een bestel-ID in:");
                            waarde = Menu.MethodeCheckforID("bestelling");
                            Console.Clear();
                            MenuBestellingenHoofdmenu("bestelID", waarde);
                            break;
                        case 2:
                            Console.Clear();
                            ProductMenu.MenuProductZoeken();
                            break;
                            
                        case 3:
                            Console.Clear();
                            SchotelMenu.MenuSchotelHoofdmenu();
                            break;
                        case 4:
                            Console.WriteLine("\n Geef een klant ID in:");
                            waarde = Menu.MethodeCheckforID("klant");
                            Console.Clear();
                            KlantMenu.MenuKlantZoeken();
                            break;
                        case 0:
                            Console.Clear();
                            MenuBestellingenHoofdmenu(menukeuze, waarde);
                            break;
                    }
                    break;

              
                case 0:
                    Menu.MenuHoofdmenu();
                    break;
                    
            }
            MenuBestellingenHoofdmenu(menukeuze, waarde);
        }

        public static void OverzichtBestellingen(string zoekmethode = "alles", int getal = 0)
        {
            List<Bestelling> toEdit = Data.GetBestelling();
            List<Bestelling> results = new List<Bestelling>();
            
            switch (zoekmethode)
            {
                case "klantID":
                    results = toEdit.FindAll(x => x.KlantID == getal);
                    break;

                case "<":
                    results = toEdit.FindAll(x => (int)x.MethodeTotaalPrijs() < getal);
                    break;

                case "=":
                    results = toEdit.FindAll(x => (int)x.MethodeTotaalPrijs() == getal);
                    break;

                case ">":
                    results = toEdit.FindAll(x => (int)x.MethodeTotaalPrijs() > getal);
                    break;

                case "product":
                    results = toEdit.FindAll(x => x.Producten.Exists(x => x.ID == getal) == true);
                    break;

                case "schotel":
                    results = toEdit.FindAll(x => x.Schotels.Exists(x => x.ID == getal) == true);
                    break;

                case "afgerond":
                    results = toEdit.FindAll(x => x.Afgerond == true);
                    break;

                case "open":
                    results = toEdit.FindAll(x => x.Afgerond == false);
                    break;
                case "alles":
                     results = toEdit;
                    break;
                case "bestelID":
                    results = toEdit.FindAll(x => x.ID == getal);
                    break;
                default:
                    break;
            }

            foreach (var item in results)
            {
                decimal totaalPrijsBestelling = 0.00M;
                Console.WriteLine($" ID: {item.ID}".PadRight(6) + $"  Klant: {Data.GetKlant()[item.KlantID - 1].VoorNaam}".PadRight(12) + $"  -  {item.DatumAanmaak}".PadRight(12) + $"  -  Afgerond: {item.Afgerond}".PadRight(20));
                Console.Write("\tProducten:");

                foreach (var instance in item.Producten)
                {
                    Console.Write($"{instance.AantalBesteld} x {instance.Naam}, ");
                    totaalPrijsBestelling += instance.Prijs;
                }
                Console.Write("\n\tSchotels:");
                foreach (var instance in item.Schotels)
                {
                    Console.Write($"{instance.AantalBesteld} x {instance.Naam}, ");
                    totaalPrijsBestelling += instance.Prijs;
                }
                Console.WriteLine($"\n\tTotaalprijs: {totaalPrijsBestelling} euro");

                
            }
            
        }
        public static void MethodeNieuweBestelling(int klantID)
        {
            Bestelling nieuw = new Bestelling(klantID);
            Console.Clear();
            nieuw.MethodeNieuweBestelling();
            Data.AddBestelling(nieuw);
            Console.Clear();
            OverzichtBestellingen("klantID", klantID);
        }
    }
}