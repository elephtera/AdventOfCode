namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day18Test
    {
        private const int AnswerPart1 = 4418;
        private const int AnswerPart2 = 2486;
        private const int AnswerExamplePart1 = 64;
        private const int AnswerExamplePart2 = 58;


        private readonly IDay<int> day = new Day18();
        private readonly IDayInput input = new Day18Input();

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
            // not 2482
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}