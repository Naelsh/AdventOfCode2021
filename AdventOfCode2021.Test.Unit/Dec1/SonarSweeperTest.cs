using AdventOfCode2021.Dec1;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2021.Test.Unit.Dec1
{
    [TestFixture]
    class SonarSweeperTest
    {
        [TestCase(new int[]{ 1, 2, 3}, 2)]
        [TestCase(new int[]{ 2, 1, 3}, 1)]
        [TestCase(new int[]{ 2, 2, 3}, 1)]
        [TestCase(new int[]{ 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7)]
        public void DepthIncreaseCounter_Success(int[] depths, int expected)
        {
            SonarSweeper sonarSweeper = new SonarSweeper();
            int sweepCount = sonarSweeper.CalculateNumberOfDepthIncreases(depths);

            Assert.AreEqual(expected, sweepCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4}, 1)]
        [TestCase(new int[] { 1, 1, 1, 1}, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 5)]
        public void SlidingDepthIncreaseCounter_Success(int[] depths, int expected)
        {
            SonarSweeper sonarSweeper = new SonarSweeper();
            int sweepCount = sonarSweeper.CalculateNumberOfSlidingDepthIncreases(depths);

            Assert.AreEqual(expected, sweepCount);
        }
    }
}
