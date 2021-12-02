using AdventOfCode2021.Dec2;
using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2021.Test.Unit.Dec2
{
    [TestFixture]
    class SubmarineTest
    {
        [TestCase(5, MovementDirection.forward, 5,0)]
        [TestCase(5, MovementDirection.down, 0,5)]
        [TestCase(5, MovementDirection.up, 0,-5)]
        public void MoveSubmarineFromStart(int magnitude, MovementDirection direction, float expectedX, float expectedY)
        {
            Submarine submarine = new Submarine();
            submarine.MoveSubmarine(magnitude, direction);

            Assert.AreEqual(expectedX, submarine.GetPosition().X);
            Assert.AreEqual(expectedY, submarine.GetPosition().Y);
        }

        [TestCase(5, MovementDirection.forward, 10, 5)]
        [TestCase(5, MovementDirection.down, 5, 10)]
        [TestCase(5, MovementDirection.up, 5, 0)]
        public void MoveSubmarineFromPosition(int magnitude, MovementDirection direction, float expectedX, float expectedY)
        {
            Submarine submarine = new Submarine();
            submarine.MoveSubmarine(5, MovementDirection.forward);
            submarine.MoveSubmarine(5, MovementDirection.down);
            submarine.MoveSubmarine(magnitude, direction);

            Assert.AreEqual(expectedX, submarine.GetPosition().X);
            Assert.AreEqual(expectedY, submarine.GetPosition().Y);
        }

        public static IEnumerable<TestCaseData> HandleCommandData
        {
            get
            {
                yield return new TestCaseData(
                    new Vector2(0,0),
                    5,
                    new Movement[] {
                        new Movement()
                        {
                            direction = MovementDirection.down,
                            magnitude = 5
                        }
                    });
                yield return new TestCaseData(
                    new Vector2(5, 0),
                    5,
                    new Movement[] {
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.down,
                            magnitude = 5
                        }
                    });
                yield return new TestCaseData(
                    new Vector2(10, 25),
                    5,
                    new Movement[] {
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.down,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 5
                        }
                    });
                yield return new TestCaseData(
                    new Vector2(20, (25-20)),
                    -2,
                    new Movement[] {
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.down,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 5
                        },
                        new Movement()
                        {
                            direction = MovementDirection.up,
                            magnitude = 7
                        },
                        new Movement()
                        {
                            direction = MovementDirection.forward,
                            magnitude = 10
                        }
                    });
            }
        }

        [Test, TestCaseSource(nameof(HandleCommandData))]
        public void HandleInputWithValidInput(Vector2 expectedPosition, int expectedAim, params Movement[] movements)
        {
            Submarine submarine = new Submarine();
            foreach (Movement move in movements)
            {
                submarine.HandleCommand(move);
            }

            Assert.AreEqual(expectedPosition, submarine.GetPosition());
            Assert.AreEqual(expectedAim, submarine.GetAim());

        }
    }
}
