namespace AdventOfCode2021.Assignments
{
    /**
     
     */
    public class Day14 : IDay
    {
        public string Part1()
        {
            var template = Day14Input.Input2;
            var input = InputHandler.GetInputAsStringList(Day14Input.Input);


            var polymerInsertionDict = new Dictionary<string, string>();
            foreach(var line in input)
            {
                var items = line.Split(new string[] { " -> " },
                    StringSplitOptions.None);
                polymerInsertionDict.Add(items[0], items[1] + items[0][1]);
            }


            for (int i = 0; i < 10; i++)
            {
                var newTemplate = "" + template[0];
                for (int t = 0; t < template.Length - 1; t++)
                {

                    newTemplate += polymerInsertionDict[template.Substring(t, 2)];
                }

                template = newTemplate;
            }

            var letterCount = new int[26];

            foreach(char letter in template)
            {
                letterCount[letter - 'A'] += 1;
            }

            var max = letterCount.Max();
            var min = letterCount.Where(l => l != 0).Min();

            return (max - min).ToString();

        }

        public string Part2()
        {
            var template = Day14Input.Input2;
            var input = InputHandler.GetInputAsStringList(Day14Input.Input);


            var polymerInsertionDict = new Dictionary<string, List<string>>();
            foreach (var line in input)
            {
                var items = line.Split(new string[] { " -> " },
                    StringSplitOptions.None);
                polymerInsertionDict.Add(items[0], new List<string>() { items[0][0] + items[1], items[1] + items[0][1] });
            }

            var pairDict = new Dictionary<string, long>();
            for (int t = 0; t < template.Length - 1; t++)
            {
                var key = template.Substring(t, 2);
                SetOrAddToDict(pairDict, key, 1);
            }


            for (int i = 0; i < 40; i++)
            {
                var nextPairDict = new Dictionary<string, long>();
                foreach (var pair in pairDict)
                {
                    SetOrAddToDict(nextPairDict, polymerInsertionDict[pair.Key][0], pair.Value);
                    SetOrAddToDict(nextPairDict, polymerInsertionDict[pair.Key][1], pair.Value);
                }
                pairDict = nextPairDict;
            }

            var letterCount = new long[26];

            foreach (var keyValue in pairDict)
            {
                letterCount[keyValue.Key[0] - 'A'] += keyValue.Value;
                letterCount[keyValue.Key[1] - 'A'] += keyValue.Value;
            }

            var max = letterCount.Max();
            var min = letterCount.Where(l => l != 0).Min();

            // We have duplicate items in our count because every letter is in here twice. 
            var result = (max - min - 1) / 2;
            return result.ToString();
        }

        private static void SetOrAddToDict(Dictionary<string, long> pairDict, string key, long count)
        {
            if (pairDict.ContainsKey(key))
            {
                pairDict[key] += count;
            }
            else
            {
                pairDict[key] = count;
            }
        }
    }
}
