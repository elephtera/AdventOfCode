namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day3Test
    {
        private const int AnswerPart1 = 7889;
        private const int AnswerPart2 = 2825;
        private const int AnswerExamplePart1 = 157;
        private const int AnswerExamplePart2 = 70;


        private readonly IDay<int> day = new Day3();
        private readonly IDayInput input = new Day3Input();

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
        public void ConvertTestLower()
        {
            Assert.AreEqual(1, Day3.ConvertToPrio('a'));
        }

        [TestMethod]
        public void ConvertTestUpper()
        {
            Assert.AreEqual(27, Day3.ConvertToPrio('A'));
        }

        [TestMethod]
        public void TestDuplicateFinder()
        {
            Assert.AreEqual('A', Day3.FindDuplicateItem("ABCA"));
            Assert.AreEqual('A', Day3.FindDuplicateItem("BAAC"));
            Assert.ThrowsExactly<InvalidOperationException>(() => Day3.FindDuplicateItem("BAaC"));
        }

        [TestMethod]
        public void TestDuplicateFinderV2()
        {
            // Examples
            Assert.AreEqual('r', Day3.FindDuplicateItem("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg"));
            Assert.AreEqual('Z', Day3.FindDuplicateItem("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw"));
            
            Assert.AreEqual('a', Day3.FindDuplicateItem("aBCD", "ABCDa", "abcde"));
            Assert.ThrowsExactly<InvalidOperationException>(() => Day3.FindDuplicateItem("ABCD", "ABCD", "ABCD"));

        }
    }
}