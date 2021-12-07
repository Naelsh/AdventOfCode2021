using AdventOfCode2021.Dec7;
using AdventOfCode2021.Input;
using System;

namespace AdventOfCode2021.Menusystem
{
    class Dec7Menu : ProblemMenu
    {
        private Menu _mainMenu;

        public Dec7Menu(Menu mainMenu)
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
            Console.WriteLine("Welcome to december 7th. Make sure that you copy your input into a file called dec7.txt in the debug folder");
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
            string[] results = inputHandler.GetInputRows("dec7.txt");
            HorizontalMover mover = new HorizontalMover();
            mover.SetupVehicles(results);
            switch (input)
            {
                case 1:
                    int fuelCost = mover.CalculateOptimalFuelCost();
                    Console.WriteLine($"The crabs need {fuelCost} fuel toe move to index {mover.CalcualteOptimalIndexToMoveTowards()}");
                    break;
                case 2:
                    int crabFuelCost = mover.CalculateOptimalFuelCostCrabStyle();
                    Console.WriteLine($"The crabs need {crabFuelCost} fuel toe move to index {mover.CalcualteOptimalIndexToMoveTowardsCrabStyle()}");
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