using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day4Test
    {
        private const long AnswerPart1 = 1549;
        private const long AnswerPart2 = 8887;
        private const long AnswerExamplePart1 = 13;
        private const long AnswerExamplePart2 = 43;


        private readonly IDay<long> day = new Day4();
        private readonly IDayInput input = new Day4Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1SmallExample()
        {
            var input = 
@"...
...
...";
            var result = day.Part1(input);
            Assert.AreEqual(0, result);

            input =
@"@..
.@.
..@";
            result = day.Part1(input);
            Assert.AreEqual(3, result);

            input =
@"@..
@..
@..";
            result = day.Part1(input);
            Assert.AreEqual(3, result);

            input =
@"..@
..@
..@";
            result = day.Part1(input);
            Assert.AreEqual(3, result);

            input =
            @"...
...
@@@";
            result = day.Part1(input);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void Part1ExtraSmallExample()
        {
            var input =
                @"@@
@@";
            var result = day.Part1(input);
            Assert.AreEqual(4, result);

            input =
                @".@
@.";
            result = day.Part1(input);
            Assert.AreEqual(2, result);

            input =
               @"..
..";
            result = day.Part1(input);
            Assert.AreEqual(0, result);

            input =
               @".@
.@";
            result = day.Part1(input);
            Assert.AreEqual(2, result);

            input =
               @"..
@@";
            result = day.Part1(input);
            Assert.AreEqual(2, result);

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
    }
}