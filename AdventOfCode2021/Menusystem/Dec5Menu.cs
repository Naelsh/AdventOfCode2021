using AdventOfCode2021.Dec2;
using AdventOfCode2021.Dec3;
using AdventOfCode2021.Dec5;
using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec5Menu : ProblemMenu
    {
        private Menu _mainMenu;

        public Dec5Menu(Menu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public override void PrintResult(string result)
        {
            throw new NotImplementedException();
        }

        public override void PrintResult(int result)
        {
            throw new NotImplementedException();
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Welcome to december 5th. Make sure that you copy your input into a file called dec5.txt in the debug folder");
            Console.WriteLine("Then select one of the following:");
            Console.WriteLine("1. Problem one");
            Console.WriteLine("2. Problem two");
            Console.WriteLine("3. Return to main menu");
        }

        public override Menu GetNextMenu(int input)
        {
            if (input == 3)
            {
                return _mainMenu;
            }
            else
            {
                return this;
            }
        }

        public override int HandleInput()
        {
            int input = GetIntAboveZeroFromUserInput(3);
            InputHandler inputHandler = new InputHandler();
            string[] results = inputHandler.GetInputRows("dec5.txt");
            HydrothermalVentScanner scanner = new HydrothermalVentScanner();
            scanner.SetupVents(results);
            scanner.CalculateIntersections();
            int overlaps = scanner.CountOfOverlappedPoints();
            switch (input)
            {
                case 1:
                    Console.WriteLine($"The number of oerlaps are: {overlaps}");
                    break;
                case 2:
                    Console.WriteLine($"The number of oerlaps are: {overlaps}");
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            return input;
        }
    }
}
