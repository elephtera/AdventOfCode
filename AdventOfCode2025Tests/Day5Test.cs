using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day5Test
    {
        private const long AnswerPart1 = 679;
        private const long AnswerPart2 = 358155203664116;
        private const long AnswerExamplePart1 = 3;
        private const long AnswerExamplePart2 = 14;


        private readonly Day5 day = new Day5();
        private readonly Day5Input input = new Day5Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, input.ExampleInput2);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input, input.Input2);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleInput, input.ExampleInput2);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input, input.Input2);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}