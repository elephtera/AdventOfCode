namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day12Test
    {
        private const int AnswerPart1 = 534;
        private const int AnswerPart2 = 525;
        private const int AnswerExamplePart1 = 31;
        private const int AnswerExamplePart2 = 29;


        private readonly Day12 day = new Day12();
        private readonly IDayInput input = new Day12Input();

        [TestMethod]
        public async Task Part1ExampleAsync()
        {
            var result = await day.Part1Async(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public async Task Part1Async()
        {
            var result = await day.Part1Async(input.Input);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public async Task Part2Example()
        {
            var result = await day.Part2Async(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public async Task Part2Async()                                                                         
        {
            var result = await day.Part2Async(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}