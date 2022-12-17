namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day3 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            foreach(var line in inputData)
            {
                var c = FindDuplicateItem(line);
                result += ConvertToPrio(c);
            }
         
            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;

            // sets of 3
            for (int i = 0; i <= inputData.Count - 3; i += 3)
            {

                var c = FindDuplicateItem(inputData[i], inputData[i + 1], inputData[i + 2]);
                result += ConvertToPrio(c);
            }

            return result;
        }

        public static char FindDuplicateItem(string v1, string v2, string v3)
        {
            var intersection = v1.Intersect(v2).Intersect(v3);
            return intersection.Single();
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }

        public static int ConvertToPrio(char asciiVal)
        {
            if (asciiVal < 97)
            {
                return asciiVal - 38; // Offset to 27
            }

            return asciiVal - 96; // Offset to 1
        }

        public static char FindDuplicateItem(string input)
        {
            string firsthalf = input.Substring(0, input.Length / 2);
            string secondhalf = input.Substring(input.Length / 2);


            var intersection = firsthalf.Intersect(secondhalf);
            return intersection.Single();
        }
    }

}
