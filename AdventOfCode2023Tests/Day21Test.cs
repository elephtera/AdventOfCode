using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day21Test
    {
        private const long AnswerPart1 = 3642;
        private const long AnswerPart2 = 0;
        private const long AnswerExamplePart1 = 16;
        private const long AnswerExamplePart2 = 0;


        private readonly Day21 day = new Day21();
        private readonly IDayInput input = new Day21Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, 6);
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
            var result = day.Part1(input.ExampleInput, 10);
            Assert.AreEqual(50, result);

            result = day.Part1(input.ExampleInput, 50);
            Assert.AreEqual(1594, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}