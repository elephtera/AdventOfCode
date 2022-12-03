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
        public void PartATest()
        {
            var day = new Day19();
            Assert.AreEqual("512", day.PartA());
        }

        //[TestMethod()]
        public void PartBTest()
        {
            var day = new Day19();
            Assert.AreEqual("16802", day.PartB());
        }

        //
    }
}