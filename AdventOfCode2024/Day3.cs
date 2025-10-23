using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day3 : IDay<long>
    {
        public long Part1(string input)
        {
            //var inputData = ProcessInput(input);
            Regex regex = new Regex(@"mul\(\d+,\d+\)");
            var matches = regex.Matches(input);
            var result = 0L;

            foreach (Match match in matches)
            {
                result += match.Value[4..^1].Split(',').Select(x => int.Parse(x)).Aggregate((a,b) => a*b);
            }
            return result;
        }

        public long Part2(string input)
        {
            Regex regex = new(@"mul\(\d+,\d+\)|do\(\)|don\'t\(\)");
            var matches = regex.Matches(input);
            var result = 0L;

            var multiply = true;
            foreach (Match match in matches)
            {
                if (match.Value.StartsWith("don't"))
                {
                    multiply = false;
                    continue;
                }
                else if (match.Value.StartsWith("do"))
                {
                    multiply = true;
                    continue;
                }

                if (!multiply)
                    continue;

                result += match.Value[4..^1].Split(',').Select(x => int.Parse(x)).Aggregate((a, b) => a * b);
            }
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
