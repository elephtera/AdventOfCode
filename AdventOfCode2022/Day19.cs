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
            var inputData = ProcessInput(input);
            var totalBlueprintQuality = 0;
            foreach (var item in inputData)
            {
                // Blueprint 1: Each ore robot costs 4 ore.
                // Each clay robot costs 2 ore.
                // Each obsidian robot costs 3 ore and 14 clay.
                // Each geode robot costs 2 ore and 7 obsidian
                var productionCost = new List<int[]>()
                {
                    new[] {item[1],0,0,0 },
                    new[] {item[2],0,0,0 },
                    new[] {item[3],item[4],0,0 },
                    new[] {item[5],0,item[6],0 },
                };
                var RobotCount = new int[4] { 1, 0, 0, 0 };
                var newGeode = CalculateGeodeProduction(24, productionCost, new[] { 0, 0, 0, 0 }, RobotCount);
                totalBlueprintQuality += newGeode * item[0];
            }

            return totalBlueprintQuality;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0;
            return result;
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
                result.Add(n1);// umbers);
            }

            return result;
        }

        public int CalculateGeodeProduction(int timeLeft, List<int[]> productionCost, int[] Inventory, int[] robotCount)
        {
            if(timeLeft == 2)
            {

            }
            int maxOre = productionCost.Max(p => p[0]);
            int maxClay = productionCost.Max(p => p[1]);
            int maxObsidian = productionCost.Max(p => p[2]);
            int maximumGeode = 0;
            var nextTypes = new List<int>();
            for (int i = 3; i >= 0; i--)
            {
                if (i == 0 && (robotCount[0] >= maxOre))
                {
                    continue;
                }
                if (i == 1 && (robotCount[1] >= maxClay))
                {
                    continue;
                }
                if (i == 2 && (robotCount[2] >= maxObsidian))
                {
                    continue;
                }

                if (Inventory[0] >= productionCost[i][0] &&
                    Inventory[1] >= productionCost[i][1] &&
                    Inventory[2] >= productionCost[i][2])
                {
                    nextTypes.Add(i);
                    if(i == 3)
                    {
                        break;
                    }
                }
            }

            if (nextTypes.Count == 0)
            {
                // Also keep track of "no new device"
                nextTypes.Add(-1);
            }

            foreach (var typeId in nextTypes)
            {
                var newInventory = new int[4];
                var newRobotCount = new int[4];
                Inventory.CopyTo(newInventory, 0);
                robotCount.CopyTo(newRobotCount, 0);

                if (typeId >= 0)
                {
                    newInventory[0] -= productionCost[typeId][0];
                    newInventory[1] -= productionCost[typeId][1];
                    newInventory[2] -= productionCost[typeId][2];
                }

                // Devices produce new items
                newInventory[0] += robotCount[0];
                newInventory[1] += robotCount[1];
                newInventory[2] += robotCount[2];
                newInventory[3] += robotCount[3];

                if (typeId >= 0) newRobotCount[typeId]++;

                int newTimeLeft = timeLeft - 1;
                if (newTimeLeft >= 0)
                {
                    var newGeode = CalculateGeodeProduction(newTimeLeft, productionCost, newInventory, newRobotCount);
                    maximumGeode = Math.Max(maximumGeode, newGeode);
                }
            }

            return Math.Max(Inventory[3], maximumGeode);
        }
    }

}
