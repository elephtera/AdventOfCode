using AdventOfCode2023;
using AdventOfCode2023Tests.Input;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class Day6Test
    {
        private const int AnswerPart1 = 1155175;
        private const long AnswerPart2 = 35961505;
        private const int AnswerExamplePart1 = 288;
        private const int AnswerExamplePart2 = 71503;


        private readonly IDay<long> day = new Day6();
        private readonly IDayInput input = new Day6Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1("example");
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1("real");

            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2("example");
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