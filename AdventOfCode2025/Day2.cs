namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day2 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;

            foreach (var (start, end) in inputData)
            {
                for (long i = start; i <= end; i++)
                {
                    result += CheckSilly(i) ? i : 0;
                }
            }

            return result;
        }

        private bool CheckSilly(long i)
        {
            var inStr = i.ToString();

            var subStr = inStr[0..(inStr.Length / 2)];
            return inStr == $"{subStr}{subStr}";
        }

        private bool CheckSilly2(long i)
        {
            var inStr = i.ToString();
            for (var subStrLen = 1; subStrLen <= inStr.Length / 2; subStrLen++)
            {
                
                if (inStr.Length % subStrLen != 0)
                {
                    continue;
                }

                var duplicateCount = inStr.Length / subStrLen;
                var subStr = inStr[0..subStrLen];

                var builtStr = string.Concat(Enumerable.Repeat(subStr, duplicateCount));
                if (builtStr == inStr)
                {
                    return true;
                }
            }

            return false;

        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;

            foreach (var (start, end) in inputData)
            {
                for (long i = start; i <= end; i++)
                {
                    result += CheckSilly2(i) ? i : 0;
                }
            }

            return result;
        }

        public static IList<(long, long)> ProcessInput(string input)
        {
            var result = new List<(long, long)>();
            var ranges = input.Split([','],
                    StringSplitOptions.None);
            foreach (var range in ranges)
            {
                var parts = range.Split('-');
                var start = long.Parse(parts[0]);
                var end = long.Parse(parts[1]);
                result.Add((start, end));
            }

            return result;
        }
    }

}
