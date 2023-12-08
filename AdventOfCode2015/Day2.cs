namespace AdventOfCode2015
{
    /**
     * 
     */
    public class Day2 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var totalpaper = 0;
            foreach (var present in inputData)
            {
                var dimensions = present.Split('x').Select(int.Parse).ToList();
                dimensions.Sort();
                var paper = 2 * dimensions[0] * dimensions[1] + 2 * dimensions[1] * dimensions[2] +
                            2 * dimensions[0] * dimensions[2];
                paper += dimensions[0] * dimensions[1];
                totalpaper += paper;
            }

            return totalpaper;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var totalRibbon = 0;
            foreach (var present in inputData)
            {
                var dimensions = present.Split('x').Select(int.Parse).ToList();
                dimensions.Sort();

                var ribbon = dimensions[0] + dimensions[0] + dimensions[1] + dimensions[1];
                ribbon += dimensions[0] * dimensions[1] * dimensions[2];
                
                totalRibbon += ribbon;
            }

            return totalRibbon;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
