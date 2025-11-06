using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day1 : IDay<long>
    {
        public long Part1(string input)
        {
            var (leftList, rightList) = ProcessInput(input);
            var orderedLeftList = leftList.Order();
            var orderedRightList = rightList.Order().ToList();

            return orderedLeftList.Select((value, index) => Math.Abs(value - orderedRightList[index])).Sum();
        }

        public long Part2(string input)
        {
            var (leftList, rightList) = ProcessInput(input);
            var orderedLeftList = leftList.Order();

            var rightCount = rightList.CountBy(x => x).ToDictionary();

            return orderedLeftList.Sum(leftValue => leftValue * rightCount.GetValueOrDefault(leftValue,0));
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
