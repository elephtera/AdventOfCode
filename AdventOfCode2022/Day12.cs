using Microsoft.VisualBasic;
using SCGraphTheory;
using SCGraphTheory.Search.Classic;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day12
    {
        public async Task<int> Part1Async(string input)
        {
            var inputData = ProcessInput(input, false);

            var search = new BreadthFirstSearch<Day12Node, Day12Edge>(
    source: inputData.Start,
    isTarget: n => n.ID == inputData.End.ID);

            await search.CompleteAsync();
            var path = search.PathToTarget();

            var result = path.ToList().Count;
            return result;
        }

        public async Task<int> Part2Async(string input)
        {
            var inputData = ProcessInput(input, true);

            var dijkstra = new DijkstraSearch<Day12Node, Day12Edge>(
    source: inputData.End,
    isTarget: n => n.Val == 'a',
    getEdgeCost: e => 1);

            await dijkstra.CompleteAsync();
            var path = dijkstra.PathToTarget();

            var result = path.ToList().Count;
            return result;
        }

        public static Day12Graph ProcessInput(string input, bool reverse)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var graph = new Day12Graph();

            var maxX = lines.Length;
            var maxY = lines[0].Length;
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    string lineX = lines[x];
                    char valueXY = lineX[y];
                    if (valueXY == 'S')
                    {
                        lines[x] = lineX.Replace('S', 'a');
                        graph.Start = graph.AddNode(x, y, valueXY);
                    }
                    else if (valueXY == 'E')
                    {
                        lines[x] = lineX.Replace('E', 'z');
                        graph.End = graph.AddNode(x, y, valueXY);
                    }
                    else
                    {
                        graph.AddNode(x, y, valueXY);
                    }
                }
            }

            // Add edges
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    string lineX = lines[x];
                    if (x < maxX - 1 && lineX[y] + 1 >= lines[x + 1][y])
                    {
                        graph.AddEdge(x, y, x + 1, y, reverse);
                    }

                    if (x < maxX - 1 && lineX[y] <= lines[x + 1][y] + 1)
                    {
                        graph.AddEdge(x + 1, y, x, y, reverse);
                    }

                    if (y < maxY - 1 && lineX[y] + 1 >= lineX[y + 1])
                    {
                        graph.AddEdge(x, y, x, y + 1, reverse);
                    }

                    if (y < maxY - 1 && lineX[y] <= lineX[y + 1] + 1)
                    {
                        graph.AddEdge(x, y + 1, x, y, reverse);
                    }
                }
            }

            return graph;
        }


    }


    public class Day12Graph : IGraph<Day12Node, Day12Edge>
    {
        private List<Day12Node> nodes = new List<Day12Node>();
        private List<Day12Edge> edges = new List<Day12Edge>();
        public Day12Node Start { get; set; }
        public Day12Node End { get; set; }

        public IEnumerable<Day12Node> Nodes => nodes;

        public IEnumerable<Day12Edge> Edges => edges;

        public Day12Node AddNode(int x, int y, char val)
        {
            var node = new Day12Node($"{x},{y}", val, x, y);
            AddNode(node);

            return node;
        }

        public void AddNode(Day12Node node)
        {
            nodes.Add(node);
        }

        public void AddEdge(Day12Edge edge)
        {
            edges.Add(edge);
        }

        internal void AddEdge(int x1, int y1, int x2, int y2, bool inverted)
        {
            var xy1 = $"{x1},{y1}";
            var xy2 = $"{x2},{y2}";
            var from = nodes.First(n => n.ID == xy1);
            var to = nodes.First(n => n.ID == xy2);

            if (!inverted)
            {
                AddEdge(new Day12Edge(from, to));
            }
            else
            {
                AddEdge(new Day12Edge(to, from));

            }

        }
    }

    public class Day12Node : INode<Day12Node, Day12Edge>
    {
        public override string ToString()
        {
            return $"({ID}) {Val}";
        }
        public Day12Node(string id, char val, int x, int y)
        {
            ID = id;
            Val = val;
            X = x;
            Y = y;
        }

        public string ID { get; }
        public char Val { get; }
        public int X { get; }
        public int Y { get; }

        private IList<Day12Edge> edges = new List<Day12Edge>();
        public IReadOnlyCollection<Day12Edge> Edges => new ReadOnlyCollection<Day12Edge>(edges);

        public void AddEdge(Day12Edge edge)
        {
            edges.Add(edge);
        }

        internal float Distance(Day12Node end)
        {
            return Math.Abs(end.X - X) + Math.Abs(end.Y - Y);
        }
    }

    public class Day12Edge : IEdge<Day12Node, Day12Edge>
    {
        public Day12Node From { get; }

        public Day12Node To { get; }

        public Day12Edge(Day12Node from, Day12Node to)
        {
            From = from;
            To = to;
            // Directed edges
            From.AddEdge(this);
            //To.AddEdge(this);
        }
    }
}
