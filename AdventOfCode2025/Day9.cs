using System.Linq;
using System.Numerics;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day9 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;
            foreach (var line in inputData)
            {
                foreach (var line2 in inputData)
                {
                    var maxSize = Math.Abs(line.X - line2.X + 1) * Math.Abs(line.Y - line2.Y + 1);
                    result = Math.Max(result, maxSize);
                }
            }
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            // all the points in inputData are connected, in order, and are a bounding box 
            // we need to find the largest box that can fit inside the bounding box, where the two diagonally opposing corners are in the inputData set


            // All vertices in the polygon, sorted by horizontal and vertical vertices
            IList<Line> verticalLines = new List<Line>();
            IList<Line> horizontalLines = new List<Line>();
            for(int i = 0; i < inputData.Count; i++)
            {
                var point = inputData[i];
                var point2 = inputData[(i + 1) % inputData.Count];

                if (point.X == point2.X)
                {
                    verticalLines.Add(new Line(point, point2));
                }
                else
                {
                    horizontalLines.Add(new Line(point, point2));
                }
            }

            // Calculate all the sizes of the boxes that can be formed by the points in inputData
            var sizes = new Dictionary<(Point, Point), long>();
            foreach (var point1 in inputData)
            {
                foreach (var point2 in inputData)
                {
                    var maxSize = Math.Abs(point1.X - point2.X + 1) * Math.Abs(point1.Y - point2.Y + 1);
                    sizes.Add((point1, point2), maxSize);
                }
            }

            // Order the sizes by largest to smallest
            var orderedSize = sizes.OrderByDescending(s => s.Value).ToList();


            // Check for every box, in the sizes list, if it fits inside the polygon.
            // We can do this by checking if the edges of the box intersect with any of the edges of the polygon.

            foreach (var pair in orderedSize)
            {
                // Create the 4 points of the box

                var boxTopLeft = new Point(Math.Min(pair.Key.Item1.X, pair.Key.Item2.X), Math.Min(pair.Key.Item1.Y, pair.Key.Item2.Y));
                var boxBottomRight = new Point(Math.Max(pair.Key.Item1.X, pair.Key.Item2.X), Math.Max(pair.Key.Item1.Y, pair.Key.Item2.Y));
                var boxTopRight = new Point(boxBottomRight.X, boxTopLeft.Y);
                var boxBottomLeft = new Point(boxTopLeft.X, boxBottomRight.Y);


                // both horizontal lines
                var line1 = new Line(boxTopLeft, boxTopRight);
                var line2 = new Line(boxBottomLeft, boxBottomRight);

                // both vertical lines
                var line3 = new Line(boxTopLeft, boxBottomLeft);
                var line4 = new Line(boxTopRight, boxBottomRight);

                bool intersects = false;

                // Check if any of the horizontal lines intersect with the vertical polygon lines
                foreach (var vLine in verticalLines)
                {
                    if (DoLinesIntersect(line1, vLine) || DoLinesIntersect(line2, vLine)||
                        DoLinesIntersect(line3, vLine) || DoLinesIntersect(line4, vLine))
                    {
                        intersects = true;
                        break;
                    }
                }
                if (intersects)
                {
                    continue;
                }
                // Check if any of the vertical lines intersect with the horizontal polygon lines
                foreach (var hLine in horizontalLines)
                {
                    if (DoLinesIntersect(line3, hLine) || DoLinesIntersect(line4, hLine)||
                        DoLinesIntersect(line1, hLine) || DoLinesIntersect(line2, hLine))
                    {
                        intersects = true;
                        break;
                    }
                }
                if (intersects)
                {
                    continue;
                }

                // check if the middle of the box is inside the polygon
                var boxCenter = new Point((boxTopLeft.X + boxBottomRight.X) / 2, (boxTopLeft.Y + boxBottomRight.Y) / 2);
                if (!IsPointInPolygon(inputData, boxCenter))
                {
                    continue;
                }

                // If we reach here, the box fits inside the polygon
                return pair.Value;
            }

            // 2323334942 te hoog
            return 0L;
        }

        private bool DoLinesIntersect(Line line, Line vertex)
        {
            if(line.Start.X == line.End.X && vertex.Start.X == vertex.End.X)
            {
                return false; // both vertical
            }

            if(line.Start.Y == line.End.Y && vertex.Start.Y == vertex.End.Y)
            {
                return false; // both horizontal
            }

            // one vertical, one horizontal
            if (line.Start.X == line.End.X) // line is vertical
            {
                return (vertex.Start.X <= line.Start.X && vertex.End.X >= line.Start.X) &&
                       (line.Start.Y <= vertex.Start.Y && line.End.Y >= vertex.Start.Y);
            }
            else // line is horizontal
            {
                return (line.Start.X <= vertex.Start.X && line.End.X >= vertex.Start.X) &&
                       (vertex.Start.Y <= line.Start.Y && vertex.End.Y >= line.Start.Y);
            }
        }

        public static IList<Point> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(l => l.Split(',').Select(parts => long.Parse(parts)).ToArray());
            return lines.Select(line => new Point(line[0], line[1])).ToList();
        }

        public static bool IsPointInPolygon(IList<Point> polygon, Point testPoint)
        {
            bool isInside = false;
            int j = polygon.Count - 1;

            for (int i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y) ||
                (polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y))
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) /
                    (polygon[j].Y - polygon[i].Y) *
                    (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        isInside = !isInside;
                    }
                }
                j = i;
            }

            return isInside;
        }
    }

    public record Point(long X, long Y);
    public record Line(Point Start, Point End);

}
