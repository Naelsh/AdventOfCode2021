using AdventOfCode2021.Dec8;
using NUnit.Framework;

namespace AdventOfCode2021.Test.Unit.Dec8
{
    [TestFixture]
    class SevenSegmentDisplayTest
    {
        [Test]
        public void CreateNewSegment()
        {
            string[] input = { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe" };
            SevenSegmentDisplay display = new SevenSegmentDisplay();
            display.SetupSegments(input);
            int expectedLength = 1;
            string expectedSignalAtFirstPosition = "be";
            string expectedOutputAtFourthPosition = "gcbe";

            Assert.AreEqual(expectedLength, display.Segments.Count);
            Assert.AreEqual(expectedSignalAtFirstPosition, display.Segments[0].SignalPattern[0]);
            Assert.AreEqual(expectedOutputAtFourthPosition, display.Segments[0].Output[3]);
        }

        [TestCase(new string[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe" }, 2)]
        [TestCase(new string[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
        "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
        "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
        "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
        "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
        "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
        "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
        "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
        "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
        "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"}, 26)]
        public void CountDigitsOneFourSevenEigth(string[] input, int expected)
        {
            SevenSegmentDisplay display = new SevenSegmentDisplay();
            display.SetupSegments(input);

            Assert.AreEqual(expected, display.CountOnesFoursSevenEigths());
        }
    }
}
