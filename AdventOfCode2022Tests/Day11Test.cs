namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day11Test
    {
        private const long AnswerPartA = 78960;
        private const long AnswerPartB = 0;
        private const long AnswerExamplePartA = 10605;
        private const long AnswerExamplePartB = 2713310158;


        private readonly Day11 day = new Day11();
        private readonly Day11Input input = new Day11Input();

        [TestMethod]
        public void PartAExample()
        {
            var result = day.PartA(input.ExampleMonkeys);
            Assert.AreEqual(AnswerExamplePartA, result);
        }

        [TestMethod]
        public void PartA()
        {
            var result = day.PartA(input.Monkeys);
            Assert.AreEqual(AnswerPartA, result);
        }

        [TestMethod]
        public void PartBExample()
        {
            var result = day.PartB(input.ExampleMonkeys);
            Assert.AreEqual(AnswerExamplePartB, result);
        }

        [TestMethod]
        public void PartB()
        {
            var result = day.PartB(input.Monkeys);
            Assert.AreEqual(AnswerPartB, result);
        }
    }
}