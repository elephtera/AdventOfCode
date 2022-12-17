namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day11Test
    {
        private const long AnswerPart1 = 78960;
        private const long AnswerPart2 = 0;
        private const long AnswerExamplePart1 = 10605;
        private const long AnswerExamplePart2 = 2713310158;


        private readonly Day11 day = new Day11();
        private readonly Day11Input input = new Day11Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleMonkeys);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Monkeys);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleMonkeys);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Monkeys);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}