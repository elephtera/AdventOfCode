

using System.Security;

namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day1Test
    {
        private const int AnswerPartA = 72240;
        private const int AnswerPartB = 210957;
        private const int AnswerExamplePartA = 24000;
        private const int AnswerExamplePartB = 45000;


        private readonly IDay day = new Day1();
        private readonly IDayInput input = new Day1Input();

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