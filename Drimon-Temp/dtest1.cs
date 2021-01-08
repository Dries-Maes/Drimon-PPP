using System;
using System.Linq;
using System.Collections.Generic;

namespace Drimon_Temp
{
    public class dtest1
    {
        public static void Dostuff()
        {
            Console.WriteLine("doing stuff.");
            Schotel toEdit = new Schotel("Warme schotel 1", 0.5M, 2);

            List<Product> temprecipe = Data.GetProduct();
            toEdit.IDlijst.Add(3, 5);
            toEdit.IDlijst.Add(4, 3);
            toEdit.IDlijst.Add(5, 2);
            toEdit.IDlijst.Add(1, 3);


            foreach (var koppel in toEdit.IDlijst)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Naam van product: {temprecipe[koppel.Key-1].Naam}");
                Console.WriteLine($"Stock: {temprecipe[koppel.Key-1].Voorraad}" +
                    $"\ngebruik in recept: {koppel.Value} (per recept) x {toEdit.Voorraad} (voorraad van het recept) = {koppel.Value*toEdit.Voorraad} (totaal dat recept gebruikt)" +
                    $"\nNieuwe Stock: {temprecipe[koppel.Key-1].Voorraad} (stock) - {koppel.Value * toEdit.Voorraad} (totaal dat recept gebruikt) = {temprecipe[koppel.Key-1].Voorraad - (koppel.Value * toEdit.Voorraad)} (nieuwe stock na aanmaak schotel)");
                Console.WriteLine("----------------------------------------------");
                temprecipe[koppel.Key - 1].Voorraad = temprecipe[koppel.Key - 1].Voorraad - (koppel.Value * toEdit.Voorraad);

            }
            
            Data.AddSchotel(toEdit);
            Data.SetProduct(temprecipe);
            Console.ReadLine();
        }

        //public static void TestVeld()
        //{
        //    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        //    Console.WriteLine("Testzone Dries");
        //    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

        //    // TEST KLANTEN ADD/GET/DELETE

        //    Klant Dries = new Klant("Dries", "Maes");
        //    Dries.HuisBusNummer = "59";
        //    Dries.Straat = "Tarwestraat";
        //    Dries.Postcode = 9000;
        //    Dries.Telefoonnummer = "0484/62.39.97";
        //    Data.AddKlant(Dries);
        //    Klant Simon = new Klant("Simon", "Says");
        //    Simon.HuisBusNummer = "22 101";
        //    Simon.Straat = "Maisstraat";
        //    Simon.Postcode = 9040;
        //    Simon.Telefoonnummer = "0484/66.77.22";
        //    Data.AddKlant(Simon);
        //    Klant Michiel = new Klant("Michiel", "Smiel");
        //    Michiel.HuisBusNummer = "22";
        //    Michiel.Straat = "Gerststraat";
        //    Michiel.Postcode = 1000;
        //    Michiel.Telefoonnummer = "0032485224567";
        //    Data.AddKlant(Michiel);

        //    Data.DeleteKlant(1);

        //    foreach (var item in Data.GetKlant())
        //    {
        //        Console.WriteLine(item.ID);
        //        Console.WriteLine(item.DatumAanmaak);
        //        Console.WriteLine(item.VoorNaam);
        //        Console.WriteLine(item.AchterNaam);
        //        Console.Write(item.Straat + " ");
        //        Console.WriteLine(item.HuisBusNummer);
        //        Console.WriteLine(item.Postcode);
        //        Console.WriteLine(item.Telefoonnummer);
        //        Console.WriteLine("Actief: " + item.Actief);
        //    }

        //    // TEST PRODUCTEN ADD/GET/DELETE

        //    Product Tomaten = new Product("Tomaten", 1.99M, 77);
        //    Data.AddProduct(Tomaten);
        //    Product Bouillon = new Product("Bouillon", 0.50M, 123);
        //    Data.AddProduct(Bouillon);
        //    Product Room = new Product("Room", 1.07M, 54);
        //    Data.AddProduct(Room);
        //    Data.DeleteProduct(2);
        //    foreach (var item in Data.GetProduct())
        //    {
        //        Console.WriteLine(item.ID);
        //        Console.WriteLine(item.Naam);
        //        Console.WriteLine(item.Prijs);
        //        Console.WriteLine("items beschikbaar: " + item.Voorraad);
        //        Console.WriteLine(item.Actief);
        //    }

