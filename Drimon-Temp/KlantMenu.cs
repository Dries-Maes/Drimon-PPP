using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class KlantMenu
    {
        public static void MenuKlantHoofdmenu()
        {
            Console.WriteLine($"1.Klant zoeken\n2.Klant Toevoegen\n3.Terug naar hoofdmenu");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtKlantLijst();
                    MenuKlantZoeken();
                    break;

                case 2:
                    Console.Clear();
                    MethodeKlantToevoegen();
                    break;

                case 3:
                    Menu.MenuHoofdmenu();
                    break;
            }
        }

        public static void MenuKlantZoeken()
        {
            Console.WriteLine($"\n1.Selecteer klant\n2.Terug\n\nZoek op: \n  3.Voornaam\n  4.Naam\n  5.Straat\n  6.Postcode");
            string userinput;
            switch (Menu.Kiezer(6))
            {
                case 1:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\nGeef het ID gevolgd door 'enter':");
                    int input = MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    MenuKlantEnkel(input, "zoeken");
                    break;

                case 2:
                    Console.Clear();
                    MenuKlantHoofdmenu();
                    break;

                case 3:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\nGeef de voornaam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("voornaam", userinput);
                    MenuKlantZoeken();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\nGeef de naam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("naam", userinput);
                    MenuKlantZoeken();
                    break;

                case 5:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\nGeef de straatnaam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("straat", userinput);
                    MenuKlantZoeken();
                    break;

                case 6:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\nGeef postcode in gevolgd door 'enter':");
                    int input2 = MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtKlantLijst("postcode", input2.ToString());
                    MenuKlantZoeken();
                    break;
            }
        }

        public static void MenuKlantEnkel(int klantID, string zoekenToevoegen)
        {
            OverzichtKlantEnkel(klantID);

            Console.WriteLine($"1.Klant aanpassen\n2.Bestellingen tonen\n3.Terug");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    MenuKlantEdit(klantID);
                    Console.Clear();
                    MenuKlantEnkel(klantID, zoekenToevoegen);
                    break;

                case 2:
                    Console.Clear();
                    OverzichtKlantBestellingen(klantID);
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
                    MenuKlantEnkel(klantID, zoekenToevoegen);
                    break;

                case 3:
                    if (zoekenToevoegen == "zoeken")
                    {
                        Console.Clear();
                        OverzichtKlantLijst();
                        MenuKlantZoeken();
                    }
                    else if (zoekenToevoegen == "toevoegen")
                    {
                        Console.Clear();
                        MenuKlantHoofdmenu();
                    }

                    break;
            }
        }

        public static void MenuKlantEdit(int klantID)
        {
            List<Klant> klantEdit = Data.GetKlant();
            
            Console.WriteLine($"1.Verwijder\\herstel klant\n2.Terug\n\nWijzig: \n 3.De voornaam\n 4.De naam\n 5.De straat\n 6.Het huisbusnummer\n 7.De postcode\n 8.Het telefoonnummer");
            switch (Menu.Kiezer(8))
            {
                case 1:
                    klantEdit[klantID - 1].Actief = !klantEdit[klantID - 1].Actief;
                    break;

                case 2:               
                    Console.Clear();
                    MenuKlantEnkel(klantID, "zoeken");
                    break;

                case 3:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].VoorNaam = Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].AchterNaam = Console.ReadLine();
                    break;

                case 5:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Straat = Console.ReadLine();
                    break;

                case 6:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].HuisBusNummer = Console.ReadLine();
                    break;

                case 7:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Postcode = MethodeCheckforInt(Console.ReadLine());
                    break;

                case 8:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine("Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Telefoonnummer = Console.ReadLine();
                    break;

            }
            Data.SetKlant(klantEdit);
            Console.Clear();
            OverzichtKlantEnkel(klantID);
            MenuKlantEdit(klantID);
        }

        public static void OverzichtKlantBestellingen(int KlantID)
        {
            Bestelling objectSelectie = Data.GetBestelling().Find(delegate (Bestelling del){  return del.KlantID == KlantID; });
            
                
                    Console.WriteLine($"\tID:-{objectSelectie.ID}-------------------------------------------------{ objectSelectie.DatumAanmaak}");
                    decimal totaalprijs = 0.0M;
                    foreach (var product in objectSelectie.Producten)
                    {
                        Console.WriteLine($"\t{Data.GetProduct()[product.ID - 1].Naam.PadRight(23)}|\tPrijs: {product.Prijs} euro\t|\t{product.Aantal} stuks");
                        totaalprijs += (product.Prijs * product.Aantal);
                    }
                    foreach (var schotels in objectSelectie.Schotels)
                    {
                        Console.WriteLine($"\t{Data.GetSchotel()[schotels.ID - 1].Naam.PadRight(23)}|\tPrijs: {schotels.Prijs} euro\t|\t{schotels.Aantal} stuks");
                        totaalprijs += (schotels.Prijs * schotels.Aantal);
                    }
                   Console.WriteLine($"\tTotaal: {totaalprijs} euro-----------------------------------------{objectSelectie.IsAfgerond()}\n");
                
            
        }

        public static void OverzichtKlantEnkel(int klantID)
        {
            Klant objectSelectie = Data.GetKlant().Find(delegate (Klant del) { return del.ID == klantID;});
            
            if (!objectSelectie.Actief)
            {
                Console.WriteLine($"\n\tLET OP: DEZE KLANT WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {objectSelectie.ID}\n\tNaam: {objectSelectie.VoorNaam} {objectSelectie.AchterNaam}\n\tAdres: {objectSelectie.Straat} {objectSelectie.HuisBusNummer}\n\tPostcode: {objectSelectie.Postcode}\n\tTelefoonnummer: {objectSelectie.Telefoonnummer}\n\tDatum aanmaak: {objectSelectie.DatumAanmaak}\n");
        }

        public static void OverzichtKlantLijst(string zoekmethode = "alles", string parameter = "alles")
        {
                    List<Klant> results = Data.GetKlant();
                    switch (zoekmethode)
                    {
                        case "voornaam":
                            results = Data.GetKlant().FindAll(x => x.VoorNaam.ToLower() == parameter.ToLower());
                            break;
                        case "naam":
                            results = Data.GetKlant().FindAll(x => x.AchterNaam.ToLower() == parameter.ToLower());
                            break;
                        case "straat":
                            results = Data.GetKlant().FindAll(x => x.Straat.ToLower() == parameter.ToLower());
                            break;
                        case "postcode":
                            results = Data.GetKlant().FindAll(x => x.Postcode == Int32.Parse(parameter));
                            break;
                        case "alles":   
                            break;
                    }
            Console.WriteLine(" |ID  " + $"|Voornaam".PadRight(12) + $"|Naam".PadRight(12) + $"|Adres".PadRight(20) + $"|Postcode".PadRight(10) + $"|Telefoonnummer".PadRight(20) + $"|Aanmaakdatum ");

            foreach (var item in results)
                    {
                        Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}");
                    }
        }

        public static void MethodeKlantToevoegen()   // to add: escape optie
        {
            Klant foo = new Klant("bar");
            foo.NieuweKlant();
            Data.AddKlant(foo);
            MenuKlantEnkel(foo.ID, "toevoegen");
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