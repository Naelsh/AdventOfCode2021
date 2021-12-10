using AdventOfCode2021.Dec9;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec9
{
    [TestFixture]
    class HeightMapTest
    {
        [Test]
        public void SetHeightMap()
        {
            string[] input = { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" };
            HeightMap map = new HeightMap();
            map.SetHeightMap(input);

            Assert.AreEqual(2, map.Map[0][0]);
            Assert.AreEqual(9, map.Map[1][1]);
        }
    }
}
