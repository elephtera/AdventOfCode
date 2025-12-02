using AdventOfCode2025.Helpers;
using System.ComponentModel;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day1 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var dialNumber = 50;
            var result = 0;

            foreach (var (clockwise, steps) in inputData)
            {
                dialNumber += clockwise ? steps : -steps;
                dialNumber %= 100;

                if (dialNumber == 0) {
                    result++;
                }
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var dialNumber = 50;
            var result = 0;

            foreach (var (clockwise, steps) in inputData)
            {
                var previousDialNumber = dialNumber;
                dialNumber += clockwise ? steps : -steps;
                
                var fullCircleCount = steps / 100;
                result += fullCircleCount;

                dialNumber = MathHelper.Mod(dialNumber, 100);

                if (previousDialNumber == 0)
                {
                    continue;
                }

                if (dialNumber < previousDialNumber && clockwise)
                {
                    result++;
                }

                if (dialNumber > previousDialNumber && !clockwise)
                {
                    result++;
                }

                // landing on 0 when going counterclockwise is an edge case not catched above
                if (dialNumber == 0 && !clockwise)
                {
                    result++;
                }
            }

            return result;
        }

        public static IList<(bool clockwise, int steps)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<(bool direction, int steps)>();
            foreach (var line in lines)
            {
                var clockwise = line[0] == 'R';
                var steps = int.Parse(line[1..]);
                result.Add((clockwise, steps));
            };

            return result;
        }
    }

}
