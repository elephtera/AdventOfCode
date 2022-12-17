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
    public class Day19Tests
    {
        //[TestMethod()]
        public void Part1Test()
        {
            var day = new Day19();
            Assert.AreEqual("512", day.Part1());
        }

        //[TestMethod()]
        public void Part2Test()
        {
            var day = new Day19();
            Assert.AreEqual("16802", day.Part2());
        }

        //
    }
}