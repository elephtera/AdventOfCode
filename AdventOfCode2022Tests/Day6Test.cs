namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day6Test
    {
        private const int AnswerPart1 = 1100;
        private const int AnswerPart2 = 2421;
        private const int AnswerExamplePart1 = 7;
        private const int AnswerExamplePart2 = 19;


        private readonly IDay<int> day = new Day6();
        private readonly IDayInput input = new Day6Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);

        }

        [TestMethod]
        public void Part1ExampleExtra()
        {
            var result = day.Part1("bvwbjplbgvbhsrlpgdmjqwftvncz");
            Assert.AreEqual(5, result);

            result = day.Part1("nppdvjthqldpwncqszvftbrmjlhg");
            Assert.AreEqual(6, result);

            result = day.Part1("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            Assert.AreEqual(10, result);

            result = day.Part1("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            Assert.AreEqual(11, result);

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
        public void Part2ExampleExtra()
        {
            var result = day.Part2("bvwbjplbgvbhsrlpgdmjqwftvncz");
            Assert.AreEqual(23, result);

            result = day.Part2("nppdvjthqldpwncqszvftbrmjlhg");
            Assert.AreEqual(23, result);

            result = day.Part2("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            Assert.AreEqual(29, result);

            result = day.Part2("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            Assert.AreEqual(26, result);

        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }
    }
}