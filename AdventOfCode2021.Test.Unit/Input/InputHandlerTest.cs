using NUnit.Framework;
using AdventOfCode2021.Input;

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
            InputHandler inputHandler = new InputHandler(filePath);

            string[] extracted = inputHandler.GetSingleColumnInputToList();
            
            Assert.AreEqual(expected, extracted);
        }
    }
}
