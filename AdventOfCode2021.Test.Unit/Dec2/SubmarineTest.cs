using AdventOfCode2021.Dec2;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec2
{
    [TestFixture]
    class SubmarineTest
    {
        [TestCase(5, MovementDirection.forward, 5,0)]
        [TestCase(5, MovementDirection.down, 0,5)]
        [TestCase(5, MovementDirection.up, 0,-5)]
        public void MoveSubmarineFromStart(int magnitude, MovementDirection direction, float expectedX, float expectedY)
        {
            Submarine submarine = new Submarine();
            submarine.MoveSubmarine(magnitude, direction);

            Assert.AreEqual(expectedX, submarine.GetPosition().X);
            Assert.AreEqual(expectedY, submarine.GetPosition().Y);
        }

        [TestCase(5, MovementDirection.forward, 10, 5)]
        [TestCase(5, MovementDirection.down, 5, 10)]
        [TestCase(5, MovementDirection.up, 5, 0)]
        public void MoveSubmarineFromPosition(int magnitude, MovementDirection direction, float expectedX, float expectedY)
        {
            Submarine submarine = new Submarine();
            submarine.MoveSubmarine(5, MovementDirection.forward);
            submarine.MoveSubmarine(5, MovementDirection.down);
            submarine.MoveSubmarine(magnitude, direction);

            Assert.AreEqual(expectedX, submarine.GetPosition().X);
            Assert.AreEqual(expectedY, submarine.GetPosition().Y);
        }
    }
}
