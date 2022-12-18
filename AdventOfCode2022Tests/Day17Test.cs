using AdventOfCode2022.Day17;

namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day17Test
    {
        private const int AnswerPart1 = 3081;
        private const long AnswerPart2 = 0;
        private const int AnswerExamplePart1 = 3068;
        private const long AnswerExamplePart2 = 1514285714288;


        private readonly Day17 day = new Day17();
        private readonly IDayInput input = new Day17Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);


            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            // niet: 1 525 217 391 284; te hoog
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void Square()
        {
            IDay17Shape shape = new Day17Square(new List<bool[]>());
            shape.MoveDown();
            shape.MoveLeft();
            shape.MoveDown();
            shape.MoveRight();
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(false, shape.MoveDown());
            Assert.AreEqual("0011000", string.Concat(shape.NewHeight()[0].Select(v => v ? '1' : '0')));
            Assert.AreEqual("0011000", string.Concat(shape.NewHeight()[1].Select(v => v ? '1' : '0')));

        }

        #region Line
        [TestMethod]
        public void ExampleLine()
        {
            IDay17Shape shape = new Day17Line(new List<bool[]>());

            shape.MoveRight();
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(3, shape.Position().X);
            Assert.AreEqual(2, shape.Position().Y);
            shape.MoveRight();
            Assert.AreEqual(true, shape.MoveDown());
            shape.MoveRight();
            Assert.AreEqual(true, shape.MoveDown());
            shape.MoveLeft();
            Assert.AreEqual(false, shape.MoveDown());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(0, shape.Position().Y);

            Assert.AreEqual("0011110", string.Concat(shape.NewHeight()[0].Select(v => v? '1' : '0')));
        }

        [TestMethod]
        public void LineLeft()
        {
            IDay17Shape shape = new Day17Line(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveLeft();
            Assert.AreEqual(0, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            // Already most left, no change
            shape.MoveLeft();
            Assert.AreEqual(0, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);
        }

        [TestMethod]
        public void LineLeftBlocked()
        {
            var heights = new List<bool[]>();
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            IDay17Shape shape = new Day17Line(heights);

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(9, shape.Position().Y);

            // Na 4x down zitten we in dezelfde rij als de hoogste tot nu toe
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());

            // Naar links bewegen op weg naar de blokkade
            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(5, shape.Position().Y);

            // Blocked, return false and no change
            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(5, shape.Position().Y);

        }


        [TestMethod]
        public void LineRight()
        {
            IDay17Shape shape = new Day17Line(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveRight();
            Assert.AreEqual(3, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            // Already most right, no change
            shape.MoveRight();
            Assert.AreEqual(3, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

        }

        [TestMethod]
        public void LineDown()
        {
            IDay17Shape shape = new Day17Line(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(2, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(1, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(0, shape.Position().Y);

            // Down, no change, return false;
            Assert.AreEqual(false, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(0, shape.Position().Y);
        }
        #endregion


        #region Cross
        [TestMethod]
        public void ExampleCross()
        {
            IDay17Shape shape = new Day17Line(new List<bool[]>());

            shape.MoveRight();
            shape.MoveDown();
            shape.MoveRight();
            shape.MoveDown();
            shape.MoveRight();
            shape.MoveDown();
            shape.MoveLeft();
            shape.MoveDown();
            
            var newHeight = shape.NewHeight();

            shape = new Day17Cross(newHeight);
            shape.MoveLeft();
            shape.MoveDown();
            shape.MoveRight();
            shape.MoveDown();
            shape.MoveLeft();
            shape.MoveDown();
            shape.MoveRight();
            Assert.AreEqual(false, shape.MoveDown());

            newHeight = shape.NewHeight();
            Assert.AreEqual("0001000", string.Concat(shape.NewHeight()[3].Select(v => v ? '1' : '0')));
            Assert.AreEqual("0011100", string.Concat(shape.NewHeight()[2].Select(v => v ? '1' : '0')));
            Assert.AreEqual("0001000", string.Concat(shape.NewHeight()[1].Select(v => v ? '1' : '0')));
            Assert.AreEqual("0011110", string.Concat(shape.NewHeight()[0].Select(v => v ? '1' : '0')));
        }

        [TestMethod]
        public void CrossLeft()
        {
            IDay17Shape shape = new Day17Cross(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveLeft();
            Assert.AreEqual(0, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            // Already most left, no change
            shape.MoveLeft();
            Assert.AreEqual(0, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);
        }

        [TestMethod]
        public void CrossLeftBlocked()
        {
            var heights = new List<bool[]>();
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            heights.Add(new bool[] { true, false, false, false, false, false, false });
            IDay17Shape shape = new Day17Cross(heights);

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(9, shape.Position().Y);

            // Na 4x down zitten we in dezelfde rij als de hoogste tot nu toe
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(true, shape.MoveDown());

            // Naar links bewegen op weg naar de blokkade
            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(4, shape.Position().Y);

            // Blocked, return false and no change
            shape.MoveLeft();
            Assert.AreEqual(1, shape.Position().X);
            Assert.AreEqual(4, shape.Position().Y);

        }


        [TestMethod]
        public void CrossRight()
        {
            IDay17Shape shape = new Day17Cross(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            shape.MoveRight();
            Assert.AreEqual(3, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);
            
            shape.MoveRight();
            Assert.AreEqual(4, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            // Already most right, no change
            shape.MoveRight();
            Assert.AreEqual(4, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

        }

        [TestMethod]
        public void CrossDown()
        {
            IDay17Shape shape = new Day17Cross(new List<bool[]>());

            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(3, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(2, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(1, shape.Position().Y);

            Assert.AreEqual(true, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(0, shape.Position().Y);

            // Down, no change, return false;
            Assert.AreEqual(false, shape.MoveDown());
            Assert.AreEqual(2, shape.Position().X);
            Assert.AreEqual(0, shape.Position().Y);
        }
        #endregion
    }
}