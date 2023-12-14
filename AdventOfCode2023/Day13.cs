using System.Linq.Expressions;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day13 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            var result = inputData.Sum(pattern => pattern.GetSummary(false)); ;
            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            var result = inputData.Sum(pattern => pattern.GetSummary(true)); ;
            return result;
        }

        public static List<Pattern> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            List<Pattern> patterns = new List<Pattern>();
            List<string> patternStrings = new List<string>();
            foreach (var line in lines)
            {
                if (line.Equals(""))
                {
                    // next pattern
                    patterns.Add(new Pattern(patternStrings));
                    patternStrings = new List<string>();
                }
                else
                {
                    patternStrings.Add(line);
                }
            }
            patterns.Add(new Pattern(patternStrings));

            return patterns;
        }
    }

    public class Pattern
    {
        private readonly List<string> Input;

        public Pattern(List<string> patternStrings)
        {
            this.Input = patternStrings;
        }


        public int GetSummary(bool hasSmudge)
        {
            var horizontal = GetHorizontalMirror(hasSmudge);
            var vertical = GetVerticalMirror(hasSmudge);
            if (horizontal == -1)
            {
                return vertical;
            }

            if (vertical == -1)
            {
                return 100 * horizontal;
            }

            return (100 * horizontal) + vertical;
        }

        public int GetVerticalMirror(bool hasSmudge)
        {
            // transpose
            var transposedInput = Input
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => string.Concat(g))
                .ToList();

            var previous = string.Empty;
            var lineCount = 0;
            foreach (var line in transposedInput)
            {
                if ((hasSmudge || line == previous) && CheckMirror(lineCount, transposedInput, hasSmudge))
                {
                    return lineCount;
                }
                else
                {
                    previous = line;
                    lineCount++;
                }
            }

            return -1;
        }

        public int GetHorizontalMirror(bool hasSmudge)
        {
            var previous = string.Empty;
            var lineCount = 0;
            foreach (var line in Input)
            {
                if ((hasSmudge || line == previous ) && CheckMirror(lineCount, Input, hasSmudge))
                {
                    return lineCount;
                }
                else
                {
                    previous = line;
                    lineCount++;
                }
            }

            return -1;
        }

        public bool CheckMirror(int lineId, List<string> input, bool hasSmudge)
        {
            var oneSmudge = false;
            for (int i = 0; i < lineId; i++)
            {
                if (lineId + i >= input.Count)
                {
                    return !hasSmudge || oneSmudge;
                }

                if (input[lineId - i - 1] != input[lineId + i])
                {
                    if (!hasSmudge)
                    {
                        // no smudge OR smudge + not mirror border; AND lines not identical
                        return false;
                    }

                    if (oneSmudge)
                    {
                        // Already have a smudge
                        return false;
                    }

                    // count diff
                    var first = input[lineId - i - 1];
                    var second = input[lineId + i];
                    int result = first.Zip(second, (x, y) => x == y).Count(z => !z);

                    if (result > 1)
                    {
                        // only one smudge allowed
                        return false;
                    }

                    if (result == 1)
                    {
                        oneSmudge = true;
                    }
                }
            }

            return !hasSmudge || oneSmudge;
        }
    }
}
