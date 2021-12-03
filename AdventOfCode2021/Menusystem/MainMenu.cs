using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    class MainMenu : Menu
    {
        private Dictionary<int, Menu> _possibleMenus;
        public MainMenu()
        {
            _possibleMenus = new Dictionary<int, Menu>();
            _possibleMenus.Add(1, new Dec1Menu(this));
            _possibleMenus.Add(2, new Dec2Menu(this));
            _possibleMenus.Add(3, new Dec3Menu(this));
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Welcome to this years challenge, please enter the corresponding number for the day you want to go to");
            foreach (var item in _possibleMenus)
            {
                Console.WriteLine($"{item.Key}. {item.Value.GetType().Name}");
            }
            Console.WriteLine($"{_possibleMenus.Count + 1}. Exit application");
        }

        public override Menu GetNextMenu(int input)
        {
            if (input == _possibleMenus.Count + 1)
            {
                return null;
            }
            return _possibleMenus[input];
        }

        public override int HandleInput()
        {
            int input = GetIntAboveZeroFromUserInput(_possibleMenus.Count + 1);
            return input;
        }
    }
}
