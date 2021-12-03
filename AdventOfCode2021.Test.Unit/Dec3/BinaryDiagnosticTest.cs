using AdventOfCode2021.Dec3;
using NUnit.Framework;
using System;

namespace AdventOfCode2021.Test.Unit.Dec3
{
    [TestFixture]
    class BinaryDiagnosticTest
    {
        [TestCase("00100", 4)]
        [TestCase("00101", 5)]
        [TestCase("10101", 21)]
        public void GetIntFromBinarySuccessfully(string bitInput, int expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            int result = binaryDiagnostic.GetIntFromBinary(bitInput);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "00100", "00101", "00100" }, "00100")]
        [TestCase(new string[] { "00101", "00101", "00100" }, "00101")]
        public void GetGammaRateSuccesfully(string[] bitInput, string expectedBitOuput)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string result = binaryDiagnostic.GetGammaRate(bitInput);

            Assert.AreEqual(expectedBitOuput, result);
        }

        [TestCase("00001", "11110")]
        [TestCase("00011", "11100")]
        [TestCase("00111", "11000")]
        public void GetOmegaRateFromGammaSuccesfully(string gamma, string expectedEpsilon)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string result = binaryDiagnostic.GetEpsilonFromGamma(gamma);

            Assert.AreEqual(expectedEpsilon, result);
        }

        [TestCase("10110", 198)]
        public void GetPowerConsumption(string gamma, int expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            int gammaValue = binaryDiagnostic.GetIntFromBinary(gamma);
            int epsilonValue = binaryDiagnostic.GetIntFromBinary(binaryDiagnostic.GetEpsilonFromGamma(gamma));
            int result = gammaValue * epsilonValue;

            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "11111", "11000", "10000" }, "11111")]
        [TestCase(new string[] { "10110", "00101", "10100" }, "10110")]
        [TestCase(new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, "10111")]
        public void GetLifeSuportRateSuccesfully(string[] bitInput, string expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string result = binaryDiagnostic.GetLifeSupportRate(bitInput);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "10100", "00101", "10100" }, '1', 0, new string[] { "10100", "10100" })]
        [TestCase(new string[] { "10100", "00101", "10100" }, '1', 2, new string[] { "10100", "00101", "10100" })]
        [TestCase(new string[] { "10100", "00101", "10100" }, '0', 4, new string[] { "10100", "10100" })]
        public void GetStringsWithDigitInIndex(string[] bitInput, char lookedForChar, int index, string[] expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string[] result = binaryDiagnostic.GetStringsWithDigitInIndex(bitInput, lookedForChar, index);

            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "10100", "00101", "10100" }, 0, new string[] { "10100", "10100" })]
        [TestCase(new string[] { "10100", "00101", "10100" }, 2, new string[] { "10100", "00101", "10100" })]
        [TestCase(new string[] { "10100", "00101", "10100" }, 4, new string[] { "10100", "10100" })]
        public void GetTruncatedList(string[] bitInput, int index, string[] expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string[] result = binaryDiagnostic.GetTruncatedLifeSupportList(bitInput, index);

            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new string[] { "00110", "00101", "10100" }, "10100")]
        [TestCase(new string[] { "01111", "00000", "10000", "11000" }, "00000")]
        [TestCase(new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, "01010")]
        public void GetCO2ScrubberRating(string[] bitInput, string expected)
        {
            BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
            string result = binaryDiagnostic.GetCO2ScrubberRating(bitInput);

            Assert.AreEqual(expected, result);
        }


    }
}
