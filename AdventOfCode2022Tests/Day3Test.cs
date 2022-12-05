namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day3Test
    {
        private const int AnswerPartA = 7889;
        private const int AnswerPartB = 2825;
        private const int AnswerExamplePartA = 157;
        private const int AnswerExamplePartB = 70;


        private readonly IDay<int> day = new Day3();
        private readonly IDayInput input = new Day3Input();

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
            Assert.ThrowsException<InvalidOperationException>(() => Day3.FindDuplicateItem("BAaC"));
        }

        [TestMethod]
        public void TestDuplicateFinderV2()
        {
            // Examples
            Assert.AreEqual('r', Day3.FindDuplicateItem("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg"));
            Assert.AreEqual('Z', Day3.FindDuplicateItem("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw"));
            
            Assert.AreEqual('a', Day3.FindDuplicateItem("aBCD", "ABCDa", "abcde"));
            Assert.ThrowsException<InvalidOperationException>(() => Day3.FindDuplicateItem("ABCD", "ABCD", "ABCD"));

        }
    }
}