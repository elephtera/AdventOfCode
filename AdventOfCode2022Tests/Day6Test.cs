namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day6Test
    {
        private const int AnswerPartA = 1100;
        private const int AnswerPartB = 2421;
        private const int AnswerExamplePartA = 7;
        private const int AnswerExamplePartB = 19;


        private readonly IDay<int> day = new Day6();
        private readonly IDayInput input = new Day6Input();

        [TestMethod]
        public void PartAExample()
        {
            var result = day.PartA(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartA, result);

        }

        [TestMethod]
        public void PartAExampleExtra()
        {
            var result = day.PartA(new List<string>() { "bvwbjplbgvbhsrlpgdmjqwftvncz" });
            Assert.AreEqual(5, result);

            result = day.PartA(new List<string>() { "nppdvjthqldpwncqszvftbrmjlhg" });
            Assert.AreEqual(6, result);

            result = day.PartA(new List<string>() { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" });
            Assert.AreEqual(10, result);

            result = day.PartA(new List<string>() { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" });
            Assert.AreEqual(11, result);

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
        public void PartBExampleExtra()
        {
            var result = day.PartB(new List<string>() { "bvwbjplbgvbhsrlpgdmjqwftvncz" });
            Assert.AreEqual(23, result);

            result = day.PartB(new List<string>() { "nppdvjthqldpwncqszvftbrmjlhg" });
            Assert.AreEqual(23, result);

            result = day.PartB(new List<string>() { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" });
            Assert.AreEqual(29, result);

            result = day.PartB(new List<string>() { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" });
            Assert.AreEqual(26, result);

        }

        [TestMethod]
        public void PartB()
        {
            var result = day.PartB(input.Input);
            Assert.AreEqual(AnswerPartB, result);
        }
    }
}