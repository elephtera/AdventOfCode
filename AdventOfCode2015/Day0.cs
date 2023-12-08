namespace AdventOfCode2015
{
    /**
     * 
     */
    public class Day0 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;            
            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
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
