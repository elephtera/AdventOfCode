using System.Runtime.CompilerServices;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day4 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;

            var xMax = inputData[0].Length;
            var yMax = inputData.Length;
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if (inputData[y][x] == '.')
                    {
                        continue;
                    }

                    var cnt = 0;



                    int boxXMin = Math.Max(0, x - 1);
                    int boxXMax = Math.Min(xMax - 1, x + 1);

                    int boxYMin = Math.Max(0, y - 1);
                    int boxYMax = Math.Min(yMax - 1, y + 1);

                    for (int boxX = boxXMin; boxX <= boxXMax; boxX++)
                    {
                        for (int boxY = boxYMin; boxY <= boxYMax; boxY++)
                        {
                            if (boxX == x && boxY == y)
                            {
                                continue;
                            }

                            if (inputData[boxY][boxX] == '@')
                            {
                                cnt++;
                            }
                        }
                    }

                    if (cnt < 4)
                    {
                        result++;
                    }
                }

            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;

            var xMax = inputData[0].Length;
            var yMax = inputData.Length;
            var changes = true;
            while (changes)
            {
                changes = false;
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        if (inputData[y][x] == '.')
                        {
                            continue;
                        }

                        var cnt = 0;

                        int boxXMin = Math.Max(0, x - 1);
                        int boxXMax = Math.Min(xMax - 1, x + 1);

                        int boxYMin = Math.Max(0, y - 1);
                        int boxYMax = Math.Min(yMax - 1, y + 1);

                        for (int boxX = boxXMin; boxX <= boxXMax; boxX++)
                        {
                            for (int boxY = boxYMin; boxY <= boxYMax; boxY++)
                            {
                                if (boxX == x && boxY == y)
                                {
                                    continue;
                                }

                                if (inputData[boxY][boxX] == '@')
                                {
                                    cnt++;
                                }
                            }
                        }

                        if (cnt < 4)
                        {
                            inputData[y][x] = '.';
                            result++;
                            changes = true;
                        }
                    }

                }
            }
            return result;
        }

        public static char[][] ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(l => l.ToArray()).ToArray();

            return lines;
        }
    }

}
