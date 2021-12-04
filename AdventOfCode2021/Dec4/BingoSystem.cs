using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec4
{
    public class BingoSystem
    {
        public int[] GuessNumbers { get; private set; }
        public List<BingoBoard> Boards { get; private set; }

        public BingoSystem()
        {
            Boards = new List<BingoBoard>();
        }

        public void SetGuessedNumbers(string input)
        {
            string[] splitInput = input.Split(',');
            InputHandler inputHandler = new InputHandler();
            GuessNumbers = inputHandler.ConvertStringListToInt(splitInput);
        }

        public void SetUpBoards(string[] boardData)
        {
            string[] newBoardData = new string[] { "","","","",""};
            int boardIndex = 0;
            for (int row = 0; row < boardData.Length; row++)
            {
                if (boardData[row].Length == 0)
                {
                    if (newBoardData[4].Length > 0)
                    {
                        CreateBoard(newBoardData);
                    }
                    newBoardData = new string[5];
                    boardIndex = 0;
                }
                else
                {
                    newBoardData[boardIndex] = boardData[row];
                    boardIndex++;
                }
            }
            CreateBoard(newBoardData);
        }

        private void CreateBoard(string[] newBoardData)
        {
            BingoBoard newBoard = new BingoBoard();
            newBoard.CreateBoard(newBoardData);
            Boards.Add(newBoard);
        }

        public int DrawNumbers(out BingoBoard winningBoard)
        {
            foreach (int number in GuessNumbers)
            {
                foreach (BingoBoard board in Boards)
                {
                    board.FindMatch(number);
                    if (board.HasWon())
                    {
                        winningBoard = board;
                        return number;
                    }
                }
            }
            winningBoard = null;
            return 0;
        }
    }
}
