using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec6
{
    public class LanternfishScanner
    {
        public List<Lanternfish> Fishes { get; set; } = new List<Lanternfish>();

        public int CalculateNextDay()
        {
            int newFishcount = 0;
            foreach (Lanternfish lanternfish in Fishes)
            {
                bool givesBirth = lanternfish.IsReadyToGiveBirth();
                lanternfish.TickDay();
                if (givesBirth)
                {
                    newFishcount++;
                }
            }
            return newFishcount;
        }


        public void SetupFishCollection(string[] input)
        {
            InputHandler inputHandler = new InputHandler();
            int[] fishNumbers = inputHandler.ConvertStringListToInt(input[0].Split(','));

            foreach (int number in fishNumbers)
            {
                Lanternfish newFish = new Lanternfish(number);
                Fishes.Add(newFish);
            }
        }

        public void BreedNewFishes(int amount)
        {
            for (int fish = 0; fish < amount; fish++)
            {
                Lanternfish newFish = new Lanternfish(8);
                Fishes.Add(newFish);
            }
        }

        public void TakeOverTheWorldCounter(int numDays)
        {
            for (int day = 0; day < numDays; day++)
            {
                long[] temp = new long[9];
                WorldDominationFishes.CopyTo(temp, 0);
                for (int maturity = WorldDominationFishes.Length-1; maturity >= 0; maturity--)
                {
                    if (maturity == 0)
                    {
                        WorldDominationFishes[8] = temp[0];
                        WorldDominationFishes[6] += temp[0];
                    }
                    else
                    {
                        WorldDominationFishes[maturity - 1] = temp[maturity];
                    }
                }
            }
        }

        public long[] WorldDominationFishes { get; set; } = new long[9];

        public void SetupWorldDominationCounter(string[] input)
        {
            InputHandler inputHandler = new InputHandler();
            int[] fishNumbers = inputHandler.ConvertStringListToInt(input[0].Split(','));
            Array.Sort(fishNumbers);
            long[] fishesByNumbers = new long[9];
            foreach (int fish in fishNumbers)
            {
                 fishesByNumbers[fish]++;
            }
            WorldDominationFishes = fishesByNumbers;
        }

        public long TotalAmountOfWorldDominationFishes()
        {
            long result = 0;
            foreach (long value in WorldDominationFishes)
            {
                result += value;
            }
            return result;
        }
    }
}
