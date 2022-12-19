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
            var blueprints = ProcessInput(input);
            int qualities = 0;

            for (int i = 0; i < blueprints.Count; i++)
            {
                int newScore = ProcessBlueprint(blueprint: blueprints[i], ore: 0, oreBots: 1, clay: 0, clayBots: 0, obsidian: 0, obsidianBots: 0, geode: 0, geodeBots: 0, minutesLeft: 24);
                qualities += newScore * (i + 1);
            }

            return qualities;
        }

        public int Part2(string input)
        {
            var blueprints = ProcessInput(input);
            var score = 1;
            for (int i = 0; i < Math.Min(3, blueprints.Count); i++)
            {
                int newScore = ProcessBlueprint(blueprint: blueprints[i], ore: 0, oreBots: 1, clay: 0, clayBots: 0, obsidian: 0, obsidianBots: 0, geode: 0, geodeBots: 0, minutesLeft: 32);
                score *= newScore;
            }
            
            return score;
        }
        public struct Blueprint
        {
            public int Ore, Clay;
            public int ObsidianOre, ObsidianClay;
            public int GeodeOre, GeodeObsidian;

            public Blueprint(int[] input)
            {
                Ore = input[0];
                Clay = input[1];
                ObsidianOre = input[2];
                ObsidianClay = input[3];
                GeodeOre = input[4];
                GeodeObsidian = input[5];
            }
        }

  
        public static int ProcessBlueprint(
                Blueprint blueprint,
                int ore,
                int oreBots,
                int clay,
                int clayBots,
                int obsidian,
                int obsidianBots,
                int geode,
                int geodeBots,
                int minutesLeft)
        {
            bool prevCanOre = false;
            bool prevCanClay = false;
            bool prevCanObs = false;
            bool prevCanGeo = false;
            int score = geode;
            var maxOre = new[] { blueprint.Ore, blueprint.Clay, blueprint.ObsidianOre, blueprint.GeodeOre }.Max();
            var maxClay = blueprint.ObsidianClay;
            var maxObs = blueprint.GeodeObsidian;

            for (int i = minutesLeft - 1; i >= 0; i--)
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
                    subscore = ProcessBlueprint(blueprint, ore - blueprint.GeodeOre, oreBots, clay, clayBots, obsidian - blueprint.GeodeObsidian, obsidianBots, geode, geodeBots + 1, i);
                    score = Math.Max(score, subscore);
                    prevCanGeo = canGeo;
                }
                if (canObs && !prevCanObs && obsidianBots < maxObs)
                {
                    subscore = ProcessBlueprint(blueprint, ore - blueprint.ObsidianOre, oreBots, clay - blueprint.ObsidianClay, clayBots, obsidian, obsidianBots + 1, geode, geodeBots, i);
                    score = Math.Max(score, subscore);
                    prevCanObs = canObs;
                }
                if (canClay && !prevCanClay && clayBots < maxClay)
                {
                    subscore = ProcessBlueprint(blueprint, ore - blueprint.Clay, oreBots, clay, clayBots + 1, obsidian, obsidianBots, geode, geodeBots, i);
                    score = Math.Max(score, subscore);
                    prevCanClay = canClay;
                }
                if (canOre && !prevCanOre && oreBots < maxOre)
                {
                    subscore = ProcessBlueprint(blueprint, ore - blueprint.Ore, oreBots + 1, clay, clayBots, obsidian, obsidianBots, geode, geodeBots, i);
                    score = Math.Max(score, subscore);
                    prevCanOre = canOre;
                }

                score = Math.Max(score, geode);
            }
            return score;
        }

        private static List<Blueprint> ProcessInput(string input)
        {
            var blueprints = new List<Blueprint>();

            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<int[]>();
            foreach (var line in lines)
            {
                var numbers = Regex.Split(line, @"\D+");
                var blueprintInput = numbers.Where(n => !string.IsNullOrEmpty(n)).Skip(1).Select(n => int.Parse(n)).ToArray();
                blueprints.Add(new Blueprint(blueprintInput));

            }

            return blueprints;
        }

    }
}
