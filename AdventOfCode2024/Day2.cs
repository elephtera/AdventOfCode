using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024
{
    public class Day2 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            return inputData.Count(IsSafe);
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            return inputData.Count(IsSafeWithDamper);
        }

        private static bool IsSafeWithDamper(IList<int> report)
        {
            if (IsSafe(report))
            {
                return true;
            }

            for (var i = 0; i < report.Count; i++)
            {
                var reportWithOneItemSkipped = new List<int>(report);
                reportWithOneItemSkipped.RemoveAt(i);

                if (IsSafe(reportWithOneItemSkipped))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSafe(IList<int> report)
        {
            var ascending = report[0] < report[1];

            for (var i = 0; i < report.Count - 1; i++)
            {
                var diff = ascending ? report[i + 1] - report[i] : report[i] - report[i + 1];
                if (diff is < 1 or > 3)
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<IList<int>> ProcessInput(string input)
        {
            var lines = input.Split([Environment.NewLine], StringSplitOptions.None);
            var result = new List<IList<int>>();
            foreach (var line in lines)
            {
                result.Add(line.Split(' ').Select(int.Parse).ToList());
            }

            return result;
        }
    }
}
