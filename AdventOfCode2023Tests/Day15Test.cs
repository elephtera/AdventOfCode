using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day15Test
    {
        private const int AnswerPart1 = 514639;
        private const int AnswerPart2 = 279470;
        private const int AnswerExamplePart1 = 1320;
        private const int AnswerExamplePart2 = 145;


        private readonly IDay<int> day = new Day15();
        private readonly IDayInput input = new Day15Input();

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