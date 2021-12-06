using AdventOfCode2021.Dec6;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2021.Test.Unit.Dec6
{
    [TestFixture]
    class LanternfishScannerTest
    {
        [Test]
        public void PrepareFishesFromInput()
        {
            string[] input = { "1,2,3,2,1" };
            LanternfishScanner scanner = new LanternfishScanner();
            scanner.SetupFishCollection(input);

            Assert.AreEqual(5, scanner.Fishes.Count);
            Assert.AreEqual(2, scanner.Fishes[1].InternalTimer);
        }

        public static IEnumerable<TestCaseData> NumberOfFishesAftertimeData
        {
            get
            {
                {
                    yield return new TestCaseData(new string[] { "1,2,3,4,5" }, 1, 5);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 1, 5);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 3, 7);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 4, 9);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 5, 10);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 6, 10);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 7, 10);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 8, 10);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 9, 11);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 10, 12);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 11, 15);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 12, 17);
                    yield return new TestCaseData(new string[] { "3,4,3,1,2" }, 13, 19);
                }
            }
        }

        [Test, TestCaseSource(nameof(NumberOfFishesAftertimeData))]
        public void CeckNumberOfFishesAfterSetNumberOfDays(string[] input, int numDays, int expected)
        {
            LanternfishScanner scanner = new LanternfishScanner();
            scanner.SetupFishCollection(input);

            for (int day = 0; day < numDays; day++)
            {
                scanner.BreedNewFishes(scanner.CalculateNextDay());
            }

            Assert.AreEqual(expected, scanner.Fishes.Count);
        }

        [TestCase(0, 5)]
        [TestCase(2, 6)]
        [TestCase(3, 7)]
        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        [TestCase(256, 26984457539)]
        public void TakeOverTheWorldCounterForDifferentNumberOfDays(int numDays, long expected)
        {
            LanternfishScanner scanner = new LanternfishScanner();
            string[] input = new string[] { "3,4,3,1,2" };
            scanner.SetupWorldDominationCounter(input);
            scanner.TakeOverTheWorldCounter(numDays);
            long result = scanner.TotalAmountOfWorldDominationFishes();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "3,4,3,1,2" }, new long[] { 0, 1, 1, 2, 1, 0, 0, 0, 0 })]
        [TestCase(new string[] { "3,4,3,1,2,5,6" }, new long[] { 0, 1, 1, 2, 1, 1, 1, 0, 0 })]
        public void SetupFishCountersForWorldDomination(string[] input, long[] expected)
        {
            LanternfishScanner scanner = new LanternfishScanner();
            scanner.SetupWorldDominationCounter(input);

            Assert.AreEqual(expected, scanner.WorldDominationFishes);
        }

    }
}
