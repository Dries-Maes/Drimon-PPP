using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class KlantMenu
    {
        public static void MenuKlantHoofdmenu()
        {
            Console.Clear();
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

                default:
                    break;
            }
        }

        public static void MenuKlantZoeken()
        {
            Console.WriteLine();
            Console.WriteLine($"1.Selecteer klant\n2.Terug\n\nZoek op: \n  3.Voornaam\n  4.Naam\n  5.Straat\n  6.Postcode");

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
                    OverzichtKlantLijst();
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

                default:

                    break;
            }
        }

        public static void MenuKlantEnkel(int klantID, string zoekenToevoegen)
        {
            OverzichtKlantEnkel(klantID);
            ;
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
                            MenuKlantEnkel(klantID, zoekenToevoegen);
                            break;

                        case 2:
                            Console.Clear();
                            MenuKlantEnkel(klantID, zoekenToevoegen);
                            break;

                        default:
                            break;
                    }

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
                        MenuKlantHoofdmenu();
                    }

                    break;

                default:
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
                    if (klantEdit[klantID - 1].Actief)
                    {
                        klantEdit[klantID - 1].Actief = false;
                    }
                    else
                    {
                        klantEdit[klantID - 1].Actief = true;
                    }

                    break;

                case 2:

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

                default:
                    break;
            }
            Data.SetKlant(klantEdit);
            Console.Clear();
            MenuKlantEnkel(klantID, "toevoegen");
        }

        public static void OverzichtKlantBestellingen(int KlantID)
        {
            Console.WriteLine($"Bestellingen:\n");
            foreach (var item in Data.GetBestelling())
            {
                string status;
                if (item.Afgerond)
                {
                    status = "----Status: Afgerond";
                }
                else
                {
                    status = "Status: Open";
                }
                if (item.KlantID == KlantID)
                {
                    Console.WriteLine($"\tID:-{item.ID}-------------------------------------------------{ item.DatumAanmaak}");
                    decimal totaalprijs = 0.0M;
                    foreach (var product in item.Producten)
                    {
                        Console.WriteLine($"\t{Data.GetProduct()[product.ID - 1].Naam.PadRight(23)}|\tPrijs: {product.Prijs} euro\t|\t{product.Aantal} stuks");
                        totaalprijs += (product.Prijs * product.Aantal);
                    }
                    foreach (var schotels in item.Schotels)
                    {
                        Console.WriteLine($"\t{Data.GetSchotel()[schotels.ID - 1].Naam.PadRight(23)}|\tPrijs: {schotels.Prijs} euro\t|\t{schotels.Aantal} stuks");
                        totaalprijs += (schotels.Prijs * schotels.Aantal);
                    }

                    Console.WriteLine($"\tTotaal: {totaalprijs} euro-----------------------------------------{status}\n");
                }
            }
        }

        public static void OverzichtKlantEnkel(int klantID)
        {
            klantID = klantID - 1;

            List<Klant> klantEdit = Data.GetKlant();

            if (!klantEdit[klantID].Actief)
            {
                Console.WriteLine($"\n\tLET OP: DEZE KLANT WERD VERWIJDERD");
            }
            Console.WriteLine($"\n\tID: {klantEdit[klantID].ID}\n\tNaam: {klantEdit[klantID].VoorNaam} {klantEdit[klantID].AchterNaam}\n\tAdres: {klantEdit[klantID].Straat} {klantEdit[klantID].HuisBusNummer}\n\tPostcode: {klantEdit[klantID].Postcode}\n\tTelefoonnummer: {klantEdit[klantID].Telefoonnummer}\n\tDatum aanmaak: {klantEdit[klantID].DatumAanmaak}\n");
        }

        public static void OverzichtKlantLijst(string zoekmethode = "alles", string parameter = "alles")
        {
            Console.WriteLine(" |ID  " + $"|Voornaam".PadRight(12) + $"|Naam".PadRight(12) + $"|Adres".PadRight(20) + $"|Postcode".PadRight(10) + $"|Telefoonnummer".PadRight(20) + $"|Aanmaakdatum ");
            switch (zoekmethode)
            {
                case "ID":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.ID == Convert.ToInt32(parameter))
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                case "voornaam":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.VoorNaam.ToLower() == parameter.ToLower())
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                case "naam":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.AchterNaam.ToLower() == parameter.ToLower())
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                case "straat":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.Straat.ToLower() == parameter.ToLower())
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                case "postcode":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.Postcode.ToString() == parameter)
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                case "alles":
                    foreach (var item in Data.GetKlant())
                    {
                        { Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.VoorNaam}".PadRight(12) + $"|{item.AchterNaam}".PadRight(12) + $"|{item.Straat}{item.HuisBusNummer}".PadRight(20) + $"|{item.Postcode}".PadRight(10) + $"|{item.Telefoonnummer}".PadRight(20) + $"|{item.DatumAanmaak}"); }
                    }
                    break;

                default:

                    break;
            }
        }

        public static void MethodeKlantToevoegen()
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