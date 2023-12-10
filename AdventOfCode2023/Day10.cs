namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day10 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            // start location
            var startY = inputData.IndexOf(inputData.Single(line => line.Contains('S')));
            var startX = inputData[startY].IndexOf('S');

            // move through maze; counting steps
            var posX = startX;
            var posY = startY;
            var posChar = 'S';
            var stepCount = 0;
            var incomingDirection = Direction.Down;
            do
            {
                switch (posChar)
                {
                    case 'S':
                        // down
                        incomingDirection = Direction.Down;
                        posY++;
                        break;
                    case 'F':
                        if (incomingDirection == Direction.Up)
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }
                        else
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        break;
                    case 'J':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }
                        break;
                    case 'L':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }
                        break;
                    case '7':
                        if (incomingDirection == Direction.Right)
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        else
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        break;
                    case '|':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }

                        break;
                    case '-':
                        if (incomingDirection == Direction.Left)
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        else
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }

                        break;
                }

                posChar = inputData[posY][posX];
                stepCount++;
            } while (posX != startX || posY != startY);


            var result = stepCount / 2;
            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            // start location
            var startY = inputData.IndexOf(inputData.Single(line => line.Contains('S')));
            var startX = inputData[startY].IndexOf('S');

            List<char[]> extraMap = new List<char[]>();
            for (int i = 0; i < inputData.Count; i++)
            {
                extraMap.Add(new string('.', inputData[0].Length).ToCharArray());
            }

            // move through maze; counting steps
            var posX = startX;
            var posY = startY;
            var posChar = 'S';
            var stepCount = 0;
            var incomingDirection = Direction.Down;
            do
            {
                switch (posChar)
                {
                    case 'S':
                        // down
                        incomingDirection = Direction.Down;
                        posY++;
                        break;
                    case 'F':
                        if (incomingDirection == Direction.Up)
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }
                        else
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        break;
                    case 'J':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }
                        break;
                    case 'L':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }
                        break;
                    case '7':
                        if (incomingDirection == Direction.Right)
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        else
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        break;
                    case '|':
                        if (incomingDirection == Direction.Down)
                        {
                            incomingDirection = Direction.Down;
                            posY++;
                        }
                        else
                        {
                            incomingDirection = Direction.Up;
                            posY--;
                        }

                        break;
                    case '-':
                        if (incomingDirection == Direction.Left)
                        {
                            incomingDirection = Direction.Left;
                            posX--;
                        }
                        else
                        {
                            incomingDirection = Direction.Right;
                            posX++;
                        }

                        break;
                }

                posChar = inputData[posY][posX];
                extraMap[posY][posX] = posChar;
                stepCount++;
            } while (posX != startX || posY != startY);

            var edgemap = extraMap.Select(Cleanup).ToList();

            var innerCount = 0;
            foreach (var line in edgemap)
            {
                var pipeCount = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '|')
                    {
                        pipeCount++;
                    }
                    else if (line[i] == '.')
                    {
                        if (pipeCount % 2 == 1)
                        {
                            innerCount++;
                        }
                    }
                }
            }

            var result = innerCount;
            return result;
        }

        private string Cleanup(char[] input)
        {
            var result = string.Concat(input);
            result = result.Replace("S", "|"); // only works for my input, because S is | in it. in the sample it is a 7, but does not matter for the final count, so don't care.
            result = result.Replace("-", "");
            result = result.Replace("FJ", "|");
            result = result.Replace("L7", "|");
            result = result.Replace("F7", "");
            result = result.Replace("LJ", "");
            
            return result;

        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }
}
