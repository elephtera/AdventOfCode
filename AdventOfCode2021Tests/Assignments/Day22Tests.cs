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
    public class Day22Tests
    {
        [TestMethod()]
        public void ExampleA1Test()
        {
            var day = new Day22();
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputExampleA1);
            var result = day.Calc(input);

            Assert.AreEqual(39, result);
        }

        [TestMethod()]
        public void ExampleA2Test()
        {
            var day = new Day22();
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputExampleA2);
            var result = day.Calc(input);

            Assert.AreEqual(590784, result);
        }

        [TestMethod()]
        public void ExampleB1Test()
        {
            var day = new Day22();
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputExampleB1);
            var result = day.Calc(input);

            Assert.AreEqual(2758514936282235, result);
        }

        [TestMethod()]
        public void Part1Test()
        {
            var day = new Day22();
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputA);
            var result = day.Calc(input);

            Assert.AreEqual(609563, result);
        }

        [TestMethod()]
        public void Part2Test()
        {
            var day = new Day22();
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputB);
            var result = day.Calc(input);

            Assert.AreEqual(1234650223944734, result);
        }
    }
}