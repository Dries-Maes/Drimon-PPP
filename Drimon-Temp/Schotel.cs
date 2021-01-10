using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    [Serializable]
    internal class Schotel
    {
        private List<int> productIDLijst = new List<int>();

        public Dictionary<int, int> IDlijst { get; set; }
        //Eventueel dictionary van maken om aantal van producten toe te voegen (eerste unieke waarde = product, 2de waarde aantal)

        public List<int> ProductIDLijst
        {
            get { return productIDLijst; }
            set { productIDLijst = value; }
        }

        public int ID { get; set; }
        public string Naam { get; set; }

        public DateTime DatumAanmaak { get; set; }

        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public int AantalBesteld { get; set; }
        public bool Actief { get; set; }

        public Schotel(string naam, decimal prijs=0, int voorraad = 0)
        {
            IDlijst = new Dictionary<int, int>();
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;
            Actief = true;
            DatumAanmaak = DateTime.Now;

            ID = Data.GetSchotel().Count + 1;
        }

        
        public void MethodeNieuweSchotel()
        {

            Menu.MethodeBannerLine("0");
            Console.WriteLine(" Geef de naam in van de schotel:");
            Console.WriteLine(" " + Naam);
            Console.WriteLine(" Schotel prijs:");
            Prijs = Convert.ToDecimal(Console.ReadLine());
            Menu.MethodeClearLine(-1);
            Console.WriteLine(" " + Prijs);
            Console.WriteLine(" Geef de actuele voorraad in"); 
            Voorraad = Convert.ToInt32(Console.ReadLine());
            Menu.MethodeClearLine(-1);
            Console.WriteLine(" " + Voorraad);
            bool producten = true;
            List<Product> productenLijst = Data.GetProduct();
            string zoekmethode = "alles" ;
            string parameter = "alles";
            
               do
                {
                    
                    Console.Clear();
                    Menu.MethodeBannerLine("Geef productID in", "Zoek product op naam", "Toon alle producten","Voeg Schotel toe!");
                    if (IDlijst.Count != 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
                        Console.WriteLine(HorizontaleLijn);
                        foreach (var item in IDlijst)
                        {
                            Console.WriteLine($" Je hebt {item.Value} keer {productenLijst[item.Key-1].Naam} geselecteerd.");
                        }
                        
                        Console.WriteLine(HorizontaleLijn);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
                    Console.WriteLine(HorizontaleLijn);

                        Console.WriteLine($" Voeg producten toe aan je schotel: {Naam} ");
                    Console.WriteLine(HorizontaleLijn);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                    Console.WriteLine();
                    ProductMenu.OverzichtProductLijst(zoekmethode, parameter);
                    switch (Menu.MethodeKiezer(4))
                    {
                        case 1:
                            Console.WriteLine(" Geef productID en vervolgens aantal in:");
                            int productID = Menu.MethodeCheckforID("product");
                            Console.WriteLine(" Geef het aantal in:");
                            IDlijst.Add(productID, Menu.MethodeCheckforInt(Console.ReadLine()));
                            Menu.MethodeSpinner(" wordt togevoegd aan schotel...");
                            break;
                        case 2:
                            Console.WriteLine(" Geef naam in:");
                            zoekmethode = "naam";
                            parameter = Console.ReadLine();
                            break;
                        case 3:
                            zoekmethode = "alles";
                            parameter = "alles";
                            break;
                    case 4:
                        producten = false;
                        break;
                        case 0:
                        SchotelMenu.MenuSchotelEnkel(ID);
                            break;
                        default:
                            break;
                    }

                } while (producten);
           

            Menu.MethodeSpinner("Schotel wordt aangemaakt...");

        }
    }
}