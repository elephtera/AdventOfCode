using System.Linq;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day8 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input).ToList();
            var steps = inputData[0];
            List<Node> nodes = ParseNodes(inputData.GetRange(2, inputData.Count - 2));

            var startNode = nodes.Single(n => n.Id == "AAA");

            var resultCycle = CalculateCycle(startNode, steps, true);
           
            return resultCycle;
        }
        
        public long Part2(string input)
        {
            var inputData = ProcessInput(input).ToList();
            var steps = inputData[0];
            List<Node> nodes = ParseNodes(inputData.GetRange(2, inputData.Count - 2));


            var startNodes = nodes.Where(n => n.StartNode).ToArray();
            var cycles = new List<long>();
            foreach (var startNode in startNodes)
            {
                var resultCycle = CalculateCycle(startNode, steps, false);

                cycles.Add(resultCycle);
            }

            return cycles.Aggregate(MathHelper.LCM);
        }

        private static List<Node> ParseNodes(IList<string> inputData)
        {
            var nodes = new List<Node>();
            foreach (var nodeDefinition in inputData)
            {
                nodes.Add(new Node(nodeDefinition[..3]));
            }

            foreach (var nodeDefinition in inputData)
            {
                var node = nodes.Single(n => n.Id == nodeDefinition[..3]);
                node.Left = nodes.Single(n => n.Id == nodeDefinition[7..10]);
                node.Right = nodes.Single(n => n.Id == nodeDefinition[12..15]);
            }

            return nodes;
        }

        private static long CalculateCycle(Node startNode, string steps, bool endOnZZZ)
        {
            var currentNode = startNode;
            var stepcount = 0L;
            while (true)
            {
                foreach (var step in steps)
                {
                    switch (step)
                    {
                        case 'L':
                            currentNode = currentNode.Left;
                            break;
                        case 'R':
                            currentNode = currentNode.Right;
                            break;
                    }

                    stepcount++;
                    if (endOnZZZ && currentNode.Id == "ZZZ" || !endOnZZZ && currentNode.EndNode)
                    {
                        return stepcount;
                    }
                }
            }
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

    public class Node
    {
        public Node(string Id)
        {
            this.Id = Id;
            if (Id[2] == 'Z')
            {
                this.EndNode = true;
            }

            if (Id[2] == 'A')
            {
                this.StartNode = true;
            }
        }

        public bool StartNode { get; set; }

        public bool EndNode { get; set; }

        public string Id { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
