using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class KlantMenu
    {
        public static void MenuKlantHoofdmenu()
        {
            Console.WriteLine($" 1.Klant zoeken\n 2.Klant Toevoegen\n 3.Terug naar hoofdmenu");
            switch (Menu.MethodeKiezer(3))
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

        public static void MenuKlantZoeken(string vanWaar = "nvt")
        {
            string userinput;

            Console.WriteLine($"\n 1.Selecteer klant\n 2.Terug\n\n Zoek op: \n  3.Voornaam\n  4.Naam\n  5.Straat\n  6.Postcode");

            switch (Menu.MethodeKiezer(6))
            {
                case 1:

                    Console.WriteLine("\n Geef het ID gevolgd door 'enter':");
                    int inputID = Menu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    if (vanWaar == "bestelling")
                    {
                        BestellingMenu.MethodeNieuweBestelling(inputID);
                   
                    }
                    MenuKlantEnkel(inputID, "zoeken");
                    break;

                case 2:
                    Console.Clear();
                    if (vanWaar == "bestelling")
                    {
                        Menu.MenuHoofdmenu();
                    }
                    MenuKlantHoofdmenu();

                    break;

                case 3:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\n Geef de voornaam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("voornaam", userinput);
                    MenuKlantZoeken(vanWaar);
                    break;

                case 4:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\n Geef de naam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("naam", userinput);
                    MenuKlantZoeken(vanWaar);
                    break;

                case 5:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\n Geef de straatnaam in gevolgd door 'enter':");
                    userinput = Console.ReadLine();
                    Console.Clear();
                    OverzichtKlantLijst("straat", userinput);
                    MenuKlantZoeken(vanWaar);
                    break;

                case 6:
                    Console.Clear();
                    OverzichtKlantLijst();
                    Console.WriteLine("\n Geef postcode in gevolgd door 'enter':");
                    int input2 = Menu.MethodeCheckforInt(Console.ReadLine());
                    Console.Clear();
                    OverzichtKlantLijst("postcode", input2.ToString());
                    MenuKlantZoeken(vanWaar);
                    break;
            }
        }

        public static void MenuKlantEnkel(int klantID, string zoekenToevoegen)
        {
            OverzichtKlantEnkel(klantID);

            Console.WriteLine($" 1.Klant aanpassen\n 2.Bestellingen tonen\n 3.Terug");
            switch (Menu.MethodeKiezer(3))
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
                    BestellingMenu.OverzichtBestellingen("klant", klantID);
                    Console.WriteLine($"\n 1.Nieuwe bestelling plaatsen\n 2.Terug");
                    switch (Menu.MethodeKiezer(2))
                    {
                        case 1:
                            Bestelling nieuw = new Bestelling(klantID);
                            Console.Clear();
                            nieuw.MethodeNieuweBestelling();
                            Data.AddBestelling(nieuw);
                            Menu.MenuHoofdmenu();
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

            Console.WriteLine($"\n Wijzig:  \n  1.Voornaam\n  2.Naam\n  3.Straat\n  4.Huisbusnummer\n  5.Postcode\n  6.Telefoonnummer\n\n 7.Verwijder\\herstel klant\n 8.Terug");
            switch (Menu.MethodeKiezer(8))
            {
                

                case 1:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].VoorNaam = Console.ReadLine();
                    break;

                case 2:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].AchterNaam = Console.ReadLine();
                    break;

                case 3:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Straat = Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].HuisBusNummer = Console.ReadLine();
                    break;

                case 5:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Postcode = Menu.MethodeCheckforInt(Console.ReadLine());
                    break;

                case 6:
                    Console.Clear();
                    OverzichtKlantEnkel(klantID);
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Telefoonnummer = Console.ReadLine();
                    break;
                case 7:
                    klantEdit[klantID - 1].Actief = !klantEdit[klantID - 1].Actief;
                    break;

                case 8:
                    Console.Clear();
                    MenuKlantEnkel(klantID, "zoeken");
                    break;
            }
            Data.SetKlant(klantEdit);
            Console.Clear();
            OverzichtKlantEnkel(klantID);
            MenuKlantEdit(klantID);
        }

        public static void OverzichtKlantEnkel(int klantID)
        {
            Klant objectSelectie = Data.GetKlant().Find(delegate (Klant del) { return del.ID == klantID; });

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
            Console.Clear();
            MenuKlantEnkel(foo.ID, "toevoegen");
        }
    }
}