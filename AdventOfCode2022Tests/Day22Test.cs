namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day22Test
    {
        private const int AnswerPart1 = 60362;
        private const int AnswerPart2 = 74288;
        private const int AnswerExamplePart1 = 6032;
        private const int AnswerExamplePart2 = 5031;


        private readonly Day22 day = new Day22();
        private readonly Day22Input input = new Day22Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, input.ExampleInputActions);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input, input.InputActions);
            Assert.AreEqual(AnswerPart1, result);
        }

        //Disabled, other dice format, not implemented. [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleInput, input.ExampleInputActions);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            // not 17563: low; 12224: low; 125091: high
            var result = day.Part2(input.Input, input.InputActions);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void HorizontalMovement()
        {
            var map = new List<char[]>() { "  ...#...".ToArray(), 
                                           "...#...  ".ToArray(), 
                                           "#......  ".ToArray() };
            var location = new Day22Location(map, 0);

            Assert.AreEqual(2, location.X);
            Assert.AreEqual(0, location.Y);

            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 2 });
            Assert.AreEqual(4, location.X);
            Assert.AreEqual(0, location.Y);
            
            // WALL, no move
            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 2 });
            Assert.AreEqual(4, location.X);
            Assert.AreEqual(0, location.Y);

            // turn right, thus facing down.
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnRight });
            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 2 });

            Assert.AreEqual(4, location.X);
            Assert.AreEqual(2, location.Y);
            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 2 });

            Assert.AreEqual(4, location.X);
            Assert.AreEqual(1, location.Y);
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnLeft });
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnLeft });

            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 2 });

            Assert.AreEqual(4, location.X);
            Assert.AreEqual(2, location.Y);


            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 1 });

            Assert.AreEqual(4, location.X);
            Assert.AreEqual(1, location.Y);
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnRight });
            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 3 });

            Assert.AreEqual(0, location.X);
            Assert.AreEqual(1, location.Y);
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnLeft });
            location.TakeStep(new Day22Step() { Action = Day22Action.TurnLeft });
            location.TakeStep(new Day22Step() { Action = Day22Action.Move, StepSize = 3 });

            Assert.AreEqual(4, location.X);
            Assert.AreEqual(1, location.Y);


        }
    }
}