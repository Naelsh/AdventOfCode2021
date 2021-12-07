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

        [TestCase(new string[] { "1,2,3,4,5"},3)]
        [TestCase(new string[] { "1,2,3"},2)]
        [TestCase(new string[] { "4,4,1"},4)]
        [TestCase(new string[] { "16,1,2,0,4,2,7,1,2,14" },2)]
        public void GetFuelCostsForMovingToAPoint(string[] input, int expected)
        {
            HorizontalMover mover = new HorizontalMover();
            mover.SetupVehicles(input);
            int cost = mover.CalcualteOptimalIndexToMoveTowards();

            Assert.AreEqual(expected, cost);
        }

        [TestCase(new string[] { "1" }, 1, 0)]
        [TestCase(new string[] { "1,2" }, 2, 1)]
        [TestCase(new string[] { "1,2,3,4,5" }, 2, 7)]
        public void MoveTowardsPlaces(string[] input, int targetPosition, int expected)
        {
            HorizontalMover mover = new HorizontalMover();
            mover.SetupVehicles(input);
            int moves = mover.MoveTowards(targetPosition);

            Assert.AreEqual(expected, moves);
        }

        [TestCase(new string[] { "1" }, 1, 0)]
        [TestCase(new string[] { "1,2" }, 2, 1)]
        [TestCase(new string[] { "1,2,3,4,5" }, 2, 11)]
        public void MoveTowardsCrabStyle(string[] input, int targetPosition, int expected)
        {
            HorizontalMover mover = new HorizontalMover();
            mover.SetupVehicles(input);
            int moves = mover.MoveTowardsCrabStyle(targetPosition);

            Assert.AreEqual(expected, moves);
        }
    }
}
