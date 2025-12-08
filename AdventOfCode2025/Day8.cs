namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day8
    {
        public long Part1(string input, int amount)
        {
            var inputData = ProcessInput(input);
            // order by distance to eachother
            var distances = new Dictionary<(int point1, int point2), long>();

            for (int i = 0; i < inputData.Count; i++)
            {
                for (int j = i + 1; j < inputData.Count; j++)
                {
                    if (i == j) continue;
                    var point1 = inputData[i];
                    var point2 = inputData[j];
                    //var distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
                    var distance = ((point1.X - point2.X) * (point1.X - point2.X)) + ((point1.Y - point2.Y) * (point1.Y - point2.Y)) + ((point1.Z - point2.Z) * (point1.Z - point2.Z));
                    distances.Add((point1.id, point2.id), distance);
                }
            }

            var sortedDistances = distances.OrderBy(d => d.Value).ToList();

            var connectedPoints = new Dictionary<int, List<int>>();


            for (int i = 0; i < amount; i++)
            {
                var (point1, point2) = sortedDistances[i].Key;

                var p1 = inputData.Where(item => item.id == point1).FirstOrDefault();
                var p2 = inputData.Where(item => item.id == point2).FirstOrDefault();

                // Make sure we have entries for both points
                if (!connectedPoints.ContainsKey(point1))
                {
                    connectedPoints[point1] = new List<int>();
                }
                if (!connectedPoints.ContainsKey(point2))
                {
                    connectedPoints[point2] = new List<int>();
                }

                // Add the connection both ways
                connectedPoints[point1].Add(point2);
                connectedPoints[point2].Add(point1);

                // Add the items from both sides to each other
                var itemsFromBoth = connectedPoints[point1].Union(connectedPoints[point2]).Distinct().ToList();
                foreach (var p in itemsFromBoth)
                {
                    if (!connectedPoints.ContainsKey(p))
                    {
                        // waarschijnlijk niet nodig, want is al gemaakt, anders niet in de lijst.
                        connectedPoints[p] = new List<int>();
                    }

                    connectedPoints[p] = itemsFromBoth.Where(item => item != p).ToList();
                }
            }

            var distinctConnectedPoints = connectedPoints.Select(val =>
            {
                var allPoints = new List<int>(val.Value);
                allPoints.Add(val.Key);
                return allPoints.Order().ToList();
            }).DistinctBy(val => val.First()).OrderByDescending(val => val.Count).ToList();


            var result = 1;
            for (int i = 0; i < 3; i++)
            {
                result *= distinctConnectedPoints[i].Count;
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            // order by distance to eachother
            var distances = new Dictionary<(int point1, int point2), long>();

            for (int i = 0; i < inputData.Count; i++)
            {
                for (int j = i + 1; j < inputData.Count; j++)
                {
                    if (i == j) continue;
                    var point1 = inputData[i];
                    var point2 = inputData[j];
                    //var distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
                    var distance = ((point1.X - point2.X) * (point1.X - point2.X)) + ((point1.Y - point2.Y) * (point1.Y - point2.Y)) + ((point1.Z - point2.Z) * (point1.Z - point2.Z));
                    distances.Add((point1.id, point2.id), distance);
                }
            }

            var sortedDistances = distances.OrderBy(d => d.Value).ToList();

            var connectedPoints = new Dictionary<int, List<int>>();

            var result = 0L;
            for (int i = 0; i < sortedDistances.Count; i++)
            {
                var (point1, point2) = sortedDistances[i].Key;

                var p1 = inputData.Where(item => item.id == point1).FirstOrDefault();
                var p2 = inputData.Where(item => item.id == point2).FirstOrDefault();

                // Make sure we have entries for both points
                if (!connectedPoints.ContainsKey(point1))
                {
                    connectedPoints[point1] = new List<int>();
                }
                if (!connectedPoints.ContainsKey(point2))
                {
                    connectedPoints[point2] = new List<int>();
                }

                // Add the connection both ways
                connectedPoints[point1].Add(point2);
                connectedPoints[point2].Add(point1);

                // Add the items from both sides to each other
                var itemsFromBoth = connectedPoints[point1].Union(connectedPoints[point2]).Distinct().ToList();
                foreach (var p in itemsFromBoth)
                {
                    if (!connectedPoints.ContainsKey(p))
                    {
                        // waarschijnlijk niet nodig, want is al gemaakt, anders niet in de lijst.
                        connectedPoints[p] = new List<int>();
                    }

                    connectedPoints[p] = itemsFromBoth.Where(item => item != p).ToList();
                }

                if (connectedPoints.Count >= inputData.Count)
                {
                    // all points are connected
                    result = inputData[point1].X * inputData[point2].X;
                    break;
                }

            }

            return result;
        }

        public static IList<Point3D> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(s => s.Split(',').Select(i => long.Parse(i)).ToList()).ToList();
            var result = new List<Point3D>();
            var id = 0;
            foreach (var line in lines)
            {
                result.Add(new Point3D(id, line[0], line[1], line[2]));
                id++;
            }

            return result;
        }


    }

    public record struct Point3D(int id, long X, long Y, long Z)
    {
        public static implicit operator (int id, long x, long y, long z)(Point3D value)
        {
            return (value.id, value.X, value.Y, value.Z);
        }

        public static implicit operator Point3D((int id, long x, long y, long z) value)
        {
            return new Point3D(value.id, value.x, value.y, value.z);
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }


    }
}
