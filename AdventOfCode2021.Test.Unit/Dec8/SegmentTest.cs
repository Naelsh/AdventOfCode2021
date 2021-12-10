using AdventOfCode2021.Dec8;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec8
{
    [TestFixture]
    class SegmentTest
    {
        [TestCase(1,"bg")]
        [TestCase(7,"gbd")]
        [TestCase(4,"aebg")]
        [TestCase(8,"efabdcg")]
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

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "gcdaeb")]
        [TestCase("eabfdc fgd cegd aedgf fbacgd dceaf dg aebdcgf efbag edgfac | cgebadf dgce deafc acdbfg", "edgfac")]
        public void AddNumberNineInDictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[9]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "cafdbe")]
        public void AddNumberSixInDictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[6]);
        }

        [TestCase("bg gcdaeb aebg efabdcg abdce cafdbe fcbdeg bdacg gbd cafgd | daecb dcbae gb eabg", "fcbdeg")]
        public void AddNumberZeroInDeictionary(string input, string expected)
        {
            Segment segment = new Segment(input);
            segment.CreateDecoding();

            Assert.AreEqual(expected, segment.ReverseMap[0]);
        }
    }
}
