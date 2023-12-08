using AdventOfCode2015Tests.Input;
using AdventOfCode2015;

namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day2Test
    {
        private const int AnswerPart1 = 1588178;
        private const int AnswerPart2 = 3783758;
        private const int AnswerExamplePart1 = 58;
        private const int AnswerExamplePart2 = 34;


        private readonly IDay<int> day = new Day2();
        private readonly IDayInput input = new Day2Input();

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