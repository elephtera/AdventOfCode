using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day1 : IDay<long>
    {
        public long Part1(string input)
        {
            var (leftList, rightList) = ProcessInput(input);
            var orderedLeftList = leftList.Order().ToList();
            var orderedRightList = rightList.Order().ToList();

            var result = 0L;

            for (int i = 0; i < orderedLeftList.Count; i++)
            {
                var left = orderedLeftList[i];
                var right = orderedRightList[i];
                result += Math.Abs(left - right);
            }
                        
            return result;
        }

        public long Part2(string input)
        {
            var (leftList, rightList) = ProcessInput(input);
            var orderedLeftList = leftList.Order().ToList();

            var cnt = rightList.CountBy(x => x).ToDictionary();

            var result = 0L;

            for (int i = 0; i < orderedLeftList.Count; i++)
            {
                var left = orderedLeftList[i];
                result += left * cnt.GetValueOrDefault(left,0);
            }

            return result;
        }

        public static (IList<long>, IList<long>) ProcessInput(string input)
        {
            var lines = input.Split([Environment.NewLine], StringSplitOptions.None);
            
            var leftList = new List<long>();
            var rightList = new List<long>();

            foreach (var line in lines)
            {
                // Split on whitespace, remove empty entries
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var left = long.Parse(parts[0]);
                var right = long.Parse(parts[1]);

                leftList.Add(left);
                rightList.Add(right);
            }

            return (leftList, rightList);
        }
    }
}
