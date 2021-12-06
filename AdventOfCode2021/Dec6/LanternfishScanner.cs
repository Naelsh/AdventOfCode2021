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
    }
}
