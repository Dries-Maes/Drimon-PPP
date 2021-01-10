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
            MethodeBannerLine("Nieuwe bestelling", "Overzicht bestellingen", "Klanten", "Producten beheren");
            
            switch (MethodeKiezer(4))
            {
                case 1:
                    Console.Clear();
                    
                    KlantMenu.MenuKlantZoeken("alles", "alles", "bestelling");
                    break;

                case 2:
                    Console.Clear();
                  


                    BestellingMenu.MenuBestellingenHoofdmenu();
                    
                    break;

                case 3:
                    Console.Clear();
                    KlantMenu.MenuKlantZoeken();
                    break;

                case 4:
                    Console.Clear();
                    ProductMenu.MenuProductHoofdmenu();
                    break;

                case 0:
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
            keuzelijst.Add(0);
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
        public static void MethodeBannerLine(string in1 = null, string in2 = null, string in3 = null, string in4 = null, string in5 = null, string in6 = null, string in7 = null)
            {
            int noBack = 1; 
            if (in1 == "0")
            {
                in1 = null;
                noBack = 0;
            }
            string[] menuItems = new string[7] { in1, in2, in3, in4, in5, in6, in7 } ;
            List<string> usedItems = new List<string>();
            foreach (var item in menuItems)
            {
                if (!String.IsNullOrEmpty(item)) usedItems.Add(item);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
            Console.WriteLine(HorizontaleLijn);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (noBack != 0)
            {
                Console.Write(" 0:Terug ".PadRight(Console.WindowWidth / 3 - 1));
            }
            else
            {
                Console.Write(" Vul in  ".PadRight(Console.WindowWidth / 3 - 1));
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(MethodePadLeftRight(" V i s w i n k e l   D r i M o n ".ToUpper(), Console.WindowWidth / 3));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now}".PadLeft(Console.WindowWidth / 3));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(HorizontaleLijn);
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (usedItems.Count != 0)   
            {
            Console.Write(" ");
            for (int j = 0; j < usedItems.Count; j++)
            {
                Console.Write(MethodePadLeftRight($"{j + 1}.{usedItems[j]} ", Console.WindowWidth / usedItems.Count - 2));
            }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n" + HorizontaleLijn);
            }
        





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
        public static int MethodeCheckforID(string typeID)
        {
            List<int> IDList = new List<int>();
            int input = 0;
            switch (typeID)
            {
                case "product":
                    foreach (var item in Data.GetProduct())
                    {
                        IDList.Add(item.ID);
                    }
                    while (!IDList.Contains(input = MethodeCheckforInt(Console.ReadLine()))) ;
                    break;
                case "schotel":
                    foreach (var item in Data.GetSchotel())
                    {
                        IDList.Add(item.ID);
                    }
                    while (!IDList.Contains(input = MethodeCheckforInt(Console.ReadLine()))) ;
                    break;
                case "klant":
                    foreach (var item in Data.GetKlant())
                    {
                        IDList.Add(item.ID);
                    }
                    while (!IDList.Contains(input = MethodeCheckforInt(Console.ReadLine()))) ;
                    break;
                case "bestelling":
                    foreach (var item in Data.GetBestelling())
                    {
                        IDList.Add(item.ID);
                    }
                    while (!IDList.Contains(input = MethodeCheckforInt(Console.ReadLine()))) ;
                    break;
            }
            return input;
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
            Console.Clear();
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

           
                for (int j = 0; j < 65; j++)
                {
                Console.SetCursorPosition(0, 15);
                    var margin = "".PadLeft(j);
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "       . . . . o o O o o oo O o oo o O o");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "                       O     o           o");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "         _\\_  o                             o");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "      \\\\/  o\\ .              ______      o");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "      //\\___=              _/  (   \\_");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "        ''       _       _/  (       \\_  O");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "                | \\_   _/  (   (   (0) \\");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "                |== \\_/  (   (          |");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "                |=== _ (   (   (         |");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "                |==_/ \\_ (   (      .   |");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "   _\\_  o       | _/     \\_ (   (    \\__/");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "\\\\/  o\\ .                 \\_ (      _/");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "//\\___=                     |  |___/");
                MethodeClearLine(0);
                MethodeWriteFullLine(margin + "   ''                      /__/");
                
                    Thread.Sleep(50);

                }
            
        }
        public static void MethodeSpinner(string Opmerking = "")
        {
            Console.WriteLine(" " + Opmerking);
            
                for (int j = 0; j < 19; j++)
                {
                    var margin = " ".PadLeft(j);
                    Console.Write(margin + ">))´>" );
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Thread.Sleep(70);
                }
                for (int j = 19; j > 0; j--)
                {
                    var margin = " ".PadLeft(j);
                    Console.Write(margin + "<`((< ");
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Thread.Sleep(70);
                }
            
        }
    }
}