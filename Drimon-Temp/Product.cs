using System;

namespace Drimon_Temp
{
    [Serializable]
    internal class Product
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public int AantalBesteld { get; set; }
        public bool Actief { get; set; }
        public DateTime DatumAanmaak { get; set; }

        public Product(string naam, decimal prijs = 0, int voorraad = 0)
        {
            Naam = naam;
            Prijs = prijs;
            Voorraad = voorraad;
            Actief = true;
            ID = Data.GetProduct().Count + 1;
            DatumAanmaak = DateTime.Now;
        }

        public void MethodeNieuwProduct()
        {
            
            Menu.MethodeBannerLine("0");
            Console.WriteLine(" Geef de naam van het product in:");
            Naam = Console.ReadLine();
            Menu.MethodeClearLine(-1);
            Console.WriteLine(" " + Naam);
            Console.WriteLine("Product prijs:");
            Prijs = Convert.ToDecimal(Console.ReadLine());
            Menu.MethodeClearLine(-1);
            Console.WriteLine(" " + Prijs);
            Console.WriteLine(" Geef de actuele voorraad in"); //eventueel stockwijziging loggen
            Voorraad = Convert.ToInt32(Console.ReadLine());
            Menu.MethodeClearLine(-1);
            Console.WriteLine(" " + Voorraad);
            Menu.MethodeSpinner(" Product wordt aangemaakt...");

        }
    }
}