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
            var result = 0;


            foreach (var row in inputData)
            {
                result += CalcJolt(row);
            }

            return result;
        }

        private int CalcJolt(int[] row)
        {
            var maxJolt = 0;
            for (var i = 0; i < row.Length - 1; i++)
            {
                var firstDigit = row[i] * 10;
                foreach(var secondDigit in row.Skip(i+1))
                {
                    var jolt = firstDigit + secondDigit;
                    if (jolt > maxJolt)
                    {
                        maxJolt = jolt;
                    }
                }
            }
            return maxJolt;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;


            foreach (var row in inputData)
            {
                Memoization.Clear();
                var intermediate=CalcBigJolt(row, 12);
                result += intermediate;
            }

            return result;
        }

        public Dictionary<(int, int), long> Memoization = new Dictionary<(int, int), long>();

        public long CalcBigJolt(int[] row, int batteryToActivate)
        {
            if(Memoization.ContainsKey((row.Length, batteryToActivate)))
            {
                return Memoization[(row.Length, batteryToActivate)];
            }

            if (row.Length == batteryToActivate)
            {
                return long.Parse(string.Join("", row));
            }

            long r1;
            if (batteryToActivate == 1)
            {
                r1 = (row[0]);
            }
            else
            {

                // check with the first number
                r1 = (long)(row[0] * Math.Pow(10, (batteryToActivate - 1)) + CalcBigJolt(row[1..], batteryToActivate - 1));
            }


            // check without the first number
            var r2 = CalcBigJolt(row[1..], batteryToActivate);

            if (r1 > r2)
            {
                Memoization[(row.Length, batteryToActivate)] = r1;
                return r1;
            }

            Memoization[(row.Length, batteryToActivate)] = r2;
            return r2;
        }

        public static IList<int[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
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
