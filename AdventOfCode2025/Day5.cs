using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day5
    {
        public long Part1(string input, string input2)
        {
            var inputData = ProcessRanges(input);
            var ingedients = ProcessIngredients(input2);
            
            var fresh = 0;
            foreach(var indredient in ingedients)
            {
                foreach(var range in inputData)
                {
                    if(indredient >= range[0] && indredient <= range[1])
                    {
                        fresh++;
                        break;
                    }
                }
            }

            var result = 0L;
            return fresh;
        }

        public long Part2(string input, string input2)
        {
            var inputData = ProcessRanges(input);

            var cleanedRanges = new List<long[]>();

            // ranges toevoegen aan cleanedRanges, waarbij overlap eruit is gehaald.
            // Ranges worden gecombineerd als ze deels overlap hebben.
            foreach (var range1 in inputData)
            {
                var hasMerged = false;
                for (int i = 0; i < cleanedRanges.Count; i++)
                {
                    var range2 = cleanedRanges[i];
                    // Check for overlap
                    if (range1[0] <= range2[1] && range1[1] >= range2[0])
                    {
                        // Merge ranges
                        cleanedRanges[i] = new long[]
                        {
                            Math.Min(range1[0], range2[0]),
                            Math.Max(range1[1], range2[1])
                        };
                        hasMerged = true;
                        break;
                    }
                }
                if (!hasMerged)
                {
                    cleanedRanges.Add(range1);
                }

            }

            var result = 0L;


            // now cleanedRanges contains non-overlapping ranges. 
            // count the total amount of numbers covered by these ranges.
            foreach (var range in cleanedRanges)
            {
                var rangeSize = range[1] - range[0] + 1;
                result+= rangeSize;
            }


            return result;
        }

        public static IList<long[]> ProcessRanges(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine}, StringSplitOptions.None)
                                .Select(l => l.Split('-')
                                        .Select(i => long.Parse(i))
                                        .ToArray()).OrderBy(range => range[0]).ToList();


            return lines;
        }

        public static IList<long> ProcessIngredients(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(n => long.Parse(n)).ToList();

            return lines;
        }
    }

}
