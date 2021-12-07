using AdventOfCode2021.Input;
using System;

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

        public int CalculateOptimalFuelCost()
        {
            return MoveTowards(CalcualteOptimalIndexToMoveTowards());
        }

        public int CalcualteOptimalIndexToMoveTowards()
        {
            int index = 0;
            bool isSearching = true;
            while (isSearching)
            {
                if (MoveTowards(index) > MoveTowards(index + 1))
                {
                    index++;
                }
                else if (MoveTowards(index) > MoveTowards(index - 1))
                {
                    index--;
                }
                else
                {
                    isSearching = false;
                }
            }
            return index;
        }

        public int MoveTowards(int position)
        {
            int total = 0;
            foreach (int vehicle in Vehicles)
            {
                total += Math.Abs(position - vehicle);
            }
            return total;
        }

        public int MoveTowardsCrabStyle(int position)
        {
            int total = 0;
            foreach (int vehicle in Vehicles)
            {
                int stepsToTake = Math.Abs(position - vehicle);
                for (int step = 1; step <= stepsToTake; step++)
                {
                    total += step;
                }
            }
            return total;
        }

        public int CalcualteOptimalIndexToMoveTowardsCrabStyle()
        {
            int index = 0;
            bool isSearching = true;
            while (isSearching)
            {
                if (MoveTowardsCrabStyle(index) > MoveTowardsCrabStyle(index + 1))
                {
                    index++;
                }
                else if (MoveTowardsCrabStyle(index) > MoveTowardsCrabStyle(index - 1))
                {
                    index--;
                }
                else
                {
                    isSearching = false;
                }
            }
            return index;
        }

        public int CalculateOptimalFuelCostCrabStyle()
        {
            return MoveTowardsCrabStyle(CalcualteOptimalIndexToMoveTowardsCrabStyle());
        }
    }
}