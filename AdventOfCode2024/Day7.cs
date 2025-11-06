using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace AdventOfCode2024
{
    public class Day7 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;

            foreach (var line in inputData)
            {
                // Implement the logic for Part 1 here
                var answer = line[0];
                var res = calcNext(line[1], line.Skip(2).ToList());
                if(res.Any(x => x == answer))
                {
                    result += answer;
                }


            }
            return result;
        }

        public IEnumerable<long> calcNext(long current, IList<long> numbers)
        {
            if(numbers.Count == 0) { 
                yield return current;
                yield break;
            }

            foreach (var c in calcNext(current * numbers[0], numbers.Skip(1).ToList()))
            {
                yield return c;
            }
            foreach (var c in calcNext(current + numbers[0], numbers.Skip(1).ToList()))
            {
                yield return c;
            }
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;

            foreach (var line in inputData)
            {
                // Implement the logic for Part 1 here
                var answer = line[0];
                var res = calcNext2(answer, line[1], line.Skip(2).ToList());
                if (res.Any())
                {
                    result += answer;
                }


            }
            return result;
        }

        public IEnumerable<long> calcNext2(long answer, long current, IList<long> numbers)
        {
            if (numbers.Count == 0)
            {
                if (current == answer)
                {
                    yield return current;
                }
                yield break;
            }

            if (current > answer)
            {
                yield break;
            }

            foreach (var c in calcNext2(answer, current * numbers[0], numbers.Skip(1).ToList()))
            {
                yield return c;
            }
            foreach (var c in calcNext2(answer, current + numbers[0], numbers.Skip(1).ToList()))
            {
                yield return c;
            }
            foreach (var c in calcNext2(answer, long.Parse($"{current}{numbers[0]}"), numbers.Skip(1).ToList()))
            {
                yield return c;
            }
        }

        public static IList<List<long>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var res = lines.Select(x => x.Split(new char[] { ':', ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToList()).ToList();
            return res;
        }
    }
}
