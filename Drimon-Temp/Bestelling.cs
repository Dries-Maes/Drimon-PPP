﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Drimon_Temp
{
    [Serializable]
    internal class Bestelling
    {
        private List<Product> producten;
        private List<Schotel> schotels;

        public List<Product> Producten
        {
            get { return producten; }
            set { producten = value; }
        }

        public List<Schotel> Schotels
        {
            get { return schotels; }
            set { schotels = value; }
        }

        public Dictionary<int, int> ProdID { get; set; }
        public Dictionary<int, int> SchotID { get; set; }

        public int ID { get; set; }
        public DateTime DatumAanmaak { get; set; }

        public bool Afgerond { get; set; }
        public int KlantID { get; set; }

        public Bestelling(int klantID)
        {
            Afgerond = false;
            KlantID = klantID;
            DatumAanmaak = DateTime.Now;
            ProdID = new Dictionary<int, int>();
            SchotID = new Dictionary<int, int>();

            if (Data.GetBestelling().Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Data.GetBestelling()[Data.GetBestelling().Count - 1].ID + 1; // indien bestelling 1/-/3/4 -> next=5 // indien 1/2/3/-/ next = 4!! ok of niet?
            }
        }

        public string IsAfgerond()
        {
            if (Afgerond)
            {
                return "----Status: Afgerond";
            }
            else
            {
                return "Status: Open";
            }
        }

        public int totaalPrijs()
        {
            decimal result = 0;
            foreach (var item in producten)
            {
                result += item.Prijs;
            }
            foreach (var item in schotels)
            {
                result += item.Prijs;
            }
            return Convert.ToInt32(result);
        }

        public void NieuweBestelling() // lege bestelling is mogelijk!
        {
            List<Product> besteldeProducten = new List<Product>();
            List<Schotel> besteldeSchotels = new List<Schotel>();
            List<Product> huidigeProducten = Data.GetProduct();
            List<Schotel> huidigeSchotels = Data.GetSchotel();
            bool actief = true;

            do
            {
                Console.Clear();
                if (besteldeSchotels.Count != 0 || besteldeProducten.Count != 0)
                {
                    decimal totaalPrijsBestelling = 0.00M;
                    Console.WriteLine($"\n |ID".PadRight(6) + $"| Naam".PadRight(12) + $"| Prijs".PadRight(12) + $"| Stuks".PadRight(12));
                    foreach (var item in besteldeProducten)
                    {
                        Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.Naam}".PadRight(12) + $"|{item.Prijs}".PadRight(12) + $"|{item.AantalBesteld}".PadRight(12));
                        totaalPrijsBestelling += (item.Prijs * item.AantalBesteld);
                    }
                    foreach (var item in besteldeSchotels)
                    {
                        Console.WriteLine($" |{item.ID}".PadRight(6) + $"|{item.Naam}".PadRight(12) + $"|{item.Prijs}".PadRight(12) + $"|{item.AantalBesteld}".PadRight(12));
                        totaalPrijsBestelling += (item.Prijs * item.AantalBesteld);
                    }
                    Console.WriteLine($"\n Totaalprijs van de bestelling is: {totaalPrijsBestelling} euro\n");
                }
                Console.WriteLine($" Dag {Data.GetKlant()[KlantID - 1].VoorNaam}, wat wil je bestellen?\n 1.Een product\n 2.Een schotel\n 3.Annuleer bestelling\n 4.Plaats bestelling!");
                switch (Menu.Kiezer(4))
                {
                    case 1:
                        Console.Clear();
                        ProductMenu.OverzichtProductLijst();
                        Console.WriteLine("\n Geef het productID in:");
                        Product tempProduct = huidigeProducten[Menu.MethodeCheckforInt(Console.ReadLine()) - 1];
                        Menu.Clearline(-1);
                        Console.WriteLine(" " +tempProduct.Naam);
                        Console.WriteLine("\n Geef het aantal in:");
                        tempProduct.AantalBesteld = Menu.MethodeCheckforInt(Console.ReadLine());
                       Menu.Spinner();

                        if (tempProduct.AantalBesteld != 0)
                        {
                                besteldeProducten.Add(tempProduct);        
                        }
                        break;

                    case 2:
                        Console.Clear();
                        SchotelMenu.OverzichtSchotelLijst();
                        Console.WriteLine("\n Geef het schotel ID in:");
                        
                        Schotel tempSchotel = huidigeSchotels[Menu.MethodeCheckforInt(Console.ReadLine()) - 1];
                        Menu.Clearline(-1);
                        Console.WriteLine(" " + tempSchotel.Naam);
                        Console.WriteLine("\n Geef het aantal in:");
                        tempSchotel.AantalBesteld = Menu.MethodeCheckforInt(Console.ReadLine());
                        
                        Menu.Spinner();

                        if (tempSchotel.AantalBesteld != 0 )
                        {
                            besteldeSchotels.Add(tempSchotel);
                        }
                        
                        break;

                    case 3:
                        Menu.MenuHoofdmenu();
                        break;

                    case 4:
                        actief = false;
                        break;
                }
            } while (actief);
            producten = besteldeProducten;
            schotels = besteldeSchotels;
        }
    }
}