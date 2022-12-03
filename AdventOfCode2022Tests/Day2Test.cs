

using System.Security;

namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day2Test
    {
        private const int AnswerPartA = 12794;
        private const int AnswerPartB = 14979;
        private const int AnswerExamplePartA = 15;
        private const int AnswerExamplePartB = 12;


        private readonly IDay day = new Day2();
        private readonly IDayInput input = new Day2Input();

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