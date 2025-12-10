using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day10 : IDay<long>
    {
        public long Part1(string input)
        {
            IList<(uint lights, IList<uint> bitmasks, IList<int> jolts)> inputData = ProcessInput(input);

            var result = 0;

            foreach (var (lights, bitmasks, jolts) in inputData)
            {
                result += CalculateToggles(lights, bitmasks, 0, 0);
            }
            return result;
        }

        public static int CalculateToggles(uint lights, IList<uint> bitmasks, uint currentLightsOn, int position)
        {

            // try to get the "lights" value as result for currentLightsOn by applying the bitmasks in any combination


            // check if currentLightsOn is equal to lights, after applying the next bitmask

            if (currentLightsOn == lights)
            {
                return 0;
            }
            if (position >= bitmasks.Count)
            {
                return int.MaxValue;
            }

            var val1 = CalculateToggles(lights, bitmasks, currentLightsOn ^ bitmasks[position], position + 1);
            var val2 = CalculateToggles(lights, bitmasks, currentLightsOn, position + 1);
            return Math.Min(val1 == int.MaxValue ? int.MaxValue : val1 + 1, val2);

        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            return result;
        }

        public static IList<(uint lights, IList<uint> bitmasks, IList<int> jolts)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<(uint lights, IList<uint> bitmasks, IList<int> jolts)>();

           
            var bracketRegex = new Regex(@"\[.*\]");
            var bitmaskRegex = new Regex(@"\(.*?\)");
            var joltsRegex = new Regex(@"\{.*\}");
            foreach (var line in lines)
            {
                var lights = 0u;
                var bitmasks = new List<uint>();
                //regex all between brackets, and convert the string with dots and hashtags to zero's and ones as bitwise representation of an int
                var match = bracketRegex.Match(line);
                var lightsLength = 0;
                if (match.Success)
                {
                    var inner = match.Groups[0].Value[1..^1];
                    lights = CalculateLightEndstate(inner);
                    lightsLength = inner.Length;
                }

                var match2 = bitmaskRegex.Matches(line);
                if (match2.Count > 0)
                {
                    foreach (var group in match2)
                    {
                        uint bitmask = CalculateLightswitch(lightsLength, group.ToString()[1..^1]);
                        bitmasks.Add(bitmask);
                    }
                }

                match = joltsRegex.Match(line);
                var jolts = new List<int>();
                if (match.Success)
                {
                    var inner = match.Groups[0].Value[1..^1].Split(',');

                    for (int i = 0; i < inner.Length; i++)
                    {
                        jolts.Add(int.Parse(inner[i]));
                    }

                }
                result.Add((lights, bitmasks, jolts));
            }
            return result;
        }

        public static uint CalculateLightEndstate(string lightEndstate)
        {
            var bitmask = Convert.ToUInt32(lightEndstate.Replace(".", "0").Replace("#", "1"), 2);
            return bitmask;
        }

        public static uint CalculateLightswitch(int lightsLength, string switchData)
        {
            var inner = switchData.Split(',');
            char[] mask = new char[lightsLength];
            for (int j = 0; j < mask.Length; j++)
            {
                mask[j] = '0';
            }

            for (int i = 0; i < inner.Length; i++)
            {
                int maskIndex = int.Parse(inner[i]);
                mask[maskIndex] = '1';
            }

            var bitmask = Convert.ToUInt32(new string(mask), 2);
            return bitmask;
        }
    }

}
