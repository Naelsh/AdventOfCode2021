using AdventOfCode2021.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec5
{
    public class HydrothermalVentScanner
    {
        public List<Vent> Vents { get; private set; } = new List<Vent>();
        public int[,] VentLocations { get; private set; }

        public HydrothermalVentScanner()
        {
            SetupLocations();
        }

        public int CountOfOverlappedPoints()
        {
            int count = 0;
            foreach (int item in VentLocations)
            {
                if (item > 1)
                {
                    count++;
                }
            }
            return count;
        }

        private void SetupLocations()
        {
            int[,] locations = new int[1000, 1000];
            for (int row = 0; row < locations.GetLength(0); row++)
            {
                for (int column = 0; column < locations.GetLength(1); column++)
                {
                    locations[row, column] = 0;
                }
            }
            VentLocations = locations;
        }

        public void CalculateIntersections()
        {
            foreach (Vent vent in Vents)
            {
                switch (vent.GetDirection())
                {
                    case Direction.HorizontalRight:
                        MarkHorizontal(vent.StartPosition, vent.GetLength());
                        break;
                    case Direction.VerticalDown:
                        MarkVertical(vent.EndPosition, vent.GetLength());
                        break;
                    case Direction.Diagonal:
                        MarkDiagonal(vent.StartPosition, vent.EndPosition, vent.GetLength());
                        break;
                    case Direction.HorizontalLeft:
                        MarkHorizontal(vent.EndPosition, vent.GetLength());
                        break;
                    case Direction.VerticalUp:
                        MarkVertical(vent.StartPosition, vent.GetLength());
                        break;
                    default:
                        break;
                }
            }
        }

        private void MarkDiagonal(Vector2 startPosition, Vector2 endPosition, int magnitude)
        {
            // make sure we always go left to right.
            if (startPosition.X > endPosition.X)
            {
                Vector2 temp = startPosition;
                startPosition = endPosition;
                endPosition = temp;
            }
            bool isDropping = false;
            if (startPosition.Y > endPosition.Y)
            {
                isDropping = true;
            }

            for (int ventIndex = 0; ventIndex < magnitude; ventIndex++)
            {
                if (isDropping)
                {
                    VentLocations[(int)startPosition.X + ventIndex, (int)startPosition.Y - ventIndex] += 1;
                }
                else
                {
                    VentLocations[(int)startPosition.X + ventIndex, (int)startPosition.Y + ventIndex] += 1;
                }
            }
        }

        private void MarkVertical(Vector2 startPosition, int magnitude)
        {
            for (int ventIndex = 0; ventIndex < magnitude; ventIndex++)
            {
                VentLocations[(int)startPosition.X, (int)startPosition.Y + ventIndex] += 1;
            }
        }

        private void MarkHorizontal(Vector2 startPosition, int magnitude)
        {
            for (int ventIndex = 0; ventIndex < magnitude; ventIndex++)
            {
                VentLocations[(int)startPosition.X + ventIndex, (int)startPosition.Y] += 1;
            }
        }

        public void SetupVents(string[] input)
        {
            foreach (string row in input)
            {
                SetupNewVent(row);
            }
        }

        private void SetupNewVent(string input)
        {
            InputHandler inputHandler = new InputHandler();
            string[] splitString = input.Split(' ');

            string[] startPos = splitString[0].Split(',');
            int[] startPosNum = inputHandler.ConvertStringListToInt(startPos);

            string[] endPos = splitString[2].Split(',');
            int[] endPosNum = inputHandler.ConvertStringListToInt(endPos);

            Vent newVent = new Vent();
            newVent.StartPosition = new Vector2(startPosNum[0], startPosNum[1]);
            newVent.EndPosition = new Vector2(endPosNum[0], endPosNum[1]);
            Vents.Add(newVent);
        }
    }
}
