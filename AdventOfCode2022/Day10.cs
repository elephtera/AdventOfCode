namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day10 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            var duringCycleValue = ProcessCommands(inputData);
            var result = 20 * duringCycleValue[20 - 1];
            result += 60 * duringCycleValue[60 - 1];
            result += 100 * duringCycleValue[100 - 1];
            result += 140 * duringCycleValue[140 - 1];
            result += 180 * duringCycleValue[180 - 1];
            result += 220 * duringCycleValue[220 - 1];
            return result;
        }

        public static List<int> ProcessCommands(IList<string> inputData)
        {
            var duringCycleValue = new List<int>();

            var registerX = 1;
            foreach (var item in inputData)
            {
                // During the cycle, add current value to our "during" list
                duringCycleValue.Add(registerX);

                if (item == "noop")
                {
                    // Noop does nothing, go to next command.
                    continue;
                }

                // Other commands, take 2 cycles. 
                duringCycleValue.Add(registerX);

                // After finishing, the value is added.
                var addX = int.Parse(item.Split(" ")[1]);
                registerX += addX;
            }
            duringCycleValue.Add(registerX);

            return duringCycleValue;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var duringCycleValue = ProcessCommands(inputData);
            var screen = new List<bool>();
            for(int i = 0; i < 240; i++)
            {
                screen.Add(duringCycleValue[i] >= (i % 40) - 1 && duringCycleValue[i] <= (i % 40) + 1);
            }

            var result = string.Concat(screen.Select(s => s ? '#' : '.'));

            return result.Length;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
