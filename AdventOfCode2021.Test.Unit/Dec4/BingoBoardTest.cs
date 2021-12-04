using AdventOfCode2021.Dec4;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2021.Test.Unit.Dec4
{
    [TestFixture]
    class BingoBoardTest
    {
        public static IEnumerable<TestCaseData> BingoBoardCreationData
        {
            get
            {
                {
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15 }, new int[] { 16, 17, 18, 19, 20 }, new int[] { 21, 22, 23, 24, 25 } });
                    yield return new TestCaseData(new string[] { "10 20 30 40 50", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[][] { new int[] { 10, 20, 30, 40, 50 }, new int[] { 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15 }, new int[] { 16, 17, 18, 19, 20 }, new int[] { 21, 22, 23, 24, 25 } });
                }
            }
        }

        [Test, TestCaseSource(nameof(BingoBoardCreationData))]
        public void SuccesfullySetUpBingoBoard(string[] input, int[][] expectedBingoBoard)
        {
            BingoBoard newBingoBoard = new BingoBoard();
            newBingoBoard.CreateBoard(input);

            Assert.AreEqual(expectedBingoBoard, newBingoBoard.boardNumber);
        }

        public static IEnumerable<TestCaseData> NumberPickerData
        {
            get
            {
                {
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        1,
                        new byte[][] { new byte[] { 1, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        2,
                        new byte[][] { new byte[] { 0, 1, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                }
            }
        }

        [Test, TestCaseSource(nameof(NumberPickerData))]
        public void PickNumber(string[] boardInput, int guess, byte[][] expected)
        {
            BingoBoard bingoBoard = new BingoBoard();
            bingoBoard.CreateBoard(boardInput);
            bingoBoard.FindMatch(guess);

            Assert.AreEqual(expected, bingoBoard.hitMarkers);

        }

        public static IEnumerable<TestCaseData> NumberPickerMultipleGuessesData
        {
            get
            {
                {
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[] { 1 },
                        new byte[][] { new byte[] { 1, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[] { 2 },
                        new byte[][] { new byte[] { 0, 1, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[] { 1, 2, 3, 4, 5 },
                        new byte[][] { new byte[] { 1, 1, 1, 1, 1 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[] { 1, 6, 9, 10, 12 },
                        new byte[][] { new byte[] { 1, 0, 0, 0, 0 }, new byte[] { 1, 0, 0, 1, 1 }, new byte[] { 0, 1, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });
                    yield return new TestCaseData(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" },
                        new int[] { 100, 600, 900, 101, 120 },
                        new byte[][] { new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0 } });

                }
            }
        }

        [Test, TestCaseSource(nameof(NumberPickerMultipleGuessesData))]
        public void PickNumberSeveralTimes(string[] boardInput, int[] guesses, byte[][] expected)
        {
            BingoBoard bingoBoard = new BingoBoard();
            bingoBoard.CreateBoard(boardInput);
            foreach (int guess in guesses)
            {
                bingoBoard.FindMatch(guess);
            }

            Assert.AreEqual(expected, bingoBoard.hitMarkers);
        }

        [TestCase(new int[]{1,2,3,4,5}, true)]
        [TestCase(new int[]{1,2,3,4,6}, false)]
        [TestCase(new int[]{1,6,11,16,21}, true)]
        [TestCase(new int[]{1,7,11,16,21}, false)]
        [TestCase(new int[]{100,700,3,4,8,13,20,18,25,23}, true)]
        public void BoardHasWon(int[] guesses, bool expected)
        {
            BingoBoard bingoBoard = new BingoBoard();
            bingoBoard.CreateBoard(new string[] { "1 2 3 4 5", "6 7 8 9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" });
            foreach (int guess in guesses)
            {
                bingoBoard.FindMatch(guess);
            }

            Assert.AreEqual(expected, bingoBoard.HasWon());
        }
    }
}
