using AdventOfCode2022.Helpers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day15
    {
        public int Part1(string input, int row)
        {
            var inputData = ProcessInput(input);
            List<int[]> beacons = GetBeacons(inputData);
            var result = AllRangesWithoutBeaconOnRow(inputData, row);

            var beaconsOnRow = beacons.Where(b => b[1] == row).Count();
            var count = result.Select(r => RangeCount(r)).Sum();
            return count - beaconsOnRow;
        }

        private List<int[]> GetBeacons(IList<int[]> inputData)
        {
            var beacons = new List<int[]>();
            foreach (var sensor in inputData)
            {
                if (beacons.Any(x => x[0] == sensor[2] && x[1] == sensor[3]))
                {
                    continue;
                }

                beacons.Add(new int[2] { sensor[2], sensor[3] });
            }

            return beacons;
        }

        public static int ManhattenDistance(int x1, int y1, int x2, int y2)
        {
            var distance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return distance;
        }

        public static Range<int>? ScannedRange(int x1, int y1, int yTarget, int maxDistance)
        {
            int minDistanceToY = ManhattenDistance(x1, y1, x1, yTarget);
            int remaining = maxDistance - minDistanceToY;

            if (minDistanceToY > maxDistance)
            {
                return null;
            }

            return new Range<int>(x1 - remaining, x1 + remaining);
           // return new Range<int>(Math.Max(-100,x1 - remaining), Math.Min(x1 + remaining, 4000000));
        }

        public static int RangeCount(Range<int> range)
        {
            return range.UpperBound + 1 - range.LowerBound;
        }

        public long Part2(string input, int maxRange)
        {
            // Zoek de enige lege plek die er is in de range [0-max]
            var inputData = ProcessInput(input);
            List<int[]> beacons = GetBeacons(inputData);

            for (int row = 0; row < maxRange; row++)
            {
                var result = AllRangesWithoutBeaconOnRow(inputData, row);
                if(result.Count > 1 && result[0].UpperBound > 0 && result[0].UpperBound < 4000000)
                {
                    long x = result[0].UpperBound + 1;
                    return x * 4000000 + row;
                }
            }

            return 0;
        }

        private IList<Range<int>> AllRangesWithoutBeaconOnRow(IList<int[]> inputData, int row)
        {
            var rangesForRow = new List<Range<int>>();
            foreach (var item in inputData)
            {
                int distance = ManhattenDistance(item[0], item[1], item[2], item[3]);

                var range = ScannedRange(item[0], item[1], row, distance);
                if (range != null)
                {
                    rangesForRow.Add(range);
                }
            }

            var ranges = rangesForRow.Coalesce().ToList();

            return ranges;
        }


        public static IList<int[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<int[]>();
            foreach (var line in lines)
            {
                result.Add(Regex.Matches(line, @"-?\d+").Select(d => int.Parse(d.Value)).ToArray());
            }

            return result;
        }
    }

}
