using AdventOfCode2021.Dec6;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec6
{
    [TestFixture]
    class LanternfishTest
    {
        [Test]
        public void CreateLanternFish()
        {
            Lanternfish lanternfish = new Lanternfish(5);

            Assert.AreEqual(5, lanternfish.InternalTimer);
        }

        [TestCase(5,4)]
        [TestCase(0,6)]
        public void UpdateInternalTimer(int initial, int expected)
        {
            Lanternfish lanternfish = new Lanternfish(initial);
            lanternfish.TickDay();

            Assert.AreEqual(expected, lanternfish.InternalTimer);
        }

        [TestCase(5, false)]
        [TestCase(0, true)]
        public void FindOutIfNewFishIsBeingBorn(int initial, bool expected)
        {
            Lanternfish lanternfish = new Lanternfish(initial);

            Assert.AreEqual(expected, lanternfish.IsReadyToGiveBirth());
        }
    }
}
