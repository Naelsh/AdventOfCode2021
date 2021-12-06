using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec6
{
    public class Lanternfish
    {
        public int InternalTimer { get; set; }

        public Lanternfish(int initialTimer)
        {
            InternalTimer = initialTimer;
        }

        public bool IsReadyToGiveBirth()
        {
            if (InternalTimer == 0)
            {
                return true;
            }
            return false;
        }

        public void TickDay()
        {
            if (InternalTimer == 0)
            {
                InternalTimer = 7;
            }
            InternalTimer--;
        }
    }
}
