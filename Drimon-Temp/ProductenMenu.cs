using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class ProductMenu
    {
        public static void MenuProductHoofdmenu()
        {
            Menu.MethodeBannerLine("Producten beheren", "Schotels beheren");

            switch (Menu.MethodeKiezer(3))
            {
                case 1:
                    Console.Clear();
                    MenuProductZoeken();
                    break;

                case 2:
                    Console.Clear();
                    SchotelMenu.MenuSchotelHoofdmenu();
                    break;

                case 0:
                    Console.Clear();
                    Menu.MenuHoofdmenu();
                    break;
            }
        }

        public static void MenuProductZoeken(string zoekmethode = "alles", string parameter = "true", bool status = true, string returpagina = null)
        {
            Menu.MethodeBannerLine("Toon alles", "Selecteer", "Zoek op status", "Zoek op naam", "Zoek op schotel", "Voeg toe");
            OverzichtProductLijst(zoekmethode, parameter, status);

            switch (Menu.MethodeKiezer(6))
            {
                case 1:

                    Console.Clear();
                    MenuProductZoeken("status", parameter, true, returpagina);
                    break;

                case 2:
                    if (returpagina == "schotel")
                    {
                        Console.WriteLine("\nGeef het ID gevolgd door 'enter':");
                        int waarde = Menu.MethodeCheckforID("product");
                        Console.Clear();
                        SchotelMenu.MenuSchotelHoofdmenu("product", waarde);
                    }
                    Console.WriteLine("\nGeef het ID gevolgd door 'enter':");
                    int inputID = Menu.MethodeCheckforID("product");
                    Console.Clear();
                    MenuProductEnkel(inputID);
                    break;

                case 3:
                    Console.Clear();
                    if (status)
                    {
                        MenuProductZoeken("status", parameter, false, returpagina);
                    }
                    else
                    {
                        MenuProductZoeken("status", parameter, true, returpagina);
                    }
                    break;

                case 4:

                    Console.WriteLine("\nGeef de naam in gevolgd door 'enter':");
                    parameter = Console.ReadLine();
                    Console.Clear();
                    MenuProductZoeken("naam", parameter, status, returpagina);
                    break;

                case 5:
                    // zoek op schotel > goto schotel overzicht
                    Console.WriteLine("todo");
                    break;

                case 6:
                    Console.Clear();
                    MethodeProductToevoegen();
                    break;

                case 0:
                    Console.Clear();
                    MenuProductHoofdmenu();
                    break;
            }
        }

        public static void MenuProductEnkel(int productID)
        {
            Menu.MethodeBannerLine("Wijzig naam", "Wijzig prijs", "Wijzig voorraad", "Wijzig status", "Toon bestellingen");
            OverzichtProductEnkel(productID);

            List<Product> productEdit = Data.GetProduct();
            switch (Menu.MethodeKiezer(5))
            {
                case 1:
                    Console.WriteLine("Geef de nieuwe naam in:");
                    productEdit[productID - 1].Naam = Console.ReadLine();
                    Data.SetProduct(productEdit);
                    Console.Clear();
                    MenuProductEnkel(productID);
                    break;

                case 2:

                    Console.WriteLine("Geef de nieuwe waarde in:");
                    productEdit[productID - 1].Prijs = Convert.ToDecimal(Console.ReadLine());
                    Data.SetProduct(productEdit);
                    Console.Clear();
                    MenuProductEnkel(productID);
                    break;

                case 3:

                    Console.WriteLine("Geef de nieuwe voorraad in:");
                    productEdit[productID - 1].Voorraad = Convert.ToInt32(Console.ReadLine());
                    Data.SetProduct(productEdit);
                    Console.Clear();
                    MenuProductEnkel(productID);
                    break;

                case 4:

                    productEdit[productID - 1].Actief = !productEdit[productID - 1].Actief;
                    Data.SetProduct(productEdit);
                    Console.Clear();
                    MenuProductEnkel(productID);
                    break;

                case 5:
                    Console.Clear();
                    BestellingMenu.MenuBestellingenHoofdmenu("product", productID);
                    break;

                case 0:
                    Console.Clear();
                    MenuProductZoeken();

                    break;
            }
        }

        public static void OverzichtProductEnkel(int productID)
        {
            Product objectSelectie = Data.GetProduct().Find(delegate (Product del) { return del.ID == productID; });

            if (!objectSelectie.Actief)
            {
                Console.WriteLine($"\n\tLET OP: DIT PRODUCT WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {objectSelectie.ID}\n\tNaam: {objectSelectie.Naam} \n\tPrijs: {objectSelectie.Prijs}\n\tVoorraad: {objectSelectie.Voorraad}\n\t");
        }

        public static void OverzichtProductLijst(string zoekmethode = "alles", string parameter = "alles", bool status = true)
        {
            List<Product> results = Data.GetProduct();
            switch (zoekmethode)
            {
                case "naam":
                    results = Data.GetProduct().FindAll(x => x.Naam.ToLower() == parameter.ToLower());

                    break;

                case "status":
                    results = Data.GetProduct().FindAll(x => x.Actief == status);
                    break;

                case "allesalles":
                    break;
            }

            Console.WriteLine(" |ID  " + $"|Naam".PadRight(25) + $"|Prijs".PadRight(10) + $"|Voorraad".PadRight(10) + $"|ID".PadRight(10) + $"|Status".PadRight(20) + $"|Aanmaakdatum ");
            string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(HorizontaleLijn);
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var item in results)
            {
                Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.Naam}".PadRight(25) + $"|{item.Prijs}".PadRight(10) + $"|{item.Voorraad}".PadRight(10) + $"|{item.ID}".PadRight(10) + $"|{item.Actief}".PadRight(20) + $"|{item.DatumAanmaak}");
            }
        }

        public static void MethodeProductToevoegen()
        {
            Product foo = new Product("bar");
            foo.MethodeNieuwProduct();
            Data.AddProduct(foo);
            Console.Clear();
            MenuProductEnkel(foo.ID);
        }
    }
}