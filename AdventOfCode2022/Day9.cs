namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day9 : IDay<int>
    {
        public int PartA(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            var head = new int[2] { 0, 0 };
            var tails = new int[2] { 0, 0 };
            var tailLocations = new List<string>();

            tailLocations.Add($"{tails[0]},{tails[1]}");

            foreach(var step in inputData)
            {
                for (int i = 0; i < int.Parse(step[1]); i++)
                {
                    switch (step[0])
                    {
                        case "R":
                            head[0]--;
                            break;
                        case "L":
                            head[0]++;
                            break;
                        case "U":
                            head[1]--;
                            break;
                        case "D":
                            head[1]++;
                            break;
                    }

                    tails = MoveTail(tails, head);
                    tailLocations.Add($"{tails[0]},{tails[1]}");
                }
            }

            var result = tailLocations.Distinct();           
            return result.Count();
        }

        public static int[] MoveTail(int[] tails, int[] head)
        {
            var newtails = new int[2] { tails[0], tails[1] };
            if (Math.Abs(tails[0] - head[0]) > 1 && Math.Abs(tails[1] - head[1]) > 1)
            {
                newtails[0] += (tails[0] - head[0] > 0)? -1 : 1;
                newtails[1] += (tails[1] - head[1] > 0)? -1 : 1;
            }
            else if (tails[0] - head[0] > 1)
            {
                newtails[0]--;
                newtails[1] = head[1];
            }
            else if (tails[0] - head[0] < -1)
            {
                newtails[0]++;
                newtails[1] = head[1];
            }
            else if (tails[1] - head[1] > 1)
            {
                newtails[1]--;
                newtails[0] = head[0];
            }
            else if (tails[1] - head[1] < -1)
            {
                newtails[1]++;
                newtails[0] = head[0];
            }

            return newtails;
        }

        public int PartB(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            var head = new int[2] { 0, 0 };
            var tails1 = new int[2] { 0, 0 };
            var tails2 = new int[2] { 0, 0 };
            var tails3 = new int[2] { 0, 0 };
            var tails4 = new int[2] { 0, 0 };
            var tails5 = new int[2] { 0, 0 };
            var tails6 = new int[2] { 0, 0 };
            var tails7 = new int[2] { 0, 0 };
            var tails8 = new int[2] { 0, 0 };
            var tails9 = new int[2] { 0, 0 };
            var tailLocations = new List<string>();

            tailLocations.Add($"{tails9[0]},{tails9[1]}");

            foreach (var step in inputData)
            {
                for (int i = 0; i < int.Parse(step[1]); i++)
                {
                    switch (step[0])
                    {
                        case "R":
                            head[0]--;
                            break;
                        case "L":
                            head[0]++;
                            break;
                        case "U":
                            head[1]--;
                            break;
                        case "D":
                            head[1]++;
                            break;
                    }

                    tails1 = MoveTail(tails1, head);
                    tails2 = MoveTail(tails2, tails1);
                    tails3 = MoveTail(tails3, tails2);
                    tails4 = MoveTail(tails4, tails3);
                    tails5 = MoveTail(tails5, tails4);
                    tails6 = MoveTail(tails6, tails5);
                    tails7 = MoveTail(tails7, tails6);
                    tails8 = MoveTail(tails8, tails7);
                    tails9 = MoveTail(tails9, tails8);
                    tailLocations.Add($"{tails9[0]},{tails9[1]}");
                }

            }

            var result = tailLocations.Distinct();
            return result.Count();
        }

        public static IList<string[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            var result = lines.Select(line => line.Split(" ")).ToList();
            return result;
        }
    }

}
