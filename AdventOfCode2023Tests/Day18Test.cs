using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day18Test
    {
        private const long AnswerPart1 = 76387;
        private const long AnswerPart2 = 250022188522074;
        private const long AnswerExamplePart1 = 62;
        private const long AnswerExamplePart2 = 952408144115;


        private readonly IDay<long> day = new Day18();
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
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}