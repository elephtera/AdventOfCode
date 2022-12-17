using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Assignments.Tests
{
    [TestClass()]
    public class Day20Tests
    {
        [TestMethod()]
        public void Part1Test()
        {
            var day = new Day20();
            Assert.AreEqual("5391", day.Part1());
        }

        [TestMethod()]
        public void Part2Test()
        {
            var day = new Day20();
            Assert.AreEqual("16383", day.Part2());
        }


        [TestMethod()]
        public void EnhancerTest()
        {
            var day = new Day20();
            var input = InputHandler.ConvertInputToPadded2DArray(Input);
            var output = Day20.EnhanceImage(input, Enhancer, "0");

            /**
             * .....##.##.....
             * ....#..#.#.....
             * ....##.#..#....
             * ....####..#....
             * .....#..##.....
             * ......##..#....
             * .......#.#.....
            */
            CollectionAssert.AreEqual(new int[] { 0, 0, 1, 1, 0, 1, 1, 0, 0 }, output[1]);
            CollectionAssert.AreEqual(new int[] { 0, 1, 0, 0, 1, 0, 1, 0, 0 }, output[2]);
            CollectionAssert.AreEqual(new int[] { 0, 1, 1, 0, 1, 0, 0, 1, 0 }, output[3]);
            CollectionAssert.AreEqual(new int[] { 0, 1, 1, 1, 1, 0, 0, 1, 0 }, output[4]);
            CollectionAssert.AreEqual(new int[] { 0, 0, 1, 0, 0, 1, 1, 0, 0 }, output[5]);
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 1, 1, 0, 0, 1, 0 }, output[6]);
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 0 }, output[7]);

            output = Day20.EnhanceImage(output, Enhancer, "0");
            /**
             * ..........#....
             * ....#..#.#.....
             * ...#.#...###...
             * ...#...##.#....
             * ...#.....#.#...
             * ....#.#####....
             * .....#.#####...
             * ......##.##....
             * .......###.....
             */
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, }, output[2]);
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, }, output[3]);


        }

        [TestMethod()]
        public void CountLitItemsTest()
        {
            var day = new Day20();
            var input = InputHandler.ConvertInputToPadded2DArray(Input);
            var output = Day20.EnhanceImage(input, Enhancer, "0");
            output = Day20.EnhanceImage(output, Enhancer, "0");
            var count = Day20.CountLitItems(output);
            Assert.AreEqual(35, count);
        }

        [TestMethod()]
        public void CountLitItemsBTest()
        {
            var day = new Day20();
            var input = InputHandler.ConvertInputToPadded2DArray(Input);
            int[][]? output = input;
            for (int i = 0; i < 50; i++)
            {
                output = Day20.EnhanceImage(output, Enhancer, i % 2 == 0? "0" : "0");
            }

            var count = Day20.CountLitItems(output);
            Assert.AreEqual(3351, count);
        }

        [TestMethod()]
        public void Part1CountTest()
        {
            var day = new Day20();
            var input = InputHandler.ConvertInputToPadded2DArray(Day20Input.Input);
            int[][]? output = input;
            for (int i = 0; i < 2; i++)
            {
                output = Day20.EnhanceImage(output, Day20Input.Enhancer, i % 2 == 0 ? "0" : "1");
            }

            var count = Day20.CountLitItems(output);
            Assert.AreEqual(5391, count);
        }

        [TestMethod()]
        public void Part2CountTest()
        {
            var day = new Day20();
            var input = InputHandler.ConvertInputToPadded2DArray(Day20Input.Input);
            int[][]? output = input;
            for (int i = 0; i < 50; i++)
            {
                output = Day20.EnhanceImage(output, Day20Input.Enhancer, i % 2 == 0 ? "0" : "1");
            }

            var count = Day20.CountLitItems(output);
            Assert.AreEqual(16383, count);
        }


        [TestMethod()]
        public void MinMaxEnhanceTest()
        {
            var day = new Day20();
            var binary = "000000000";
            int lookupIndex = Convert.ToInt32(binary, 2);
            int res = Day20Input.Enhancer[lookupIndex] == '#' ? 1 : 0;
            Assert.AreEqual(1, res);

            binary = "111111111";
            lookupIndex = Convert.ToInt32(binary, 2);
            res = Day20Input.Enhancer[lookupIndex] == '#' ? 1 : 0;
            Assert.AreEqual(0, res);
        }



        public static string Enhancer = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#";
        public static string Input = @"#..#.
#....
##..#
..#..
..###";
        //
    }
}