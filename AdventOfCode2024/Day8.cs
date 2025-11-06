using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day8 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var xMax = lines[0].Length;
            var yMax = lines.Length;

            var antinode = new List<(int x, int y)>();

            foreach (var kvp in inputData)
            {
                if (kvp.Value.Count < 2)
                {
                    continue;
                }

                char c = kvp.Key;
                List<(int x, int y)> positions = kvp.Value;

                foreach (var pos in positions)
                {
                    foreach (var pos2 in positions)
                    {
                        if (pos != pos2)
                        {
                            var diffX = pos.x - pos2.x;
                            var diffY = pos.y - pos2.y;


                            var antinode1 = (x: pos.x + diffX, y: pos.y + diffY);
                            var antinode2 = (x: pos2.x - diffX, y: pos2.y - diffY);
                            if (antinode1.x >= 0 && antinode1.x < xMax && antinode1.y >= 0 && antinode1.y < yMax)
                            {
                                antinode.Add(antinode1);
                            }
                            if (antinode2.x >= 0 && antinode2.x < xMax && antinode2.y >= 0 && antinode2.y < yMax)
                            {
                                antinode.Add(antinode2);

                            }

                        }
                    }
                }
            }


            var result = antinode.Distinct().Count();

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);

            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var xMax = lines[0].Length;
            var yMax = lines.Length;

            var antinode = new List<(int x, int y)>();

            foreach (var kvp in inputData)
            {
                if (kvp.Value.Count < 2)
                {
                    continue;
                }

                char c = kvp.Key;
                List<(int x, int y)> positions = kvp.Value;

                foreach (var pos in positions)
                {
                    foreach (var pos2 in positions)
                    {
                        if (pos != pos2)
                        {
                            antinode.Add(pos);
                            antinode.Add(pos2);

                            var diffX = pos.x - pos2.x;
                            var diffY = pos.y - pos2.y;

                            var x1 = pos.x + diffX;
                            var y1 = pos.y + diffY;
                            while(x1 >=0 && x1 < xMax && y1 >=0 && y1 < yMax)
                            {
                                antinode.Add((x1, y1));
                                x1 += diffX;
                                y1 += diffY;
                            }

                            var x2 = pos2.x - diffX;
                            var y2 = pos2.y - diffY;
                            while(x2 >= 0 && x2 < xMax && y2 >= 0 && y2 < yMax)
                            {
                                antinode.Add((x2, y2));
                                x2 -= diffX;
                                y2 -= diffY;
                            }

                        }
                    }
                }
            }


            var result = antinode.Distinct().Count();

            return result;
        }

        public static IDictionary<char, List<(int x, int y)>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new Dictionary<char, List<(int x, int y)>>();
            for (int y = 0; y < lines.Length; y++)
            {
                string? line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    if (c != '.')
                    {
                        result.TryAdd(c, new List<(int x, int y)>());
                        result[c].Add((x, y));
                    }
                }
            }

            return result;
        }
    }
}
