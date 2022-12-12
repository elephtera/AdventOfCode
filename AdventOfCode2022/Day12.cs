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
        public async Task<int> PartAAsync(IList<string> input)
        {
            var inputData = ProcessInput(input.Single(), false);

            var dijkstra = new DijkstraSearch<Day12Node, Day12Edge>(
    source: inputData.Start,
    isTarget: n => n.ID == inputData.End.ID,
    getEdgeCost: e => 1);

            await dijkstra.CompleteAsync();
            var path = dijkstra.PathToTarget();

            var result = path.ToList().Count;
            return result;
        }

        public async Task<int> PartBAsync(IList<string> input)
        {
            var inputData = ProcessInput(input.Single(), true);

            var dijkstra = new DijkstraSearch<Day12Node, Day12Edge>(
    source: inputData.Start,
    isTarget: n => n.Val == 'a',
    getEdgeCost: e => 1);

            await dijkstra.CompleteAsync();
            var path = dijkstra.PathToTarget();

            var result = path.ToList().Count;
            return result;
        }

        public static Day12Graph ProcessInput(string input, bool inverted)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var graph = new Day12Graph();

            //var x = lines.Count() - 1;
            Day12Node? start = null;
            Day12Node? end = null;

            var maxX = lines.Length;
            var maxY = lines[0].Length;
            //Add nodes
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (lines[x][y] == 'S')
                    {
                        lines[x] = lines[x].Replace('S', 'a');
                        start = graph.AddNode(x, y, lines[x][y]);
                    }
                    else if (lines[x][y] == 'E')
                    {
                        lines[x] = lines[x].Replace('E', 'z');
                        end = graph.AddNode(x, y, lines[x][y]);
                    }
                    else
                    {
                        graph.AddNode(x, y, lines[x][y]);
                    }
                }
            }

            // Add edges
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (x < maxX - 1 && lines[x][y] + 1 >= lines[x + 1][y])
                    {
                        if (inverted)
                        {
                            graph.AddEdge(x + 1, y, x, y);
                        }
                        else
                        {
                            graph.AddEdge(x, y, x + 1, y);

                        }
                    }

                    if (x < maxX - 1 && lines[x][y] <= lines[x + 1][y] + 1)
                    {
                        if (inverted)
                        {
                            graph.AddEdge(x, y, x + 1, y);

                        }
                        else
                        {
                            graph.AddEdge(x + 1, y, x, y);
                        }
                    }

                    if (y < maxY - 1 && lines[x][y] + 1 >= lines[x][y + 1])
                    {
                        if (inverted)
                        {
                            graph.AddEdge(x, y + 1, x, y);

                        }
                        else
                        {
                            graph.AddEdge(x, y, x, y + 1);
                        }
                    }
                    if (y < maxY - 1 && lines[x][y] <= lines[x][y + 1] + 1)
                    {
                        if (inverted)
                        {
                            graph.AddEdge(x, y, x, y + 1);
                        }
                        else
                        {
                            graph.AddEdge(x, y + 1, x, y);

                        }
                    }
                }
            }

            graph.Start = inverted ? end : start;
            graph.End = inverted ? start : end;
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
            var node = new Day12Node($"{x},{y}", val);
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

        internal void AddEdge(int x1, int y1, int x2, int y2)
        {
            var from = nodes.Where(n => n.ID == $"{x1},{y1}").Single();
            var to = nodes.Where(n => n.ID == $"{x2},{y2}").Single();
            var edge = new Day12Edge(from, to);
            AddEdge(edge);
        }
    }

    public class Day12Node : INode<Day12Node, Day12Edge>
    {
        public override string ToString()
        {
            return $"({ID}) {Val}";
        }
        public Day12Node(string id, char val)
        {
            ID = id;
            Val = val;
        }

        public string ID { get; }
        public char Val { get; }

        private IList<Day12Edge> edges = new List<Day12Edge>();
        public IReadOnlyCollection<Day12Edge> Edges => new ReadOnlyCollection<Day12Edge>(edges);

        public void AddEdge(Day12Edge edge)
        {
            edges.Add(edge);
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
