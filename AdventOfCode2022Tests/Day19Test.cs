namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day19Test
    {
        private const int AnswerPart1 = 1395;
        private const int AnswerPart2 = 2700;
        private const int AnswerExamplePart1 = 33;
        private const int AnswerExamplePart2 = 3472;


        private readonly IDay<int> day = new Day19();
        private readonly IDayInput input = new Day19Input();

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
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}