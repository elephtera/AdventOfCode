namespace AdventOfCode2021.Assignments
{
    /**
     * --- Day 15: Chiton ---
You've almost reached the exit of the cave, but the walls are getting closer together. Your submarine can barely still fit, though; the main problem is that the walls of the cave are covered in chitons, and it would be best not to bump any of them.

The cavern is large, but has a very low ceiling, restricting your motion to two dimensions. The shape of the cavern resembles a square; a quick scan of chiton density produces a map of risk level throughout the cave (your puzzle input). For example:

1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581
You start in the top left position, your destination is the bottom right position, and you cannot move diagonally. The number at each position is its risk level; to determine the total risk of an entire path, add up the risk levels of each position you enter (that is, don't count the risk level of your starting position unless you enter it; leaving it adds no risk to your total).

Your goal is to find a path with the lowest total risk. In this example, a path with the lowest total risk is highlighted here:

1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581
The total risk of this path is 40 (the starting position is never entered, so its risk is not counted).

What is the lowest total risk of any path from the top left to the bottom right?
     */
    public class Day15 : IDay
    {


        public string Part1()
        {
            var input = InputHandler.ConvertInputToDoubleArray(Day15Input.Input);

            var result = Dijkstra(input);
            return result.ToString();


        }
        public string Part2()
        {
            var input = InputHandler.ConvertInputToDoubleArray(Day15Input.Input);
            var extendedInput = GenerateExtendedInput(input);
            var start = DateTime.Now;
            var result = Dijkstra(extendedInput);
            var end = DateTime.Now;
            return result.ToString() + " start: " + start + " end: " + end;
        }

        private int[][] GenerateExtendedInput(int[][] input)
        {
            var size = input.Length;
            var targetSize = size * 5;
            var extendedResult = new int[targetSize][];
            for (int x = 0; x < size; x++)
            {
                extendedResult[x] = new int[targetSize];

                for (int y = 0; y < size; y++)
                {
                    extendedResult[x][y] = input[x][y];
                }
            }

            for (int column = 1; column < 5; column++)
            {
                // Bovenste rij
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        var val = extendedResult[x][y + ((column - 1) * size)] + 1;
                        extendedResult[x][y + column * size] = val > 9 ? 1 : val;
                    }
                }
            }

            // Overige rijen

            for (int x = size; x < targetSize; x++)
            {
                extendedResult[x] = new int[targetSize];
                for (int y = 0; y < targetSize; y++)
                {
                    var val = extendedResult[x - size][y] + 1;
                    extendedResult[x][y] = val > 9 ? 1 : val;
                }
            }

            return extendedResult;
        }


        // Function that implements Dijkstra's
        // single source shortest path algorithm
        // for a graph represented using adjacency
        // matrix representation
        private int Dijkstra(int[][] input)
        {
            var arraySize = input.Length;
            var vertices = arraySize * arraySize;
            int[] dist = new int[vertices]; // The output array. dist[i]
                                            // will hold the shortest
                                            // distance from src to i

            // sptSet[i] will true if vertex
            // i is included in shortest path
            // tree or shortest distance from
            // src to i is finalized
            bool[] sptSet = new bool[vertices];

            // Initialize all distances as
            // INFINITE and stpSet[] as false
            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of startingpoint is always 0
            dist[0] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < vertices - 1; count++)
            {
                // Pick the minimum distance vertex
                // from the set of vertices not yet
                // processed. u is always equal to
                // src in first iteration.
                int from = minDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[from] = true;

                // Update dist value of the adjacent
                // vertices of the picked vertex.
                foreach(var neighbour in GetNeighbours(from, input))
                {
                    var to = neighbour[0];
                    var graphValue = neighbour[1];

                    // Update dist[to] only if is not in
                    // sptSet, there is an edge from u
                    // to v, and total weight of path
                    // from start to "to" through "from" is smaller
                    // than current value of dist[to]
                    if (!sptSet[to] && graphValue != 0 &&
                        dist[from] != int.MaxValue && dist[from] + graphValue < dist[to])
                    {
                        dist[to] = dist[from] + graphValue;
                    }
                }
            }

            return dist[vertices - 1];
        }

        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;
            
            for (int v = 0; v < dist.Length; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        private IEnumerable<int[]> GetNeighbours(int from, int[][] input)
        {
            var arraySize = input.Length;

            var x = from % arraySize;
            var y = from / arraySize;

            // yield return to items.
            var lineairPosition = y * arraySize + x;

            if (x < arraySize - 1)
            {
                yield return new int[2] { lineairPosition + 1, input[y][x + 1] };
            }

            if (y < arraySize - 1)
            {
                yield return new int[2] { lineairPosition + arraySize, input[y + 1][x] };
            }

            if (x > 0)
            {
                yield return new int[2] { lineairPosition - 1, input[y][x - 1] };
            }

            if (y > 0)
            {
                yield return new int[2] { lineairPosition - arraySize, input[y - 1][x] };
            }
        }
    }


}