        //    // TEST SCHOTELS ADD/GET/DELETE

        //    Schotel vissalade = new Schotel("Vissalade", 4.50M, 48);
        //    Data.AddSchotel(vissalade);
        //    Schotel Vleessalade = new Schotel("Vleessalade", 4.50M, 48);
        //    Data.AddSchotel(Vleessalade);
        //    Schotel Garnaalsalade = new Schotel("Garnaalsalade", 4.50M, 48);
        //    Data.AddSchotel(Garnaalsalade);
        //    Schotel Tomatensoep = new Schotel("Tomatensoep", 4.50M, 48);
        //    Tomatensoep.ProductIDLijst.Add(1);
        //    Tomatensoep.ProductIDLijst.Add(2);
        //    Tomatensoep.ProductIDLijst.Add(3);
        //    Tomatensoep.Prijs = 2.22M;
        //    Tomatensoep.Actief = false;
        //    Data.AddSchotel(Tomatensoep);

        //    foreach (var item in Data.GetSchotel())
        //    {
        //        Console.WriteLine(item.ID);
        //        Console.WriteLine(item.Naam);
        //        Console.WriteLine(item.Prijs);
        //        Console.WriteLine("items beschikbaar: " + item.Voorraad);
        //        foreach (var ID in item.ProductIDLijst)
        //        { Console.WriteLine("Ingrediënt:" + Data.GetProduct()[ID - 1].Naam); }
        //    }

        //    // TEST Bestellingen ADD/GET/DELETE

        //    Bestelling order1 = new Bestelling(1);
        //    order1.Producten.Add((1, Data.GetProduct()[1 - 1].Prijs, 4));
        //    order1.Producten.Add((2, Data.GetProduct()[2 - 1].Prijs, 3));
        //    order1.Producten.Add((3, Data.GetProduct()[3 - 1].Prijs, 7));
        //    order1.Schotels.Add((1, Data.GetSchotel()[1 - 1].Prijs, 4));
        //    order1.Schotels.Add((2, Data.GetSchotel()[2 - 1].Prijs, 3));
        //    order1.Schotels.Add((3, Data.GetSchotel()[3 - 1].Prijs, 7));
        //    Data.AddBestelling(order1);
        //    Bestelling order2 = new Bestelling(2);
        //    order2.Producten.Add((1, 2.22M, 1));
        //    order2.Producten.Add((2, 2.05M, 1));
        //    order2.Producten.Add((3, 1.99M, 1));
        //    order2.Schotels.Add((2, 2.05M, 1));
        //    order2.Schotels.Add((3, 1.99M, 1));
        //    Data.AddBestelling(order2);

        //    Bestelling orderX = new Bestelling(3);
        //    orderX.Producten.Add((3, 1.99M, 99));
        //    orderX.Schotels.Add((1, 2.22M, 99));
        //    orderX.Schotels.Add((2, 2.05M, 55));
        //    orderX.Schotels.Add((3, 1.99M, 99));
        //    Data.AddBestelling(orderX);

        //    Data.DeleteBestelling(2);

        //    foreach (var item in Data.GetBestelling())
        //    {
        //        Console.WriteLine("-----------------------------------------");
        //        Console.WriteLine("----- Bestel-ID: " + item.ID + " ---------------------- ");
        //        Console.WriteLine(item.DatumAanmaak);
        //        Console.WriteLine("Besteld door: " + Data.GetKlant()[item.KlantID - 1].VoorNaam);
        //        Console.WriteLine("\t\t>>>Bestelde producten:");
        //        decimal totaalprijs = 0.0M;
        //        foreach (var product in item.Producten)
        //        {
        //            Console.WriteLine($"\t\t\t{Data.GetProduct()[product.ID - 1].Naam}, prijs: {product.Prijs} euro, {product.Aantal} stuks.");
        //            totaalprijs += (product.Prijs * product.Aantal);
        //        }
        //        Console.WriteLine("\t\t>>>Bestelde Schotels:");
        //        foreach (var schotels in item.Schotels)
        //        {
        //            Console.WriteLine($"\t\t\t{Data.GetSchotel()[schotels.ID - 1].Naam}, prijs: {schotels.Prijs} euro, {schotels.Aantal} stuks.");
        //            totaalprijs += (schotels.Prijs * schotels.Aantal);
        //        }
        //        Console.WriteLine($"$$$ - Totaalprijs: {totaalprijs} euro - $$$");
        //    }
        //}
    }
}