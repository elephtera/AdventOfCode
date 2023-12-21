using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day21 : IDay<long>
    {
        public long WalkAmount(string input, int steps)
        {
            var inputData = ProcessInput(input);

            var startPoint = FindStartPoint(inputData);

            // hashset is a distinct dataset
            var visiting = new HashSet<(int x, int y)> { (startPoint) };

            for (var i = 0; i < steps; i++)
            {
                var willVisit = new HashSet<(int x, int y)>();
                foreach (var (x, y) in visiting)
                {
                    // if (x,y) is a valid location, continue walking.
                    if (x < 0 || y < 0 || x >= inputData[0].Length || y >= inputData.Count)
                    {
                        continue;
                    }

                    // Steen
                    if (inputData[y][x] == '#')
                    {
                        continue;
                    }

                    willVisit.Add((x + 1, y));
                    willVisit.Add((x - 1, y));
                    willVisit.Add((x, y + 1));
                    willVisit.Add((x, y - 1));
                }

                visiting = willVisit;
            }

            var validVisiting = visiting.Where(v => inputData[v.y][v.x] != '#');
            var result = validVisiting.Count();
            return result;
        }



        public long Part1(string input)
        {
            return WalkAmount(input, 64);
        }

        public long Part2(string input)
        {
            var totalSteps = 26501365L;

            var inputData = ProcessInput(input);
            var startPoint = FindStartPoint(inputData);

            var width = inputData.Count;

            var visiting = new HashSet<(int x, int y)> { (startPoint) };
            var counts = new List<(int x, int y)>();
            
            // start at 1, because we are talking about actual steps, not "array indexes".
            // end at 65 (start to edge) + 2 extra fields. this should give enough data for the lagrange interpolation formula.
            for (var steps = 1; steps <= startPoint.x + 2 * width; steps++)
            {
                var willVisit = new HashSet<(int x, int y)>();
                foreach (var (x, y) in visiting)
                {
                    // Stone
                    if (inputData[MathHelper.Mod(y, 131)][MathHelper.Mod(x, 131)] == '#')
                    {
                        continue;
                    }

                    willVisit.Add((x + 1, y));
                    willVisit.Add((x - 1, y));
                    willVisit.Add((x, y + 1));
                    willVisit.Add((x, y - 1));
                }

                visiting = willVisit;

                if ((steps - startPoint.x) % width == 0)
                {
                    var validVisitingCount = visiting.Count(v => inputData[MathHelper.Mod(v.y, 131)][MathHelper.Mod(v.x, 131)] != '#');
                    counts.Add((steps, validVisitingCount));
                }
            }

            var result = MathHelper.LagrangeInterpolation(counts, totalSteps);

            return (long)result;
        }

        private static (int x, int y) FindStartPoint(IList<string> inputData)
        {
            var startPoint = (x: 0, y: 0);

            // find Startpoint S
            for (int i = 0; i < inputData.Count; i++)
            {
                if (inputData[i].Contains('S'))
                {
                    startPoint = (inputData[i].IndexOf('S'), i);
                    break;
                }
            }

            return startPoint;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

}
