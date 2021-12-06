using AdventOfCode2021.Dec5;
using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2021.Test.Unit.Dec5
{
    [TestFixture]
    class HydrothermalVentScannerTest
    {
        public static IEnumerable<TestCaseData> TestCaseDatas
        {
            get
            {
                {
                    yield return new TestCaseData
                    (
                        new string[] {"0,9 -> 5,9" },
                        new Vent{StartPosition = new Vector2(0,9), EndPosition = new Vector2(5,9)},
                        0
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "8,0 -> 0,8"},
                        new Vent { StartPosition = new Vector2(8, 0), EndPosition = new Vector2(0, 8) },
                        0
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,9 -> 5,9", "8,0 -> 0,8" },
                        new Vent { StartPosition = new Vector2(8, 0), EndPosition = new Vector2(0, 8) },
                        1
                    );
                }
            }
        }

        [Test, TestCaseSource(nameof(TestCaseDatas))]
        public void SetupVents(string[] input, Vent expected, int expectedAtIndex)
        {
            HydrothermalVentScanner scanner = new HydrothermalVentScanner();
            scanner.SetupVents(input);

            Assert.AreEqual(expected.StartPosition.X, scanner.Vents[expectedAtIndex].StartPosition.X);
            Assert.AreEqual(expected.StartPosition.Y, scanner.Vents[expectedAtIndex].StartPosition.Y);
            Assert.AreEqual(expected.EndPosition.X, scanner.Vents[expectedAtIndex].EndPosition.X);
            Assert.AreEqual(expected.EndPosition.Y, scanner.Vents[expectedAtIndex].EndPosition.Y);
        }

        public static IEnumerable<TestCaseData> CaseDatas
        {
            get
            {
                {
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "8,0 -> 0,8" },
                        1,
                        new Vector2(0, 0)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "8,0 -> 0,8" },
                        1,
                        new Vector2(1, 0)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "8,0 -> 0,8" },
                        1,
                        new Vector2(2, 0)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 0,8" },
                        2,
                        new Vector2(0, 0)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 0,8" },
                        1,
                        new Vector2(0, 8)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 0,8" },
                        0,
                        new Vector2(0, 9)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,5"},
                        1,
                        new Vector2(1, 1)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "5,5 -> 0,0" },
                        1,
                        new Vector2(1, 1)
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "5,0 -> 0,5" },
                        1,
                        new Vector2(4, 1)
                    );
                }
            }
        }


        [Test, TestCaseSource(nameof(CaseDatas))]
        public void CalculateIntersectionsFromMultipleVents(string[] input, int expected, Vector2 atLocation)
        {
            HydrothermalVentScanner scanner = new HydrothermalVentScanner();
            scanner.SetupVents(input);
            scanner.CalculateIntersections();

            Assert.AreEqual(expected, scanner.VentLocations[(int)atLocation.X, (int)atLocation.Y]);

        }

        public static IEnumerable<TestCaseData> CountData
        {
            get
            {
                {
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "8,0 -> 0,8" },
                        0
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 0,1" },
                        1
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 5,0" },
                        6
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "50,50 -> 50,100", "0,0 -> 0,8", "75,50 -> 45,50" },
                        2
                    );
                    yield return new TestCaseData
                    (
                        new string[] { "0,0 -> 5,0", "0,0 -> 5,0", "0,0 -> 5,0" },
                        6
                    );
                }
            }
        }

        [Test, TestCaseSource(nameof(CountData))]
        public void TestCountsOfIntersectionPeeks(string[] input, int expected)
        {
            HydrothermalVentScanner scanner = new HydrothermalVentScanner();
            scanner.SetupVents(input);
            scanner.CalculateIntersections();
            int overlaps = scanner.CountOfOverlappedPoints();

            Assert.AreEqual(expected, overlaps);
        }
    }
}
