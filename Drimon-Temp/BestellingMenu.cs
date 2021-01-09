using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class BestellingMenu
    {
        public static void MenuBestellingenHoofdmenu(string menukeuze = "open", int waarde = 0)
        {
           
            

            Console.WriteLine($"\n 1.Toon alle bestellingen\n 2.Filter op prijs\n 3.Filter op product \n 4.Filter op schotel \n 5.Toon enkel afgeronde bestellingen\n 6.Toon enkel open bestellingen \n 7.Terug");
            switch (Menu.MethodeKiezer(7))
            {
                case 1:
                    Console.Clear();
                    OverzichtBestellingen("alles", waarde);
                    break;

                case 2:
                    Console.WriteLine("\n 1.Groter dan\n 2.Kleiner dan\n 3.Gelijk aan");
                    
                    switch (Menu.MethodeKiezer(6))
                    {
                        case 1:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen(">", waarde);
                            break;

                        case 2:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen("<", waarde);
                            break;

                        case 3:
                            Console.WriteLine("\n Geef een geheel getal in:");
                            waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen("=", waarde);
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("\n Geef een product ID in:");
                    waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtBestellingen("product", waarde);
                    break;

                case 4:
                    Console.WriteLine("\n Geef een schotel ID in:");
                    waarde = Menu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtBestellingen("=", waarde);
                    break;

                case 5:

                    Console.Clear();
                    OverzichtBestellingen("afgerond", waarde);
                    break;

                case 6:
                    Console.Clear();
                    OverzichtBestellingen("open", waarde);
                    break;

                case 7:
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
            Menu.MenuHoofdmenu();
        }
    }
}