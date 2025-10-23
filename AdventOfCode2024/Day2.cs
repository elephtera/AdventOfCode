using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day2 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            foreach (var report in inputData)
            {
                if (checkIfSafe(report))
                {
                    result++;
                }                
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            foreach (var report in inputData)
            {
                if (checkSafetyWithDampener(report))
                {
                    result++;
                }
            }
            return result;
        }

        private static bool checkSafetyWithDampener(IList<int> report)
        {
            if (checkIfSafe(report))
            {
                return true;
            }

            for (var i = 0; i < report.Count; i++)
            {
                var reportWithout = new List<int>(report);
                reportWithout.RemoveAt(i);

                if (checkIfSafe(reportWithout))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool checkIfSafe(IList<int> report)
        {
            if (report[0] == report[1])
            {
                return false;
            }

            if (report[0] < report[1])
            {
                // all should be ascending
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var diff = report[i + 1] - report[i];
                    if (diff > 3 || diff < 1)
                    {
                        return false;
                    }
                }

                return true;
            }

            if (report[0] > report[1])
            {
                // all should be ascending
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var diff = report[i] - report[i + 1];
                    if (diff > 3 || diff < 1)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public static IList<IList<int>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None);
            var result = new List<IList<int>>();
            foreach (var line in lines)
            {
                // Process each line as needed
                result.Add(line.Split(' ').Select(x => int.Parse(x)).ToList());
            }

            return result;
        }
    }
}
