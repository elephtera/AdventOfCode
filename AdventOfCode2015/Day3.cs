namespace AdventOfCode2015
{
    /**
     * 
     */
    public class Day3 : IDay<int>
    {
        public int Part1(string input)
        {
            var visitedHouses = new HashSet<(int x, int y)>();
            var currentPosition = (x: 0, y: 0);
            visitedHouses.Add(currentPosition);

            foreach (char c in input)
            {
                switch(c)
                {
                    case '^':
                        currentPosition.y++;
                        break;
                    case 'v':
                        currentPosition.y--;
                        break;
                    case '<':
                        currentPosition.x--;
                        break;
                    case '>':
                        currentPosition.x++;
                        break;
                }
                visitedHouses.Add(currentPosition);
            }



            //var inputData = ProcessInput(input);
            var result = visitedHouses.Count;
            return result;
        }

        public int Part2(string input)
        {
            var visitedHouses = new HashSet<(int x, int y)>();
            var currentPositionSanta = (x: 0, y: 0);
            var currentPositionRoboSanta = (x: 0, y: 0);
            visitedHouses.Add(currentPositionSanta);

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                var currentPosition = (i % 2 == 0) ? currentPositionSanta : currentPositionRoboSanta;
                switch (c)
                {
                    case '^':
                        currentPosition.y++;
                        break;
                    case 'v':
                        currentPosition.y--;
                        break;
                    case '<':
                        currentPosition.x--;
                        break;
                    case '>':
                        currentPosition.x++;
                        break;
                }
                if (i % 2 == 0)
                {
                    currentPositionSanta = currentPosition;
                }
                else
                {
                    currentPositionRoboSanta = currentPosition;
                }
                visitedHouses.Add(currentPosition);
            }



            //var inputData = ProcessInput(input);
            var result = visitedHouses.Count;
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
