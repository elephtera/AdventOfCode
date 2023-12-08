namespace AdventOfCode2015
{
    /**
     * 
     */
    public class Day1 : IDay<int>
    {
        public int Part1(string input)
        {
            var open = input.Count(c => c == '(');
            var closed = input.Count(c => c == ')');

            var result = 0 + open - closed;
            return result;
        }

        public int Part2(string input)
        {
            var floor = 0;
            var count = 0;
            foreach (var step in input)
            {
                count++;
                if (step == '(')
                {
                    floor++;
                }
                else
                {
                    floor--;
                }

                if (floor == -1)
                {
                    return count;
                }
            }

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
