using AdventOfCode2022.Helpers;
using SCGraphTheory;
using SCGraphTheory.Search.Classic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day16
    {
        public async Task<long> PartAAsync(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());

            // We starten bij AA, deze moet dus altijd in de lijst
            var workingValves = inputData.Nodes.Where(n => n.Flowrate > 0 || n.ID == "AA");
            var valveFlowrates = workingValves.Select(p => new { key = p.ID, value = p.Flowrate })
    .ToDictionary(x => x.key, x => x.value);
            var shorestPath = new Dictionary<string, List<Day16Edge>>();
            var IDs = workingValves.Select(wv => wv.ID).ToList();

            // afstand tussen valves
            foreach(var workingValve in workingValves)
            {
                foreach(var ID in IDs.Where(id => id != workingValve.ID))
                    {
                    var search = new DijkstraSearch<Day16Node, Day16Edge>(workingValve, (node) => node.ID == ID, (edge) => 1);
                    await search.CompleteAsync();
                    shorestPath.Add($"{workingValve.ID}-{ID}", search.PathToTarget().ToList());
                }
            }

            var result = CalculateReleasedPressure(30, workingValves.Where(wv => wv.ID != "AA").ToList(), "AA", shorestPath); 
            return result;
        }

        public long CalculateReleasedPressure(int countdown, IList<Day16Node> usefull, string curV, Dictionary<string, List<Day16Edge>> shortestPaths)
        {
            long best = 0;
            foreach (var t in usefull)
            {
                var steps = shortestPaths[$"{curV}-{t.ID}"].Count();
                int newTimeToGo = countdown - steps - 1;
                if (newTimeToGo > 0)
                {
                    long gain = newTimeToGo * t.Flowrate + CalculateReleasedPressure(newTimeToGo, usefull.Where(c => c.ID != t.ID).ToList(), t.ID, shortestPaths);
                    if (best < gain) best = gain;
                }
            }
            return best;
        }

        public long GetReleasedPressureTogether(int countdown, int countdownElephant, IList<Day16Node> usefull, string curV, string curVE, Dictionary<string, List<Day16Edge>> searchResults)
        {
            var elephant = countdown < countdownElephant;

            long best = 0;
            foreach (var t in usefull)
            {
                var steps = searchResults[$"{(elephant? curVE : curV)}-{t.ID}"].Count();
                int newTimeToGo = (elephant? countdownElephant: countdown) - steps - 1;
                if (newTimeToGo > 0)
                {
                    long gain = newTimeToGo * t.Flowrate + GetReleasedPressureTogether(elephant? countdown : newTimeToGo, elephant? newTimeToGo : countdownElephant, usefull.Where(c => c.ID != t.ID).ToList(), elephant? curV : t.ID, elephant? t.ID : curVE, searchResults);
                    if (best < gain) best = gain;
                }
            }
            return best;
        }

        public async Task<long> PartBAsync(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            // We start with AA, thus is part of the tree.
            var workingValves = inputData.Nodes.Where(n => n.Flowrate > 0 || n.ID == "AA");
            var valveFlowrates = workingValves.Select(p => new { key = p.ID, value = p.Flowrate })
    .ToDictionary(x => x.key, x => x.value);
            var searchResults = new Dictionary<string, List<Day16Edge>>();
            var IDs = workingValves.Select(wv => wv.ID).ToList();
            // afstand tussen valves
            foreach (var workingValve in workingValves)
            {
                foreach (var ID in IDs.Where(id => id != workingValve.ID))
                {
                    var search = new DijkstraSearch<Day16Node, Day16Edge>(workingValve, (node) => node.ID == ID, (edge) => 1);
                    await search.CompleteAsync();
                    searchResults.Add($"{workingValve.ID}-{ID}", search.PathToTarget().ToList());
                }
            }

            var result = GetReleasedPressureTogether(26, 26, workingValves.Where(wv => wv.ID != "AA").ToList(), "AA", "AA", searchResults);
            return result;
        }

        public static Day16Graph ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var graph = new Day16Graph();
            foreach (var line in lines)
            {
                //Valve EK has flow rate=12; tunnels lead to valves JE, VE, PJ, CS, IX
                var from = line.Substring(6, 2);
                var flowRate = line.Substring(23, line.IndexOf(';') - 23);
                graph.AddNode(from, int.Parse(flowRate));

            }

            foreach (var line in lines)
            {
                //Valve EK has flow rate=12; tunnels lead to valves JE, VE, PJ, CS, IX
                var from = line.Substring(6, 2);
                var toString = line.Substring(line.IndexOf(';') + 24);
                var toList = toString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                foreach (var to in toList)
                {
                    graph.AddEdge(from, to);
                }
            }

            return graph;
        }
    }

    public class Day16Graph : IGraph<Day16Node, Day16Edge>
    {
        private List<Day16Node> nodes = new List<Day16Node>();
        private List<Day16Edge> edges = new List<Day16Edge>();
        public Day16Node Start { get; set; }
        public Day16Node End { get; set; }

        public IEnumerable<Day16Node> Nodes => nodes;

        public IEnumerable<Day16Edge> Edges => edges;

        public Day16Node AddNode(string id, int flowrate)
        {
            var node = new Day16Node(id, flowrate);
            AddNode(node);

            return node;
        }

        public void AddNode(Day16Node node)
        {
            nodes.Add(node);
        }

        public void AddEdge(Day16Edge edge)
        {
            edges.Add(edge);
        }

        internal void AddEdge(string fromId, string toId)
        {
            var from = nodes.First(n => n.ID == fromId);
            var to = nodes.First(n => n.ID == toId);

            AddEdge(new Day16Edge(from, to));

        }
    }

    public class Day16Node : INode<Day16Node, Day16Edge>
    {
        public override string ToString()
        {
            return $"({ID}) {Flowrate}";
        }
        public Day16Node(string id, int flowrate)
        {
            ID = id;
            Flowrate = flowrate;
        }

        public string ID { get; }
        public int Flowrate { get; }

        private IList<Day16Edge> edges = new List<Day16Edge>();
        public IReadOnlyCollection<Day16Edge> Edges => new ReadOnlyCollection<Day16Edge>(edges);

        public void AddEdge(Day16Edge edge)
        {
            edges.Add(edge);
        }
    }

    public class Day16Edge : IEdge<Day16Node, Day16Edge>
    {
        public Day16Node From { get; }

        public Day16Node To { get; }

        public Day16Edge(Day16Node from, Day16Node to)
        {
            From = from;
            To = to;

            From.AddEdge(this);
            //To.AddEdge(this);
        }
    }
}
