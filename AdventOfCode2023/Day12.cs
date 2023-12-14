namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day12 : IDay<int>
    {
        public int Part1(string input)
        {
            var solutionCount = 0;
            var field = ProcessInput(input);
            foreach (var row in field)
            {
                var splittedRow = row.Split(' ');
                var solutions = CalculateArrangements(splittedRow[0], splittedRow[1].Split(',').Select(int.Parse).ToList());
                solutionCount += solutions;
            }

            return solutionCount;
        }

        private int CalculateArrangements(string row, List<int> damagedSprings)
        {
            var solutionCount = 0;

            var rowLength = row.Length;
            var minSprings = damagedSprings.Sum() + damagedSprings.Count - 1;
            var diff = rowLength - minSprings;

            // determine permutations
            List<string> permutations = DeterminePermutations(rowLength, damagedSprings);

            // validate permutations
            var validPermutations = DetermineValidPermutations(row, permutations, rowLength);

            return validPermutations.Count;

        }

        private static List<string> DetermineValidPermutations(string row, List<string> permutations, int rowLength)
        {
            List<string> validPermutations = new List<string>();
            foreach (var permutation in permutations)
            {
                var valid = true;
                // compare with row;
                for (int i = 0; i < rowLength; i++)
                {
                    if (permutation[i] != row[i] && row[i] != '?')
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    validPermutations.Add(permutation);
                }
            }

            return validPermutations;
        }

        private List<string> DeterminePermutations(int rowLength, List<int> damagedSprings)
        {
            var result = new List<string>();
            var minSprings = damagedSprings.Sum() + damagedSprings.Count - 1;
            var permutationSpace = rowLength - minSprings;

            if (damagedSprings.Count == 0)
            {
                // last "gap", fill it with working stuff
                result.Add(new string('.', rowLength));
                return result;
            }

            for (int i = 0; i <= permutationSpace; i++)
            {
                var working = new string('.', i);
                var damaged = new string('#', damagedSprings[0]);
                var pre = working + damaged;

                var newRowLength = rowLength - i - damagedSprings[0] - 1;
                if (newRowLength < 0)
                {
                    result.Add(pre);
                }
                else
                {
                    var extra = DeterminePermutations(newRowLength,
                        damagedSprings.GetRange(1, damagedSprings.Count - 1));
                    result.AddRange(extra.Select(e => pre + '.' + e));
                }
            }

            return result;
        }

        public int Part2(string input)
        {
            var solutionCount = 0;
            var field = ProcessInput(input);
            foreach (var row in field)
            {
                var splittedRow = row.Split(' ');
                var targetRow = string.Concat(Enumerable.Repeat(splittedRow[0], 5));
                var brokenList = splittedRow[1].Split(',').Select(int.Parse);
                var brokenextendedList = Enumerable.Repeat(brokenList, 5).SelectMany(bl => bl).ToList();
                var solutions = CalculateArrangements(targetRow, brokenextendedList);
                solutionCount += solutions;
            }

            return solutionCount;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
