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
    public class Day24Tests
    {
        [TestMethod()]
        public void PartATest()
        {
            var day = new Day24();
            var result = day.PartA();
            Assert.AreEqual(result, "lowest 123");
        }
    }
}