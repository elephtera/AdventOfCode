using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day9 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }
}
