using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day16Test
    {
        private const int AnswerPart1 = 7496;
        private const int AnswerPart2 = 7932;
        private const int AnswerExamplePart1 = 46;
        private const int AnswerExamplePart2 = 51;


        private readonly IDay<int> day = new Day16();
        private readonly IDayInput input = new Day16Input();

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