namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day0 : IDay<int>
    {
        public int PartA(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            var result = 0;            
            return result;
        }

        public int PartB(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
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
