using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day19Test
    {
        private const long AnswerPart1 = 409898;
        private const long AnswerPart2 = 113057405770956;
        private const long AnswerExamplePart1 = 19114;
        private const long AnswerExamplePart2 = 167409079868000;


        private readonly IDay<long> day = new Day19();
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