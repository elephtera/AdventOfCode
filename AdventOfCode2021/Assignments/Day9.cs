namespace AdventOfCode2021.Assignments
{
    /**
     * --- Day 9: Smoke Basin ---
     * These caves seem to be lava tubes. Parts are even still volcanically active; small hydrothermal vents release smoke into the caves that slowly settles like rain.
     * 
     * If you can model how the smoke flows through the caves, you might be able to avoid it and be that much safer. The submarine generates a heightmap of the floor of the nearby caves for you (your puzzle input).
     * 
     * Smoke flows to the lowest point of the area it's in. For example, consider the following heightmap:
     * 
     * 2199943210
     * 3987894921
     * 9856789892
     * 8767896789
     * 9899965678
     * Each number corresponds to the height of a particular location, where 9 is the highest and 0 is the lowest a location can be.
     * 
     * Your first goal is to find the low points - the locations that are lower than any of its adjacent locations. Most locations have four adjacent locations (up, down, left, and right); locations on the edge or corner of the map have three or two adjacent locations, respectively. (Diagonal locations do not count as adjacent.)
     * 
     * In the above example, there are four low points, all highlighted: two are in the first row (a 1 and a 0), one is in the third row (a 5), and one is in the bottom row (also a 5). All other locations on the heightmap have some lower adjacent location, and so are not low points.
     * 
     * The risk level of a low point is 1 plus its height. In the above example, the risk levels of the low points are 2, 1, 6, and 6. The sum of the risk levels of all low points in the heightmap is therefore 15.
     * 
     * Find all of the low points on your heightmap. What is the sum of the risk levels of all low points on your heightmap?
     * 
     * --- Part Two ---
     * Next, you need to find the largest basins so you know what areas are most important to avoid.
     * 
     * A basin is all locations that eventually flow downward to a single low point. Therefore, every low point has a basin, although some basins are very small. Locations of height 9 do not count as being in any basin, and all other locations will always be part of exactly one basin.
     * 
     * The size of a basin is the number of locations within the basin, including the low point. The example above has four basins.
     * 
     * The top-left basin, size 3:
     * 
     * 2199943210
     * 3987894921
     * 9856789892
     * 8767896789
     * 9899965678
     * The top-right basin, size 9:
     * 
     * 2199943210
     * 3987894921
     * 9856789892
     * 8767896789
     * 9899965678
     * The middle basin, size 14:
     * 
     * 2199943210
     * 3987894921
     * 9856789892
     * 8767896789
     * 9899965678
     * The bottom-right basin, size 9:
     * 
     * 2199943210
     * 3987894921
     * 9856789892
     * 8767896789
     * 9899965678
     * Find the three largest basins and multiply their sizes together. In the above example, this is 9 * 14 * 9 = 1134.
     * 
     * What do you get if you multiply together the sizes of the three largest basins?
     */
    public class Day9 : IDay
    {
        public string Part1()
        {
            var input = InputHandler.GetInputAsStringList(Day9Input.Input);
            var ground = new int[input.Count][];
            for (int i = 0; i < input.Count; i++)
            {
                ground[i] = input[i].Select(height => int.Parse(height.ToString())).ToArray();
            }

            //          x,y-1
            // x-1,y    x,y    x+1,y
            //          x,y+1

            var total = 0;
            for (int x = 0; x < ground.Length; x++)
            {
                for (int y = 0; y < ground[0].Length; y++)
                {
                    var height = ground[x][y];
                    if ((x <= 0 || ground[x - 1][y] > height) &&
                        (x >= ground.Length - 1 || ground[x + 1][y] > height) &&
                        (y <= 0 || ground[x][y - 1] > height) &&
                        (y >= ground[0].Length - 1 || ground[x][y + 1] > height))
                    {
                        total += height + 1;
                    }
                }
            }



            return total.ToString();

        }

        public string Part2()
        {
            var input = InputHandler.GetInputAsStringList(Day9Input.Input);
            var ground = new int[input.Count][];
            for (int i = 0; i < input.Count; i++)
            {
                ground[i] = input[i].Select(height => int.Parse(height.ToString())).ToArray();
            }

            //          x,y-1
            // x-1,y    x,y    x+1,y
            //          x,y+1

            var flooded = new FloodedMap();

            var floodSizes = new List<int>();
            for (int x = 0; x < ground.Length; x++)
            {
                for (int y = 0; y < ground[0].Length; y++)
                {
                    var height = ground[x][y];
                    if ((x <= 0 || ground[x - 1][y] > height) &&
                        (x >= ground.Length - 1 || ground[x + 1][y] > height) &&
                        (y <= 0 || ground[x][y - 1] > height) &&
                        (y >= ground[0].Length - 1 || ground[x][y + 1] > height))
                    {
                        floodSizes.Add(FloodBasin(ground, flooded, x, y));
                    }
                }
            }

            var sortedFloods = floodSizes.OrderByDescending(x => x).ToArray();
            

            var result = sortedFloods[0] * sortedFloods[1] * sortedFloods[2];

            return result.ToString();
        }

        private int FloodBasin(int[][] ground, FloodedMap flooded, int x, int y)
        {
            if(x < 0 || x >= ground.Length || y < 0 || y >= ground[0].Length || flooded.GetFlooded(x,y))
            {
                // out of bounds or already checked
                return 0;
            }

            flooded.SetFlooded(x,y);

            if (ground[x][y] == 9)
            {
                return 0;
            }

            var count = 1;

            // Down
            count += FloodBasin(ground, flooded, x + 1, y);
            // Up
            count += FloodBasin(ground, flooded, x - 1, y);
            // Right
            count += FloodBasin(ground, flooded, x, y + 1);
            // Left
            count += FloodBasin(ground, flooded, x, y - 1);

            return count;
        }
    }

    public class FloodedMap
    {
        private bool[,] flooded = new bool[100, 100];

        public FloodedMap()
        {
            for(int x = 0; x < 100; x++)
            {
                for(int y = 0; y < 100; y++)
                {
                    flooded[x,y] = false;
                }
            }
        }
        public bool GetFlooded(int x, int y)
        {
            return flooded[x, y];
        }

        public bool SetFlooded(int x, int y)
        {
            return flooded[x, y] = true;
        }
    }
}
