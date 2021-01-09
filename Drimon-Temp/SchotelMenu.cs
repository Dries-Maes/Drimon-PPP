using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class SchotelMenu
    {
        public static void MenuSchotelHoofdmenu()
        {
            Console.WriteLine($"1.Schotel zoeken\n2.Schotel samenstellen\n3.Terug naar hoofdmenu");
            switch (Menu.MethodeKiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtSchotelLijst();
                    MenuSchotelZoeken();
                    break;

                case 2:
                    Console.Clear();
                    MethodeSchotelSamenstellen();
                    break;

                case 3:
                    Menu.MenuHoofdmenu();
                    break;
            }
        }

        public static void MethodeSchotelSamenstellen(string zoekmethode = "alles", string parameter = "alles")
        {
            OverzichtSchotelLijst();

            List<Schotel> schotelsedit = Data.GetSchotel();
            List<Schotel> newschotel = new List<Schotel>();
            List<Product> ingredienten = Data.GetProduct();
            Product ingredient = new Product(9999);
            List<Product> recept = new List<Product>();

            Console.WriteLine("Schotel SAMENSTELLEN");
            Console.WriteLine("Geef productID in om schotel te maken:");
            int userinput = Convert.ToInt32(Console.ReadLine());
            ingredient.ID = userinput;
            recept.Add(new Product(ingredient.ID));

            foreach (var item in schotelsedit)
            {
            }

            {
                List<Product> results = Data.GetProduct();

                Console.WriteLine(" |ID  " + $"|Naam".PadRight(12) + $"|Prijs".PadRight(12) + $"|Status".PadRight(20) + $"Kolom".PadRight(10) + $"|Kolom".PadRight(20) + $"|Aanmaakdatum ");
                foreach (var item in results)
                {
                    Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.Naam}".PadRight(12) + $"|{item.Prijs}".PadRight(12) + $"|{item.Voorraad}{item.ID}".PadRight(20) + $"|{item.ID}".PadRight(10) + $"|{item.ID}".PadRight(20) + $"|{item.ID}");
                }
            }
            MenuSchotelZoeken();
        }

        public static void OverzichtSchotelLijst(string zoekmethode = "alles", string parameter = "alles")
        {
            List<Schotel> results = Data.GetSchotel();
            switch (zoekmethode)
            {
                case "ID":
                    results = Data.GetSchotel().FindAll(x => x.ID == Int32.Parse(parameter.ToLower()));
                    break;

                case "Naam":
                    results = Data.GetSchotel().FindAll(x => x.Naam.ToLower() == parameter.ToLower());
                    break;

                case "Prijs":
                    results = Data.GetSchotel().FindAll(x => x.Prijs == Convert.ToDecimal(parameter));
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

        public static void MenuSchotelZoeken()
        {
            Console.WriteLine($"\n1.Selecteer schotel\n2.Terug\n\nZoek op: \n  3.Naam\n  4.Ingedriënt\n ");
            string userinput;
            switch (Menu.MethodeKiezer(4))
            {
                case 1:
                    Console.Clear();
                    OverzichtSchotelLijst();
                    Console.WriteLine("\nGeef het ID gevolgd door 'enter':");
                    int input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    MenuSchotelEnkel(input, "zoeken");
                    break;

                case 2:
                    Console.Clear();
                    MenuSchotelHoofdmenu();
                    break;

                case 3:
                    Console.Clear();
                    OverzichtSchotelLijst();
                    Console.WriteLine("\nGeef de voornaam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtSchotelLijst("voornaam", userinput);
                    MenuSchotelZoeken();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtSchotelLijst();
                    Console.WriteLine("\nGeef de naam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtSchotelLijst("naam", userinput);
                    MenuSchotelZoeken();
                    break;
            }
        }

        public static void MenuSchotelEnkel(int schotelID, string zoekenToevoegen)
        {
            OverzichtSchotelEnkel(schotelID);

            Console.WriteLine($"1.Schotel aanpassen\n2.Bestellingen tonen\n3.Terug");
            switch (Menu.MethodeKiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    MenuSchotelEdit(schotelID);
                    Console.Clear();
                    MenuSchotelEnkel(schotelID, zoekenToevoegen);
                    break;

                case 2:
                    Console.Clear();
                    //OverzichtSchotelBestellingen(schotelID);
                    Console.WriteLine($"1.Bestelling selecteren\n2.Terug");
                    switch (Menu.MethodeKiezer(2))
                    {
                        case 1:
                            Console.WriteLine("TODO");                                                  ///////////// TODO > GO TO MAIN BESTELMENU
                            Console.ReadLine();
                            break;

                        case 2:
                            break;
                    }
                    Console.Clear();
                    MenuSchotelEnkel(schotelID, zoekenToevoegen);
                    break;

                case 3:
                    if (zoekenToevoegen == "zoeken")
                    {
                        Console.Clear();
                        OverzichtSchotelLijst();
                        MenuSchotelZoeken();
                    }
                    else if (zoekenToevoegen == "toevoegen")
                    {
                        Console.Clear();
                        MenuSchotelHoofdmenu();
                    }

                    break;
            }
        }

        public static void OverzichtSchotelEnkel(int schotelID)
        {
            Schotel objectSelectie = Data.GetSchotel().Find(delegate (Schotel del) { return del.ID == schotelID; });

            if (!objectSelectie.Actief)
            {
                Console.WriteLine($"\n\tLET OP: DEZE SCHOTEL WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {objectSelectie.ID}\n\tNaam: {objectSelectie.Naam}\n\t Datum aanmaak: {objectSelectie.DatumAanmaak}\n\t");
        }

        public static void MenuSchotelEdit(int schotelID)
        {
            List<Schotel> schotelEdit = Data.GetSchotel();

            Console.WriteLine($"1.Verwijder\\herstel schotel\n2.Terug\n\nWijzig: \n 3.Naam\n 4.Prijs\n 5.Voorraad\n 6.Status\n 7.Ingedrienten\n");
            switch (Menu.MethodeKiezer(7))
            {
                case 1:
                    schotelEdit[schotelID - 1].Actief = !schotelEdit[schotelID - 1].Actief;
                    break;

                case 2:
                    Console.Clear();
                    MenuSchotelEnkel(schotelID, "zoeken");
                    break;

                case 3:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    Console.WriteLine("Geef de nieuwe naam in:");
                    schotelEdit[schotelID - 1].Naam = Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    Console.WriteLine("Geef de nieuwe prijs in:");
                    schotelEdit[schotelID - 1].Prijs = Convert.ToDecimal(Console.ReadLine());
                    break;

                case 5:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    schotelEdit[schotelID - 1].Voorraad = Convert.ToInt32(Console.ReadLine());
                    break;

                case 6:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    Data.DeleteSchotel(schotelID);
                    Console.WriteLine("Status gewijzigd");

                    //if (schotelEdit[schotelID - 1].Actief == true)
                    //{
                    //    schotelEdit[schotelID - 1].Actief = false;

                    //}
                    //else
                    //{
                    //    schotelEdit[schotelID - 1].Actief = true;
                    //}

                    //schotelEdit[schotelID - 1].Actief = Console.ReadLine();
                    break;

                case 7:
                    Console.Clear();
                    OverzichtSchotelEnkel(schotelID);
                    Console.WriteLine("Naar schotelmaker");
                    break;
            }

            Data.SetSchotel(schotelEdit);
            Console.Clear();
            OverzichtSchotelEnkel(schotelID);
            MenuSchotelEdit(schotelID);
        }
    }
}