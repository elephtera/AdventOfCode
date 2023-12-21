using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day21 : IDay<long>
    {
        public long Part1(string input, int steps)
        {
            var inputData = ProcessInput(input);

            var startPoint = (x: 0,y: 0);

            // find Startpoint S
            for (int i = 0; i < inputData.Count; i++)
            {
                if (inputData[i].Contains('S'))
                {
                    startPoint = (inputData[i].IndexOf('S'), i);
                    break;
                }
            }

            // initialize a map
            var map = new char[inputData.Count][];
            var finalMap = new char[inputData.Count][];
            for (var i = 0; i < inputData.Count; i++)
            {
                map[i] = new char[inputData[0].Length];
                finalMap[i] = new char[inputData[0].Length];
            }


            var queue = new Queue<(int x, int y, int stepsLeft)>();
            queue.Enqueue((startPoint.x, startPoint.y, steps));
            var currentStep = steps;
            while (queue.Count > 0)
            {
                var walk = queue.Dequeue();

                if (currentStep != walk.stepsLeft)
                {
                    // reset map
                    for (var i = 0; i < inputData.Count; i++)
                    {
                        map[i] = new char[inputData[0].Length];
                    }
                    currentStep = walk.stepsLeft;
                }

                // Ongeldige x/y
                if (walk.x < 0 || walk.y < 0 || walk.x >= inputData[0].Length || walk.y >= inputData.Count)
                {
                    continue;
                }

                // Al geweest
                if (map[walk.y][walk.x] == 'X')
                {
                    continue;
                }

                // Steen
                if (inputData[walk.y][walk.x] == '#')
                {
                    map[walk.y][walk.x] = '#';
                    continue;
                }

                // Alle stappen al gezet
                if (walk.stepsLeft == 0)
                {
                    finalMap[walk.y][walk.x] = 'X';
                    continue;
                }

                map[walk.y][walk.x] = 'X';

                queue.Enqueue((walk.x + 1, walk.y, walk.stepsLeft- 1));
                queue.Enqueue((walk.x - 1, walk.y, walk.stepsLeft - 1));
                queue.Enqueue((walk.x, walk.y + 1, walk.stepsLeft - 1));
                queue.Enqueue((walk.x, walk.y - 1, walk.stepsLeft - 1));
            }

            var walkable = finalMap.Select(m => m.Count(c => c == 'X')).Sum();

            

            var result = walkable;
            return result;
        }

        public long Part1(string input)
        {
            return Part1(input, 64);
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);


            var result = 0;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
