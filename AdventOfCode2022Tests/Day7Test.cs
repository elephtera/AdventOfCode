namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day7Test
    {
        private const long AnswerPart1 = 1232307;
        private const long AnswerPart2 = 7268994;
        private const long AnswerExamplePart1 = 95437;
        private const long AnswerExamplePart2 = 24933642;


        private readonly IDay<long> day = new Day7();
        private readonly IDayInput input = new Day7Input();

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
        public void Part1ExampleDirectoryBuilder()
        {
            var inputData = Day7.ProcessInput(input.ExampleInput);
            var result = Day7.CreateDirectoryTree(inputData);

            Assert.IsTrue(result.SubDirectories.Count == 2);
            Assert.IsTrue(result.Files.Count == 2);

            var dirA = result.SubDirectories.Where(d => d.Name == "a").Single();
            Assert.AreEqual(94853, dirA.Size);

            var dirE = dirA.SubDirectories.Where(d => d.Name == "e").Single();
            Assert.AreEqual(584, dirE.Size);
        }

        [TestMethod]
        public void FileNodeTest()
        {
            var file = new FileNodes("file1", 1234);
            Assert.IsNotNull(file);
            Assert.AreEqual(1234, file.Size);
            Assert.AreEqual("file1", file.Name);
        }

        [TestMethod]
        public void DirectoryParentTest()
        {
            var root = new DirectoryNode("Parent", null);
            Assert.IsNull(root.Parent);
            var dir = new DirectoryNode("Subdir", root);
            Assert.IsNotNull(dir.Parent);
        }

        [TestMethod]
        public void DirectorySizeTest()
        {
            var root = new DirectoryNode("A", null);
            root.AddFile("AA", 10);
            root.AddFile("AB", 15);
            Assert.AreEqual(25, root.Size);

            var subdir = root.AddSubdir("B");
            subdir.AddFile("BA", 3);
            Assert.AreEqual(3, subdir.Size);
            Assert.AreEqual(28, root.Size);


        }
    }
}