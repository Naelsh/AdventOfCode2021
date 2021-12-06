using AdventOfCode2021.Dec2;
using AdventOfCode2021.Dec3;
using AdventOfCode2021.Dec6;
using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec6Menu : ProblemMenu
    {
        private Menu _mainMenu;

        public Dec6Menu(Menu mainMenu)
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
            Console.WriteLine("Welcome to december 6th. Make sure that you copy your input into a file called dec6.txt in the debug folder");
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
            string[] results = inputHandler.GetInputRows("dec6.txt");
            LanternfishScanner scanner = new LanternfishScanner();
            scanner.SetupFishCollection(results);
            int days = 80;
            switch (input)
            {
                case 1:
                    days = 80;
                    for (int day = 0; day < days; day++)
                    {
                        scanner.BreedNewFishes(scanner.CalculateNextDay());
                    }
                    Console.WriteLine($"The total number of fishes after {days} days are: {scanner.Fishes.Count}");
                    break;
                case 2:
                    scanner.SetupWorldDominationCounter(results);
                    days = 256;
                    scanner.TakeOverTheWorldCounter(days);
                    long total = scanner.TotalAmountOfWorldDominationFishes();
                    Console.WriteLine($"The total number of fishes after {days} days are: {total}");
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
