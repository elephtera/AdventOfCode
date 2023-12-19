using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day18 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var currentX = 0;
            var currentY = 0;
            var rangeX = (min: 0, max: 0);
            var rangeY = (min: 0, max: 0);
            foreach (var edge in inputData)
            {
                // D 5 (#0dc571)
                var values = edge.Split(' ');
                var length = int.Parse(values[1]);
                switch (values[0])
                {
                    case "D":
                        currentY += length;
                        break;
                    case "U":
                        currentY -= length;
                        break;
                    case "L":
                        currentX -= length;
                        break;
                    case "R":
                        currentX += length;
                        break;
                }

                rangeX = (Math.Min(rangeX.min, currentX), Math.Max(rangeX.max, currentX));
                rangeY = (Math.Min(rangeY.min, currentY), Math.Max(rangeY.max, currentY));
            }

            var deltaX = rangeX.max - rangeX.min + 1;
            var deltaY = rangeY.max - rangeY.min + 1;

            // make empty map
            var map = new bool[deltaY][];
            for (var i = 0; i < deltaY; i++)
            {
                map[i] = new bool[deltaX];
            }

            // Draw map boundries
            currentX = 0 - rangeX.min;
            currentY = 0 - rangeY.min;
            foreach (var edge in inputData)
            {
                var values = edge.Split(' ');
                var length = int.Parse(values[1]);
                switch (values[0])
                {
                    case "D":
                        for (var i = 0; i < length; i++)
                        {
                            map[currentY + i][currentX] = true;
                        }
                        currentY += length;
                        break;
                    case "U":
                        for (var i = 0; i < length; i++)
                        {
                            map[currentY - i][currentX] = true;
                        }
                        currentY -= length;
                        break;
                    case "L":
                        for (var i = 0; i < length; i++)
                        {
                            map[currentY][currentX - i] = true;
                        }
                        currentX -= length;
                        break;
                    case "R":
                        for (var i = 0; i < length; i++)
                        {
                            map[currentY][currentX + i] = true;
                        }
                        currentX += length;
                        break;
                }
            }

            // flood fill the array
            // find first point in circle
            var inside = false;
            for (int i = 0; i < map[1].Length; i++)
            {
                if (map[1][i] == true)
                {
                    inside = true;
                }

                if (map[1][i] == false && inside)
                {
                    map = FloodFill(map, 1, i);
                    break;
                }
            }

            // count!
            var count = 0;
            for (int y = 0; y < map.Length; y++)
            {
                count += map[y].Count(b => b);
            }

            var result = count;
            return result;
        }

        private bool[][] FloodFill(bool[][] map, int startY, int startX)
        {
            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((startX,startY));

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                if (map[y][x])
                {
                    continue;
                }

                map[y][x] = true;
                if (y > 0) queue.Enqueue((x, y - 1));
                if (y < map.Length) queue.Enqueue((x, y + 1));
                if (x > 0) queue.Enqueue((x - 1, y));
                if (x < map[0].Length) queue.Enqueue((x + 1, y));
            }

            return map;

        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var currentX = 0L;
            var currentY = 0L;

            var points = new List<(long y, long x)>(){(0,0)};
            var perimeter = 0L;

            foreach (var edge in inputData)
            {
                //R 6 (#70c710)
                var value = edge.Split(' ')[2][2..^1];
                var distance = Convert.ToInt32(value[..^1], 16);
                var direction = value[^1..];
                switch (direction)
                {
                    case "0":
                        currentX += distance;
                        break;
                    case "1":
                        currentY += distance;
                        break;
                    case "2":
                        currentX -= distance;
                        break;
                    case "3":
                        currentY -= distance;
                        break;
                }

                points.Add((currentY, currentX));
                perimeter += distance;
            }

            // shoelace
            var area = 0L;

            for (var i = 0; i < points.Count; i++)
            {
                var nextX = points[MathHelper.Mod(i + 1, points.Count)].x;
                var prevX = points[MathHelper.Mod(i - 1,points.Count)].x;
                area += points[i].y * (nextX - prevX);
            }

            area = Math.Abs(area) / 2;

            // adjust for the perimeter being the outer edge of the area
            area += perimeter / 2 + 1;

            return area;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

}
