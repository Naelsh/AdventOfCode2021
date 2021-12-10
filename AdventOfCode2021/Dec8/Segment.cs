using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec8
{
    public class Segment
    {
        public List<string> SignalPattern { get; set; } = new List<string>();
        public List<string> Output { get; set; } = new List<string>();
        private Dictionary<string, int> Map = new Dictionary<string, int>();
        public Dictionary<int, string> ReverseMap = new Dictionary<int, string>();
        public SignalMap _signalMap = new SignalMap();

        public Segment(string input)
        {
            string[] splitInput = input.Split('|');
            SetupSignalPattern(splitInput[0].Trim().Split(' '));
            SetupOutput(splitInput[1].Trim().Split(' '));
        }

        private void SetupOutput(string[] sequence)
        {
            foreach (string output in sequence)
            {
                string sorted = String.Concat(output.OrderBy(c => c));
                Output.Add(sorted);
            }
        }

        private void SetupSignalPattern(string[] sequence)
        {
            foreach (string signal in sequence)
            {
                string sorted = String.Concat(signal.OrderBy(c => c));
                SignalPattern.Add(sorted);
            }
        }

        internal int CalculateOuputValue()
        {
            string number = Map[Output[0]].ToString() + Map[Output[1]].ToString() + Map[Output[2]].ToString() + Map[Output[3]].ToString();
            return int.Parse(number);
        }

        public int CountOneFourSevenAndEigths()
        {
            int count = 0;
            foreach (string output in Output)
            {
                switch (output.Length)
                {
                    case 2:
                        // one
                        count++;
                        break;
                    case 3:
                        // seven
                        count++;
                        break;
                    case 4:
                        // four
                        count++;
                        break;
                    case 7:
                        // eight
                        count++;
                        break;
                    default:
                        break;
                }
            }
            return count;
        }

        public void CreateDecoding()
        {
            MapInitialFourDigits();

            //SetupNumberEigth();

            // trim for the initial numbers
            TrimWithNumberOne();
            TrimWithNumberSeven();
            TrimWithNumberFour();

            // find number 9
            SetupNumberNine();
            TrimWithNumberNine();

            // find number 6
            SetupNumberSix();
            TrimWithNumberSix();

            // find number 0
            SetupNumberZero();
            TrimWithNumberZero();
        }

        public void FinalizeMap()
        {
            foreach (string signal in SignalPattern)
            {
                if (!Map.TryGetValue(signal, out int value))
                {
                    Map.Add(signal, _signalMap.GetValueFromSignal(signal));
                }
            }
        }


        private void SetupNumberZero()
        {
            foreach (string signal in SignalPattern)
            {
                if (signal.Length == 6)
                {
                    if (signal == ReverseMap[6] || signal == ReverseMap[9])
                    {
                        continue;
                    }
                    else
                    {
                        ReverseMap.Add(0, signal);
                        Map.Add(signal, 0);
                    }
                }
            }
        }



        // The only 6 digit item that only has one match with number one
        private void SetupNumberSix()
        {
            foreach (string signal in SignalPattern)
            {
                if (signal.Length == 6)
                {
                    int count = 0;
                    foreach (char letter in signal)
                    {
                        foreach (char oneLetter in ReverseMap[1])
                        {
                            if (letter == oneLetter)
                            {
                                count++;
                            }
                        }
                    }
                    if (count == 1)
                    {
                        ReverseMap.Add(6, signal);
                        Map.Add(signal, 6);
                    }
                }
            }
        }



        // The only 6 digit item that has all matches with a four is nine.
        private void SetupNumberNine()
        {
            foreach (string signal in SignalPattern)
            {
                if (signal.Length == 6)
                {
                    int count = 0;
                    foreach (char letter in signal)
                    {
                        foreach (char fourLetter in ReverseMap[4])
                        {
                            if (letter == fourLetter)
                            {
                                count++;
                            }
                        }
                    }
                    if (count == 4)
                    {
                        ReverseMap.Add(9, signal);
                        Map.Add(signal, 9);
                    }
                }
            }
        }

        private void TrimWithNumberZero()
        {
            // 0
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(0);
            TrimFromSides(ReverseMap[0], new Side[] { Side.Mid });
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.LeftUpper });
        }

        private void TrimWithNumberSix()
        {
            // 6
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(6);
            TrimFromSides(ReverseMap[6], new Side[] { Side.RightUpper });
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.RighBottom, Side.LeftUpper, Side.Mid });
        }

        private void TrimWithNumberNine()
        {
            // 9
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(9);
            TrimFromSides(ReverseMap[9], new Side[] { Side.LeftBottom});
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.RighBottom, Side.RightUpper, Side.Floor, Side.LeftUpper, Side.Mid });
        }

        private void TrimWithNumberOne()
        {
            // 1
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(1);
            TrimFromSides(ReverseMap[1], new Side[] { Side.Floor, Side.LeftUpper, Side.LeftBottom, Side.Mid, Side.Roof });
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.RighBottom, Side.RightUpper });
        }

        private void TrimWithNumberSeven()
        {
            // 7
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(7);
            TrimFromSides(ReverseMap[7], new Side[] { Side.Floor, Side.LeftUpper, Side.LeftBottom, Side.Mid });
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.RighBottom, Side.RightUpper, Side.Roof });
        }

        private void TrimWithNumberFour()
        {
            // 4
            string charsToRemoveFromDigit = GetCharactersToRemoveFromDigit(4);
            TrimFromSides(ReverseMap[4], new Side[] { Side.Floor, Side.LeftBottom, Side.Floor });
            TrimFromSides(charsToRemoveFromDigit, new Side[] { Side.RighBottom, Side.RightUpper, Side.Mid, Side.LeftUpper });
        }

        private string GetCharactersToRemoveFromDigit(int number)
        {
            string charsToRemoveFromDigit = "abcdefg";
            for (int charIndex = 0; charIndex < ReverseMap[number].Length; charIndex++)
            {
                char character = ReverseMap[number][charIndex];
                charsToRemoveFromDigit = charsToRemoveFromDigit.Remove(charsToRemoveFromDigit.IndexOf(character), 1);
            }

            return charsToRemoveFromDigit;
        }

        private void TrimFromSides(string characters, Side[] sides)
        {
            for (int sideIndex = 0; sideIndex < sides.Length; sideIndex++)
            {
                foreach (char character in characters)
                {
                    _signalMap.TryRemoveValue(sides[sideIndex], character);
                }
            }
        }

        private void MapInitialFourDigits()
        {
            foreach (string signal in SignalPattern)
            {
                if (signal.Length == 2)
                {
                    Map.Add(signal, 1);
                    ReverseMap.Add(1, signal);
                }
                else if (signal.Length == 3)
                {
                    Map.Add(signal, 7);
                    ReverseMap.Add(7, signal);
                }
                else if (signal.Length == 4)
                {
                    Map.Add(signal, 4);
                    ReverseMap.Add(4, signal);
                }
                else if (signal.Length == 7)
                {
                    Map.Add(signal, 8);
                    ReverseMap.Add(8, signal);
                }
            }
        }

        public class SignalMap
        {
            public Dictionary<Side, string> locationMap = new Dictionary<Side, string>();

            public SignalMap()
            {
                for (int index = 0; index <= (int)Side.Floor ; index++)
                {
                    locationMap.Add((Side)index,"abcdefg");
                }
            }

            public void TryRemoveValue(Side sideIndex, char character)
            {
                if (HasCharacter(sideIndex, character))
                {
                    locationMap[sideIndex] = locationMap[sideIndex].Remove(locationMap[sideIndex].IndexOf(character), 1);
                }
            }

            public bool HasCharacter(Side side, char character)
            {
                return locationMap[side].Contains(character);
            }

            public int GetValueFromSignal(string signal)
            {
                // 0, 1, 4, 6, 7, 8, 9 are already taken care of.

                // gives 5
                if (signal.Contains(locationMap[Side.LeftUpper]))
                {
                    return 5;
                }
                // gives 2, 3
                else if (signal.Contains(locationMap[Side.LeftBottom]))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }
    }
}
