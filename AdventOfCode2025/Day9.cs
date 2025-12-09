using System.Linq;

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
            for (int i = 0; i < inputData.Count; i++)
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
            for (int i = 0; i < inputData.Count; i++)
            {
                Point point1 = inputData[i];
                for (int j = i + 1; j < inputData.Count; j++)
                {
                    Point? point2 = inputData[j];
                    var maxSize = (Math.Abs(point1.X - point2.X) + 1) * (Math.Abs(point1.Y - point2.Y) + 1);
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

                if (!IsPointInPolygon(inputData, boxTopLeft) ||
                    !IsPointInPolygon(inputData, boxBottomRight) ||
                    !IsPointInPolygon(inputData, boxTopRight) ||
                    !IsPointInPolygon(inputData, boxBottomLeft))
                {
                    continue;
                }

                bool isValid = CheckBoxIntersection(verticalLines, horizontalLines, boxTopLeft, boxBottomRight, boxTopRight, boxBottomLeft);
                if (!isValid)
                {
                    continue;
                }

                return pair.Value;

            }

            return 0L;
        }

        private bool CheckBoxIntersection(IList<Line> verticalLines, IList<Line> horizontalLines, Point boxTopLeft, Point boxBottomRight, Point boxTopRight, Point boxBottomLeft)
        {
            // both horizontal lines
            var line1 = new Line(boxTopLeft, boxTopRight);
            var line2 = new Line(boxBottomLeft, boxBottomRight);

            // both vertical lines
            var line3 = new Line(boxTopLeft, boxBottomLeft);
            var line4 = new Line(boxTopRight, boxBottomRight);

            // Check if any of the horizontal lines intersect with the vertical polygon lines
            foreach (var vLine in verticalLines)
            {
                if (DoLinesIntersect(line1, vLine) || DoLinesIntersect(line2, vLine))
                {
                    return false;
                }
            }

            // Check if any of the vertical lines intersect with the horizontal polygon lines
            foreach (var hLine in horizontalLines)
            {
                if (DoLinesIntersect(line3, hLine) || DoLinesIntersect(line4, hLine))
                {
                    return false;
                }
            }

            return true;
        }

        private bool DoLinesIntersect(Line edgeOfBox, Line vertex)
        {
            if (edgeOfBox.Start.X == edgeOfBox.End.X) // edgeOfBox is vertical
            {
                return (vertex.Start.X < edgeOfBox.Start.X && vertex.End.X > edgeOfBox.Start.X) &&
                       (edgeOfBox.Start.Y < vertex.Start.Y && edgeOfBox.End.Y > vertex.Start.Y);
            }
            else // edgeOfBox is horizontal
            {
                return (edgeOfBox.Start.X < vertex.Start.X && edgeOfBox.End.X > vertex.Start.X) &&
                       (vertex.Start.Y < edgeOfBox.Start.Y && vertex.End.Y > edgeOfBox.Start.Y);
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
            int n = polygon.Count;
            int j = n - 1;

            for (int i = 0; i < n; j = i++)
            {
                Point a = polygon[i];
                Point b = polygon[j];

                // If the test point is exactly on an edge or vertex, consider it inside
                if (IsPointOnSegment(a, b, testPoint))
                {
                    return true;
                }

                // Ray-casting test for edge intersection with horizontal ray to the right of testPoint
                // Use double arithmetic to avoid integer division truncation
                bool intersects = ((a.Y > testPoint.Y) != (b.Y > testPoint.Y)) &&
                                  (testPoint.X < (double)(b.X - a.X) * (testPoint.Y - a.Y) / (double)(b.Y - a.Y) + a.X);

                if (intersects)
                {
                    isInside = !isInside;
                }
            }

            return isInside;
        }

        private static bool IsPointOnSegment(Point a, Point b, Point point)
        {
            return Math.Min(a.X, b.X) <= point.X && point.X <= Math.Max(a.X, b.X) &&
                Math.Min(a.Y, b.Y) <= point.Y && point.Y <= Math.Max(a.Y, b.Y);
        }
    }

    public record Point(long X, long Y);
    public record Line(Point Start, Point End);

}
