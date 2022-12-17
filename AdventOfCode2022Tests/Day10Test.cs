namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day10Test
    {
        private const int AnswerPart1 = 13440;
        private const int AnswerPart2 = 0; //PBZGRAZA
        private const int AnswerExamplePart1 = 13140;
        private const int AnswerExamplePart2 = 0;


        private readonly IDay<int> day = new Day10();
        private readonly IDayInput input = new Day10Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1Example2()
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
        public void Part1Example3()
        {
            var inputData = Day10.ProcessInput(input.ExampleInput);
            var result = Day10.ProcessCommands(inputData);

            Assert.AreEqual(21, result[20 - 1]);
            Assert.AreEqual(19, result[60 - 1]);
            Assert.AreEqual(18, result[100 - 1]);
            Assert.AreEqual(21, result[140 - 1]);
            Assert.AreEqual(16, result[180 - 1]);
            Assert.AreEqual(18, result[220 - 1]);
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