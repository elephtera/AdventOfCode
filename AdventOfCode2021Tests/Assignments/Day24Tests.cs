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
            var instructions = InputHandler.ConvertInputToOpcodes(Day24Input.Input);

            int[] valueInput = new int[14]
            {
                1,1, 1,1,1, 1,1,1, 1,1,1, 1,1,1,
            };

            int[] result = day.ProcessAluInstructions(instructions, valueInput);
            Assert.AreEqual(result[3], 0);
        }

        [TestMethod()]
        public void PartAIterateTest()
        {

            var day = new Day24();
            var instructions = InputHandler.ConvertInputToOpcodes(Day24Input.Input);

            int[] valueInput = new int[14]
               {
                    1,1, 1,1,1, 1,1,1, 1,1,1, 1,1,1,
               };

            for(int i = 1; i < 10; i++)
            {
                valueInput[0] = i;
                for(int j = 1; j < 10; j++)
                {
                    valueInput[1] = j;
                    for(var k = 1; k < 10; k++)
                    {
                        valueInput[2] = k;
                        for(var l = 1; l < 10; l++)
                        {
                            valueInput[3] = l;

                            int[] result = day.ProcessAluInstructions(instructions, valueInput);
                            if(result[3] == 0)
                            {
                                Assert.AreEqual(result[3], 1);
                            }
                        }
                    }
                }
            }
        }



        [TestMethod()]
        public void BinaryExampleTest()
        {
            var inputstring = @"inp w
add z w
mod z 2
div w 2
add y w
mod y 2
div w 2
add x w
mod x 2
div w 2
mod w 2";
            var day = new Day24();
            var instructions = InputHandler.ConvertInputToOpcodes(inputstring);

            for (int i = 0; i < 16; i++)
            {
                int[] valueInput = new int[1]
                {
                i,
                };

                int[] result = day.ProcessAluInstructions(instructions, valueInput);
                var check = Convert.ToInt32(string.Concat(result), 2);

                Assert.AreEqual(i, check);
            }
        }
    }
}