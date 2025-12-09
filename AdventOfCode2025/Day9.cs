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
            for (int i = 0; i < inputData.Count; i++)
            {
                Point point1 = inputData[i];
                for (int j = i+1; j < inputData.Count; j++)
                {
                    Point? point2 = inputData[j];
                    var maxSize = (Math.Abs(point1.X - point2.X)+1) * (Math.Abs(point1.Y - point2.Y)+1);
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

                //// check if the middle of the box is inside the polygon
                var boxCenter = new Point((boxTopLeft.X + boxBottomRight.X) / 2, (boxTopLeft.Y + boxBottomRight.Y) / 2);
                if (!IsPointInPolygon(inputData, boxCenter))
                {
                    continue;
                }

                // check all points on the box edges to be in the polygon
                var notInPolygon = false;
                for (long x = boxBottomLeft.X; x <= boxBottomRight.X; x++)
                {
                    if (!IsPointInPolygon(inputData, new Point(x, boxBottomLeft.Y)))
                    {
                        notInPolygon = true;
                        break;
                    }

                    if (!IsPointInPolygon(inputData, new Point(x, boxTopLeft.Y)))
                    {
                        notInPolygon = true;
                        break;
                    }

                }
                if (notInPolygon)
                {
                    continue;
                }

                for (long y = boxBottomLeft.Y; y <= boxTopLeft.Y; y++)
                {
                    if (!IsPointInPolygon(inputData, new Point(boxBottomLeft.X, y)))
                    {
                        notInPolygon = true;
                        break;
                    }

                    if (!IsPointInPolygon(inputData, new Point(boxBottomRight.X, y)))
                    {
                        notInPolygon = true;
                        break;
                    }
                }
                
                if (notInPolygon)
                {
                    continue;
                }

                return pair.Value;


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
                    if (DoLinesIntersect(line1, vLine) || DoLinesIntersect(line2, vLine))
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
                    if (DoLinesIntersect(line3, hLine) || DoLinesIntersect(line4, hLine))
                    {
                        intersects = true;
                        break;
                    }
                }
                if (intersects)
                {
                    continue;
                }

                //// check if the middle of the box is inside the polygon
                //var boxCenter = new Point((boxTopLeft.X + boxBottomRight.X) / 2, (boxTopLeft.Y + boxBottomRight.Y) / 2);
                //if (!IsPointInPolygon(inputData, boxCenter))
                //{
                //    continue;
                //}

                // If we reach here, the box fits inside the polygon
                return pair.Value;
            }

            // 4630762112 <-- ook fout
            // 2323334942 te hoog
            return 0L;
        }

        private bool DoLinesIntersect(Line edgeOfBox, Line vertex)
        {
            if(edgeOfBox.Start.X == edgeOfBox.End.X && vertex.Start.X == vertex.End.X)
            {
                return false; // both vertical
            }
            if(edgeOfBox.Start.Y == edgeOfBox.End.Y && vertex.Start.Y == vertex.End.Y)
            {
                return false; // both horizontal
            }

            //// Check if one of the points are identical to each of the lines
            //if (edgeOfBox.Start == vertex.Start || edgeOfBox.Start == vertex.End ||
            //    edgeOfBox.End == vertex.Start || edgeOfBox.End == vertex.End)
            //{
            //    return false;
            //}

            // one vertical, one horizontal
            if (edgeOfBox.Start.X == edgeOfBox.End.X) // line1 is vertical
            {   
                return (vertex.Start.X <= edgeOfBox.Start.X && vertex.End.X >= edgeOfBox.Start.X) &&
                       (edgeOfBox.Start.Y <= vertex.Start.Y && edgeOfBox.End.Y >= vertex.Start.Y);
            }
            else // line1 is horizontal
            {
                return (edgeOfBox.Start.X <= vertex.Start.X && edgeOfBox.End.X >= vertex.Start.X) &&
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
            if (polygon == null || polygon.Count == 0)
            {
                return false;
            }

            // Helper: check if point p lies exactly on segment a-b
            static bool IsPointOnSegment(Point a, Point b, Point p)
            {
                // Cross product to test collinearity
                long cross = (p.Y - a.Y) * (b.X - a.X) - (p.X - a.X) * (b.Y - a.Y);
                if (cross != 0)
                {
                    return false;
                }

                // Check if p is within bounding box of a and b
                if (Math.Min(a.X, b.X) <= p.X && p.X <= Math.Max(a.X, b.X) &&
                    Math.Min(a.Y, b.Y) <= p.Y && p.Y <= Math.Max(a.Y, b.Y))
                {
                    return true;
                }

                return false;
            }

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
    }

    public record Point(long X, long Y);
    public record Line(Point Start, Point End);

}
