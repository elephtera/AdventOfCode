using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day5Test
    {
        private const int AnswerPart1 = 199602917;
        private const int AnswerPart2 = 2254686;
        private const int AnswerExamplePart1 = 35;
        private const int AnswerExamplePart2 = 46;


        private readonly IDay<long> day = new Day5();
        private readonly IDayInput input = new Day5Input();

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