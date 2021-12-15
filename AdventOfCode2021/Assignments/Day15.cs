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
		

		public string PartA()
        {
            var input = InputHandler.ConvertInputToDoubleArray(Day15Input.Input2);

			var graph = ConvertInputToGraph(input);


			var result = Dijkstra(graph, 0, input.Length * input.Length);
			return result.ToString();


        }
		public string PartB()
		{
			var input = InputHandler.ConvertInputToDoubleArray(Day15Input.Input2);
			int[][] extendedInput = GenerateExtendedInput(input);

			var graph = ConvertInputToGraph(extendedInput);


			var result = Dijkstra(graph, 0, extendedInput.Length * extendedInput.Length);
			return result.ToString();
		}

		private int[,] ConvertInputToGraph(int[][] input)
        {
			var arraySize = input.Length;
			var Vertices = arraySize * arraySize;

			int[,] graph = new int[Vertices, Vertices];
			for(int y = 0; y < arraySize; y++)
            {
				for(int x = 0; x < arraySize; x++)
                {
					var lineairPosition = y * arraySize + x;
					// Alleen vullen wat naar ons toekomt. uitgaand word door de ontvangende node ingevuld
					if (x + 1 < arraySize)
					{
						graph[lineairPosition + 1, lineairPosition] = input[x][y];
					}
					if (y + 1 < arraySize)
					{

						graph[lineairPosition + arraySize, lineairPosition] = input[x][y];
					}
					if (x - 1 >= 0)
					{

						graph[lineairPosition - 1, lineairPosition] = input[x][y];
					}
					if (y - 1 >= 0)
					{

						graph[lineairPosition - arraySize, lineairPosition] = input[x][y];
					}
				}
            }

			return graph;
        }

        

        private int[][] GenerateExtendedInput(int[][] input)
        {
			var size = input.Length;
			var targetSize = size * 5;
			var extendedResult = new int[targetSize][];
			for(int x = 0; x < size; x++)
            {
				extendedResult[x] = new int[targetSize];

				for(int y = 0; y < size; y++)
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
						extendedResult[x][y + column * size] = val > 9? 1 : val;
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


        /**
		 * Dijkstra algorithm from Geeks for geeks
		 * 
		 */


        // A C# program for Dijkstra's single
        // source shortest path algorithm.
        // The program is for adjacency matrix
        // representation of the graph

        // A utility function to find the
        // vertex with minimum distance
        // value, from the set of vertices
        // not yet included in shortest
        // path tree

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

		// A utility function to print
		// the constructed distance array
		private string GetSolution(int[] dist, int n)
		{
			var result = "";
			result = "Vertex	 Distance from Source" + Environment.NewLine;


			for (int i = 0; i < dist.Length; i++)
			{
				result += i + " \t\t " + dist[i] + Environment.NewLine;
			}
			return result;
		}

		// Function that implements Dijkstra's
		// single source shortest path algorithm
		// for a graph represented using adjacency
		// matrix representation
		private int Dijkstra(int[,] graph, int src, int vertices)
		{
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

			// Distance of source vertex
			// from itself is always 0
			dist[src] = 0;

			// Find shortest path for all vertices
			for (int count = 0; count < vertices - 1; count++)
			{
				// Pick the minimum distance vertex
				// from the set of vertices not yet
				// processed. u is always equal to
				// src in first iteration.
				int u = minDistance(dist, sptSet);

				// Mark the picked vertex as processed
				sptSet[u] = true;

				// Update dist value of the adjacent
				// vertices of the picked vertex.
				for (int v = 0; v < vertices; v++)

					// Update dist[v] only if is not in
					// sptSet, there is an edge from u
					// to v, and total weight of path
					// from src to v through u is smaller
					// than current value of dist[v]
					if (!sptSet[v] && graph[u, v] != 0 &&
						dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v];
			}

			return dist[vertices - 1];
			// print the constructed distance array
			//return GetSolution(dist, Vertices);
		}
	}

	// This code is contributed by ChitraNayal


}
