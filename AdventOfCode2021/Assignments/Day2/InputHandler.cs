namespace AdventOfCode2021.Assignments.Day2
{
    public static class InputHandler
    {
        public static IList<Tuple<SubmarineAction, int>> GetInputAsList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = lines.Select(line => ConvertToTuple(line)).ToList();
            return result;
        }

        public static Tuple<SubmarineAction, int> ConvertToTuple(string inputLine)
        {
            var bits = inputLine.Split(new string[] { " " }, StringSplitOptions.None);

            var action = SubmarineAction.nothing;
            if (!Enum.TryParse<SubmarineAction>(bits[0], out action))
            {
                action = SubmarineAction.nothing;
            }

            var amount = int.Parse(bits[1]);

            return new Tuple<SubmarineAction, int>(action, amount);
        }
    }

}

namespace AdventOfCode2021
{
    public enum SubmarineAction
    {
        forward,
        up,
        down,
        nothing,
    }
}

