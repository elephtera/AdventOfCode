using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day9 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var inputNumbers = inputData.Select(line => InputParsing.ToLongList(line)).ToList();

            List<long> nextNumbers = inputNumbers.Select(CalculateNextNumber).ToList();
            var result = nextNumbers.Sum();
            return result;
        }

        private static long CalculateNextNumber(List<long> list)
        {
            var diffLists = new List<List<long>>() { list };

            var diff = list;
            do
            {
                diff = CalculateDiffList(diff);
                diffLists.Add(diff);
            } while (diff.Any(n => n != 0));

            var previous = 0L;
            for (var i = diffLists.Count - 1; i >= 0; i--)
            {
                previous = diffLists[i].Last() + previous;
            }

            return previous;
        }

        private static long CalculatePreviousNumber(List<long> list)
        {
            var diffLists = new List<List<long>>() { list };

            var diff = list;
            do
            {
                diff = CalculateDiffList(diff);
                diffLists.Add(diff);
            } while (diff.Any(n => n != 0));

            var previous = 0L;
            for (var i = diffLists.Count - 1; i >= 0; i--)
            {
                previous = diffLists[i][0] - previous;
            }

            return previous;
        }

        private static List<long> CalculateDiffList(List<long> list)
        {
            var diffList = new List<long>();

            long previousNumber = list[0];
            for (var index = 1; index < list.Count; index++)
            {
                diffList.Add(list[index] - previousNumber);
                previousNumber = list[index];
            }

            return diffList;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);

            var inputNumbers = inputData.Select(line => InputParsing.ToLongList(line)).ToList();

            List<long> previousNumbers = inputNumbers.Select(CalculatePreviousNumber).ToList();
            var result = previousNumbers.Sum();
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
