﻿using AdventOfCode2021.Dec1;
using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec1Menu : ProblemMenu
    {
        private Menu _mainMenu;
        public Dec1Menu(Menu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Welcome to december 1st. Make sure that you copy your input into a file called dec1.txt in the debug folder");
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
            InputHandler inputHandler = new InputHandler("dec1.txt");
            SonarSweeper sonarSweeper = new SonarSweeper();
            try
            {
                switch (input)
                {
                    case 1:
                        int[] depths = inputHandler.ConvertStringListToInt(inputHandler.GetSingleColumnInputToList());
                        int result = sonarSweeper.CalculateNumberOfDepthIncreases(depths);
                        PrintResult(result);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            return input;
        }

        public override void PrintResult(string result)
        {
            Console.WriteLine("The result for the problem is: \n " + result);
        }

        public override void PrintResult(int result)
        {
            PrintResult(result.ToString());
        }
    }
}