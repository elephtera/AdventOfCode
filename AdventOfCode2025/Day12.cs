using System.Runtime.ExceptionServices;

namespace AdventOfCode2025
{
    /**
     * 
     */
    public class Day12
    {
        public long Part1(string input, string treeSpace)
        {
            var packages = ProcessInput(input);
            var treeSpaceData = ProcessInputTreeSpace(treeSpace);
            var result = 0L;

            foreach (var ts in treeSpaceData)
            {
                // Process each tree space
                // ts.Size gives the size of the tree space
                // ts.PackageCounts gives the counts of each package type that is needed
                // A first check could be to see if the total area of the packages fits in the tree space

                var totalPackageArea = ts.Size.X * ts.Size.Y;
                var totalPackageSize = ts.PackageCounts
                    .Select((count, index) => count * packages[index].Shape.OccupiedCount)
                    .Sum();

                if (totalPackageSize > totalPackageArea)
                {
                    // Cannot fit
                    continue;
                }

                // handle all packages as 3x3 blocks for now
                var blocksX = (ts.Size.X + 2) / 3;
                var blocksY = (ts.Size.Y + 2) / 3;
                var totalBlocks = blocksX * blocksY;
                var neededBlocks = ts.PackageCounts.Sum();
                if (neededBlocks > totalBlocks)
                {
                    // Cannot fit
                    continue;
                }

                // Now try to fit the packages in the tree space


                result++;
            }


            return result;
        }



        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var result = 0L;
            return result;
        }

        public static IList<Package> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<Package>();
            // Parse the package data

            // Example:
            // 0:
            // ###
            // ##.
            // #..

            // Every set of package data is separated by a blank line
            // The first line is the package ID, followed by the package shape
            List<string> nextShape = new List<string>();
            var packageId = 0;
            foreach (var line in lines)
            {

                // Process each line as needed
                if (string.IsNullOrWhiteSpace(line))
                {
                    // End of current package definition
                    // Store the package with its shape
                    result.Add(new Package(
                        packageId,
                        Bit3x3.FromStrings(nextShape)
                        ));
                    nextShape = new List<string>();
                }
                else if (line[^1] == ':')
                {
                    packageId = int.Parse(line.Substring(0, line.Length - 1));
                }
                else
                {
                    // Part of the package shape
                    nextShape.Add(line);
                }
            }

            return result;
        }

        internal IList<TreeSpace> ProcessInputTreeSpace(string treeSpace)
        {
            var lines = treeSpace.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = new List<TreeSpace>();

            // example line: 44x41: 54 50 44 38 45 49
            foreach (var line in lines)
            {
                var xIndex = line.IndexOf('x');
                var colonIndex = line.IndexOf(':');
                var sizeX = int.Parse(line.Substring(0, xIndex).Trim());
                var sizeY = int.Parse(line.Substring(xIndex + 1, colonIndex - xIndex - 1).Trim());
                var packageCounts = line.Substring(colonIndex + 1).Trim()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToList();
                result.Add(new TreeSpace((sizeX, sizeY), packageCounts));

            }
            return result;
        }
    }

    public record TreeSpace((int X, int Y) Size, List<int> PackageCounts);

    public record Package(int Id, Bit3x3 Shape);
}
