using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day20Test
    {
        private const long AnswerPart1 = 680278040;
        private const long AnswerPart2 = 243548140870057;
        private const long AnswerExamplePart1 = 32000000;
        private const long AnswerExample2Part1 = 11687500;

        private readonly IDay<long> day = new Day20();
        private readonly Day20Input input = new Day20Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1Example2()
        {
            var result = day.Part1(input.ExampleInput2);
            Assert.AreEqual(AnswerExample2Part1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}