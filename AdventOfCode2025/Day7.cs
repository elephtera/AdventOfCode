namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day7 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            // find the start
            for (var i = 0; i < inputData[0].Length; i++)
            {
                if (inputData[0][i] == 'S')
                {
                    // Start the recursion!
                    return BuildTree(1, i, inputData);
                }
            }

            var result = 0;
            return result;
        }

        private long BuildTree(int row, int index, IList<char[]> inputData)
        {
            if (row == inputData.Count)
            {
                // finished
                return 0;
            }

            switch (inputData[row][index])
            {
                case '^':
                    // split
                    var splitCount = 1L;
                    if (index - 1 >= 0)
                    {
                        splitCount += BuildTree(row, index - 1, inputData);
                    }
                    if (index + 1 < inputData[0].Length)
                    {
                        splitCount += BuildTree(row, index + 1, inputData);
                    }
                    return splitCount;
                case '.':
                    inputData[row][index] = '|';
                    return BuildTree(row + 1, index, inputData);
                case '|':
                    // Already visited
                    return 0;
            }

            throw new Exception("Should not be reached");

        }

        private readonly Dictionary<(int row, int index), long> Memoization = [];
        private long BuildTimelines(int row, int index, IList<char[]> inputData)
        {
            if (Memoization.ContainsKey((row, index)))
            {
                return Memoization[(row, index)];
            }

            if (row == inputData.Count)
            {
                // finished
                return 1;
            }

            switch (inputData[row][index])
            {
                case '^':
                    // split
                    var timelines = 0L;
                    if (index - 1 >= 0)
                    {
                        timelines += BuildTimelines(row, index - 1, inputData);
                    }
                    if (index + 1 < inputData[0].Length)
                    {
                        timelines += BuildTimelines(row, index + 1, inputData);
                    }

                    Memoization[(row, index)] = timelines;
                    return timelines;
                case '.':
                    return BuildTimelines(row + 1, index, inputData);

            }

            throw new Exception("Should not be reached");

        }

        public long Part2(string input)
        {
            Memoization.Clear();

            var inputData = ProcessInput(input);

            // find the start
            for (var i = 0; i < inputData[0].Length; i++)
            {
                if (inputData[0][i] == 'S')
                {
                    // Start the recursion!
                    return BuildTimelines(1, i, inputData);
                }
            }

            var result = 0;
            return result;
        }

        public static IList<char[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(l => l.ToArray()).ToList();

            return lines;
        }
    }

}
