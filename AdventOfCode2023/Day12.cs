using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day12 : IDay<long>
    {
        public long Part1(string input)
        {
            var solutionCount = 0L;
            var field = ProcessInput(input);
            var cache  = new Dictionary<(string row, string damagedSpringsHash), long>();
            foreach (var row in field)
            {
                var splittedRow = row.Split(' ');
                var damagedSprings = splittedRow[1].Split(',').Select(int.Parse).ToList();
                var solutions = DetermineOnlyValidPermutations(splittedRow[0], damagedSprings, cache);
                solutionCount += solutions;
            }

            return solutionCount;
        }

        private long DetermineOnlyValidPermutations(string row, List<int> damagedSprings, Dictionary<(string row, string damagedSpringsHash), long> cache)
        {
            var damagedSpringsHash = string.Join(",", damagedSprings);
            if (cache.ContainsKey((row, damagedSpringsHash)))
            {
                return cache.GetValueOrDefault((row, damagedSpringsHash));
            }

            if (damagedSprings.Count == 0)
            {
                // no damaged springs left, so return it as valid permutation only if the row contains no damaged springs. 
                return row.All(c => c != '#') ? 1 : 0;
            }

            if (row.Length == 0)
            {
                return 0;
            }

            var minSprings = damagedSprings.Sum() + damagedSprings.Count - 1;
            var permutationSpace = row.Length - minSprings;
            if (permutationSpace < 0)
            {
                return 0;
            }

            var validPermutationsCount = 0L;


            if (row[0] == '.' || row[0] == '?')
            {
                validPermutationsCount += DetermineOnlyValidPermutations(row[1..], damagedSprings, cache);
            }

            if (row[0] == '#' || row[0] == '?')
            {
                for (int i = 0; i < damagedSprings[0]; i++)
                {
                    if (row[i] == '.')
                    {
                        // no valid permutations available
                        return validPermutationsCount;
                    }
                }

                if (row.Length == damagedSprings[0] && damagedSprings.Count == 1)
                {
                    validPermutationsCount++;
                }
                else if (row.Length > damagedSprings[0] && row[damagedSprings[0]] != '#')
                {
                    validPermutationsCount += DetermineOnlyValidPermutations(row[(damagedSprings[0]+1)..],
                        damagedSprings.GetRange(1, damagedSprings.Count - 1), cache);
                }
            }

            cache.Add((row, damagedSpringsHash), validPermutationsCount);
            return validPermutationsCount;
        }

        public long Part2(string input)
        {
            var solutionCount = 0L;
            var field = ProcessInput(input);
            var cache = new Dictionary<(string row, string damagedSpringsHash), long>();

            foreach (var row in field)
            {
                var splittedRow = row.Split(' ');

                var targetRow = "" + splittedRow[0] + "?" + splittedRow[0] + "?" + splittedRow[0] + "?" + splittedRow[0] + "?" + splittedRow[0];
                var broken = "" + splittedRow[1] + "," + splittedRow[1] + "," + splittedRow[1] + "," + splittedRow[1] + "," + splittedRow[1];

                var brokenList = broken.Split(',').Select(int.Parse).ToList();
                var solutions = DetermineOnlyValidPermutations(targetRow, brokenList, cache);
                solutionCount += solutions;
            }

            return solutionCount;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

}
