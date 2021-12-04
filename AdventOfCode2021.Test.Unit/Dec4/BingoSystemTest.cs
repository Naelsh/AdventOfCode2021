using AdventOfCode2021.Dec4;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec4
{
    [TestFixture]
    class BingoSystemTest
    {
        [TestCase("1,2,3,4,5", new int[] { 1, 2, 3, 4, 5 })]
        [TestCase("2,3,4,5,6", new int[] { 2, 3, 4, 5, 6 })]
        public void SetupNumbersToBeIteratedThrough(string input, int[] expected)
        {
            BingoSystem bingoSystem = new BingoSystem();
            bingoSystem.SetGuessedNumbers(input);

            Assert.AreEqual(expected, bingoSystem.GuessNumbers);
        }

        [TestCase(new string[] { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, 1, 0)]
        [TestCase(new string[] { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25","", " 2  2  2  2  2", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, 2, 0)]
        [TestCase(new string[] { " 2  2  2  2  2", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25","", " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, 2, 1)]
        public void CreatePlayboards(string[] input, int expectedCount, int expectedIndexOfexpectedBoard)
        {
            BingoBoard expectedBoard = new BingoBoard();
            expectedBoard.CreateBoard(new string[] { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" });
            BingoSystem bingoSystem = new BingoSystem();
            bingoSystem.SetUpBoards(input);

            Assert.AreEqual(expectedCount, bingoSystem.Boards.Count);
            Assert.AreEqual(expectedBoard.boardNumber, bingoSystem.Boards[expectedIndexOfexpectedBoard].boardNumber);
        }

        [TestCase(new string[] { "27  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, "27,6,11,16,21", 270, 21)]
        [TestCase(new string[] { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, "1,2,3,4,5", 310, 5)]
        [TestCase(new string[] { " 2  2  2  2  2", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25", "", " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" }, "1,6,11,21,16", 270, 16)]
        public void FindWinningBoard(string[] boardInput, string guessNumbers, int expectedWinnerSum, int expectedWinningNumber)
        {
            BingoSystem bingoSystem = new BingoSystem();
            bingoSystem.SetUpBoards(boardInput);
            bingoSystem.SetGuessedNumbers(guessNumbers);

            int finalNumber = bingoSystem.DrawNumbers(out BingoBoard bingoBoard);

            Assert.AreEqual(expectedWinningNumber, finalNumber);
            Assert.AreEqual(expectedWinnerSum, bingoBoard.SumUnmarkedTiles());
        }
    }
}
