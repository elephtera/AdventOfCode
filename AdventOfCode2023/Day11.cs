using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day11 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            
            var galaxies = new List<Galaxy>();

            var emptyColumns = new List<bool>();
            var lineLength = inputData[0].Length;
            for (int i = 0; i < lineLength; i++)
            {
                emptyColumns.Add(inputData.All(data => data[i] == '.'));
            }

            var y = -1;

            foreach (var line in inputData)
            {
                y++;
                if (line.All(c => c == '.'))
                {
                    y++;
                    continue;
                }

                var x = -1;
                for (int i = 0; i < lineLength; i++)
                {
                    x++;
                    if (line[i] == '#')
                    {
                        // add new galaxy
                        galaxies.Add(new Galaxy(){X = x, Y = y});
                    }
                    else if (emptyColumns[i] == true)
                    {
                        x++;
                    }
                }

            }

            // calculate distance between galaxies
            var totalDistance = 0L;
            var processed = new List<Galaxy>();
            foreach (var galaxy in galaxies)
            {
                processed.Add(galaxy);
                foreach (var otherGalaxy in galaxies)
                {
                    if (processed.Contains(otherGalaxy))
                    {
                        continue;
                    }

                    totalDistance += galaxy.DistanceTo(otherGalaxy);
                }
            }

            var result = totalDistance;
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);


            var galaxies = new List<Galaxy>();

            var emptyColumns = new List<bool>();
            var lineLength = inputData[0].Length;
            for (int i = 0; i < lineLength; i++)
            {
                emptyColumns.Add(inputData.All(data => data[i] == '.'));
            }

            var y = -1L;

            foreach (var line in inputData)
            {
                y++;
                if (line.All(c => c == '.'))
                {
                    y+= 1000000 - 1;
                    continue;
                }

                var x = -1L;
                for (int i = 0; i < lineLength; i++)
                {
                    x++;
                    if (line[i] == '#')
                    {
                        // add new galaxy
                        galaxies.Add(new Galaxy() { X = x, Y = y });
                    }
                    else if (emptyColumns[i] == true)
                    {
                        x+= 1000000 - 1;
                    }
                }

            }

            // calculate distance between galaxies
            var totalDistance = 0L;
            var processed = new List<Galaxy>();
            foreach (var galaxy in galaxies)
            {
                processed.Add(galaxy);
                foreach (var otherGalaxy in galaxies)
                {
                    if (processed.Contains(otherGalaxy))
                    {
                        continue;
                    }

                    totalDistance += galaxy.DistanceTo(otherGalaxy);
                }
            }

            var result = totalDistance;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

    public class Galaxy
    {
        public long X { get; set; }
        public long Y { get; set; }

        public long DistanceTo(Galaxy otherGalaxy)
        {
            var result = Math.Abs(X - otherGalaxy.X);
            result += Math.Abs(Y - otherGalaxy.Y);
            return result;
        }
    }
}
