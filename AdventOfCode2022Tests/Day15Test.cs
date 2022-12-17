namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day15Test
    {
        private const int AnswerPart1 = 5525990;
        private const long AnswerPart2 = 11756174628223;
        private const int AnswerExamplePart1 = 26;
        private const int AnswerExamplePart2 = 56000011;


        private readonly Day15 day = new Day15();
        private readonly Day15Input input = new Day15Input();

        [TestMethod]
        public void RegexParser()
        {
            var res = Day15.ProcessInput(input.ExampleInput);
            Assert.AreEqual(2, res[0][0]);
            Assert.AreEqual(18, res[0][1]);
            Assert.AreEqual(-2, res[0][2]);
            Assert.AreEqual(15, res[0][3]);
        }

        [TestMethod]
        public void ManhattanDistance()
        {
            var res = Day15.ManhattenDistance(1,1,1,1);
            Assert.AreEqual(0, res);

            res = Day15.ManhattenDistance(1, 1, 2, 2);
            Assert.AreEqual(2, res);

            res = Day15.ManhattenDistance(2, 2, 1, 1);
            Assert.AreEqual(2, res);

            res = Day15.ManhattenDistance(1, 1, 2, 1);
            Assert.AreEqual(1, res);

            res = Day15.ManhattenDistance(-1, -1, 1, 1);
            Assert.AreEqual(4, res);

            res = Day15.ManhattenDistance(0, 0, 0, 2);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void NoBeacons()
        {
            var x1 = 0;
            var y1 = 0;
            var row = 2;

            var res = Day15.ScannedRange(x1, y1, row, 1);
            Assert.AreEqual(null, res);

            res = Day15.ScannedRange(x1, y1, row, 2);
            Assert.AreEqual(1, Day15.RangeCount(res));

            res = Day15.ScannedRange(x1, y1, row, 3);
            Assert.AreEqual(3, Day15.RangeCount(res));
        }

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, 10);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input, 2000000);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleInput, 20);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input, 4000000);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}