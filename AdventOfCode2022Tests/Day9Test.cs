namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day9Test
    {
        private const int AnswerPart1 = 5513;
        private const int AnswerPart2 = 2427;
        private const int AnswerExamplePart1 = 13;
        private const int AnswerExamplePart2 = 1;
        private const int AnswerExample2Part2 = 36;

        public string Example2Input => @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20" ;

        private readonly IDay<int> day = new Day9();
        private readonly IDayInput input = new Day9Input();

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
        public void Part2Example2()
        {
            var result = day.Part2(Example2Input);
            Assert.AreEqual(AnswerExample2Part2, result);

        }



        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void MoveTailsTest()
        {
            var tails = new int[2] { 0, 0 };
            var heads = new int[2] { 0, 0 };
            var result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[0]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 0 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 1 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 2, 0 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 0, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 2, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);


        }
    }
}