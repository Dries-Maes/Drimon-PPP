using System;
using System.Collections.Generic;

namespace Drimon_Temp
{
    internal class Menu
    {
        public static void MenuHoofdmenu()
        {
            Console.Clear();
            Console.WriteLine($"1.Nieuwe bestelling\n2.Klanten\n3.Overzicht bestellingen\n4.Producten beheren");
            switch (Kiezer(4))
            {
                case 1:
                    dtest1.Dostuff2();
                    MenuHoofdmenu();
                    break;

                case 2:
                    Console.Clear();
                    KlantMenu.MenuKlantHoofdmenu();
                    break;

                case 3:
                    Console.WriteLine("ToDo, press any key to return. ");//ToDo
                    MenuHoofdmenu();
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
    }
}