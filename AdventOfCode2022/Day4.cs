using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day4 : IDay
    {
        public int PartA(string input)
        {
            var inputData = ProcessInput(input);
            var containsCount = 0;
            for (int i = 0; i < inputData.Count; i++)
            {
                if (Contains(inputData[i].Item1, inputData[i].Item2))
                {
                    containsCount++;
                }
            }
            return containsCount;
        }

        public int PartB(string input)
        {
            var inputData = ProcessInput(input);
            var overlapsCount = 0;
            for (int i = 0; i < inputData.Count; i++)
            {
                if (Overlaps(inputData[i].Item1, inputData[i].Item2))
                {
                    overlapsCount++;
                }
            }

            return overlapsCount;
        }

        public static IList<Tuple<Range, Range>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<Tuple<Range, Range>>();
            foreach (var line in lines)
            {
                var ranges = line.Split(',', '-').Select(item => int.Parse(item)).ToList();
                var r1 = new Range(ranges[0], ranges[1]);
                var r2 = new Range(ranges[2], ranges[3]);
                result.Add(new Tuple<Range, Range>(r1, r2));
            }

            return result;
        }

        public static bool Contains(Range left, Range right)
        {
            if (left.Start.Value <= right.Start.Value && left.End.Value >= right.End.Value ||
                right.Start.Value <= left.Start.Value && right.End.Value >= left.End.Value)
            {
                return true;
            }

            return false;
        }

        public static bool Overlaps(Range left, Range right)
        {
            var leftStart = left.Start.Value;
            var leftEnd = left.End.Value;
            var rightStart = right.Start.Value;
            var rightEnd = right.End.Value;

            if (leftStart >= rightStart && leftStart <= rightEnd ||
                rightStart >= leftStart && rightStart <= leftEnd ||
                leftEnd >= rightStart && leftEnd <= rightEnd ||
                rightEnd >= leftStart && rightEnd <= leftEnd)
            {
                return true;
            }


            return false;
        }

    }

}
