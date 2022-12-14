namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day14Test
    {
        private const int AnswerPartA = 961;
        private const int AnswerPartB = 26375;
        private const int AnswerExamplePartA = 24;
        private const int AnswerExamplePartB = 93;


        private readonly Day14 day = new Day14();
        private readonly IDayInput input = new Day14Input();

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
            var res = Day14.ProcessInput(input.ExampleInput.Single());
            Assert.AreEqual(20, res.Count);
            
        }
    }
}