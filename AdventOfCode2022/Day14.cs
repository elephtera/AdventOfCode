using System.Drawing;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day14
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            int[,] map = ConvertToMap(inputData);

            // Do something with sand..
            int lowest = FindLowest(inputData);

            var sandGrains = 0;
            while (true) 
            { 
                Blockade? sand = NewSand(map, lowest, false);
                
                if(sand == null)
                {
                    return sandGrains;
                }

                map[sand.Value.X, sand.Value.Y] = 2;
                sandGrains++;
            }

            var result = 0;            
            return result;
        }

        private int[,] ConvertToMap(IList<Blockade> inputData)
        {
            int[,] map = new int[1000,500];
            foreach (var blockade in inputData)
            {
                map[blockade.X, blockade.Y] = 1;
            }

            return map;
        }

        private Blockade? NewSand(int[,] map, int floorDepth, bool floor)
        {
            Blockade grain = new Blockade(500, 0);
            if (map[500,0] != 0)
            {
                return null;
            }

            var changed = false;
            do
            {
                changed = false;
                if(grain.Y == floorDepth && floor)
                {
                    break;
                }
                if (map[grain.X, grain.Y + 1] == 0)
                {
                    grain.Y++;
                    changed = true;
                }
                else if (map[grain.X - 1, grain.Y + 1] == 0)
                {
                    grain.X--;
                    grain.Y++;
                    changed = true;
                }
                else if (map[grain.X + 1, grain.Y + 1] == 0)
                {
                    grain.X++;
                    grain.Y++;
                    changed = true;
                }
                
                if(grain.Y > floorDepth)
                {
                    return null;
                }

            } while(changed);
            
            return grain;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            int[,] map = ConvertToMap(inputData);

            // Do something with sand..
            int floor = FindLowest(inputData) + 2;
            var sandGrains = 0;
            while (true)
            {
                Blockade? sand = NewSand(map, floor, true);

                if (sand == null)
                {
                    return sandGrains;
                }

                map[sand.Value.X, sand.Value.Y] = 2;
                sandGrains++;
            }
        }

        private int FindLowest(IList<Blockade> map)
        {
            var maxY = 0;
            foreach(Blockade block in map)
            {
                maxY = Math.Max(block.Y, maxY);
            }

            // -1 because of zero based arrays
            return maxY - 1;
        }

        public static IList<Blockade> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            List<Blockade> walls = CreateWalls(lines);

            return walls;
        }

        public static List<Blockade> CreateWalls(string[] lines)
        {
            var walls = new List<Blockade>();
            foreach (var line in lines)
            {
                var stones = new List<int[]>();
                var coords = line.Split(" -> ");
                foreach (var c in coords)
                {
                    var xy = c.Split(",").Select(i => int.Parse(i)).ToArray();
                    stones.Add(xy);
                }

                for (int i = 0; i < stones.Count - 1; i++)
                {
                    var corner1 = new Blockade(stones[i]);
                    var corner2 = new Blockade(stones[i + 1]);
                    if (corner1.X == corner2.X)
                    {
                        if (corner1.Y < corner2.Y)
                        {
                            for (int y = corner1.Y; y <= corner2.Y; y++)
                            {
                                walls.Add(new Blockade(corner1.X, y));
                            }
                        }
                        else
                        {
                            for (int y = corner2.Y; y <= corner1.Y; y++)
                            {
                                walls.Add(new Blockade(corner1.X, y));
                            }
                        }
                    }
                    else if (corner1.Y == corner2.Y)
                    {
                        if (corner1.X < corner2.X)
                        {
                            for (int x = corner1.X; x <= corner2.X; x++)
                            {
                                walls.Add(new Blockade(x, corner1.Y));
                            }
                        }
                        else
                        {
                            for (int x = corner2.X; x <= corner1.X; x++)
                            {
                                walls.Add(new Blockade(x, corner1.Y));
                            }
                        }
                    }

                }
            }

            return walls.Distinct().ToList();
        }

        public struct Blockade
        {
            public int X;
            public int Y;

            public Blockade(int[] coords) : this()
            {
                X = coords[0];
                Y = coords[1];
            }

            public Blockade(int x, int y) : this()
            {
                X = x;
                Y = y;
            }
        }
    }

}
