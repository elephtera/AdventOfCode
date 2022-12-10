namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day10Test
    {
        private const int AnswerPartA = 13440;
        private const int AnswerPartB = 0; //PBZGRAZA
        private const int AnswerExamplePartA = 13140;
        private const int AnswerExamplePartB = 0;


        private readonly IDay<int> day = new Day10();
        private readonly IDayInput input = new Day10Input();

        [TestMethod]
        public void PartAExample()
        {
            var result = day.PartA(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartA, result);
        }

        [TestMethod]
        public void PartAExample2()
        {
            var input = new List<string>() { "noop","addx 3","addx -5" };
            var result = Day10.ProcessCommands(input);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
            Assert.AreEqual(1, result[2]);
            Assert.AreEqual(4, result[3]);
            Assert.AreEqual(4, result[4]);
            Assert.AreEqual(-1, result[5]);
        }

        [TestMethod]
        public void PartAExample3()
        {
            var inputData = Day10.ProcessInput(input.ExampleInput.Single());
            var result = Day10.ProcessCommands(inputData);

            Assert.AreEqual(21, result[20 - 1]);
            Assert.AreEqual(19, result[60 - 1]);
            Assert.AreEqual(18, result[100 - 1]);
            Assert.AreEqual(21, result[140 - 1]);
            Assert.AreEqual(16, result[180 - 1]);
            Assert.AreEqual(18, result[220 - 1]);
        }

        [TestMethod]
        public void PartA()
        {
            var result = day.PartA(input.Input);
            Assert.AreEqual(AnswerPartA, result);
        }

        [TestMethod]
        public void PartBExample()
        {
            var result = day.PartB(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartB, result);
        }

        [TestMethod]
        public void PartB()
        {
            var result = day.PartB(input.Input);
            Assert.AreEqual(AnswerPartB, result);
        }
    }
}