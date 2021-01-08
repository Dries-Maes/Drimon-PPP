using System;
using System.Collections.Generic;

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
            int legeKlant = 0;

            do
            {
                
                KlantMenu.OverzichtKlantLijst();
                Console.WriteLine("\nGeef een klanten ID in:");
                legeKlant = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"\nDag {Data.GetKlant()[legeKlant - 1].VoorNaam}, wat wil je bestellen?\n1.Een product\n2.Een schotel\n3.Annuleer bestelling\n4.Plaats bestelling!");
                switch (Menu.Kiezer(4))
                {
                    case 1:
                        ProductMenu.OverzichtProductLijst();
                        Console.WriteLine("\nGeef het productID in:");
                        Product tempProduct = huidigeProducten[KlantMenu.MethodeCheckforInt(Console.ReadLine()) - 1];
                        Console.WriteLine("\nGeef het productID aantal in:");
                        int tempAantal = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                        Console.WriteLine($"Je koos {tempProduct.Naam} en wil dit {tempAantal} keer bestellen.\n1.Toevoegen aan bestelling\n2.Niet toevoegen en opnieuw kiezen");
                        switch (Menu.Kiezer(2))
                        {
                            case 1:
                                ProdID.Add(tempProduct.ID, tempAantal);
                                besteldeProducten.Add(tempProduct);
                                break;
                            case 2:
                                
                                break;
                        }
                        break;
                    case 2:
                        SchotelMenu.OverzichtSchotelLijst();
                        Console.WriteLine("\nGeef het schotel ID in:");
                        Schotel tempSchotel = huidigeSchotels[KlantMenu.MethodeCheckforInt(Console.ReadLine()) - 1];
                        Console.WriteLine("\nGeef het schotel ID aantal in:");
                        int tempAantal2 = KlantMenu.MethodeCheckforInt(Console.ReadLine());
                        Console.WriteLine($"Je koos {tempSchotel.Naam} en wil dit {tempAantal2} keer bestellen.\n1.Toevoegen aan bestelling\n2.Niet toevoegen en opnieuw kiezen");
                        switch (Menu.Kiezer(2))
                        {
                            case 1:
                                ProdID.Add(tempSchotel.ID, tempAantal2);
                                besteldeSchotels.Add(tempSchotel);
                                break;
                            case 2:
                                
                                break;
                        }
                        break;
                    case 3:
                        Menu.MenuHoofdmenu();
                        break;
                    case 4:
                        break;
                }
            } while (actief);
            producten = besteldeProducten;
            schotels = besteldeSchotels;
            KlantID = legeKlant;

        }   







        

    }
}