using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day8Test
    {
        private const int AnswerPart1 = 11309;
        private const long AnswerPart2 = 13740108158591;
        private const int AnswerExamplePart1 = 6;
        private const int AnswerExample2Part1 = 2;
        private const int AnswerExamplePart2 = 6;


        private readonly IDay<long> day = new Day8();
        private readonly Day8Input input = new();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1Example2()
        {
            var result = day.Part1(input.Example2Input);
            Assert.AreEqual(AnswerExample2Part1, result);
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
            var result = day.Part2(input.Example3Input);
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