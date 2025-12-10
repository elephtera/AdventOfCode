using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day10Test
    {
        private const long AnswerPart1 = 432;
        private const long AnswerPart2 = 0;
        private const long AnswerExamplePart1 = 7;
        private const long AnswerExamplePart2 = 33;


        private readonly IDay<long> day = new Day10();
        private readonly IDayInput input = new Day10Input();

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
        public void LightSwitchTest()
        {
            var result = Day10.CalculateLightswitch(4, "1,2"); // 0b0110
            Assert.AreEqual(0b0110u, result);

            result = Day10.CalculateLightswitch(4, "0"); // 0b0001
            Assert.AreEqual(0b1000u, result);
        }

        [TestMethod]
        public void LightEndstateTest()
        {
            var result = Day10.CalculateLightEndstate("..#."); // 0b0010
            Assert.AreEqual(2u, result);

            result = Day10.CalculateLightEndstate("...#"); // 0b0010
            Assert.AreEqual(1u, result);
        }

        [TestMethod]
        public void CalcToggleTest()
        {
            var result = Day10.CalculateToggles(
                Day10.CalculateLightEndstate("..#."),
                new List<uint> {
                    Day10.CalculateLightswitch(4, "2"),
                    Day10.CalculateLightswitch(4, "1")
                               },
                0,
                0);
            Assert.AreEqual(1, result);

            result = Day10.CalculateToggles(
                Day10.CalculateLightEndstate(".##."),
                new List<uint> {
                    Day10.CalculateLightswitch(4, "0,2"),
                    Day10.CalculateLightswitch(4, "0,1")
                               },
                0,
                0);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CalcToggleTestExample1()
        {
            // [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1)
            var result = Day10.CalculateToggles(
                Day10.CalculateLightEndstate(".##."),
                new List<uint> {
                    Day10.CalculateLightswitch(4, "3"),
                    Day10.CalculateLightswitch(4, "1,3"),
                    Day10.CalculateLightswitch(4, "2"),
                    Day10.CalculateLightswitch(4, "2,3"),
                    Day10.CalculateLightswitch(4, "0,2"),
                    Day10.CalculateLightswitch(4, "0,1")
                               },
                0,
                0);
            Assert.AreEqual(2, result);

            var input = Day10.ProcessInput("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}");
            Assert.AreEqual(1, input.Count);
            Assert.AreEqual(0b0110u, input[0].lights);
            Assert.AreEqual(6, input[0].bitmasks.Count);
            Assert.AreEqual(4, input[0].jolts.Count);



            var result2 = day.Part1("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}");
            Assert.AreEqual(2, result2);
        }

        [TestMethod]
        public void Part1SeperateExampleTest()
        {
            var result = day.Part1("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}");
            Assert.AreEqual(2, result);

            result = day.Part1("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(3, result);

            result = day.Part1("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}");
            Assert.AreEqual(2, result);


            result = day.Part1(@"[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void CalcToggleTestExample2()
        {
            // [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}

            var input = Day10.ProcessInput("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(1, input.Count);
            Assert.AreEqual(0b00010u, input[0].lights);
            Assert.AreEqual(5, input[0].bitmasks.Count);
            Assert.AreEqual(5, input[0].jolts.Count);

            Assert.AreEqual(0b10111u, input[0].bitmasks[0]);
            Assert.AreEqual(0b00110u, input[0].bitmasks[1]);
            Assert.AreEqual(0b10001u, input[0].bitmasks[2]);
            Assert.AreEqual(0b11100u, input[0].bitmasks[3]);
            Assert.AreEqual(0b01111u, input[0].bitmasks[4]);


            var result = Day10.CalculateToggles(
                Day10.CalculateLightEndstate("...#."),
                new List<uint> {
                    Day10.CalculateLightswitch(5, "0,4"),
                    Day10.CalculateLightswitch(5, "0,1,2"),
                    Day10.CalculateLightswitch(5, "1,2,3,4")
                               },
                0,
                0);
            Assert.AreEqual(3, result);

            result = Day10.CalculateToggles(
                Day10.CalculateLightEndstate("...#."),
                new List<uint> {
                    Day10.CalculateLightswitch(5, "0,2,3,4"),
                    Day10.CalculateLightswitch(5, "2,3"),
                    Day10.CalculateLightswitch(5, "0,4"),
                    Day10.CalculateLightswitch(5, "0,1,2"),
                    Day10.CalculateLightswitch(5, "1,2,3,4")
                               },
                0,
                0);
            Assert.AreEqual(3, result);



            var result2 = day.Part1("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(3, result2);
        }

        [TestMethod]
        public void Part2SeperateExampleTest()
        {
            var result = day.Part2("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}");
            Assert.AreEqual(10, result);

            result = day.Part2("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(12, result);

            result = day.Part2("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}");
            Assert.AreEqual(11, result);


            result = day.Part2(@"[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}");
            Assert.AreEqual(22, result);
        }
    }
}