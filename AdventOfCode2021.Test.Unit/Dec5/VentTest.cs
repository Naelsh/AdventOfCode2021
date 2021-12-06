using AdventOfCode2021.Dec5;
using NUnit.Framework;
using System.Numerics;

namespace AdventOfCode2021.Test.Unit.Dec5
{
    [TestFixture]
    class VentTest
    {
        [TestCase(0f,1f,0f,2f,Direction.VerticalUp)]
        [TestCase(0f,2f,0f,1f,Direction.VerticalDown)]
        [TestCase(1f,1f,0f,1f,Direction.HorizontalLeft)]
        [TestCase(0f,1f,1f,1f,Direction.HorizontalRight)]
        [TestCase(1f,3f,2f,1f,Direction.Diagonal)]
        public void GetDirection(float sX, float sY, float eX, float eY, Direction expected)
        {
            Vent vent = new Vent();
            vent.StartPosition = new Vector2(sX, sY);
            vent.EndPosition = new Vector2(eX, eY);

            Assert.AreEqual(expected, vent.GetDirection());
        }

        [TestCase(0f, 1f, 0f, 2f, 2)]
        [TestCase(0f, 2f, 0f, 1f, 2)]
        [TestCase(1f, 1f, 0f, 1f, 2)]
        [TestCase(0f, 1f, 1f, 1f, 2)]
        [TestCase(1f, 3f, 3f, 1f, 3)]
        public void GetLength(float sX, float sY, float eX, float eY, int expected)
        {
            Vent vent = new Vent();
            vent.StartPosition = new Vector2(sX, sY);
            vent.EndPosition = new Vector2(eX, eY);

            Assert.AreEqual(expected, vent.GetLength());
        }
    }
}
