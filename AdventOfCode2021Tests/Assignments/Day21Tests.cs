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
    public class Day21Tests
    {
        [TestMethod()]
        public void PartATest()
        {
            var losingScore = Day21.PlayGame(1, 6);
            Assert.AreEqual(604998, losingScore);
        }

        [TestMethod()]
        public void ExampleTest()
        {
            var losingScore = Day21.PlayGame(4, 8);
            Assert.AreEqual(739785, losingScore);
        }

        [TestMethod()]
        public void PartBTest()
        {
            var dag = new Day21();
            var results = dag.Speel(true, 1, 0, 6, 0);
            Assert.AreEqual(157253621231420, results.Win1);
            Assert.AreEqual(63247472387933, results.Win2);
        }

        [TestMethod()]
        public void ExampleBTest()
        {
            var dag = new Day21();
            var results = dag.Speel(true, 4, 0, 8, 0);
            Assert.AreEqual(444356092776315, results.Win1);
            Assert.AreEqual(341960390180808, results.Win2);
        }
    }
}