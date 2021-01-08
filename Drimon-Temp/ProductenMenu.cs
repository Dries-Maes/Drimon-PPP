using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drimon_Temp
{
    internal class ProductMenu
    {
        public static void MenuProductHoofdmenu()
        {
            Console.WriteLine($"1.Product zoeken \n2.Product Toevoegen \n3.Schotels \n4.Terug naar hoofdmenu");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtProductLijst();
                    MenuProductZoeken();
                    break;

                case 2:
                    Console.Clear();
                    MethodeProductToevoegen();
                    break;

                case 3:
                    Console.Clear();
                    SchotelMenu.MenuSchotelHoofdmenu();
                    break;

                case 4:
                    Menu.MenuHoofdmenu();
                    break;
            }
        }

        public static void MenuProductZoeken()
        {
            Console.WriteLine($"\n1.Selecteer product\n2.Terug\n\nZoek op: \n  3.Naam\n ");
            string userinput;
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtProductLijst();
                    Console.WriteLine("\nGeef het ID gevolgd door 'enter':");
                    int input = MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    MenuProductEnkel(input, "zoeken");
                    break;

                case 2:
                    Console.Clear();
                    MenuProductHoofdmenu();
                    break;

                case 3:
                    Console.Clear();
                    OverzichtProductLijst();
                    Console.WriteLine("\nGeef de naam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtProductLijst("naam", userinput);
                    MenuProductZoeken();
                    break;
            }
        }

        public static void MenuProductEnkel(int productID, string zoekenToevoegen)
        {
            OverzichtProductEnkel(productID);

            Console.WriteLine($"1.Product aanpassen\n2.Bestellingen tonen\n3.Terug");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtProductEnkel(productID);
                    MenuProductEdit(productID);
                    Console.Clear();
                    MenuProductEnkel(productID, zoekenToevoegen);
                    break;

                case 2:
                    Console.Clear();
                    OverzichtProductBestellingen(productID);
                    Console.WriteLine($"1.Bestelling selecteren\n2.Terug");
                    switch (Menu.Kiezer(2))
                    {
                        case 1:
                            Console.WriteLine("TODO");                                                  ///////////// TODO > GO TO MAIN BESTELMENU
                            Console.ReadLine();
                            break;

                        case 2:
                            break;
                    }
                    Console.Clear();
                    MenuProductEnkel(productID, zoekenToevoegen);
                    break;

                case 3:
                    if (zoekenToevoegen == "zoeken")
                    {
                        Console.Clear();
                        OverzichtProductLijst();
                        MenuProductZoeken();
                    }
                    else if (zoekenToevoegen == "toevoegen")
                    {
                        Console.Clear();
                        MenuProductHoofdmenu();
                    }

                    break;
            }
        }

        public static void MenuProductEdit(int productID)
        {
            List<Product> productEdit = Data.GetProduct();

            Console.WriteLine
                ($"1.Verwijder\\herstel product" + $"\n" +
                $"2.Terug" +
                $"\n\nWijzig: \n " +
                $"3.naam\n " +
                $"4.prijs\n " +
                $"5.voorraad\n " +
                $"6.status\n");

            switch (Menu.Kiezer(6))
            {
                case 1:
                    productEdit[productID - 1].Actief = !productEdit[productID - 1].Actief;
                    break;

                case 2:
                    Console.Clear();
                    MenuProductEnkel(productID, "zoeken");
                    break;

                case 3:
                    Console.Clear();
                    OverzichtProductEnkel(productID);
                    Console.WriteLine("Geef de nieuwe naam in:");
                    productEdit[productID - 1].Naam = Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtProductEnkel(productID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    productEdit[productID - 1].Prijs = Convert.ToDecimal(Console.ReadLine());
                    break;

                case 5:
                    Console.Clear();
                    OverzichtProductEnkel(productID);
                    Console.WriteLine("Geef de nieuwe voorraad in:");
                    productEdit[productID - 1].Voorraad = Convert.ToInt32(Console.ReadLine());
                    break;

                case 6:
                    Console.Clear();
                    OverzichtProductEnkel(productID);
                    Console.WriteLine("Verander hier de status van het product: TODO");
                    //productEdit[productID - 1].HuisBusNummer = Console.ReadLine();
                    break;
            }

            Data.SetProduct(productEdit);
            Console.Clear();
            OverzichtProductEnkel(productID);
            MenuProductEdit(productID);
        }

        public static void OverzichtProductBestellingen(int ProductID)
        {
            //Bestelling objectSelectie = Data.GetBestelling().Find(delegate (Bestelling del) { return del.ProductID == ProductID; });

            //Console.WriteLine($"\tID:-{objectSelectie.ID}-------------------------------------------------{ objectSelectie.DatumAanmaak}");
            //decimal totaalprijs = 0.0M;
            //foreach (var product in objectSelectie.Producten)
            //{
            //    Console.WriteLine($"\t{Data.GetProduct()[product.ID - 1].Naam.PadRight(23)}|\tPrijs: {product.Prijs} euro\t|\t{product.Aantal} stuks");
            //    totaalprijs += (product.Prijs * product.Aantal);
            //}
            //foreach (var schotels in objectSelectie.Schotels)
            //{
            //    Console.WriteLine($"\t{Data.GetSchotel()[schotels.ID - 1].Naam.PadRight(23)}|\tPrijs: {schotels.Prijs} euro\t|\t{schotels.Aantal} stuks");
            //    totaalprijs += (schotels.Prijs * schotels.Aantal);
            //}
            //Console.WriteLine($"\tTotaal: {totaalprijs} euro-----------------------------------------{objectSelectie.IsAfgerond()}\n");

            Console.WriteLine("doing stuff");
        }//AFWERKEN

        public static void OverzichtProductEnkel(int productID)
        {
            Product objectSelectie = Data.GetProduct().Find(delegate (Product del) { return del.ID == productID; });

            if (!objectSelectie.Actief)
            {
                Console.WriteLine($"\n\tLET OP: DIT PRODUCT WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {objectSelectie.ID}\n\tNaam: {objectSelectie.Naam} \nPrijs: {objectSelectie.Prijs}\n\tVoorraad: {objectSelectie.Voorraad}\n\t");
        }

        public static void OverzichtProductLijst(string zoekmethode = "alles", string parameter = "alles")
        {
            List<Product> results = Data.GetProduct();
            switch (zoekmethode)
            {
                case "ID":
                    results = Data.GetProduct().FindAll(x => x.ID == Int32.Parse(parameter.ToLower()));
                    break;

                case "Naam":
                    results = Data.GetProduct().FindAll(x => x.Naam.ToLower() == parameter.ToLower());
                    break;

                case "Prijs":
                    results = Data.GetProduct().FindAll(x => x.Prijs == Convert.ToDecimal(parameter));
                    break;

                case "alles":
                    break;
            }
            Console.WriteLine(" |ID  " + $"|Naam".PadRight(12) + $"|Prijs".PadRight(12) + $"|Status".PadRight(20) + $"Kolom".PadRight(10) + $"|Kolom".PadRight(20) + $"|Aanmaakdatum ");

            foreach (var item in results)
            {
                Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.Naam}".PadRight(12) + $"|{item.Prijs}".PadRight(12) + $"|{item.Voorraad}{item.ID}".PadRight(20) + $"|{item.ID}".PadRight(10) + $"|{item.ID}".PadRight(20) + $"|{item.ID}");
            }
        }

        public static void MethodeProductToevoegen()
        {
            Product foo = new Product("bar");
            foo.NieuwProduct();
            Data.AddProduct(foo);
            MenuProductEnkel(foo.ID, "toevoegen");
        }

        public static int MethodeCheckforInt(string stringInput)
        {
            string tocheck = stringInput;
            int output;
            while (!Int32.TryParse(tocheck, out output))
            {
                tocheck = Console.ReadLine();
            }
            return output;
        }
    }
}