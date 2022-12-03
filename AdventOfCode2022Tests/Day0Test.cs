namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day0Test
    {
        private const int AnswerPartA = 0;
        private const int AnswerPartB = 0;
        private const int AnswerExamplePartA = 0;
        private const int AnswerExamplePartB = 0;


        private readonly IDay day = new Day0();
        private readonly IDayInput input = new Day0Input();

        [TestMethod]
        public void PartAExample()
        {
            var result = day.PartA(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartA, result);
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