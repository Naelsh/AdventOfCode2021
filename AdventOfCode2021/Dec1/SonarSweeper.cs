using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec1
{
    public class SonarSweeper
    {
        public int CalculateNumberOfDepthIncreases(int[] depths)
        {
            int returnValue = 0;
            // took minus one since we are comparing with the next result
            for (int depth = 0; depth < depths.Length - 1; depth++)
            {
                returnValue += depths[depth] < depths[depth + 1] ? 1 : 0;
            }
            return returnValue;
        }
    }
}
