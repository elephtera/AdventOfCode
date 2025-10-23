using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Assignments;
namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day23Test
    {
        private const int AnswerPart1 = 4045;
        private const int AnswerPart2 = 963;
        private const int AnswerExamplePart1 = 110;
        private const int AnswerExamplePart2 = 20;


        private readonly IDay<int> day = new Day23();
        private readonly IDayInput input = new Day23Input();

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

        [TestMethod()]
        public void CalculateRectangleTest()
        {
            var elves = new List<(int X, int Y)>() { (1, 1), (2, 2) };
            var result = Day23.CalculateRectangle(elves);
            Assert.AreEqual(2, result);

            elves = new List<(int X, int Y)>() { (-1, -1), (2, 2) };
            result = Day23.CalculateRectangle(elves);
            Assert.AreEqual(16 - 2, result);
        }

        [TestMethod]
        public void ElvesNearTest()
        {
            var elves = new List<(int X, int Y)>() { (1, 1), (1,2), (4, 4) };
            var result = Day23.ElvesNear((1,2), elves, Direction.North);
            Assert.IsTrue(result);

            result = Day23.ElvesNear((4,4), elves, Direction.North);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ExtraExampleTest()
        {
            var example = @".....
..##.
..#..
.....
..##.
.....";

            var result = day.Part1(example);
            Assert.AreEqual(AnswerExamplePart1, result);

        }
    }
}