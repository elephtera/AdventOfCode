using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day12Test
    {
        private const long AnswerPart1 = 565;
        private const long AnswerPart2 = 0;
        private const long AnswerExamplePart1 = 2;
        private const long AnswerExamplePart2 = 0;


        private readonly Day12 day = new Day12();
        private readonly Day12Input input = new Day12Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, input.InputTreeSpaceExample);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input, input.InputTreeSpace);
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