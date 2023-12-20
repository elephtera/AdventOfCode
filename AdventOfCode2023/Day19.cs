using System.Data;
using System.Formats.Asn1;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day19 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var processingWorkflows = true;
            var workflows = new List<Workflow>();
            var parts = new List<Part>();
            foreach (var line in inputData)
            {
                if (line.Equals(""))
                {
                    processingWorkflows = false;
                    continue;
                }

                if (processingWorkflows)
                {
                    workflows.Add(new Workflow(line));
                }
                else
                {
                    parts.Add(new Part(line));
                }
            }

            var rating = 0;
            foreach (var part in parts)
            {
                var accepted = part.IsAccepted(workflows);
                if (accepted)
                {
                    rating += part.Rating;
                }
            }

            var result = rating;
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var workflows = new List<Workflow>();
            var resultParts = new List<RangePart>();
            foreach (var line in inputData)
            {
                if (line.Equals(""))
                {
                    break;
                }

                workflows.Add(new Workflow(line));
            }

            var unprocessed = new Queue<RangePart>();
            unprocessed.Enqueue(new RangePart() { X = (1, 4000), M = (1, 4000), A = (1, 4000), S = (1, 4000), NextWorkflow = "in" });

            while (unprocessed.Count > 0)
            {
                var part = unprocessed.Dequeue();

                var newRanges = workflows.Single(wf => wf.ID == part.NextWorkflow).ProcessRange(part);

                foreach (var rangepart in newRanges)
                {
                    if (rangepart.Finished)
                    {
                        if (rangepart.NextWorkflow == "A")
                        {
                            resultParts.Add(rangepart);

                        }
                    }
                    else
                    {
                        unprocessed.Enqueue(rangepart);
                    }
                }

            }


            var result = resultParts.Sum(rp => rp.AcceptedParts);
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

    public class Part
    {
        public int X { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int S { get; set; }


        public Part(string line)
        {
            //{x=1129,m=1499,a=669,s=1670}
            var splitted = line[1..^1].Split(',');
            X = int.Parse(splitted[0][2..]);
            M = int.Parse(splitted[1][2..]);
            A = int.Parse(splitted[2][2..]);
            S = int.Parse(splitted[3][2..]);
        }

        public bool IsAccepted(List<Workflow> workflows)
        {
            var nextWorkflow = "in";
            while (nextWorkflow != "R" && nextWorkflow != "A")
            {
                nextWorkflow = workflows.Single(wf => wf.ID == nextWorkflow).Process(this);
            }

            return nextWorkflow == "A";
        }

        public int Rating => X + M + A + S;
    }

    public class Workflow
    {
        public string ID { get; set; }

        public List<WFRule> Rules { get; set; }

        public Workflow(string line)
        {
            // px{a<2006:qkq,m>2090:A,rfg}
            var splittedOnce = line.Split('{');
            ID = splittedOnce[0];

            var rules = splittedOnce[1][..^1].Split(',');

            Rules = rules.Select(r => new WFRule(r)).ToList();
        }

        public string Process(Part part)
        {
            foreach (var wfRule in Rules)
            {
                if (wfRule.Match(part))
                {
                    return wfRule.Action;
                }
            }

            throw new Exception("No matching rule");
        }

        // (int min, int max) x, (int min, int max) m, (int min, int max) a, (int min, int max) s
        public List<RangePart> ProcessRange(RangePart rangePart)
        {
            IEnumerable<RangePart> rangeParts = new List<RangePart>() { rangePart };
            var result = new List<RangePart>();
            foreach (var wfRule in Rules)
            {
                // do rule magic, create new ranges
                rangeParts = rangeParts.Where(rp => rp.NextWorkflow == this.ID).SelectMany(rp => wfRule.Match(rp));
                result.AddRange(rangeParts.Where(rp => rp.NextWorkflow != this.ID));

            }

            return result;
        }
    }

    public class RangePart
    {
        public override string ToString()
        {
            return $"X:({X.min}-{X.max}); M:({M.min}-{M.max}); A:({A.min}-{A.max}); S:({S.min}-{S.max});";
        }

        public (int min, int max) X { get; set; }
        public (int min, int max) M { get; set; }
        public (int min, int max) A { get; set; }
        public (int min, int max) S { get; set; }

        public string NextWorkflow { get; set; } = "";

        public bool Finished => NextWorkflow is "A" or "R";
        public long AcceptedParts => (long)(X.max - X.min + 1) * (long)(M.max - M.min + 1) * (long)(A.max - A.min+ 1) * (long)(S.max - S.min + 1);

    }

    public class WFRule
    {
        public override string ToString()
        {
            return Compare == '='? $"=> {Action}" : $"{InputField} {Compare} {Value} => {Action}";
        }

        public WFRule(string rule)
        {
            var splitted = rule.Split(":");
            if (splitted.Length == 1)
            {
                Action = splitted[0];
                Compare = '=';
                return;
            }

            Action = splitted[1];

            var match = splitted[0];
            InputField = match[0];
            Compare = match[1];
            Value = int.Parse(match[2..]);
        }

        public char InputField { get; set; }

        public char Compare { get; set; }

        public int Value { get; set; }

        public string Action { get; set; }

        public bool Match(Part part)
        {
            var valueToCheck = InputField switch
            {
                'x' => part.X,
                'm' => part.M,
                'a' => part.A,
                's' => part.S,
                _ => 0
            };

            if (Compare == '<')
            {
                return valueToCheck < Value;
            }
            else if (Compare == '>')
            {
                return valueToCheck > Value;
            }

            return true;
        }

        public List<RangePart> Match(RangePart part)
        {
            var minValueToCheck = InputField switch
            {
                'x' => part.X.min,
                'm' => part.M.min,
                'a' => part.A.min,
                's' => part.S.min,
                _ => 0
            };

            var maxValueToCheck = InputField switch
            {
                'x' => part.X.max,
                'm' => part.M.max,
                'a' => part.A.max,
                's' => part.S.max,
                _ => 0
            };

            if (Compare == '<')
            {
                if (Value <= minValueToCheck)
                {
                    return new List<RangePart>();
                }
                else if (minValueToCheck < Value && Value < maxValueToCheck)
                {
                    // split range
                    var partDone = new RangePart() { X = part.X, M = part.M, A = part.A, S = part.S, NextWorkflow = Action };
                    var partNextRule = new RangePart() { X = part.X, M = part.M, A = part.A, S = part.S, NextWorkflow = part.NextWorkflow};

                    /**
                     *  minval < val < maxval
                     * check: X < val
                     * ergo: alles > val, volgende rule
                     */
                    switch (InputField)
                    {
                        case 'x':
                            partDone.X = part.X with { max = Value - 1 };
                            partNextRule.X = part.X with { min = Value };
                            break;
                        case 'm':
                            partDone.M = part.M with { max = Value - 1 };
                            partNextRule.M = part.M with { min = Value };
                            break;
                        case 'a':
                            partDone.A = part.A with { max = Value - 1 };
                            partNextRule.A = part.A with { min = Value };
                            break;
                        case 's':
                            partDone.S = part.S with { max = Value - 1 };
                            partNextRule.S = part.S with { min = Value };
                            break;
                        default:
                            break;
                    }

                    return new List<RangePart>() { partDone, partNextRule };
                }
                else if (maxValueToCheck < Value)
                {
                    part.NextWorkflow = Action;
                    return new List<RangePart>() { part };
                }


                return new List<RangePart>();
            }
            else if (Compare == '>')
            {
                if (Value >= maxValueToCheck)
                {
                    return new List<RangePart>();
                }
                else if (minValueToCheck < Value && Value < maxValueToCheck)
                {
                    // split range
                    var partDone = new RangePart() { X = part.X, M = part.M, A = part.A, S = part.S, NextWorkflow = Action };
                    var partNextRule = new RangePart() { X = part.X, M = part.M, A = part.A, S = part.S, NextWorkflow = part.NextWorkflow};

                    /**
                     *  minval > val > maxval
                     * check: X > val
                     * ergo: alles < val, volgende rule
                     */
                    switch (InputField)
                    {
                        case 'x':
                            partDone.X = part.X with { min = Value + 1 };
                            partNextRule.X = part.X with { max = Value };
                            break;
                        case 'm':
                            partDone.M = part.M with { min = Value + 1 };
                            partNextRule.M = part.M with { max = Value };
                            break;
                        case 'a':
                            partDone.A = part.A with { min = Value + 1};
                            partNextRule.A = part.A with { max = Value };
                            break;
                        case 's':
                            partDone.S = part.S with { min = Value + 1 };
                            partNextRule.S = part.S with { max = Value };
                            break;
                        default:
                            break;
                    }

                    return new List<RangePart>() { partDone, partNextRule };
                }
                else if (minValueToCheck > Value)
                {
                    part.NextWorkflow = Action;
                    return new List<RangePart>() { part };
                }
            }
            else if(Compare == '=')
            {
                part.NextWorkflow = Action;
                return new List<RangePart>() { part };
            }

            return new List<RangePart>();
        }
    }
}
