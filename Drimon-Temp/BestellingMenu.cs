using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    internal class BestellingMenu
    {
        public static void MenuBestellingenHoofdmenu(string menukeuze = "nietafgerond", int waarde = 0)
        {
            int tempWaarde = waarde;
            OverzichtBestellingen(menukeuze, waarde);

            Console.WriteLine($"\n1.Toon alle bestellingen\n2.Filter op prijs\n3.Filter op product \n4.Filter op schotel \n5.Toon enkel afgeronde bestellingen\n6.Toon enkel open bestellingen \n7.Terug");
            switch (Menu.Kiezer(7))
            {
                case 1:
                    Console.Clear();
                    OverzichtBestellingen("alles", waarde);
                    break;
                case 2:
                    Console.WriteLine("\n1.Groter dan\n2.Kleiner dan\n3.Gelijk aan");
                    switch (Menu.Kiezer(6))
                    {
                        case 1:
                            Console.WriteLine("\nGeef een geheel getal in:");
                            tempWaarde = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen(">", tempWaarde);
                            break;
                        case 2:
                            Console.WriteLine("\nGeef een geheel getal in:");
                            tempWaarde = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen("<", tempWaarde);
                            break;
                        case 3:
                            Console.WriteLine("\nGeef een geheel getal in:");
                            tempWaarde = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                            Console.Clear();
                            OverzichtBestellingen("=", tempWaarde);
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("\nGeef een product ID in:");
                    tempWaarde = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtBestellingen("product", tempWaarde);
                    break;
                case 4:
                    Console.WriteLine("\nGeef een schotel ID in:");
                    tempWaarde = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtBestellingen("=", tempWaarde);
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
        }
       
            public static void OverzichtBestellingen(string zoekmethode = "alles", int getal = 0)
        {
            List<Bestelling> toEdit = Data.GetBestelling();
            List<Bestelling> results = toEdit;
            switch (zoekmethode)
            {
                case "klantID":
                    results = toEdit.FindAll(x => x.KlantID == getal);
                    break;

                case "<":
                    results = toEdit.FindAll(x => x.totaalPrijs() < getal);
                    break;

                case "=":
                    results = toEdit.FindAll(x => x.totaalPrijs() == getal);
                    break;

                case ">":
                    results = toEdit.FindAll(x => x.totaalPrijs() > getal);
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
                    results = toEdit.FindAll(x => x.Afgerond == true);
                    break;
                default:
                    break;
            }


            foreach (var item in results)
            {
                decimal totaalPrijsBestelling = 0.00M;
                Console.WriteLine($"ID: {item.ID}".PadRight(6) + $"  Klant: {Data.GetKlant()[item.KlantID - 1].VoorNaam}".PadRight(12) + $"  -  {item.DatumAanmaak}".PadRight(12) + $"  -  Afgerond: {item.Afgerond.ToString()}".PadRight(20));
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
    }
}