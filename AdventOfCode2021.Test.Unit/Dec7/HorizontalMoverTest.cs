using AdventOfCode2021.Dec7;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec7
{
    [TestFixture]
    class HorizontalMoverTest
    {

        [TestCase(new string[] { "1"},1,1,0)]
        [TestCase(new string[] { "1,2,3,4,5"},5,2,1)]
        public void SetUpVehicles(string[] input, int expectedLength, int expectedValue, int atIndex)
        {
            HorizontalMover mover = new HorizontalMover();
            mover.SetupVehicles(input);

            Assert.AreEqual(mover.Vehicles.Length, expectedLength);
            Assert.AreEqual(mover.Vehicles[atIndex], expectedValue);

        }

        [TestCase(new string[] { "1,2,3,4,5"},6)]
        [TestCase(new string[] { "1,2,3"},2)]
        public void GetFuelCostsForMovingToAPoint(string[] input, int expected)
        {
            HorizontalMover mover = new HorizontalMover();
            int cost = mover.CalcualteOptimalFuelCost();

            Assert.AreEqual(expected, cost);
        }
    }
}
