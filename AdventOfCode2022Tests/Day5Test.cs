namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day5Test
    {
        private const string AnswerPartA = "MQSHJMWNH";
        private const string AnswerPartB = "LLWJRBHVZ";
        private const string AnswerExamplePartA = "CMZ";
        private const string AnswerExamplePartB = "MCD";


        private readonly IDay<string> day = new Day5();
        private readonly IDayInput input = new Day5Input();

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