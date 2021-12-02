using AdventOfCode2021.Dec2;
using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec2Menu : ProblemMenu
    {
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
            Console.WriteLine("Welcome to december 2nd. Make sure that you copy your input into a file called dec2.txt in the debug folder");
            Console.WriteLine("Then select one of the following:");
            Console.WriteLine("1. Problem one");
            Console.WriteLine("2. Problem two");
            Console.WriteLine("3. Return to main menu");
        }

        public override Menu GetNextMenu(int input)
        {
            throw new NotImplementedException();
        }

        public override int HandleInput()
        {
            int input = GetIntAboveZeroFromUserInput(3);
            InputHandler inputHandler = new InputHandler();
            Submarine submarine = new Submarine();
            switch (input)
            {
                case 1:
                    //string[] results = inputHandler.GetSingleColumnInputToList();
                    //Movement[] movements = inputHandler.GetMovements(results);
                    //submarine.MoveSubmarine(movements);
                    break;
                case 2:
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
