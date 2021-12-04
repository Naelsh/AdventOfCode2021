using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec4
{
    public class BingoBoard
    {
        public int[][] boardNumber;
        public byte[][] hitMarkers;
        private int hits = 0;

        public BingoBoard()
        {
            hitMarkers = new byte[][]
            {
                new byte[]{0,0,0,0,0 },
                new byte[]{0,0,0,0,0 },
                new byte[]{0,0,0,0,0 },
                new byte[]{0,0,0,0,0 },
                new byte[]{0,0,0,0,0 }
            };
        }

        public bool HasWon()
        {
            if (hits < 5)
            {
                return false;
            }
            if (RowIsFilled())
            {
                return true;
            }
            if (ColumnIsFilled())
            {
                return true;
            }
            return false;
        }

        private bool ColumnIsFilled()
        {
            for (int columnIndex = 0; columnIndex < hitMarkers[0].Length; columnIndex++)
            {
                int count = 0;
                for (int rowIndex = 0; rowIndex < hitMarkers[1].Length; rowIndex++)
                {
                    if (hitMarkers[rowIndex][columnIndex] == 1)
                    {
                        count++;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
            }
            return false;
        }

        private bool RowIsFilled()
        {
            foreach (byte[] row in hitMarkers)
            {
                int count = 0;
                foreach (byte value in row)
                {
                    if (value == 1)
                    {
                        count++;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
            }
            return false;
        }

        public void FindMatch(int guess)
        {
            for (int rowIndex = 0; rowIndex < boardNumber.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < boardNumber[0].Length; columnIndex++)
                {
                    if (boardNumber[rowIndex][columnIndex] == guess)
                    {
                        hitMarkers[rowIndex][columnIndex] = 1;
                        hits++;
                    }
                }
            }
        }

        public void CreateBoard(string[] input)
        {
            int[][] newBoard = new int[5][];
            InputHandler inputHandler = new InputHandler();
            for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
            {
                string[] numberStrings = inputHandler.GetBingoSplitRow(input[rowIndex]);
                int[] numbers = inputHandler.ConvertStringListToInt(numberStrings);
                newBoard[rowIndex] = numbers;
            }
            boardNumber = newBoard;
        }

        public int SumUnmarkedTiles()
        {
            int sum = 0;
            for (int row = 0; row < boardNumber.Length; row++)
            {
                for (int column = 0; column < boardNumber[0].Length; column++)
                {
                    if (hitMarkers[row][column] == 0)
                    {
                        sum += boardNumber[row][column];
                    }
                }
            }
            return sum;
        }
    }
}
