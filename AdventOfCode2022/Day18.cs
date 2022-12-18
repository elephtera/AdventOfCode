namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day18 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            var cube = new bool[25, 25, 25];
            foreach (var block in inputData)
            {
                cube[block[0], block[1], block[2]] = true;
            }

            // open sides
            int uncovered = FindUncovered(inputData, cube, false);

            return uncovered;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            var cube = new bool[25, 25, 25];
            foreach (var block in inputData)
            {
                cube[block[0], block[1], block[2]] = true;
            }

            // open sides
            int uncovered = FindUncovered(inputData, cube, false);

            // floodfill to get "inner" count
            var cubeFilled = FloodFill(cube, new int[3] { 0, 0, 0 });

            int uncoveredFlooded = FindUncovered(inputData, cubeFilled, true);

            return uncovered - uncoveredFlooded;
        }

        private bool[,,] FloodFill(bool[,,] cube, int[] startCoord)
        {
            List<int[]> toFlood = new List<int[]>();
            toFlood.Add(startCoord);

            while (toFlood.Count > 0)
            {
                var coord = toFlood[0];
                toFlood.RemoveAt(0);
                
                var x = coord[0];
                var y = coord[1];
                var z = coord[2];

                cube[x, y, z] = true;

                if (x > 0 && !cube[x - 1, y, z])
                {
                    var toCheck = new int[3] { x - 1, y, z };
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }

                if (x < 24 && !cube[x + 1, y, z])
                {
                    var toCheck = new int[3] { x + 1, y, z };
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }

                if (y > 0 && !cube[x, y - 1, z])
                {
                    var toCheck = new int[3] { x, y - 1, z };
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }
                if (y < 24 && !cube[x, y + 1, z])
                {
                    var toCheck = new int[3] { x, y + 1, z };
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }

                if (z > 0 && !cube[x, y, z - 1])
                {
                    var toCheck = new int[3] { x, y, z -1 };
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }
                if (z < 24 && !cube[x, y, z + 1])
                {
                    var toCheck = new int[3] { x, y, z + 1};
                    if (!toFlood.Any(c => c.SequenceEqual(toCheck))) toFlood.Add(toCheck);
                }
            }
            
            return cube;
        }

        private static int FindUncovered(IList<int[]> inputData, bool[,,] cube, bool flooded)
        {
            var uncovered = 0;
            foreach (var block in inputData)
            {
                var x = block[0];
                var y = block[1];
                var z = block[2];

                if (!flooded && x == 0 || x > 0 && !cube[x - 1, y, z]) uncovered++;
                if (!cube[x + 1, y, z]) uncovered++;
                if (!flooded && y == 0 || y > 0 && !cube[x, y - 1, z]) uncovered++;
                if (!cube[x, y + 1, z]) uncovered++;
                if (!flooded && z == 0 || z > 0 && !cube[x, y, z - 1]) uncovered++;
                if (!cube[x, y, z + 1]) uncovered++;
            }

            return uncovered;
        }

        public static IList<int[]> ProcessInput(string input)
        {
            var blocks = new List<int[]>();
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            foreach (var line in lines)
            {
                blocks.Add(line.Split(',').Select(item => int.Parse(item)).ToArray());
            }

            return blocks;
        }
    }

}
