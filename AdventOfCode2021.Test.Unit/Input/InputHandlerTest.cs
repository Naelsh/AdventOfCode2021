using NUnit.Framework;
using AdventOfCode2021.Input;
using AdventOfCode2021.Dec2;

namespace AdventOfCode2021.Test.Unit.Input
{
    [TestFixture]
    class InputHandlerTest
    {
        [Test]
        public void GetInputFromSingleColumnFile()
        {
            string[] expected = { "199", "200","208","210","200","207","240","269","260","263"};
            string filePath = "singleColumnTest.txt";
            InputHandler inputHandler = new InputHandler();

            string[] extracted = inputHandler.GetSingleColumnInputToList(filePath);
            
            Assert.AreEqual(expected, extracted);
        }

        [TestCase("forward 4", MovementDirection.forward, 4)]
        public void GetMovement(string input, MovementDirection expectedDirection, int magnitude)
        {
            //InputHandler inputHandler = new InputHandler("")
        }
    }
}
