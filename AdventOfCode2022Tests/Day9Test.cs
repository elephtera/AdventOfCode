namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day9Test
    {
        private const int AnswerPartA = 5513;
        private const int AnswerPartB = 2427;
        private const int AnswerExamplePartA = 13;
        private const int AnswerExamplePartB = 1;
        private const int AnswerExample2PartB = 36;

        public IList<string> Example2Input => new List<string>() { @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20" };

        private readonly IDay<int> day = new Day9();
        private readonly IDayInput input = new Day9Input();

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
        public void PartBExample2()
        {
            var result = day.PartB(Example2Input);
            Assert.AreEqual(AnswerExample2PartB, result);

        }



        [TestMethod]
        public void PartB()
        {
            var result = day.PartB(input.Input);
            Assert.AreEqual(AnswerPartB, result);
        }

        [TestMethod]
        public void MoveTailsTest()
        {
            var tails = new int[2] { 0, 0 };
            var heads = new int[2] { 0, 0 };
            var result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[0]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 0 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 1 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 2, 0 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(0, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 0, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 1, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);

            tails = new int[2] { 0, 0 };
            heads = new int[2] { 2, 2 };
            result = Day9.MoveTail(tails, heads);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);


        }
    }
}