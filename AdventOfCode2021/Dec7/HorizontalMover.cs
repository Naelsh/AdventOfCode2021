using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021.Dec7
{
    public class HorizontalMover
    {
        public int[] Vehicles { get; set; }

        public void SetupVehicles(string[] input)
        {
            InputHandler inputHandler = new InputHandler();
            int[] values = inputHandler.ConvertStringListToInt(input[0].Split(','));
            Vehicles = values;
        }

        public int CalcualteOptimalFuelCost()
        {
            List<int> workingList = new List<int>(Vehicles);
            workingList.Sort();
            List<int> uniqueList = new List<int>(Vehicles);
            uniqueList = uniqueList.RemoveDuplicates();
            return 0;
        }
    }
}
