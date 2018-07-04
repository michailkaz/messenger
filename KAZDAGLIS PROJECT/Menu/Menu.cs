using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class Menu
    {
        //GENERAL MENU PROCESSING METHOD
        public static string MenuRun(List<string> _menu, string Username, int AccessLevel)
        {
            int choice = 0;
            while (true)
            {
                // Print Menu Header
                Console.Clear();
                Console.WriteLine("  MESSAGES CLIENT");
                Console.WriteLine($"   Welcome <{Username.ToUpper()}>!");
                Console.WriteLine($"     Level: {AccessLevel}");
                Console.WriteLine();

                // Print Menu Items
                for (int i = 0; i < _menu.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;

                        Console.WriteLine($">> {_menu[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {_menu[i]}");
                    }
                    
                }

                ConsoleKeyInfo ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (choice >= _menu.Count-1)
                    {
                        choice = 0;
                    }
                    else
                    {
                        choice++;
                    }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (choice <= 0 )
                    {
                        choice = _menu.Count -1;
                    }
                    else
                    {
                        choice--;
                    } 
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    return _menu[choice];
                }

                Console.Clear();
            }
        }
    }
}




