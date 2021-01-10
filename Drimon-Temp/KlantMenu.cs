using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class KlantMenu
    {
       

        public static void MenuKlantZoeken(string zoekmethode = "alles", string parameter = "0", string vanWaar = "nvt")
        {
            

            Menu.MethodeBannerLine("Klant selecteren", "Klant zoeken" ,"Klant Toevoegen");
            OverzichtKlantLijst(zoekmethode, parameter);
            switch (Menu.MethodeKiezer(3))
            {
                case 1:
                    Console.WriteLine("\n Geef het ID gevolgd door 'enter':");
                    int inputID = Menu.MethodeCheckforID("klant");
                    Menu.MethodeClearLine(-1);
                    Console.WriteLine(inputID);
                    Menu.MethodeSpinner("\n Klant wordt geselecteerd...");
                    Console.Clear();
                    if (vanWaar == "bestelling")
                    {
                        
                        BestellingMenu.MethodeNieuweBestelling(inputID);

                    }
                    MenuKlantEnkel(inputID, "zoeken");
                    break;
                case 2:
                    Console.Clear();
                    Menu.MethodeBannerLine("Zoek op voornaam", "Zoek op naam", "Zoek op straat", "Zoek op postcode");
                    switch (Menu.MethodeKiezer(6))
                    {
           
                        case 1:
                            Console.WriteLine("\n Geef de voornaam in gevolgd door 'enter':");
                            parameter = Console.ReadLine();
                            zoekmethode = "voornaam";
                            Menu.MethodeSpinner("Klant wordt gezocht...");
                            Console.Clear();
                            MenuKlantZoeken(zoekmethode, parameter, vanWaar);
                            break;

                        case 2:
                            
                            Console.WriteLine("\n Geef de naam in gevolgd door 'enter':");
                            parameter = Console.ReadLine();
                            zoekmethode = "naam";
                            Menu.MethodeSpinner("Klant wordt gezocht...");
                            Console.Clear();
                            MenuKlantZoeken(zoekmethode, parameter, vanWaar);
                            break;

                        case 3:
    
                            Console.WriteLine("\n Geef de straatnaam in gevolgd door 'enter':");
                            parameter = Console.ReadLine();
                            zoekmethode = "straat";
                            Menu.MethodeSpinner("Klant wordt gezocht...");
                            Console.Clear();
                            MenuKlantZoeken(zoekmethode, parameter, vanWaar);
                            break;

                        case 4:

                            Console.WriteLine("\n Geef postcode in gevolgd door 'enter':");
                            parameter = Menu.MethodeCheckforInt(Console.ReadLine()).ToString();
                            zoekmethode = "postcode";
                            Menu.MethodeSpinner("Klant wordt gezocht...");
                            Console.Clear();
                            MenuKlantZoeken(zoekmethode, parameter, vanWaar);
                            break;
                        case 0:
                            Console.Clear();
                            if (vanWaar == "bestelling")
                            {
                                Console.Clear();
                                Menu.MenuHoofdmenu();
                            }
                            Console.Clear();
                            MenuKlantZoeken(zoekmethode, parameter, vanWaar);

                            break;

                    }

                    break;
                case 3:
                    Console.Clear();
                    MethodeKlantToevoegen();
                    break;
                case 0:   
                    Console.Clear();
                    Menu.MenuHoofdmenu();
                    break;
            }



        }

        public static void MenuKlantEnkel(int klantID, string zoekenToevoegen)
        {
            Menu.MethodeBannerLine("Klant aanpassen", "Bestellingen tonen");
            OverzichtKlantEnkel(klantID);
            switch (Menu.MethodeKiezer(3))
            {
                case 1:
                    Console.Clear();                
                    MenuKlantEdit(klantID);
                    
                    break;

                case 2:
                    Console.Clear();                
                    Menu.MethodeBannerLine("Nieuwe bestelling plaatsen");
                    BestellingMenu.OverzichtBestellingen("klantID", klantID);
                    switch (Menu.MethodeKiezer(2))
                    {
                        case 1:
                            Bestelling nieuw = new Bestelling(klantID);
                            Console.Clear();
                            Menu.MethodeBannerLine();
                            nieuw.MethodeNieuweBestelling();
                            Data.AddBestelling(nieuw);
                            Console.Clear();
                            MenuKlantEnkel(klantID, zoekenToevoegen);
                            break;
                        case 0:
                            Console.Clear();
                            MenuKlantEnkel(klantID, zoekenToevoegen);
                            break;
                    }
                    
                    
                    break;

                case 0:
                    if (zoekenToevoegen == "zoeken")
                    {
                        Console.Clear();
                        
                        MenuKlantZoeken();
                    }
                    else if (zoekenToevoegen == "toevoegen")
                    {
                        Console.Clear();
                        MenuKlantZoeken();
                    }

                    break;
            }
        }


        

            public static void MenuKlantEdit(int klantID)
        {
            List<Klant> klantEdit = Data.GetKlant();

            Menu.MethodeBannerLine("Voornaam", "Naam", "Straat", "Huisbusnummer", "Postcode","Telefoonnummer", "Status") ;
            OverzichtKlantEnkel(klantID);
            
            switch (Menu.MethodeKiezer(8))
            {
                

                case 1:     
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].VoorNaam = Console.ReadLine();
                    
                    break;

                case 2:
                    
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].AchterNaam = Console.ReadLine();
                    
                    break;

                case 3:
                    
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Straat = Console.ReadLine();
                    
                    break;

                case 4:
                    
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].HuisBusNummer = Console.ReadLine();
                    
                    break;

                case 5:
                    
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Postcode = Menu.MethodeCheckforInt(Console.ReadLine());
                    
                    break;

                case 6:
                    
                    Console.WriteLine(" Geef de nieuwe waarde in:");
                    klantEdit[klantID - 1].Telefoonnummer = Console.ReadLine();
                   
                    break;
                case 7:
                    klantEdit[klantID - 1].Actief = !klantEdit[klantID - 1].Actief;
                    break;

                case 0:
                    Console.Clear();
                    MenuKlantEnkel(klantID, "zoeken");
                    break;
                    
            }
            Data.SetKlant(klantEdit);
                      Console.Clear();
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