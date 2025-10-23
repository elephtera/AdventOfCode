namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day4Test
    {
        private const int AnswerPart1 = 588;
        private const int AnswerPart2 = 911;
        private const int AnswerExamplePart1 = 2;
        private const int AnswerExamplePart2 = 4;


        private readonly IDay<int> day = new Day4();
        private readonly IDayInput input = new Day4Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
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

        [TestMethod]
        public void ContainsTest()
        {
            Assert.IsTrue(Day4.Contains(new Range(0, 4), new Range(1, 4)));
            Assert.IsTrue(Day4.Contains(new Range(1, 4), new Range(1, 4)));
            Assert.IsTrue(Day4.Contains(new Range(2, 4), new Range(1, 4)));
            Assert.IsTrue(Day4.Contains(new Range(3, 3), new Range(1, 4)));
            Assert.IsFalse(Day4.Contains(new Range(5, 9), new Range(1, 4)));
            Assert.IsFalse(Day4.Contains(new Range(1, 4), new Range(5, 9)));
        }

        [TestMethod]
        public void OverlapTest()
        {
            Assert.IsTrue(Day4.Overlaps(new Range(0, 4), new Range(1, 5)));
            Assert.IsTrue(Day4.Overlaps(new Range(1, 4), new Range(1, 4)));
            Assert.IsTrue(Day4.Overlaps(new Range(2, 4), new Range(1, 4)));
            Assert.IsTrue(Day4.Overlaps(new Range(3, 3), new Range(1, 4)));
            Assert.IsFalse(Day4.Overlaps(new Range(1, 3), new Range(5, 8)));
            Assert.IsFalse(Day4.Overlaps(new Range(5, 8), new Range(1, 3)));

        }
    }
}