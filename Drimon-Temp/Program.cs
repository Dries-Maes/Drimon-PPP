using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Simon!");
            //Dtest.DTEST();
            Data.AddKlant();
            List<Klant> resultaat = Data.GetKlant();
            List<object> resultaatOBJ = resultaat;
            foreach (Klant item in resultaat)
            {
                Console.WriteLine(item.VoorNaam);
                Console.WriteLine(item.AchterNaam);
            }

            Console.ReadLine();
            Console.WriteLine("Simon pushtest 05 01 - 10 56");
        }
    }
}