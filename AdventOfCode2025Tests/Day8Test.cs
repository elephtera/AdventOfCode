using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day8Test
    {
        private const long AnswerPart1 = 68112;
        private const long AnswerPart2 = 44543856;
        private const long AnswerExamplePart1 = 40;
        private const long AnswerExamplePart2 = 25272;


        private readonly Day8 day = new Day8();
        private readonly IDayInput input = new Day8Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput, 10);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input,1000);
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