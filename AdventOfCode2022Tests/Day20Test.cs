namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day20Test
    {
        private const int AnswerPart1 = 7153;
        private const long AnswerPart2 = 6146976244822;
        private const int AnswerExamplePart1 = 3;
        private const long AnswerExamplePart2 = 1623178306;


        private readonly IDay<long> day = new Day20();
        private readonly IDayInput input = new Day20Input();

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
        public void NewLocation()
        {
            Assert.AreEqual(1, Day20.newLocation(0, 1, 6));
            Assert.AreEqual(2, Day20.newLocation(0, 2, 6));
            Assert.AreEqual(1, Day20.newLocation(4, -3, 6));
            Assert.AreEqual(5, Day20.newLocation(2, 3, 6));
            Assert.AreEqual(6, Day20.newLocation(2, -2, 6));
            Assert.AreEqual(4, Day20.newLocation(4, 0, 6));
            Assert.AreEqual(3, Day20.newLocation(5, 4, 6));



        }
    }
}