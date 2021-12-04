using AdventOfCode2021.Dec2;
using AdventOfCode2021.Dec3;
using AdventOfCode2021.Dec4;
using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec4Menu : ProblemMenu
    {
        private Menu _mainMenu;

        public Dec4Menu(Menu mainMenu)
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
            Console.WriteLine("Welcome to december 4th. Make sure that you copy your input into a file called dec4.txt in the debug folder");
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
            string[] results = inputHandler.GetInputRows("dec4.txt");
            BingoSystem bingoSystem = new BingoSystem();
            bingoSystem.SetGuessedNumbers(results[0]);
            List<string> tempList = results.ToList();
            tempList.RemoveAt(0);
            bingoSystem.SetUpBoards(tempList.ToArray());
            switch (input)
            {
                case 1:
                    int finalNumber = bingoSystem.DrawNumbersTillFirstWinnerIsFound(out BingoBoard winner);
                    Console.WriteLine($"And the winning number is: {finalNumber} and the board sum is {winner.SumUnmarkedTiles()}");
                    Console.WriteLine($"Which gives a total of {finalNumber * winner.SumUnmarkedTiles()}");
                    break;
                case 2:
                    int octopusFinalNumber = bingoSystem.DrawNumbersTillFinalBoardWins(out BingoBoard octopusWinner);
                    Console.WriteLine($"And the winning number is: {octopusFinalNumber} and the board sum is {octopusWinner.SumUnmarkedTiles()}");
                    Console.WriteLine($"Which gives a total of {octopusFinalNumber * octopusWinner.SumUnmarkedTiles()}");
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
