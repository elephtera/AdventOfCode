namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day12Test
    {
        private const int AnswerPartA = 534;
        private const int AnswerPartB = 0;
        private const int AnswerExamplePartA = 31;
        private const int AnswerExamplePartB = 29;


        private readonly Day12 day = new Day12();
        private readonly IDayInput input = new Day12Input();

        [TestMethod]
        public async Task PartAExampleAsync()
        {
            var result = await day.PartAAsync(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartA, result);
        }

        [TestMethod]
        public async Task PartAAsync()
        {
            var result = await day.PartAAsync(input.Input);
            Assert.AreEqual(AnswerPartA, result);
        }

        [TestMethod]
        public async Task PartBExample()
        {
            var result = await day.PartBAsync(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartB, result);
        }

        [TestMethod]
        public async Task PartBAsync()                                                                              
        {
            var result = await day.PartBAsync(input.Input);
            Assert.AreEqual(AnswerPartB, result);
        }
    }
}