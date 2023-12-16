using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day14 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var transposedInput = Transpose(inputData);

            transposedInput = MoveRocks(transposedInput);

            transposedInput = Transpose(transposedInput).ToList();

            var result = 0;

            var distance = transposedInput.Count();
            foreach (var line in transposedInput)
            {
                result += line.Count(c => c == 'O') * distance;
                distance--;
            }

            return result;
        }

        private static IEnumerable<string> MoveRocks(IEnumerable<string> transposedInput, bool rollToRight = false)
        {
            transposedInput = transposedInput.Select(line =>
            {
                var previousLine = "";
                while (line != previousLine)
                {
                    previousLine = line;
                    line = Regex.Replace(line, rollToRight ? @"(O+)(\.+)" : @"(\.+)(O+)", "$2$1");
                }

                return line;
            }).ToList();
            return transposedInput;
        }

        private static IEnumerable<string> Transpose(IEnumerable<string> inputData)
        {
            var transposedInput = inputData
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => string.Concat(g));
            return transposedInput;
        }

        public int Part2(string input)
        {
            IEnumerable<string> transposedInput = ProcessInput(input);

            var cache = new List<string>();

            for (int i = 0; i < 200; i++)
            {
                transposedInput = RunCycle(transposedInput);

                var cacheValue = string.Concat(transposedInput);
                if (cache.Contains(cacheValue))
                {
                    var preamble = cache.IndexOf(cacheValue);
                    var cycleLength = cache.Count - preamble;

                    var toRun = (1000000000 - i - 1) % cycleLength;
                    for (int j = 0; j < toRun; j++)
                    {
                        transposedInput = RunCycle(transposedInput);
                    }
                    break;

                }
                else
                {
                    cache.Add(cacheValue);
                }
            }

            var result = 0;

            var distance = transposedInput.Count();
            foreach (var line in transposedInput)
            {
                result += line.Count(c => c == 'O') * distance;
                distance--;
            }

            return result;
        }

        private static IEnumerable<string> RunCycle(IEnumerable<string> transposedInput)
        {
            // north
            transposedInput = Transpose(transposedInput); // <
            transposedInput = MoveRocks(transposedInput);

            // west
            transposedInput = Transpose(transposedInput); // ^
            transposedInput = MoveRocks(transposedInput);

            // zuid
            transposedInput = Transpose(transposedInput); // <
            transposedInput = MoveRocks(transposedInput, true);

            // oost
            transposedInput = Transpose(transposedInput); // ^
            transposedInput = MoveRocks(transposedInput, true);
            return transposedInput;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

}
