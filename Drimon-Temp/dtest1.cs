using System;
using System.Collections.Generic;
using System.Text;

namespace Drimon_Temp
{
    public class dtest1
    {
        public static void TestVeld()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("Testzone Dries");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            // TEST KLANTEN ADD/GET/DELETE
            /*Klant Dries = new Klant("Dries","Maes");
            Dries.HuisBusNummer = "59";
            Dries.Straat = "Tarwestraat";
            Dries.Postcode = 9000;
            Dries.Telefoonnummer = "0484/62.39.97";
            Data.AddKlant(Dries);
            Klant Simon = new Klant("Simon", "Says");
            Simon.HuisBusNummer = "22 101";
            Simon.Straat = "Maisstraat";
            Simon.Postcode = 9040;
            Simon.Telefoonnummer = "0484/66.77.22";
            Data.AddKlant(Simon);
            Klant Michiel = new Klant("Michiel", "Smiel");
            Michiel.HuisBusNummer = "22";
            Michiel.Straat = "Gerststraat";
            Michiel.Postcode = 1000;
            Michiel.Telefoonnummer = "0032485224567";
            Data.AddKlant(Michiel);
            Data.DeleteKlant(1);
            foreach (var item in Data.GetKlant())
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.DatumAanmaak);
                Console.WriteLine(item.VoorNaam);
                Console.WriteLine(item.AchterNaam);
                Console.Write(item.Straat + " ");
                Console.WriteLine(item.HuisBusNummer);
                Console.WriteLine(item.Postcode);
                Console.WriteLine(item.Telefoonnummer);
                Console.WriteLine("Actief: " + item.Actief);
            }*/

            // TEST PRODUCTEN ADD/GET/DELETE
            /*Product Tomaten = new Product("Tomaten", 1.99M, 77);
            Data.AddProduct(Tomaten);
            Product Bouillon = new Product("Bouillon", 0.50M, 123);
            Data.AddProduct(Bouillon);
            Product Room = new Product("Room", 1.07M, 54);
            Data.AddProduct(Room);
                     Data.DeleteProduct(2);
            foreach (var item in Data.GetProduct())
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Naam);
                Console.WriteLine(item.Prijs);
                Console.WriteLine("items beschikbaar: " + item.Voorraad);
                Console.WriteLine(item.Actief);
            }*/

            // TEST SCHOTELS ADD/GET/DELETE

            /*
            Schotel vissalade = new Schotel("Vissalade", 4.50M, 48);
            Data.AddSchotel(vissalade);
            Schotel Vleessalade = new Schotel("Vleessalade", 4.50M, 48);
            Data.AddSchotel(Vleessalade);
            Schotel Garnaalsalade = new Schotel("Garnaalsalade", 4.50M, 48);
            Data.AddSchotel(Garnaalsalade);
            Schotel Tomatensoep = new Schotel("Tomatensoep", 4.50M, 48);
            Tomatensoep.ProductID.Add(1);
            Tomatensoep.ProductID.Add(2);
            Tomatensoep.ProductID.Add(3);
            Tomatensoep.Prijs = 2.22M;
            Tomatensoep.Actief = false;
            Data.AddSchotel(Tomatensoep);
            foreach (var item in Data.GetSchotel())
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Naam);
                Console.WriteLine(item.Prijs);
                Console.WriteLine("items beschikbaar: " + item.Voorraad);
               foreach (var ID in item.ProductID)
                { Console.WriteLine("Ingrediënt:" + Data.GetProduct()[ID - 1].Naam); }
            }
            */
            // TEST SCHOTELS ADD/GET/DELETE
            /*
            Bestelling order1 = new Bestelling(1);
            order1.Producten.Add((1, 2.22M, 4));
            order1.Producten.Add((2, 2.05M, 3));
            order1.Producten.Add((3, 1.99M, 7));
            order1.Schotels.Add((1, 2.22M, 4));
            order1.Schotels.Add((2, 2.05M, 3));
            order1.Schotels.Add((3, 1.99M, 7));
            Data.AddBestelling(order1);
            Bestelling order2 = new Bestelling(2);
            order2.Producten.Add((1, 2.22M, 1));
            order2.Producten.Add((2, 2.05M, 1));
            order2.Producten.Add((3, 1.99M, 1));
            order2.Schotels.Add((2, 2.05M, 1));
            order2.Schotels.Add((3, 1.99M, 1));
            Data.AddBestelling(order2);
            Bestelling order3 = new Bestelling(3);
            order3.Producten.Add((3, 1.99M, 7));
            order3.Schotels.Add((1, 2.22M, 4));
            order3.Schotels.Add((2, 2.05M, 55));
            order3.Schotels.Add((3, 1.99M, 7));
            Data.AddBestelling(order3);
            
            //Data.DeleteBestelling(2);
            foreach (var item in Data.GetBestelling())
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("----- Bestel-ID: "+item.ID +" ---------------------- ");
                Console.WriteLine(item.DatumAanmaak);
                Console.WriteLine("Besteld door: " + Data.GetKlant()[item.KlantID - 1].VoorNaam);
                Console.WriteLine(">>>Bestelde producten:");
                decimal totaalprijs = 0.0M;
                foreach (var product in item.Producten)
                {
                    Console.WriteLine($"{Data.GetProduct()[product.ID - 1].Naam}, prijs: {product.Prijs} euro, {product.Aantal} stuks.");
                    totaalprijs += (product.Prijs * product.Aantal);
                }
                Console.WriteLine(">>>Bestelde Schotels:");
                foreach (var schotels in item.Schotels)
                {
                    Console.WriteLine($"{Data.GetSchotel()[schotels.ID - 1].Naam}, prijs: {schotels.Prijs} euro, {schotels.Aantal} stuks.");
                    totaalprijs += (schotels.Prijs * schotels.Aantal);
                }
                Console.WriteLine($"$$$ - Totaalprijs: {totaalprijs} euro - $$$");
                
            }
            */

        }
    }
}


