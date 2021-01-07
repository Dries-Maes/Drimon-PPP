using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class KlantMenu
    {
        

        public static void Klant()
        {
            Console.Clear();
            Console.WriteLine($"1.Klant zoeken\n2.Klant Toevoegen\n3.Terug naar hoofdmenu");
            switch (Menu.Kiezer(3))
            {
                case 1:
                    KlantZoeken();
                    break;

                case 2:
                    KlantToevoegen();
                    break;

                case 3:
                    Menu.Hoofdmenu();
                    break;

                default:
                    break;
            }
        }

        public static void KlantOverzicht(int klantID, string vanWaar)
        {
            Console.Clear();
            Console.WriteLine("--- dit is het overzicht van 1 klant ---\n**Eerst klantinfo**\n**Dan de bijhorende bestellingen**");
            Console.WriteLine($"1.Veld aanpassen\n2.Klant verwijderen\n3.Bestelling selecteren\n4.Terug");
            switch (Menu.Kiezer(6))
            {
                case 1:
                    Console.WriteLine($"1.Voornaam\n2.Naam\n3.Straat");
                    Console.WriteLine("Welk veld wil je aanpassen? (to-add)");
                     List<Klant> toEdit = Data.GetKlant();
                    switch (Menu.Kiezer(3))
                    {
                        case 1:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID-1].VoorNaam = Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID-1].AchterNaam = Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID-1].Straat = Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID - 1].Postcode = 5;/// TODO
                            break;

                        case 5:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID - 1].VoorNaam = Console.ReadLine();
                            break;

                        case 6:
                            Console.WriteLine("Geef de nieuwe waarde in:");
                            toEdit[klantID - 1].VoorNaam = Console.ReadLine();
                            break;

                        default:
                            break;
                    }
                    

                    Data.SetKlant(toEdit);
                    KlantOverzicht(klantID, vanWaar);
                    break;

                case 2:
                    Console.WriteLine("Druk op (J)a om te bevestigen of (N)ee om annuleren. (to-add)");//TODO
                    Console.ReadLine();
                    KlantOverzicht(klantID, vanWaar);
                    break;

                case 3:
                    Console.WriteLine("Geef het bestelling ID in dat je wil selecteren. (to-add)");//TODO
                    Console.ReadLine();
                    KlantOverzicht(klantID, vanWaar);
                    break;

                case 4:
                    if (vanWaar == "zoeken")
                    {
                        KlantZoeken();
                    }
                    else if (vanWaar == "toevoegen")
                    {
                        Klant();
                    }

                    break;

                default:
                    break;
            }
        }
        public static void KlantTabel(string zoekmethode, string parameter)
        {
            Console.Clear();
            
            List<Klant> resultaten = new List<Klant>();
            Console.WriteLine(" ---ID---  |Voornaam\t\t|Naam\t\t|Adres\t\t\t|Postcode \t|Aanmaakdatum "); // telnummer toe te voegen
            switch (zoekmethode)
            {
                case "ID":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.ID == Convert.ToInt32(parameter))
                        { Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); }
                    }
                    break;
                case "voornaam":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.VoorNaam.ToLower() == parameter.ToLower())
                        { Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); }
                    }
                    break;
                case "naam":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.AchterNaam.ToLower() == parameter.ToLower())
                        { Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); }
                    }
                    break;
                case "straat":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.Straat.ToLower() == parameter.ToLower())
                        { Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); }
                    }
                    break;
                case "postcode":
                    foreach (var item in Data.GetKlant())
                    {
                        if (item.Postcode.ToString() == parameter)
                        { Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); }
                    }
                    break;
                case "alles":
                   foreach (var item in Data.GetKlant())
                    {
                      Console.WriteLine($"Klant ID: {item.ID}|{item.VoorNaam}\t\t|{item.AchterNaam}\t\t|{item.Straat}{item.HuisBusNummer}\t\t|{item.Postcode}\t\t|{item.DatumAanmaak}"); 
                    }
                    break;
                default:
                    
                    break;
            }
           
            
        }
        
            public static void KlantZoeken(string zoekmethode = "alles", string parameter = "alles")
        {
            KlantTabel(zoekmethode, parameter);
            Console.WriteLine();
            Console.WriteLine($"1.Selecteer klant\n2.Zoek op voornaam\n3.Zoek op naam\n4.Zoek op straat\n5.Zoek op postcode\n6.Terug");
            switch (Menu.Kiezer(6))
            {
                case 1:
                    Console.WriteLine("Geef het ID gevolgd door 'enter':");
                    int ID;
                    string input = "nottoparce";
                    while (!Int32.TryParse(input, out ID))
                    { 
                        input = Console.ReadLine();     //clear line zou kunnen toegevoegd worden?
                    }

                    KlantOverzicht(ID, "zoeken");
                    break;
                case 2:
                    Console.WriteLine("Geef de voornaam in gevolgd door 'enter':");
                    KlantZoeken("voornaam", Console.ReadLine());  
                    break;

                case 3:
                    Console.WriteLine("Geef de naam in gevolgd door 'enter':");
                    KlantZoeken("naam", Console.ReadLine());
                    break;

                case 4:
                    Console.WriteLine("Geef de straatnaam in gevolgd door 'enter':");
                    KlantZoeken("straat", Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("Geef postcode in gevolgd door 'enter':");
                    if (Int32.TryParse(Console.ReadLine(), out int postcode)) { KlantZoeken("postcode", postcode.ToString()); } // check  op invoer werkt niet!
                                        break;
                case 6:
                    Klant();
                    break;

                default:
                    KlantZoeken();
                    break;
            }
        }

        public static void KlantToevoegen()
        {
            Klant foo = new Klant("bar");
            foo.NieuweKlant();
            Data.AddKlant(foo);
            KlantOverzicht(foo.ID, "toevoegen");            
        }

        
    }
}