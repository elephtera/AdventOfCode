namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day6 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;

            foreach (var (numbers, action) in inputData)
            {
                switch (action)
                {
                    case '+':
                        var sum = numbers.Sum();
                        result += sum;
                        break;
                    case '*':
                        var product = numbers.Aggregate(1L, (acc, val) => acc * val);
                        result += product;
                        break;
                }
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput2(input);
            var result = 0L;

            foreach (var (numbers, action) in inputData)
            {
                switch (action)
                {
                    case '+':
                        var sum = numbers.Sum();
                        result += sum;
                        break;
                    case '*':
                        var product = numbers.Aggregate(1L, (acc, val) => acc * val);
                        result += product;
                        break;
                }
            }

            return result;
        }

        public static IList<(IList<long>, char)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToList();

            var result = new List<(IList<long>, char)>();

            var lastLine = lines[^1];
            foreach (var line in lines[..^1])
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (result.Count <= i)
                    {
                        result.Add((new List<long>(), lastLine[i].First()));
                    }
                    result[i].Item1.Add(int.Parse(line[i]));
                }
            }

            return result;
        }

        public static IList<(IList<long>, char)> ProcessInput2(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None).ToList();

            var result = new List<(IList<long>, char)>();

            var lastLine = lines[^1];
            for (var i = 0; i < lastLine.Length; i++)
            {
                if (lastLine[i] != ' ')
                {
                    result.Add((new List<long>(), lastLine[i]));
                }

                var number = "";
                // parse other lines, vertically
                for (var j = 0; j < lines.Count - 1; j++)
                {
                    var line = lines[j];
                    if (line[i] != ' ')
                    {
                        number += line[i];
                    }
                }

                if(number == "")
                {
                    continue;
                }

                result[^1].Item1.Add(long.Parse(number));
            }


            return result;
        }
    }

}
