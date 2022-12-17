

using System.Security;

namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day2Test
    {
        private const int AnswerPart1 = 12794;
        private const int AnswerPart2 = 14979;
        private const int AnswerExamplePart1 = 15;
        private const int AnswerExamplePart2 = 12;


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