using AdventOfCode2025;
using AdventOfCode2025Tests.Input;

namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day3Test
    {
        private const long AnswerPart1 = 17403;
        private const long AnswerPart2 = 173416889848394;
        private const long AnswerExamplePart1 = 357;
        private const long AnswerExamplePart2 = 3121910778619;


        private readonly Day3 day = new Day3();
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
        public void Part2Pim()
        {
            var result = day.Part2Pim(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void CalcBigJolt2Choices()
        {
            var result = day.CalcJolt([1, 2], 1);
            Assert.AreEqual(2, result);

            result = day.CalcJolt([2, 1], 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CalcBigJolt1Item()
        {
            var result = day.CalcJolt([2], 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CalcBigJolt2()
        {
            var result = day.CalcJolt([1, 2, 3, 4, 5], 3);
            Assert.AreEqual(345, result);
        }

        [TestMethod]
        public void CalcBigJolt3()
        {
            var result = day.CalcJolt([5, 4, 3, 2, 1], 3);
            Assert.AreEqual(543, result);
        }

        [TestMethod]
        public void CalcBigJolt4()
        {
            var result = day.CalcJolt([1, 4, 3, 2, 1], 3);
            Assert.AreEqual(432, result);
        }

        [TestMethod]
        public void CalcBigJolt5()
        {
            var result = day.CalcJolt("14321".Select(c => int.Parse(c.ToString())).ToArray(), 3);
            Assert.AreEqual(432, result);
        }

        [TestMethod]
        public void CalcBigJoltExample1()
        {
            var result = day.CalcJolt("987654321111111".Select(c => int.Parse(c.ToString())).ToArray(), 12);
            Assert.AreEqual(987654321111, result);
        }

        [TestMethod]
        public void CalcBigJoltExample2()
        {
            var result = day.CalcJolt("811111111111119".Select(c => int.Parse(c.ToString())).ToArray(), 12);
            Assert.AreEqual(811111111119, result);
        }

        [TestMethod]
        public void CalcBigJoltExample3()
        {
            var result = day.CalcJolt("234234234234278".Select(c => int.Parse(c.ToString())).ToArray(), 12);
            Assert.AreEqual(434234234278, result);
        }

        [TestMethod]
        public void CalcBigJoltExample4()
        {
            var result = day.CalcJolt("818181911112111".Select(c => int.Parse(c.ToString())).ToArray(), 12);
            Assert.AreEqual(888911112111, result);
        }

        //6483266694748235893324353634344523834567333718239477213324541343624714732212276727733744455653544463

        [TestMethod]
        public void CalcBigJoltExample5()
        {
            var result = day.CalcJolt("6483266694748235893324353634344523834567333718239477213324541343624714732212276727733744455653544463".Select(c => int.Parse(c.ToString())).ToArray(), 12);
            Assert.AreEqual(999777777777, result);
        }
    }
}