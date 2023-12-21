using System.Security.Cryptography.X509Certificates;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day17 : IDay<int>
    {
        public int Part1(string input)
        {
            var map = InputParsing.StringToIntArrays(input);

            var cache = new Dictionary<(int x, int y, string direction), int>();
            int heatloss = CalculateShortestHeatRoute(map, (0, 0, ""), 0 - map[0][0], cache);

            var result = heatloss;
            return result;
        }

        private int CalculateShortestHeatRoute(int[][] map, (int x, int y, string previousDirections) step, int heatLoss, Dictionary<(int x, int y, string direction), int> cache)
        {
            if (step.x < 0 || step.y < 0 || step.x >= map[0].Length || step.y >= map.Length)
            {
                return int.MaxValue;
            }

            var currentHeatLoss = heatLoss + map[step.y][step.x];

            var direction = "";
            if (step.previousDirections.Length <= 1)
            {
                direction = step.previousDirections;
            }
            else if (step.previousDirections.Length == 2)
            {
                if (step.previousDirections[0] == step.previousDirections[1])
                {
                    direction = step.previousDirections;
                }
                else
                {
                    direction = "" + step.previousDirections[0];
                }
            }
            else if (step.previousDirections.Length == 3)
            {
                if (step.previousDirections[1] != step.previousDirections[2])
                {
                    direction = "" + step.previousDirections[2];

                }
                else if (step.previousDirections[0] != step.previousDirections[1])
                {
                    direction = step.previousDirections[1..];
                }
                else
                {
                    direction = step.previousDirections;
                }
            }

            var cacheStep = (step.x, step.y, direction);
            if (cache.TryGetValue(cacheStep, out var route))
            {
                if (route <= currentHeatLoss)
                {
                    return int.MaxValue;
                }
                cache[cacheStep] = currentHeatLoss;
            }
            else
            {
                cache.Add(cacheStep, currentHeatLoss);
            }

            if (step.x == map[0].Length - 1 && step.y == map.Length - 1)
            {
                return currentHeatLoss;
            }


            bool skip = step.previousDirections.Length == 3 && step.previousDirections.All(d => d == step.previousDirections[0]);

            var newX = step.x;
            var newY = step.y;

            var newDirection = step.previousDirections;
            if (step.previousDirections.Length > 2)
            {
                newDirection = step.previousDirections[1..];
            }

            var extraHeatReduction = int.MaxValue;

            if (!skip || step.previousDirections[0] != '>') extraHeatReduction = Math.Min(extraHeatReduction, CalculateShortestHeatRoute(map, (newX + 1, newY, newDirection + ">"), currentHeatLoss, cache));
            if (!skip || step.previousDirections[0] != '<') extraHeatReduction = Math.Min(extraHeatReduction, CalculateShortestHeatRoute(map, (newX - 1, newY, newDirection + "<"), currentHeatLoss, cache));
            if (!skip || step.previousDirections[0] != 'v') extraHeatReduction = Math.Min(extraHeatReduction, CalculateShortestHeatRoute(map, (newX, newY + 1, newDirection + "v"), currentHeatLoss, cache));
            if (!skip || step.previousDirections[0] != '^') extraHeatReduction = Math.Min(extraHeatReduction, CalculateShortestHeatRoute(map, (newX, newY - 1, newDirection + "^"), currentHeatLoss, cache));

            var heatReduction = extraHeatReduction;

            return heatReduction;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
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
