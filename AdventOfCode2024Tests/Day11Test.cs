using AdventOfCode2024;
using AdventOfCode2024Tests.Input;

namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day11Test
    {
        private const long AnswerPart1 =0;
        private const long AnswerPart2 =0;
        private const long AnswerExamplePart1 =0;
        private const long AnswerExamplePart2 =0;


        private readonly IDay<long> day = new Day11();
        private readonly IDayInput input = new Day11Input();

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