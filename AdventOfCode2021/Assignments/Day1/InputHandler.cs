namespace AdventOfCode2021.Assignments
{
    public static class InputHandler
    {
        public static IList<int> GetInputAsList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = lines.Select(line => int.Parse(line)).ToList();
            return result;
        }

    }
}