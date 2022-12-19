using System.Text.RegularExpressions;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day19 : IDay<int>
    {
        public int Part1(string input)
        {
            var blueprints = createBlueprint(input);
            int qualities = 0;

            for (int i = 0; i < blueprints.Count; i++)
            {
                int ore = 0;
                int oreBots = 1;
                int clay = 0;
                int clayBots = 0;
                int obsidian = 0;
                int obsidianBots = 0;
                int geode = 0;
                int geodeBots = 0;

                int round = 0;

                var blueprint = blueprints[i];

                int newScore = doBlueprint(blueprint, ore, oreBots, clay, clayBots, obsidian, obsidianBots, geode, geodeBots, round, 24);
                qualities += newScore * (i + 1);
            }

            return qualities;
        }

        public int Part2(string input)
        {
            int maxOre;
            int maxClay;
            int maxObs;
            var blueprints = createBlueprint(input);
            var qualities = 1;
            for (int i = 0; i < Math.Min(3, blueprints.Count); i++)
            {
                int ore = 0;
                int oreBots = 1;
                int clay = 0;
                int clayBots = 0;
                int obsidian = 0;
                int obsidianBots = 0;
                int geode = 0;
                int geodeBots = 0;

                int round = 0;

                var blueprint = blueprints[i];

                

                int newScore = doBlueprint(blueprint, ore, oreBots, clay, clayBots, obsidian, obsidianBots, geode, geodeBots, round, 32);
                qualities *= newScore;
            }
            

            return qualities;
        }
        public struct Blueprint
        {
            public int Ore, Clay;
            public int ObsidianOre, ObsidianClay;
            public int GeodeOre, GeodeObsidian;

            public Blueprint(int ore, int clay, int oOre, int oClay, int geOre, int geObsidian)
            {
                Ore = ore;
                Clay = clay;
                ObsidianOre = oOre;
                ObsidianClay = oClay;
                GeodeOre = geOre;
                GeodeObsidian = geObsidian;
            }
        }

  
        public static int doBlueprint(
                Blueprint blueprint,
                int ore,
                int oreBots,
                int clay,
                int clayBots,
                int obsidian,
                int obsidianBots,
                int geode,
                int geodeBots,
                int round,
                int maxRounds)
        {
            int maxScore = 0;
            int bestFrom = 0;
            bool prevCanOre = false;
            bool prevCanClay = false;
            bool prevCanObs = false;
            bool prevCanGeo = false;
            int score = geode;
            var maxOre = new[] { blueprint.Ore, blueprint.Clay, blueprint.ObsidianOre, blueprint.GeodeOre }.Max();
            var maxClay = blueprint.ObsidianClay;
            var maxObs = blueprint.GeodeObsidian;

            for (int i = round; i < maxRounds; i++)
            {
                bool canOre = blueprint.Ore <= ore;
                bool canClay = blueprint.Clay <= ore;
                bool canObs = blueprint.ObsidianOre <= ore && blueprint.ObsidianClay <= clay;
                bool canGeo = blueprint.GeodeOre <= ore && blueprint.GeodeObsidian <= obsidian;
                ore += oreBots;
                clay += clayBots;
                obsidian += obsidianBots;
                geode += geodeBots;

                int subscore;
                if (canGeo && !prevCanGeo)
                {
                    subscore = doBlueprint(blueprint, ore - blueprint.GeodeOre, oreBots, clay, clayBots, obsidian - blueprint.GeodeObsidian, obsidianBots, geode, geodeBots + 1, i + 1, maxRounds);
                    score = Math.Max(score, subscore);
                    prevCanGeo = canGeo;
                }
                if (canObs && !prevCanObs && obsidianBots < maxObs)
                {
                    subscore = doBlueprint(blueprint, ore - blueprint.ObsidianOre, oreBots, clay - blueprint.ObsidianClay, clayBots, obsidian, obsidianBots + 1, geode, geodeBots, i + 1, maxRounds);
                    score = Math.Max(score, subscore);
                    prevCanObs = canObs;
                }
                if (canClay && !prevCanClay && clayBots < maxClay)
                {
                    subscore = doBlueprint(blueprint, ore - blueprint.Clay, oreBots, clay, clayBots + 1, obsidian, obsidianBots, geode, geodeBots, i + 1, maxRounds);
                    score = Math.Max(score, subscore);
                    prevCanClay = canClay;
                }
                if (canOre && !prevCanOre && oreBots < maxOre)
                {
                    subscore = doBlueprint(blueprint, ore - blueprint.Ore, oreBots + 1, clay, clayBots, obsidian, obsidianBots, geode, geodeBots, i + 1, maxRounds);
                    score = Math.Max(score, subscore);
                    prevCanOre = canOre;
                }

                score = Math.Max(score, geode);
            }
            return score;
        }

        private static List<Blueprint> createBlueprint(string input)
        {
            var blueprints = new List<Blueprint>();

            var processed = ProcessInput(input);
            foreach (var blueprint in processed)
            {
                blueprints.Add(new Blueprint(blueprint[1], blueprint[2], blueprint[3], blueprint[4], blueprint[5], blueprint[6]));

            }
            return blueprints;
        }

        public static List<int[]> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<int[]>();
            foreach (var line in lines)
            {
                var numbers = Regex.Split(line, @"\D+");
                var n1 = numbers.Where(n => !string.IsNullOrEmpty(n)).Select(n => int.Parse(n)).ToArray();
                result.Add(n1);
            }

            return result;
        }
    }
}
