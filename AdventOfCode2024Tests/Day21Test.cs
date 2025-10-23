using AdventOfCode2024;
using AdventOfCode2024Tests.Input;

namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day21Test
    {
        private const long AnswerPart1 =0;
        private const long AnswerPart2 =0;
        private const long AnswerExamplePart1 =0;


        private readonly Day21 day = new Day21();
        private readonly IDayInput input = new Day21Input();

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
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}