using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day16 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);


            var count = CalculateEngergizing(inputData, (0,0,Direction.Right));

            var result = count;            
            return result;
        }

        private static int CalculateEngergizing(IList<string> inputData, (int x, int y, Direction direction) startpoint)
        {
            var energized = new bool[inputData.Count, inputData[0].Length];

            var queue = new Queue<(int x, int y, Direction direction)>();
            var visited = new HashSet<(int x, int y, Direction direction)>();
            queue.Enqueue(startpoint);

            while (queue.Count > 0)
            {
                var step = queue.Dequeue();

                if (step.x >= inputData[0].Length || step.x < 0 ||
                    step.y >= inputData.Count || step.y < 0)
                {
                    continue;
                }

                if (visited.Contains(step))
                {
                    continue;
                }

                visited.Add(step);

                energized[step.x, step.y] = true;

                var action = inputData[step.y][step.x];

                switch (action)
                {
                    case '.':
                        switch (step.direction)
                        {
                            case Direction.Up:
                                queue.Enqueue((step.x, step.y - 1, Direction.Up));
                                break;
                            case Direction.Down:
                                queue.Enqueue((step.x, step.y + 1, Direction.Down));
                                break;
                            case Direction.Left:
                                queue.Enqueue((step.x - 1, step.y, Direction.Left));
                                break;
                            case Direction.Right:
                                queue.Enqueue((step.x + 1, step.y, Direction.Right));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case '/':
                        switch (step.direction)
                        {
                            case Direction.Up:
                                queue.Enqueue((step.x + 1, step.y, Direction.Right));
                                break;
                            case Direction.Down:
                                queue.Enqueue((step.x - 1, step.y, Direction.Left));
                                break;
                            case Direction.Left:
                                queue.Enqueue((step.x, step.y + 1, Direction.Down));
                                break;
                            case Direction.Right:
                                queue.Enqueue((step.x, step.y - 1, Direction.Up));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case '\\':
                        switch (step.direction)
                        {
                            case Direction.Up:
                                queue.Enqueue((step.x - 1, step.y, Direction.Left));
                                break;
                            case Direction.Down:
                                queue.Enqueue((step.x + 1, step.y, Direction.Right));
                                break;
                            case Direction.Left:
                                queue.Enqueue((step.x, step.y - 1, Direction.Up));
                                break;
                            case Direction.Right:
                                queue.Enqueue((step.x, step.y + 1, Direction.Down));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case '|':
                        switch (step.direction)
                        {
                            case Direction.Up:
                                queue.Enqueue((step.x, step.y - 1, Direction.Up));
                                break;
                            case Direction.Down:
                                queue.Enqueue((step.x, step.y + 1, Direction.Down));
                                break;
                            case Direction.Left:
                            case Direction.Right:
                                queue.Enqueue((step.x, step.y - 1, Direction.Up));
                                queue.Enqueue((step.x, step.y + 1, Direction.Down));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;

                    case '-':
                        switch (step.direction)
                        {
                            case Direction.Up:
                            case Direction.Down:

                                queue.Enqueue((step.x - 1, step.y, Direction.Left));
                                queue.Enqueue((step.x + 1, step.y, Direction.Right));
                                break;
                            case Direction.Left:
                                queue.Enqueue((step.x - 1, step.y, Direction.Left));
                                break;
                            case Direction.Right:
                                queue.Enqueue((step.x + 1, step.y, Direction.Right));

                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                }
            }

            var count = energized.Cast<bool>().Count(v => v);
            return count;
        }

        public int Part2(string input)
        {

            var inputData = ProcessInput(input);
            var maxCount = 0;
            for (int x = 0; x < inputData[0].Length; x++)
            {
                maxCount = Math.Max(maxCount, CalculateEngergizing(inputData, (x, 0, Direction.Down)));

                maxCount = Math.Max(maxCount, CalculateEngergizing(inputData, (x, inputData.Count - 1, Direction.Up)));


            }

            for (int y = 0; y < inputData.Count; y++)
            {
                maxCount = Math.Max(maxCount, CalculateEngergizing(inputData, (0, y, Direction.Right)));

                maxCount = Math.Max(maxCount, CalculateEngergizing(inputData, (inputData[0].Length - 1, y, Direction.Left)));

            }

            var result = maxCount;
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
