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
            var result = 0;
            return result;
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
