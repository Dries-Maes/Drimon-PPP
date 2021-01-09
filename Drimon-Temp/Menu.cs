using System;
using System.Collections.Generic;
using System.Threading;

namespace Drimon_Temp
{
    internal class Menu
    {
        public static void MenuHoofdmenu()
        {
            
            Console.Clear();
            MethodeBannerLine();
            Console.WriteLine($" 1.Nieuwe bestelling\n 2.Overzicht bestellingen\n 3.Klanten\n 4.Producten beheren\n 5.Intro?");
            switch (MethodeKiezer(5))
            {
                case 1:
                    Console.Clear();
                    KlantMenu.OverzichtKlantLijst();
                    KlantMenu.MenuKlantZoeken("bestelling");
                    break;

                case 2:
                    Console.Clear();
                    BestellingMenu.OverzichtBestellingen();
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

                case 5:
                    MethodeIntro();
                    Console.Clear();
                    MenuHoofdmenu();
                    break;

                default:
                    break;
            }
        }

        public static int MethodeKiezer(int menuAantal)
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

        public static void MethodeClearLine(int relativeY)
        {
            int intendedY = Console.CursorTop + relativeY; // hier stond - ipv +
            if (intendedY < 0) { intendedY = 0; }
            if (intendedY > Console.WindowHeight) { intendedY = Console.WindowHeight; }
            Console.SetCursorPosition(0, intendedY);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, intendedY);
        }
        public static void MethodeBannerLine()
            {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
            Console.WriteLine(HorizontaleLijn);
            Console.Write(" 0:Terug ".PadRight(Console.WindowWidth / 3 - 1)); 
            Console.Write(MethodePadLeftRight("Viswinkel DriMon", Console.WindowWidth / 3)); 
            Console.WriteLine($"{DateTime.Now}".PadLeft(Console.WindowWidth / 3));
            Console.WriteLine(HorizontaleLijn);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
        }
        public static string MethodePadLeftRight(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

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

        private static void MethodeWriteFullLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void MethodeIntro()
        {
            Console.ReadKey();
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 65; j++)
                {
                    Console.ResetColor();
                    Console.Clear();

                    var margin = "".PadLeft(j);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("" + @"
                        ██╗   ██╗██╗███████╗██╗    ██╗██╗███╗   ██╗██╗  ██╗███████╗██╗
                        ██║   ██║██║██╔════╝██║    ██║██║████╗  ██║██║ ██╔╝██╔════╝██║
                        ██║   ██║██║███████╗██║ █╗ ██║██║██╔██╗ ██║█████╔╝ █████╗  ██║
                        ╚██╗ ██╔╝██║╚════██║██║███╗██║██║██║╚██╗██║██╔═██╗ ██╔══╝  ██║
                         ╚████╔╝ ██║███████║╚███╔███╔╝██║██║ ╚████║██║  ██╗███████╗███████╗
                          ╚═══╝  ╚═╝╚══════╝ ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝╚══════╝

                                ██████╗ ██████╗ ██╗███╗   ███╗ ██████╗ ███╗   ██╗
                                ██╔══██╗██╔══██╗██║████╗ ████║██╔═══██╗████╗  ██║
                                ██║  ██║██████╔╝██║██╔████╔██║██║   ██║██╔██╗ ██║
                                ██║  ██║██╔══██╗██║██║╚██╔╝██║██║   ██║██║╚██╗██║
                                ██████╔╝██║  ██║██║██║ ╚═╝ ██║╚██████╔╝██║ ╚████║
                                ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝          ");

                    Console.ResetColor();

                    MethodeWriteFullLine(margin + "       . . . . o o O o o oo O o oo o O o");
                    MethodeWriteFullLine(margin + "                       O     o           o");
                    MethodeWriteFullLine(margin + "         _\\_  o                             o");
                    MethodeWriteFullLine(margin + "      \\\\/  o\\ .              ______      o");
                    MethodeWriteFullLine(margin + "      //\\___=              _/  (   \\_");
                    MethodeWriteFullLine(margin + "        ''       _       _/  (       \\_  O");
                    MethodeWriteFullLine(margin + "                | \\_   _/  (   (   (0) \\");
                    MethodeWriteFullLine(margin + "                |== \\_/  (   (          |");
                    MethodeWriteFullLine(margin + "                |=== _ (   (   (         |");
                    MethodeWriteFullLine(margin + "                |==_/ \\_ (   (      .   |");
                    MethodeWriteFullLine(margin + "   _\\_  o       | _/     \\_ (   (    \\__/");
                    MethodeWriteFullLine(margin + "\\\\/  o\\ .                 \\_ (      _/");
                    MethodeWriteFullLine(margin + "//\\___=                     |  |___/");
                    MethodeWriteFullLine(margin + "   ''                      /__/");
                    MethodeWriteFullLine("");

                    Thread.Sleep(50);
                }
            }
        }
        public static void MethodeSpinner()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();

                    var margin = " ".PadLeft(j);



                    Console.WriteLine("Product wordt besteld...");
                    Console.Write(margin + ">))´>" );
                    Console.WriteLine("");

                    Thread.Sleep(50);
                    Console.ResetColor();
                }
                for (int j = 10; j > 0; j--)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();

                    var margin = " ".PadLeft(j);



                    Console.WriteLine("Product wordt besteld...");
                    Console.Write(margin + "<`((< ");
                    Console.WriteLine("");

                    Thread.Sleep(50);
                    Console.ResetColor();
                }
            }
        }
    }
}