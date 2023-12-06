using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day5 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            List<long> seeds = null;
            List<RangeMapper> mappings = new List<RangeMapper>();
            RangeMapper nextMapping = null;
            foreach (var line in inputData)
            {
                if (line.Length == 0)
                {
                    if (nextMapping != null)
                    {
                        nextMapping.Mappings = nextMapping.Mappings.OrderBy(m => m[1]).ToList();
                        mappings.Add(nextMapping);
                    }

                    // next
                    nextMapping = new RangeMapper();
                }
                else if (InputParsing.IsNumber(line[0]))
                {
                    var items = InputParsing.ToLongList(line);
                    seeds ??= items;
                    nextMapping?.Mappings.Add(items);
                }
                else
                {
                    
                    if (line.Equals("seeds:"))
                    {
                        // skip
                    }
                    else
                    {
                        nextMapping.Name = line;
                        // new map
                    }
                }
            }

            var seedToSoil = mappings.Single(map => map.Name.Equals("seed-to-soil map:"));
            var soilToFertilizer = mappings.Single(map => map.Name.Equals("soil-to-fertilizer map:"));
            var fertilizerToWater = mappings.Single(map => map.Name.Equals("fertilizer-to-water map:"));
            var waterToLight = mappings.Single(map => map.Name.Equals("water-to-light map:"));
            var lightToTemperature = mappings.Single(map => map.Name.Equals("light-to-temperature map:"));
            var temperatureToHumidity = mappings.Single(map => map.Name.Equals("temperature-to-humidity map:"));
            var humidityToLocation = mappings.Single(map => map.Name.Equals("humidity-to-location map:"));


            var lowest = long.MaxValue;
            foreach (var seed in seeds)
            {
                // map all
                var step = seed;
                step = seedToSoil.Map(step);
                step = soilToFertilizer.Map(step);
                step = fertilizerToWater.Map(step);
                step = waterToLight.Map(step);
                step = lightToTemperature.Map(step);
                step = temperatureToHumidity.Map(step);
                step = humidityToLocation.Map(step);
                lowest = Math.Min(lowest, step);
            }
            

            var result = lowest;            
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            List<long> seeds = null;
            List<RangeMapper> mappings = new List<RangeMapper>();
            RangeMapper nextMapping = null;
            foreach (var line in inputData)
            {
                if (line.Length == 0)
                {
                    if (nextMapping != null)
                    {
                        nextMapping.Mappings = nextMapping.Mappings.OrderBy(m => m[1]).ToList();
                        mappings.Add(nextMapping);
                    }

                    // next
                    nextMapping = new RangeMapper();
                }
                else if (InputParsing.IsNumber(line[0]))
                {
                    var items = InputParsing.ToLongList(line);
                    seeds ??= items;
                    nextMapping?.Mappings.Add(items);
                }
                else
                {

                    if (line.Equals("seeds:"))
                    {
                        // skip
                    }
                    else
                    {
                        nextMapping.Name = line;
                        // new map
                    }
                }
            }

            var seedToSoil = mappings.Single(map => map.Name.Equals("seed-to-soil map:"));
            var soilToFertilizer = mappings.Single(map => map.Name.Equals("soil-to-fertilizer map:"));
            var fertilizerToWater = mappings.Single(map => map.Name.Equals("fertilizer-to-water map:"));
            var waterToLight = mappings.Single(map => map.Name.Equals("water-to-light map:"));
            var lightToTemperature = mappings.Single(map => map.Name.Equals("light-to-temperature map:"));
            var temperatureToHumidity = mappings.Single(map => map.Name.Equals("temperature-to-humidity map:"));
            var humidityToLocation = mappings.Single(map => map.Name.Equals("humidity-to-location map:"));


            var lowest = long.MaxValue;
            for (var i = 0; i < seeds.Count; i += 2)
            {
                var start = seeds[i];
                var count = seeds[i + 1];

                // map all
                var step = seedToSoil.RangeMap(start, count);
                step = step.SelectMany(s => soilToFertilizer.RangeMap(s.Item1, s.Item2)).ToList();
                step = step.SelectMany(s => fertilizerToWater.RangeMap(s.Item1, s.Item2)).ToList();
                step = step.SelectMany(s => waterToLight.RangeMap(s.Item1, s.Item2)).ToList();
                step = step.SelectMany(s => lightToTemperature.RangeMap(s.Item1, s.Item2)).ToList();
                step = step.SelectMany(s => temperatureToHumidity.RangeMap(s.Item1, s.Item2)).ToList();
                step = step.SelectMany(s => humidityToLocation.RangeMap(s.Item1, s.Item2)).ToList();
                
                lowest = Math.Min(lowest, step.Min(s => s.Item1));
            }


            var result = lowest;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

    public class RangeMapper
    {
        public string Name { get; set; } = "";

        public List<List<long>> Mappings { get; set; } = new();

        public long Map(long input)
        {
            foreach (var mapping in Mappings)
            {
                if (mapping[1] <= input && input < mapping[1] + mapping[2])
                {
                    return input - mapping[1] + mapping[0];
                }
            }

            return input;
        }

        public List<Tuple<long, long>> RangeMap(long start, long count)
        {
            var result = new List<Tuple<long, long>>();

            // begin with start; 

            for (int i = 0; i < Mappings.Count; i++)
            {
                var mapping = Mappings[i];
                if (start > mapping[1] + mapping[2])
                {
                    // start ligt na eind, dus volgende
                    continue;
                }

                if (start < mapping[1])
                {
                    // Begin ligt ervoor, dus (deels) 1 op 1 doorzetten; als het in een andere range had gelegen, dan was het al afgehandeld.                  
                    if (start + count < mapping[1])
                    {
                        result.Add(new Tuple<long, long>(start, count));
                        return result;
                    }


                    var rangeCount = mapping[1] - start;
                    result.Add(new Tuple<long, long>(start, rangeCount));
                    
                    // new start of range
                    start = mapping[1];
                    count -= rangeCount;
                }

                if (start >= mapping[1])
                {
                    if (start + count < mapping[1] + mapping[2])
                    {
                        // ligt volledig in range; omzetten en teruggeven
                        result.Add(new Tuple<long, long>(start - mapping[1] + mapping[0], count));
                        return result;
                    }

                    // Of einde ligt na de range, dan een deel resultaat teruggeven, en volgende iteratie pakken
                    var rangeCount = mapping[1] + mapping[2] - start;
                    result.Add(new Tuple<long, long>(start - mapping[1] + mapping[0], rangeCount));
                    start = mapping[1] + mapping[2];
                    count -= rangeCount;
                }
            }

            // Niks meer over, maar nog wel een stukje range
            result.Add(new Tuple<long, long>(start, count));

            return result;
        }
    }
}
