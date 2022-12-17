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
            var timeToOpenValve = new Dictionary<string, int>();
            var IDs = workingValves.Select(wv => wv.ID).ToList();

            // afstand tussen valves
            foreach (var workingValve in workingValves)
            {
                foreach (var ID in IDs.Where(id => id != workingValve.ID))
                {
                    var search = new DijkstraSearch<Valve, Day16Edge>(workingValve, (node) => node.ID == ID, (edge) => 1);
                    await search.CompleteAsync();
                    timeToOpenValve.Add($"{workingValve.ID}-{ID}", 1 + search.PathToTarget().Count());
                }
            }

            var result = CalculateReleasedPressure(30, workingValves.Where(wv => wv.ID != "AA").ToList(), "AA", timeToOpenValve);
            return result;
        }


        public async Task<long> PartBAsync(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());

            // We starten bij AA, deze moet dus altijd in de lijst
            var workingValves = inputData.Nodes.Where(n => n.Flowrate > 0 || n.ID == "AA");
            var valveFlowrates = workingValves.Select(p => new { key = p.ID, value = p.Flowrate })
    .ToDictionary(x => x.key, x => x.value);
            var timeToOpenValve = new Dictionary<string, int>();
            var IDs = workingValves.Select(wv => wv.ID).ToList();

            // afstand tussen valves
            foreach (var workingValve in workingValves)
            {
                foreach (var ID in IDs.Where(id => id != workingValve.ID))
                {
                    var search = new DijkstraSearch<Valve, Day16Edge>(workingValve, (node) => node.ID == ID, (edge) => 1);
                    await search.CompleteAsync();
                    timeToOpenValve.Add($"{workingValve.ID}-{ID}", 1 + search.PathToTarget().Count());
                }
            }

            var result = CalculateCombinedReleasedPressure(26, 26, workingValves.Where(wv => wv.ID != "AA").ToList(), "AA", "AA", timeToOpenValve);
            return result;
        }

        public long CalculateReleasedPressure(int timeLeft, IEnumerable<Valve> unprocessedValves, string from, Dictionary<string, int> valveOpenTimes)
        {
            long maximumReleasedPressure = 0;
            foreach (var valve in unprocessedValves)
            {
                var timeToOpenValve = valveOpenTimes[$"{from}-{valve.ID}"];
                int newTimeLeft = timeLeft - timeToOpenValve;
                if (newTimeLeft > 0)
                {
                    long extraPressure = newTimeLeft * valve.Flowrate +
                        CalculateReleasedPressure(newTimeLeft, unprocessedValves.Where(c => c.ID != valve.ID), valve.ID, valveOpenTimes);
                    maximumReleasedPressure = Math.Max(maximumReleasedPressure, extraPressure);
                }
            }

            return maximumReleasedPressure;
        }

        public long CalculateCombinedReleasedPressure(int timeLeftMe, int timeLeftElephant, 
            IEnumerable<Valve> unprocessedValves, string fromMe, string fromElephant, Dictionary<string, int> valveOpenTimes)
        {
            var elephant = timeLeftMe < timeLeftElephant;

            long maximumReleasedPressure = 0;
            foreach (var valve in unprocessedValves)
            {
                var steps = valveOpenTimes[$"{(elephant ? fromElephant : fromMe)}-{valve.ID}"];
                int newTimeLeft = (elephant ? timeLeftElephant : timeLeftMe) - steps;
                if (newTimeLeft > 0)
                {
                    long extraPressure = newTimeLeft * valve.Flowrate + CalculateCombinedReleasedPressure(elephant ? timeLeftMe : newTimeLeft, elephant ? newTimeLeft : timeLeftElephant, unprocessedValves.Where(c => c.ID != valve.ID), elephant ? fromMe : valve.ID, elephant ? valve.ID : fromElephant, valveOpenTimes);
                    if (maximumReleasedPressure < extraPressure) maximumReleasedPressure = extraPressure;
                }
            }
            return maximumReleasedPressure;
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

    public class Day16Graph : IGraph<Valve, Day16Edge>
    {
        private List<Valve> nodes = new List<Valve>();
        private List<Day16Edge> edges = new List<Day16Edge>();
        public Valve Start { get; set; }
        public Valve End { get; set; }

        public IEnumerable<Valve> Nodes => nodes;

        public IEnumerable<Day16Edge> Edges => edges;

        public Valve AddNode(string id, int flowrate)
        {
            var node = new Valve(id, flowrate);
            AddNode(node);

            return node;
        }

        public void AddNode(Valve node)
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

    public class Valve : INode<Valve, Day16Edge>
    {
        public override string ToString()
        {
            return $"({ID}) {Flowrate}";
        }
        public Valve(string id, int flowrate)
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

    public class Day16Edge : IEdge<Valve, Day16Edge>
    {
        public Valve From { get; }

        public Valve To { get; }

        public Day16Edge(Valve from, Valve to)
        {
            From = from;
            To = to;

            From.AddEdge(this);
            //To.AddEdge(this);
        }
    }
}
