using AdventOfCode2021.Dec2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Input
{
    public class InputHandler
    {
        public InputHandler()
        {
        }

        public string[] GetInputRows(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string result = reader.ReadToEnd();
            return result.Replace("\r", "").Split("\n");
        }

        public int[] ConvertStringListToInt(string[] stringArr)
        {
            return Array.ConvertAll(stringArr, int.Parse);
        }

        public string[] GetSplitRow(string input)
        {
            return input.Trim().Split(' ');
        }

        public string[] GetBingoSplitRow(string input)
        {
            List<string> returnList = new List<string>();
            for (int charIndex = 0; charIndex < input.Length; charIndex+=3)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(input[charIndex]);
                sb.Append(input[charIndex + 1]);
                string finalized = sb.ToString().Trim();
                returnList.Add(finalized);
            }
            return returnList.ToArray();
        }

        public Movement[] GetMovements(string[] results)
        {
            Movement[] movements = new Movement[results.Length];
            for (int resultIndex = 0; resultIndex < results.Length; resultIndex++)
            {
                movements[resultIndex] = GetMovement(results[resultIndex]);
            }
            return movements;
        }

        public Movement GetMovement(string input)
        {
            string[] values = input.Split(' ');
            switch (values[0])
            {
                case "forward":
                    return new Movement()
                    {
                        direction = MovementDirection.forward,
                        magnitude = int.Parse(values[1])
                    };
                case "down":
                    return new Movement()
                    {
                        direction = MovementDirection.down,
                        magnitude = int.Parse(values[1])
                    };
                case "up":
                    return new Movement()
                    {
                        direction = MovementDirection.up,
                        magnitude = int.Parse(values[1])
                    };
                default:
                    return new Movement();
            }
        }
    }
}
