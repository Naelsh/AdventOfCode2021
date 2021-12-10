using AdventOfCode2021.Dec8;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec8
{
    [TestFixture]
    class SegmentTest
    {
        [TestCase(1,"bg")]
        [TestCase(7,"bdg")]
        [TestCase(4,"abeg")]
        [TestCase(8,"abcdefg")]
        public void SetupInitialFour(int number, string expected)
        {
            string input = "bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg";
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[number]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "g", "e", "d", "f")]
        //[TestCase("eabfdc fgd cegd aedgf fbacgd dceaf dg aebdcgf efbag edgfac | cgebadf dgce deafc acdbfg", "dg", "ce", "f")]
        public void OneSevenFourDigitIsRunThroughDecoder(string input, string expectedRightUpper, string expectedLeftUpper, string expectedRoof,
            string expectedBottom)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expectedRightUpper, segment._signalMap.locationMap[Side.RightUpper]);
            Assert.AreEqual(expectedLeftUpper, segment._signalMap.locationMap[Side.LeftUpper]);
            Assert.AreEqual(expectedRoof, segment._signalMap.locationMap[Side.Roof]);
            Assert.AreEqual(expectedBottom, segment._signalMap.locationMap[Side.LeftBottom]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "abcdeg")]
        [TestCase("eabfdc fgd cegd aedgf fbacgd dceaf dg aebdcgf efbag edgfac | cgebadf dgce deafc acdbfg", "acdefg")]
        public void AddNumberNineInDictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[9]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "abcdef")]
        public void AddNumberSixInDictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[6]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "bcdefg")]
        public void AddNumberZeroInDeictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[0]);
        }
    }
}
