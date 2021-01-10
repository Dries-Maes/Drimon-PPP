using System;
using System.Collections.Generic;
using System.Threading;

namespace Drimon_Temp
{
    [Serializable]
    internal class Bestelling
    {
        private List<Product> producten = new List<Product>();
        private List<Schotel> schotels = new List<Schotel>();

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
                ID = Data.GetBestelling()[^1].ID + 1; // indien bestelling 1/-/3/4 -> next=5 // indien 1/2/3/-/ next = 4!! ok of niet?
            }
        }

        public string MethodeIsAfgerond()
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

        public decimal MethodeTotaalPrijs()
        {
            decimal result = 0;
            foreach (var item in Producten)
            {
                result += item.Prijs;
            }
            foreach (var item in Schotels)
            {
                result += item.Prijs;
            }
            return Math.Round(result, 2);
        }

        public void MethodeNieuweBestelling() // lege bestelling is mogelijk!
        {
            
            
            List<Product> huidigeProducten = Data.GetProduct();
            List<Schotel> huidigeSchotels = Data.GetSchotel();
            bool actief = true;

            do
            {


                Console.Clear();
                Menu.MethodeBannerLine("Selecteer product", "selecteer schotel", "plaats bestelling");
                
                if (schotels.Count != 0 || producten.Count != 0)
                {
                    
                    Console.WriteLine($"\n |ID".PadRight(8) + $"|Naam".PadRight(15) + $"|Prijs".PadRight(12) + $"|Stuks".PadRight(20));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    string HorizontaleLijn = new String('─', 40);
                    Console.WriteLine(HorizontaleLijn);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var item in producten)
                    {
                        Console.WriteLine($" |{item.ID}".PadRight(7) + $"|{item.Naam}".PadRight(15) + $"|{item.Prijs}".PadRight(12) + $"|{item.AantalBesteld}".PadRight(20));
                        
                    }
                    foreach (var item in schotels)
                    {
                        Console.WriteLine($" |{item.ID}".PadRight(7) + $"|{item.Naam}".PadRight(15) + $"|{item.Prijs}".PadRight(12) + $"|{item.AantalBesteld}".PadRight(20));
                       
                    }
                    Console.WriteLine($"\n Totaalprijs van de bestelling is: {MethodeTotaalPrijs()} euro\n");
                }
                else
                {
                    Console.WriteLine("Voeg items toe aan je bestelling. ");
                }
                
                switch (Menu.MethodeKiezer(3))
                {
                    case 1:
                        Console.Clear();
                        Menu.MethodeBannerLine("0");
                        ProductMenu.OverzichtProductLijst();
                        Console.WriteLine("\n Geef het productID in:");
                        Product tempProduct = huidigeProducten[Menu.MethodeCheckforID("product") - 1];
                        Menu.MethodeClearLine(-1);
                        Console.WriteLine(" " +tempProduct.Naam);
                        Console.WriteLine("\n Geef het aantal in:");
                        tempProduct.AantalBesteld = Menu.MethodeCheckforInt(Console.ReadLine());
                        Menu.MethodeClearLine(-1);
                        Console.WriteLine(" " + tempProduct.AantalBesteld + "\n");
                        Menu.MethodeSpinner("Product wordt toegevoegd ...");

                        if (tempProduct.AantalBesteld != 0)
                        {
                                producten.Add(tempProduct);        
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Menu.MethodeBannerLine("0");
                        SchotelMenu.OverzichtSchotels();
                        Console.WriteLine("\n Geef het schotel ID in:");
                        Schotel tempSchotel = huidigeSchotels[Menu.MethodeCheckforID("schotel") - 1];
                        Menu.MethodeClearLine(-1);
                        Console.WriteLine(" " + tempSchotel.Naam);
                        Console.WriteLine("\n Geef het aantal in:");
                        tempSchotel.AantalBesteld = Menu.MethodeCheckforInt(Console.ReadLine());
                        Menu.MethodeClearLine(-1);
                        Console.WriteLine(" " + tempSchotel.AantalBesteld +"\n");
                        Menu.MethodeSpinner("Schotel wordt toegevoegd ...");

                        if (tempSchotel.AantalBesteld != 0 )
                        {
                            schotels.Add(tempSchotel);
                        }
                        
                        break;

                    case 3:
                        actief = false;
                        break;
                    case 0:
                        Console.Clear();
                        Menu.MenuHoofdmenu();
                        break;
                }
            } while (actief);
            
            
        }
    }
}