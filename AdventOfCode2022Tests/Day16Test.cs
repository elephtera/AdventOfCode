namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day16Test
    {
        private const int AnswerPartA = 1584;
        private const int AnswerPartB = 2052;
        private const int AnswerExamplePartA = 1651;
        private const int AnswerExamplePartB = 1707;


        private readonly Day16 day = new Day16();
        private readonly IDayInput input = new Day16Input();

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
        public async Task PartBExampleAsync()
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

        [TestMethod]
        public void GraphCreation()
        {
            var graph = Day16.ProcessInput(input.ExampleInput.Single());
            Assert.AreEqual(10, graph.Nodes.Count());
            Assert.AreEqual(13, graph.Nodes.Where(n => n.ID == "BB").Single().Flowrate);
            Assert.AreEqual(2, graph.Nodes.Where(n => n.ID == "BB").Single().Edges.Count());

        }
    }
}