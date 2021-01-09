using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class Menu
    {
        public static void MenuHoofdmenu()
        {
            Console.Clear();
            Console.WriteLine($"1.Nieuwe bestelling\n2.Overzicht bestellingen\n2.Klanten\n4.Producten beheren");
            switch (Kiezer(4))
            {
                case 1:
                    Console.Clear();
                    KlantMenu.OverzichtKlantLijst();
                    KlantMenu.MenuKlantZoeken("bestelling");
                    break;

                case 2:
                    Console.Clear();
                    BestellingMenu.MenuBestellingenHoofdmenu();
                    break;

                case 3:
                    Console.Clear();
                    KlantMenu.MenuKlantHoofdmenu();
                    break;

                case 4:
                    Console.Clear();
                    ProductMenu.MenuProductHoofdmenu();
                    // go to productenbeheermenu >
                    break;

                default:
                    break;
            }
        }

        public static int Kiezer(int menuAantal)
        {
            int menuAantalIntern = menuAantal;
            List<int> keuzelijst = new List<int>();
            do
            {
                keuzelijst.Add(menuAantalIntern);
                menuAantalIntern--;
            } while (menuAantalIntern != 0);
            int input;
            int output = 0;
            do
            {
                input = (int)(Console.ReadKey().Key);
                if (keuzelijst.Contains(input - 96))
                {
                    output = input - 96;
                    input = 0;
                }
                else if (keuzelijst.Contains(input - 111))
                {
                    output = input - 111;
                    input = 0;
                }
                else if (keuzelijst.Contains(input - 48))
                {
                    output = input - 48;
                    input = 0;
                }
                Console.CursorLeft = 0;
                Console.Write(" ");
                Console.CursorLeft = 0;
            } while (input != 0);
            return output;
        }
        
        
            public static void Clearline(int relativeY)
            {
                int intendedY = Console.CursorTop + relativeY; // hier stond - ipv +
                if (intendedY < 0) { intendedY = 0; }
                if (intendedY > Console.WindowHeight) { intendedY = Console.WindowHeight; }
                Console.SetCursorPosition(0, intendedY);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, intendedY);
            }

        public static int MethodeCheckforInt(string stringInput)
        {
            string tocheck = stringInput;
            int output;
            while (!Int32.TryParse(tocheck, out output))
            {
                tocheck = Console.ReadLine();
            }
            return output;
        }


    }
}