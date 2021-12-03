namespace AdventOfCode2021.Assignments.Day3
{
    public static class InputHandler
    {
        public static IList<string> GetInputAsList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = lines.ToList();
            return result;
        }

    }

}