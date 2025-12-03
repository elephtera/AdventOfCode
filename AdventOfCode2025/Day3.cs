using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day3 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            return inputData.Aggregate(0L, (acc, row) => acc + CalcJolt(row, 2));
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            return inputData.Aggregate(0L, (acc, row) => acc + CalcJolt(row, 12));
        }

        public long CalcJolt(int[] row, int batteryToActivate)
        {
            if (batteryToActivate == 1)
            {
                return row.Max();
            }

            var remainingBatteryToActivate = (batteryToActivate - 1);
            var maxInRow = row[..^remainingBatteryToActivate].Max();

            return (long)(maxInRow * Math.Pow(10,remainingBatteryToActivate)) 
                + CalcJolt(row[(row.IndexOf(maxInRow) + 1)..], remainingBatteryToActivate);
        }

        public static IList<int[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var res = new List<int[]>();
            foreach (var line in lines)
            {
                res.Add(Array.ConvertAll(line.ToCharArray(), c => int.Parse(c.ToString())));
            }

            return res;
        }
    }

}
