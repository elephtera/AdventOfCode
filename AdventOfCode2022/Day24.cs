using AdventOfCode2022.Assignments;

namespace AdventOfCode2022
{
    /**
     * 
     */
    public class Day24 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var left = inputData.Select(Left).ToList();
            var right = inputData.Select(Right).ToList();
            var up = Up(inputData);
            var down = Down(inputData);

            var steps = GetShortestPathForPart1(((-1, 0), 0), left, right, up, down);
            var result = steps;
            return result;
        }
        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var left = inputData.Select(Left).ToList();
            var right = inputData.Select(Right).ToList();
            var up = Up(inputData);
            var down = Down(inputData);

            var result = GetShortestPathForPart2(((-1, 0), 0, false, false), left, right, up, down);
            return result;
        }

        private static int GetShortestPathForPart1(((int Row, int Col) Player, int Time) initialState, List<string> left, List<string> right, List<string> up,
            List<string> down)
        {
            var queue = new PriorityQueue<((int Row, int Col) Player, int Time), int>();
            queue.Enqueue(initialState, 0);

            var seen = new HashSet<((int Row, int Col) Player, int Time)>();

            var maxRow = left.Count - 1;
            var maxCol = up.Count - 1;
            var destination = (maxRow + 1, maxCol);

            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                var (player, time) = state;
                var (row, col) = player;

                if (seen.Contains(state))
                {
                    continue;
                }

                seen.Add(state);

                if (player == destination)
                {
                    return state.Time;
                }

                var neighbors = new[]
                {
                (Row: row + 1, Col: col),
                (Row: row, Col: col + 1),
                (Row: row - 1, Col: col),
                (Row: row, Col: col - 1),
                (Row: row, Col: col),
            };

                foreach (var neighbor in neighbors)
                {
                    if (!IsBlizzardFreeSpot(neighbor.Col, neighbor.Row, time+1, left, right, up, down))
                    {
                        continue;
                    }

                    var newState = (Player: neighbor, Time: time + 1);
                    queue.Enqueue(newState, newState.Time);
                }
            }

            return 0;
        }

        private static int GetShortestPathForPart2(
        ((int Row, int Col) Player, int Time, bool HasReachedEnd, bool HasReachedStart) initialState, List<string> left, List<string> right, List<string> up,
        List<string> down)
        {
            var queue = new PriorityQueue<
                ((int Row, int Col) Player, int Time, bool HasReachedEnd, bool HasReachedStart), int>();
            queue.Enqueue(initialState, 0);

            var seen = new HashSet<((int Row, int Col) Player, int Time, bool HasReachedEnd, bool HasReachedStart)>();

            var maxRow = left.Count - 1;
            var maxCol = up.Count - 1;
            var destination = (maxRow + 1, maxCol);

            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                var (player, time, hasReachedEnd, hasReachedStart) = state;
                var (row, col) = player;

                if (seen.Contains(state))
                {
                    continue;
                }

                seen.Add(state);

                // this is the first time reaching the start, AFTER reaching the end
                if (player == (0, 1) && hasReachedEnd && !hasReachedStart)
                {
                    hasReachedStart = true;
                }

                if (player == destination)
                {
                    // this is the first time reaching the end
                    if (!hasReachedEnd)
                    {
                        hasReachedEnd = true;
                    }

                    // this is the first time reaching the end, AFTER reaching the start
                    if (hasReachedEnd && hasReachedStart)
                    {
                        return state.Time;
                    }
                }

                var neighbors = new[]
                {
                    (Row: row + 1, Col: col),
                    (Row: row, Col: col + 1),
                    (Row: row - 1, Col: col),
                    (Row: row, Col: col - 1),
                    (Row: row, Col: col),
                };

                foreach (var neighbor in neighbors)
                {
                    if (!IsBlizzardFreeSpot(neighbor.Col, neighbor.Row, time + 1, left, right, up, down))
                    {
                        continue;
                    }

                    var newState = (Player: neighbor, Time: time + 1, hasReachedEnd, hasReachedStart);
                    queue.Enqueue(newState, newState.Time);
                }
            }

            return 0;
        }


        public static bool IsBlizzardFreeSpot(int x, int y, int time, List<string> left, List<string> right, List<string> up, List<string> down)
        {
            // check all items
            bool valid = true;
            if (x < 0 || x >= up.Count || y < 0 || y >= right.Count)
            {

                return x == 0 && y == -1 || x == up.Count - 1 && y == right.Count; // start and end is always valid
            }

            var width = up.Count;
            var height = right.Count;

            valid &= left[y][Mod((x + time), width)] == '.';
            valid &= right[y][Mod((x - time), width)] == '.';
            valid &= up[x][Mod((y + time), height)] == '.';
            valid &= down[x][Mod((y - time), height)] == '.';

            return valid;
        }

        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        private List<string> Down(IList<string> input)
        {
            var downList = new List<string>();

            for (int i = 1; i < input[0].Length - 1; i++)
            {
                downList.Add(string.Concat(input.Select(line => line[i] == 'v'? 'v' : '.')));
            }

            return downList;
        }

        private List<string> Up(IList<string>input)
        {
            var upList = new List<string>();

            for (int i = 1; i < input[0].Length - 1 ; i++)
            {
                upList.Add(string.Concat(input.Select(line => line[i] == '^' ? '^' : '.')));
            }

            return upList;
        }

        private string Right(string arg)
        {
            // >
            var result = arg.Replace('^', '.');
            result = result.Replace('v', '.');
            result = result.Replace('<', '.');

            return result[1..^1]; // remove #;
        }

        private string Left(string arg)
        {
            // <
            var result = arg.Replace('^', '.');
            result = result.Replace('v', '.');
            result = result.Replace('>', '.');

            return result[1..^1]; // remove #;
        }
        
        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None).ToList();
            
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            return lines;
        }
    }

}
