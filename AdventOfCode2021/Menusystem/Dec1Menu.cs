using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class Dec1Menu : Menu
    {
        private Dictionary<int, Menu> _possibleMenus;
        public Dec1Menu(Menu returnMenu)
        {
            _possibleMenus = new Dictionary<int, Menu>();
            _possibleMenus.Add(0, returnMenu);
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Welcome to december 1st. Make sure that you copy your input into a file called dec1.txt in the debug folder");
            Console.WriteLine("Then select if you want to solve puzzle 1 or 2 by entering 1 or 2 :P");
        }

        public override Menu GetNextMenu(int input)
        {
            return _possibleMenus[0];
        }

        public override int HandleInput()
        {
            int input = GetIntAboveZeroFromUserInput(2);
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            return input;
        }
    }
}
