namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day14Test
    {
        private const int AnswerPart1 = 961;
        private const int AnswerPart2 = 26375;
        private const int AnswerExamplePart1 = 24;
        private const int AnswerExamplePart2 = 93;


        private readonly Day14 day = new Day14();
        private readonly IDayInput input = new Day14Input();

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
        public void CreateWall1()
        {
            var simpleWall = new string[] { "1,1 -> 1,4" };
            var res = Day14.CreateWalls(simpleWall);
            Assert.AreEqual(4, res.Count);
        }

        [TestMethod]
        public void CreateWall2()
        {
            var simpleWall = new string[] { "1,4 -> 1,1" };
            var res = Day14.CreateWalls(simpleWall);
            Assert.AreEqual(4, res.Count);
        }

        [TestMethod]
        public void CreateWall3()
        {
            var simpleWall = new string[] { "1,1 -> 4,1" };
            var res = Day14.CreateWalls(simpleWall);
            Assert.AreEqual(4, res.Count);
        }

        [TestMethod]
        public void CreateWall4()
        {
            var simpleWall = new string[] { "4,1 -> 1,1" };
            var res = Day14.CreateWalls(simpleWall);
            Assert.AreEqual(4, res.Count);
        }

        [TestMethod]
        public void CreateWall5()
        {
            var simpleWall = new string[] { "1,1 -> 1,4 -> 4,4" };
            var res = Day14.CreateWalls(simpleWall);
            Assert.AreEqual(7, res.Count);
        }

        [TestMethod]
        public void CreateExampleWalls()
        {
            var res = Day14.ProcessInput(input.ExampleInput);
            Assert.AreEqual(20, res.Count);
            
        }
    }
}