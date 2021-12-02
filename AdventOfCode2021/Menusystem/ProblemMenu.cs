using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Menusystem
{
    public abstract class ProblemMenu : Menu
    {
        public abstract void PrintResult(string result);
        public abstract void PrintResult(int result);
    }
}
