namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day16Test
    {
        private const int AnswerPart1 = 1584;
        private const int AnswerPart2 = 2052;
        private const int AnswerExamplePart1 = 1651;
        private const int AnswerExamplePart2 = 1707;


        private readonly Day16 day = new Day16();
        private readonly IDayInput input = new Day16Input();

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
        public async Task Part2ExampleAsync()
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

        [TestMethod]
        public void GraphCreation()
        {
            var graph = Day16.ProcessInput(input.ExampleInput);
            Assert.AreEqual(10, graph.Nodes.Count());
            Assert.AreEqual(13, graph.Nodes.Where(n => n.ID == "BB").Single().Flowrate);
            Assert.AreEqual(2, graph.Nodes.Where(n => n.ID == "BB").Single().Edges.Count());

        }
    }
}