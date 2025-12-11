using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day11Test
    {
        private const long AnswerPart1 = 634;
        private const long AnswerPart2 = 377452269415704;
        private const long AnswerExamplePart1 = 5;
        private const long AnswerExamplePart2 = 2;


        private readonly Day11 day = new Day11();
        private readonly Day11Input input = new Day11Input();

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
            var result = day.Part2(input.ExampleInput2);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void Part2Alternative()
        {
            var result = day.Part2Alternative(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}