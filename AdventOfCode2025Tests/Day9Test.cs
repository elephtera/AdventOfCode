using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day9Test
    {
        private const long AnswerPart1 = 4758121828;
        private const long AnswerPart2 = 0;
        private const long AnswerExamplePart1 = 50;
        private const long AnswerExamplePart2 = 24;


        private readonly IDay<long> day = new Day9();
        private readonly IDayInput input = new Day9Input();

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
            public void Part2Example1()
            {
                var customInput = @"0,0
0,5
5,5
5,0";
                var result = day.Part2(customInput);
                Assert.AreEqual(25, result);
            }

            [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}