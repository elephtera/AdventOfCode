namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day5Test
    {
        private const string AnswerPart1 = "MQSHJMWNH";
        private const string AnswerPart2 = "LLWJRBHVZ";
        private const string AnswerExamplePart1 = "CMZ";
        private const string AnswerExamplePart2 = "MCD";


        private readonly Day5 day = new Day5();
        private readonly Day5Input input = new Day5Input();

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