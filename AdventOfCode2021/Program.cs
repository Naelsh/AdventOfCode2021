using AdventOfCode2021.Menusystem;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new MainMenu();
            while (menu != null)
            {
                menu.ShowMenu();
                var input = menu.HandleInput();
                menu = menu.GetNextMenu(input);
            }
            Console.WriteLine("Good bye");
            Console.WriteLine("Press any key to exit application...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
