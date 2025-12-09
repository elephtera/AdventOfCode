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
            
            var sortedDistances = CalculateDistancesAndSort(inputData);

            var connectedPoints = new Dictionary<int, List<int>>();
            for (int i = 0; i < inputData.Count; i++)
            {
                connectedPoints[i] = [i];
            }

            for (int i = 0; i < amount; i++)
            {
                var (point1, point2) = sortedDistances[i];

                var value = connectedPoints[point1];
                var value2 = connectedPoints[point2];

                if (value != value2)
                {
                    // Combine the lists
                    value.AddRange(value2);
                    foreach (var p in value2)
                    {
                        connectedPoints[p] = value;
                    }
                }
            }

            var distinctConnectedPoints = connectedPoints.Select(cp => cp.Value).Distinct().OrderByDescending(val => val.Count).ToList();

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
            var sortedDistances = CalculateDistancesAndSort(inputData);

            var connectedPoints = new Dictionary<int, List<int>>();
            for (int i = 0; i < inputData.Count; i++)
            {
                connectedPoints[i] = [i];
            }

            foreach (var (point1, point2) in sortedDistances)
            {
                var value = connectedPoints[point1];
                var value2 = connectedPoints[point2];

                if (value != value2)
                {
                    // Combine the lists
                    value.AddRange(value2);
                    foreach (var p in value2)
                    {
                        connectedPoints[p] = value;
                    }
                }

                if (value.Count == inputData.Count)
                {
                    // all points are connected
                    return inputData[point1].X * inputData[point2].X;
                }
            }

            return 0L;
        }

        private static List<(int point1, int point2)> CalculateDistancesAndSort(IList<Point3D> inputData)
        {
            var distances = new Dictionary<(int point1, int point2), long>();
            for (int i = 0; i < inputData.Count; i++)
            {
                for (int j = i + 1; j < inputData.Count; j++)
                {
                    if (i == j) continue;
                    var point1 = inputData[i];
                    var point2 = inputData[j];
                    var distance = ((point1.X - point2.X) * (point1.X - point2.X)) + ((point1.Y - point2.Y) * (point1.Y - point2.Y)) + ((point1.Z - point2.Z) * (point1.Z - point2.Z));
                    distances.Add((point1.id, point2.id), distance);
                }
            }

            var sortedDistances = distances.OrderBy(d => d.Value).Select(kvp => kvp.Key).ToList();
            return sortedDistances;
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

    public record struct Point3D(int id, long X, long Y, long Z);
}
