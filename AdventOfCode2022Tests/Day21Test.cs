namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day21Test
    {
        private const long AnswerPart1 = 41857219607906;
        private const long AnswerPart2 = 3916936880448;
        private const int AnswerExamplePart1 = 152;
        private const int AnswerExamplePart2 = 301;


        private readonly IDay<long> day = new Day21();
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