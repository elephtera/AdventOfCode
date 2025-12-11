namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day11 : IDay<long>
    {
        public long Part1(string input)
        {
            IList<(string id, IList<string> outputs)> inputData = ProcessInput(input);

            var result = 0L;

            var me = inputData.Where(item => item.id == "you").First();

            foreach (var output in me.outputs)
            {
                result += ProcessNextItem(output, inputData);
                // Process each output
            }


            return result;
        }

        private long ProcessNextItem(string input, IList<(string id, IList<string> outputs)> inputData)
        {
            if (Memo.ContainsKey(input))
            {
                return Memo[input];
            }
            var result = 0L;
            var outputs = inputData.Where(item => item.id == input).Single().outputs;
            foreach (var output in outputs)
            {
                if (output == "out")
                {
                    result += 1;
                    continue;
                }

                result += ProcessNextItem(output, inputData);
                // Process each output
            }

            Memo.Add(input, result);
            return result;
        }

        private long ProcessNextItem3(string node, IList<(string id, IList<string> outputs)> inputData, string endNode, string other)
        {
            if (Memo.ContainsKey(node))
            {
                return Memo[node];
            }
            var result = 0L;
            var outputs = inputData.Where(item => item.id == node).Single().outputs;
            foreach (var output in outputs)
            {
                if (output == endNode)
                {
                    result += 1;
                    continue;
                }

                if (output == "out" || output == other)
                {
                    continue;
                }

                result += ProcessNextItem3(output, inputData, endNode, other);
                // Process each output
            }

            Memo.Add(node, result);
            return result;
        }

        private Dictionary<string, long> Memo = new Dictionary<string, long>();

        public long Part2(string input)
        {
            IList<(string id, IList<string> outputs)> inputData = ProcessInput(input);

            var result = 0L;

            Memo.Clear();
            var svrToFft = ProcessNextItem3("svr", inputData, "fft", "dac");

            Memo.Clear();
            var svrToDac = ProcessNextItem3("svr", inputData, "dac", "fft");

            Memo.Clear();
            var DacToFft = ProcessNextItem3("dac", inputData, "fft", "svr");

            Memo.Clear();
            var FftToDac = ProcessNextItem3("fft", inputData, "dac", "svr");

            Memo.Clear();
            var fftToOut = ProcessNextItem3("fft", inputData, "out", "dac");

            Memo.Clear();
            var dacToOut = ProcessNextItem3("dac", inputData, "out", "fft");

            result += svrToDac * DacToFft * fftToOut;
            result += svrToFft * FftToDac * dacToOut;

            return result;
        }

        public static IList<(string, IList<string>)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<(string, IList<string>)>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var values = parts[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(v => v.Trim()).ToList();
                    result.Add((key, values));
                }
            }
            return result;
        }
    }

}
