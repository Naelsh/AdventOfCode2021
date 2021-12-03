using NUnit.Framework;
using AdventOfCode2021.Input;
using AdventOfCode2021.Dec2;
using System.Collections;
using System.Collections.Generic;

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

            string[] extracted = inputHandler.GetInputRows(filePath);
            
            Assert.AreEqual(expected, extracted);
        }

        [TestCase("forward 4", MovementDirection.forward, 4)]
        [TestCase("down 3", MovementDirection.down, 3)]
        [TestCase("up 7", MovementDirection.up, 7)]
        public void GetMovement(string input, MovementDirection expectedDirection, int expectedMagnitude)
        {
            InputHandler inputHandler = new InputHandler();
            Movement movement = inputHandler.GetMovement(input);

            Assert.AreEqual(expectedDirection, movement.direction);
            Assert.AreEqual(expectedMagnitude, movement.magnitude);
        }

        public static IEnumerable<TestCaseData> GetMultipleMovementsData
        {
            get
            {
                {
                    yield return new TestCaseData(new string[] { "forward 4", "down 3", "up 7" },
                        new Movement[]
                        {
                            new Movement() {direction = MovementDirection.forward, magnitude = 4 },
                            new Movement() {direction = MovementDirection.down, magnitude = 3 },
                            new Movement() {direction = MovementDirection.up, magnitude = 7 }
                        });
                    yield return new TestCaseData(new string[] { "up 1", "up 2", "up 3" },
                        new Movement[]
                        {
                            new Movement() {direction = MovementDirection.up, magnitude = 1 },
                            new Movement() {direction = MovementDirection.up, magnitude = 2 },
                            new Movement() {direction = MovementDirection.up, magnitude = 3 }
                        });
                    yield return new TestCaseData(new string[] { "up 1", "up 2", "up 3", "down 1", "forward 9" },
                        new Movement[]
                        {
                            new Movement() {direction = MovementDirection.up, magnitude = 1 },
                            new Movement() {direction = MovementDirection.up, magnitude = 2 },
                            new Movement() {direction = MovementDirection.up, magnitude = 3 },
                            new Movement() {direction = MovementDirection.down, magnitude = 1 },
                            new Movement() {direction = MovementDirection.forward, magnitude = 9 }
                        });
                }
            }
        }

        [Test, TestCaseSource(nameof(GetMultipleMovementsData))]
        public void GetMovements(string[] input, Movement[] expectedMovements)
        {
            InputHandler inputHandler = new InputHandler();
            Movement[] movements = inputHandler.GetMovements(input);

            for (int movementIndex = 0; movementIndex < movements.Length; movementIndex++)
            {
                Assert.AreEqual(expectedMovements[movementIndex], movements[movementIndex]);
            }
        }
    }
}
