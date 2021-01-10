using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class SchotelMenu
    {
        public static void MenuSchotelHoofdmenu(string menukeuze = "open", int waarde = 0)
        {

            Menu.MethodeBannerLine("Alle schotels", "Selecteer", "Zoek op status", "Zoek op product", "Nieuwe schotel");
            OverzichtSchotels(menukeuze, waarde);
            
            switch (Menu.MethodeKiezer(7))
            {
                case 1:
                    Console.Clear();
                    MenuSchotelHoofdmenu("alles", waarde);
                    break;
                

                case 2:
                    Console.WriteLine("\n Geef een ID in:");
                    waarde = Menu.MethodeCheckforID("schotel");
                    Console.Clear();
                    MenuSchotelEnkel(waarde);
                    break;
                case 3:
                    Console.Clear();
                    if (menukeuze != "gesloten")
                    {
                        MenuSchotelHoofdmenu("gesloten", waarde);
                    }
                    MenuSchotelHoofdmenu("open", waarde);
                    break;
                case 4:

                    Console.Clear();
                    ProductMenu.MenuProductZoeken("alles", "alles", true, "schotel");
                    break;
                case 5:
                    Console.Clear();
                    MethodeNieuweSchotel();
                    break;

                case 0:
                    Console.Clear();
                    ProductMenu.MenuProductHoofdmenu();
                    break;
                    
            }
            
        }

        public static void OverzichtSchotels(string zoekmethode = "alles", int getal = 0)
        {
            List<Schotel> toEdit = Data.GetSchotel();
            List<Schotel> results = new List<Schotel>();

            results = zoekmethode switch
            {
                "ID" => toEdit.FindAll(x => x.ID == getal),
                "product" => toEdit.FindAll(x => x.IDlijst.ContainsKey(getal)),
                "open" => toEdit.FindAll(x => x.Actief),
                "gesloten" => toEdit.FindAll(x => !x.Actief),
                _ => toEdit,
            };
            foreach (var item in results)
            {
                
                Console.WriteLine($" ID: {item.ID}".PadRight(6) + $"  Naam: {item.Naam}".PadRight(12) + $"  -  {item.DatumAanmaak}".PadRight(12) + $"  -  Voorraad: {item.Voorraad}".PadRight(20));
                Console.Write("\tProducten:");
                List<Product> producten = Data.GetProduct();
                foreach (var instance in item.IDlijst)
                {
                    Console.Write($"{producten[instance.Key-1].Naam} x {instance.Value}, "); 
                }

                Console.WriteLine($"\n\tTotaalprijs: {item.Prijs} euro");
                if (!item.Actief)        
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ==>  VERWIJDERD ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine();

            }
            
        }
        public static void MethodeNieuweSchotel()
        {
            
            Menu.MethodeBannerLine("0");
            Console.WriteLine(" Geef de naam in van de schotel:");
            Schotel nieuw = new Schotel(Console.ReadLine());
            Console.Clear();
            nieuw.MethodeNieuweSchotel();
            List<Product> producten = Data.GetProduct();
            foreach (var item in nieuw.IDlijst)
            {
                if (producten[item.Key-1].Voorraad < item.Value)
                {
                    Console.WriteLine(" Je kan de schotel niet maken, er zijn niet voldoende producten!!!\nDruk op een knop om terug te keren.");
                    Console.Clear();
                    MenuSchotelHoofdmenu();
                }

               // producten[item.Key].Voorraad -= item.Value; beestje.. 
            }
            Data.AddSchotel(nieuw);
            Data.SetProduct(producten);
            Console.Clear();
            MenuSchotelHoofdmenu();
        }
        public static void MenuSchotelEnkel(int schotelID)
        {
            
            Menu.MethodeBannerLine("Wijzig naam", "Wijzig prijs", "Wijzig voorraad", "Wijzig status", "Toon bestellingen");
            OverzichtSchotelEnkel(schotelID);
            
            List<Schotel> schotelEdit = Data.GetSchotel();
            switch (Menu.MethodeKiezer(5))
            {
                case 1: 
                    Console.WriteLine("Geef de nieuwe naam in:");
                    schotelEdit[schotelID - 1].Naam = Console.ReadLine();
                    Data.SetSchotel(schotelEdit);
                    Console.Clear();
                    MenuSchotelEnkel(schotelID);
                    break;

                case 2:
                   
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    schotelEdit[schotelID - 1].Prijs = Convert.ToDecimal(Console.ReadLine());
                    Data.SetSchotel(schotelEdit);
                    Console.Clear();
                    MenuSchotelEnkel(schotelID);
                    break;

                case 3:
                    
                    Console.WriteLine("Geef de nieuwe voorraad in:");
                    schotelEdit[schotelID - 1].Voorraad = Convert.ToInt32(Console.ReadLine());
                    Data.SetSchotel(schotelEdit);
                    Console.Clear();
                    MenuSchotelEnkel(schotelID);
                    break;

                case 4:
                    
                    schotelEdit[schotelID - 1].Actief = !schotelEdit[schotelID - 1].Actief;
                    Data.SetSchotel(schotelEdit);
                    Console.Clear();
                    MenuSchotelEnkel(schotelID);
                    break;

                case 5:
                    Console.Clear();
                    BestellingMenu.MenuBestellingenHoofdmenu("schotel", schotelID);
                    break;

                case 0:
                        Console.Clear();
                        MenuSchotelHoofdmenu();
   

                    break;
            }
        }
        public static void OverzichtSchotelEnkel(int schotelID)
        {
            Schotel objectSelectie = Data.GetSchotel().Find(delegate (Schotel del) { return del.ID == schotelID; });
            List<Product> productSelectie = Data.GetProduct();
            if (!objectSelectie.Actief)
            {
                Console.WriteLine($"\n\tLET OP: DEZE SCHOTEL WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {objectSelectie.ID}\n\tNaam: {objectSelectie.Naam} \n\tPrijs: {objectSelectie.Prijs}\n\tVoorraad: {objectSelectie.Voorraad}\n\t");
            if (objectSelectie.IDlijst.Count != 0)
            {
                Console.WriteLine("Producten:");
            }
            foreach (var item in objectSelectie.IDlijst)
            {
                Console.WriteLine($" Product {productSelectie[item.Key-1].Naam}: {item.Value} stuks.");
            }

        }
    }
}