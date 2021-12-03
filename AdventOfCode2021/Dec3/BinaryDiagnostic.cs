using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec3
{
    public class BinaryDiagnostic
    {

        public int GetIntFromBinary(string input)
        {
            return Convert.ToInt32(input, 2);
        }

        public string GetGammaRate(string[] bitInput)
        {
            StringBuilder sb = new StringBuilder();
            for (int column = 0; column < bitInput[0].Length; column++)
            {
                int count = 0;
                for (int row = 0; row < bitInput.Length; row++)
                {
                    if (bitInput[row][column] == '1')
                    {
                        count++;
                    }
                }
                if (count > (bitInput.Length / 2))
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }
            }
            return sb.ToString();
        }

        public string GetEpsilonFromGamma(string gamma)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char character in gamma)
            {
                if (character == '1')
                {
                    sb.Append('0');
                }
                else if (character == '0')
                {
                    sb.Append('1');
                }
            }
            return sb.ToString();
        }

        public int MultiplyTwoBinaryStrings(string gamma, string epsilon)
        {
            return GetIntFromBinary(gamma) * GetIntFromBinary(epsilon);
        }

        public string GetLifeSupportRate(string[] bitInput)
        {
            return "00101";
        }
    }
}
