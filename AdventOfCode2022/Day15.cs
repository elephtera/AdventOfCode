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
        public int PartA(IList<string> input, int row)
        {
            var inputData = ProcessInput(input.Single());
            List<int[]> beacons = GetBeacons(inputData);
            var result = AllpointsWithoutBeaconOnRow(inputData, beacons, row);

            return result.Count();
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

        public static List<int> NoBeaconsOnRow(int x1, int y1, int yTarget, int maxDistance)
        {
            var result = new List<int>();
            int minDistanceToY = ManhattenDistance(x1, y1, x1, yTarget);

            if (minDistanceToY > maxDistance)
            {
                return result;
            }

            result.Add(x1);

            for (int i = 1; i <= maxDistance - minDistanceToY; i++)
            {
                result.Add(x1 - i);
                result.Add(x1 + i);
            }

            return result;
        }

        public static Range<int>? ScannedRange(int x1, int y1, int yTarget, int maxDistance)
        {
            int minDistanceToY = ManhattenDistance(x1, y1, x1, yTarget);
            int remaining = maxDistance - minDistanceToY;

            if (minDistanceToY > maxDistance)
            {
                return null;
            }

            return new Range<int>(Math.Max(0,x1 - remaining), Math.Min(x1 + remaining, 4000000));
        }

        public int PartB(IList<string> input, int maxRange)
        {
            // Zoek de enige lege plek die er is in de range [0-max]
            var inputData = ProcessInput(input.Single());
            List<int[]> beacons = GetBeacons(inputData);

            for (int row = 0; row < maxRange; row++)
            {
                var result = AllRangesWithoutBeaconOnRow(inputData, row);
                if(result.Count > 1)
                {
                    var x = result[0].UpperBound + 1;
                    return x * 4000000 + row;
                }
            }

            return 0;
        }

        private IEnumerable<int> AllpointsWithoutBeaconOnRow(IList<int[]> inputData, IList<int[]> beacons, int row)
        {
            var noBeaconsOnRow = new List<int>();
            foreach (var item in inputData)
            {
                int distance = ManhattenDistance(item[0], item[1], item[2], item[3]);
                noBeaconsOnRow.AddRange(NoBeaconsOnRow(item[0], item[1], row, distance));
            }

            foreach (var item in beacons.Where(item => item[1] == row))
            {
                noBeaconsOnRow.RemoveAll(i => i == item[0]);
            }

            var result = noBeaconsOnRow.Distinct();

            return result;
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
