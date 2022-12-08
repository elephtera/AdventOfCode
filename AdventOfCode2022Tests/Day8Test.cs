namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day8Test
    {
        private const int AnswerPartA = 1818;
        private const int AnswerPartB = 368368;
        private const int AnswerExamplePartA = 21;
        private const int AnswerExamplePartB = 8;


        private readonly IDay<int> day = new Day8();
        private readonly IDayInput input = new Day8Input();

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