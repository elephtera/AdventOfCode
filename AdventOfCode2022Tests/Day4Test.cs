namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day4Test
    {
        private const int AnswerPartA = 588;
        private const int AnswerPartB = 911;
        private const int AnswerExamplePartA = 2;
        private const int AnswerExamplePartB = 4;


        private readonly IDay<int> day = new Day4();
        private readonly IDayInput input = new Day4Input();

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

        [TestMethod]
        public void ContainsTest()
        {
            Assert.AreEqual(true, Day4.Contains(new Range(0, 4), new Range(1, 4)));
            Assert.AreEqual(true, Day4.Contains(new Range(1, 4), new Range(1, 4)));
            Assert.AreEqual(true, Day4.Contains(new Range(2, 4), new Range(1, 4)));
            Assert.AreEqual(true, Day4.Contains(new Range(3, 3), new Range(1, 4)));
            Assert.AreEqual(false, Day4.Contains(new Range(5, 9), new Range(1, 4)));
            Assert.AreEqual(false, Day4.Contains(new Range(1, 4), new Range(5, 9)));
        }

        [TestMethod]
        public void OverlapTest()
        {
            Assert.AreEqual(true, Day4.Overlaps(new Range(0, 4), new Range(1, 5)));
            Assert.AreEqual(true, Day4.Overlaps(new Range(1, 4), new Range(1, 4)));
            Assert.AreEqual(true, Day4.Overlaps(new Range(2, 4), new Range(1, 4)));
            Assert.AreEqual(true, Day4.Overlaps(new Range(3, 3), new Range(1, 4)));
            Assert.AreEqual(false, Day4.Overlaps(new Range(1, 3), new Range(5, 8)));
            Assert.AreEqual(false, Day4.Overlaps(new Range(5, 8), new Range(1, 3)));

        }
    }
}