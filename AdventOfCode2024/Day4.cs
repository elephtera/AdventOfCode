using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day4 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var result = 0;
            // find all X'es
            // check the M/A/S in all directions
            // count

            for (int i = 0; i < inputData.Count; i++)
            {
                var line = inputData[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    // process character
                    if (character == 'X')
                    {
                        // XMAS, to the left
                        if (j + 3 < line.Length && line[j + 1] == 'M' && line[j + 2] == 'A' && line[j + 3] == 'S')
                        {
                            result++;
                        }

                        // XMAS to the right
                        if (j - 3 >= 0 && line[j - 1] == 'M' && line[j - 2] == 'A' && line[j - 3] == 'S')
                        {
                            result++;
                        }

                        // XMAS vertical down
                        if (i + 3 < inputData.Count &&
                            inputData[i + 1][j] == 'M' &&
                            inputData[i + 2][j] == 'A' &&
                            inputData[i + 3][j] == 'S')
                        {
                            result++;
                        }

                        // XMAS vertical up
                        if (i - 3 >= 0 &&
                            inputData[i - 1][j] == 'M' &&
                            inputData[i - 2][j] == 'A' &&
                            inputData[i - 3][j] == 'S')
                        {
                            result++;
                        }

                        // XMAS diagonal down-right
                        if (i + 3 < inputData.Count && j + 3 < line.Length &&
                            inputData[i + 1][j + 1] == 'M' &&
                            inputData[i + 2][j + 2] == 'A' &&
                            inputData[i + 3][j + 3] == 'S')
                        {
                            result++;
                        }

                        // XMAS diagonal down-left
                        if (i - 3 >= 0 && j - 3 >= 0 &&
                            inputData[i - 1][j - 1] == 'M' &&
                            inputData[i - 2][j - 2] == 'A' &&
                            inputData[i - 3][j - 3] == 'S')
                        {
                            result++;
                        }

                        // XMAS diagonal up-right
                        if (i - 3 >= 0 && j + 3 < line.Length &&
                            inputData[i - 1][j + 1] == 'M' &&
                            inputData[i - 2][j + 2] == 'A' &&
                            inputData[i - 3][j + 3] == 'S')
                        {
                            result++;
                        }

                        // XMAS diagonal up-left
                        if (i + 3 < inputData.Count && j - 3 >= 0 &&
                            inputData[i + 1][j - 1] == 'M' &&
                            inputData[i + 2][j - 2] == 'A' &&
                            inputData[i + 3][j - 3] == 'S')
                        {
                            result++;
                        }
                        // check M/A/S in all directions
                    }
                }
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);

            var result = 0;
            // find all X'es
            // check the M/A/S in all directions
            // count

            for (int i = 0; i < inputData.Count; i++)
            {
                var line = inputData[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    // process character
                    if (character == 'A')
                    {
                        // check for MAS in a cross shape
                        if (j - 1 >= 0 && j + 1 < line.Length &&
                            i - 1 >= 0 && i + 1 < inputData.Count
                            )
                        {
                            if ((inputData[i - 1][j - 1] == 'M' &&
                                inputData[i + 1][j + 1] == 'S' ||
                                inputData[i - 1][j - 1] == 'S' &&
                                inputData[i + 1][j + 1] == 'M') &&
                                (inputData[i - 1][j + 1] == 'M' &&
                                inputData[i + 1][j - 1] == 'S' ||
                                inputData[i - 1][j + 1] == 'S' &&
                                inputData[i + 1][j - 1] == 'M'))
                            {
                                result++;
                            }
                        }
                    }
                }
            }
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
