namespace AdventOfCode2021.Assignments
{
    public static class InputHandler
    {
        public static IList<int[]> ConvertInputToPointList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<int[]>();
            foreach (var line in lines)
            {
                var items = line.Split(new string[] { "," },
                    StringSplitOptions.None);
                result.Add(items.Select(item => int.Parse(item)).ToArray());
            }

            return result;
        }

        public static List<Cube> ConvertInputToCubes(string input)
        {
            var result = new List<Cube>();
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            // line example: on x=-20..26,y=-36..17,z=-47..7
            foreach(var line in lines)
            {
                var splitted = line.Split(new string[] { " ", ",", "=", ".." },
                    StringSplitOptions.RemoveEmptyEntries);
                var turnedOn = splitted[0] == "on";
                var minX = Convert.ToInt32(splitted[2]);
                var maxX = Convert.ToInt32(splitted[3]);
                var minY = Convert.ToInt32(splitted[5]);
                var maxY = Convert.ToInt32(splitted[6]);
                var minZ = Convert.ToInt32(splitted[8]);
                var maxZ = Convert.ToInt32(splitted[9]);
                var cube = new Cube(minX, maxX, minY, maxY, minZ, maxZ, turnedOn);
                result.Add(cube);
            }

            return result;
        }

        internal static IList<ScannerData> ConvertInputToScannerData(string rawInput)
        {
            var input = GetInputAsStringList(rawInput);
            // --- scanner XX ---
            // where XX is a number, without leading zero.

            var scanners = new List<ScannerData>();
            var beacons = new List<Coordinate3D>();
            foreach (var line in input)
            {
                if (line.StartsWith("---"))
                {
                    // Found a new Scanner, add the old one, and process the new one.
                    if (beacons.Any())
                    {
                        scanners.Add(new ScannerData(new Coordinate3D(0, 0, 0), 0, beacons));
                        beacons = new List<Coordinate3D>();
                    }

                    continue;
                }

                var coordinates = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(coord => Convert.ToInt32(coord)).ToArray();
                beacons.Add(new Coordinate3D(coordinates[0], coordinates[1], coordinates[2]));
            }

            // Add the last one
            scanners.Add(new ScannerData(new Coordinate3D(0, 0, 0), 0, beacons));

            return scanners;
        }

        internal static string ConvertInputToBitString(string input)
        {
            string bitRepresentation = "";
            foreach (char c in input)
            {
                var i = Convert.ToInt32($"{c}", 16);
                var bit = Convert.ToString(i, 2).PadLeft(4, '0');
                bitRepresentation += bit;
            }

            return bitRepresentation;
        }

        public static IList<int> ConvertInputToIntList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine, "," },
                    StringSplitOptions.None);

            var result = lines.Select(line => int.Parse(line)).ToList();
            return result;
        }

        public static IList<string> GetInputAsStringList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            var result = lines.ToList();
            return result;
        }

        public static int[][] ConvertInputToDoubleArray(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var resultArray = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                resultArray[i] = lines[i].Select(item => int.Parse(item.ToString())).ToArray();
            }

            return resultArray;
        }

        public static int[,] ConvertInputTo2DArray(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var resultArray = new int[lines[0].Length, lines.Length];
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines.Length; x++)
                {
                    resultArray[x, y] = lines[y][x];
                }

            }

            return resultArray;
        }

        public static int[][] ConvertInputToPadded2DArray(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var resultArray = CreateInitializedDoubleArray(lines.Length, lines[0].Length);


            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    var value = lines[y][x] == '#' ? 1 : 0;
                    resultArray[y][x] = value;
                }
            }

            return resultArray;
        }

        public static int[][] CreateInitializedDoubleArray(int sizeX, int sizeY)
        {
            var result = new int[sizeX][];
            for (int i = 0; i < sizeX; i++)
            {
                result[i] = new int[sizeY];
            }
            return result;
        }
        public static IList<Day8Display> ConvertInputToDisplayItems(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<Day8Display>();

            foreach (var line in lines)
            {
                var items = line.Split(new string[] { "|" }, StringSplitOptions.None);

                var display = new Day8Display()
                {
                    inputs = items[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(i => string.Concat(i.OrderBy(x => x))).ToList(),
                    outputs = items[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(i => string.Concat(i.OrderBy(x => x))).ToList(),
                };

                result.Add(display);
            }
            return result;
        }

        public static IList<int[][]> ConvertInputToBingoCards(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            var bingoCards = new List<int[][]>();
            var bingoLines = new List<int[]>();
            foreach (var line in lines)
            {
                bingoLines.Add(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => Int32.Parse(item)).ToArray());
            }

            var lineCount = 0;
            var bingoCard = new int[5][];

            foreach (var line in bingoLines)
            {
                bingoCard[lineCount] = line;

                lineCount++;

                if (lineCount == 5)
                {
                    bingoCards.Add(bingoCard);
                    bingoCard = new int[5][];
                    lineCount = 0;
                }
            }

            return bingoCards;
        }

        internal static List<Line> ConvertInputToLines(string input)
        {
            var result = new List<Line>();
            var inputLines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            foreach (var inputLine in inputLines)
            {
                var numbers = inputLine.Split(new String[] { ",", " -> " }, StringSplitOptions.None).Select(number => Int32.Parse(number)).ToArray();
                result.Add(new Line() { x1 = numbers[0], y1 = numbers[1], x2 = numbers[2], y2 = numbers[3] });
            }

            return result;

        }

        public static IList<Tuple<SubmarineAction, int>> ConvertInputToActionList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var result = lines.Select(line => ConvertLineToAction(line)).ToList();
            return result;
        }

        public static Tuple<SubmarineAction, int> ConvertLineToAction(string inputLine)
        {
            var bits = inputLine.Split(new string[] { " " }, StringSplitOptions.None);

            var action = SubmarineAction.nothing;
            if (!Enum.TryParse<SubmarineAction>(bits[0], out action))
            {
                action = SubmarineAction.nothing;
            }

            var amount = int.Parse(bits[1]);

            return new Tuple<SubmarineAction, int>(action, amount);
        }


    }
}