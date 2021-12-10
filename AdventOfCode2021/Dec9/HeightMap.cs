using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec9
{
    public class HeightMap
    {
        public int[][] Map { get; private set; }

        public HeightMap()
        {
            
        }

        public void SetHeightMap(string[] input)
        {
            int[][] newMap = new int[input.Length][];
            for (int inputRow = 0; inputRow < input.Length; inputRow++)
            {
                int[] mapRow = new int[input[inputRow].Length];
                for (int numberIndex = 0; numberIndex < input[inputRow].Length; numberIndex++)
                {
                    mapRow[numberIndex] = int.Parse(input[inputRow][numberIndex].ToString());
                }
                newMap[inputRow] = mapRow;
            }
            Map = newMap;
        }
    }
}
