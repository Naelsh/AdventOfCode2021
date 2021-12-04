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
            _possibleMenus.Add(4, new Dec4Menu(this));
            _possibleMenus.Add(5, new Dec5Menu(this));
            _possibleMenus.Add(6, new Dec6Menu(this));
            _possibleMenus.Add(7, new Dec7Menu(this));
            _possibleMenus.Add(8, new Dec8Menu(this));
            _possibleMenus.Add(9, new Dec9Menu(this));
            _possibleMenus.Add(10, new Dec10Menu(this));
            _possibleMenus.Add(11, new Dec11Menu(this));
            _possibleMenus.Add(12, new Dec12Menu(this));
            _possibleMenus.Add(13, new Dec13Menu(this));
            _possibleMenus.Add(14, new Dec14Menu(this));
            _possibleMenus.Add(15, new Dec15Menu(this));
            _possibleMenus.Add(16, new Dec16Menu(this));
            _possibleMenus.Add(17, new Dec17Menu(this));
            _possibleMenus.Add(18, new Dec18Menu(this));
            _possibleMenus.Add(19, new Dec19Menu(this));
            _possibleMenus.Add(20, new Dec20Menu(this));
            _possibleMenus.Add(21, new Dec21Menu(this));
            _possibleMenus.Add(22, new Dec22Menu(this));
            _possibleMenus.Add(23, new Dec23Menu(this));
            _possibleMenus.Add(24, new Dec24Menu(this));
            _possibleMenus.Add(25, new Dec25Menu(this));
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
