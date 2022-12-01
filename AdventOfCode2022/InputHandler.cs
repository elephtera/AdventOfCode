namespace AdventOfCode2022.Assignments
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

        public static List<int[]> ConvertInputToOpcodes(string input)
        {
            var result = new List<int[]>();

            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i += 18)
            {
                var lineSet = lines.Skip(i).Take(18).ToList();

                var resultSet = new string[3] { lineSet[4], lineSet[5], lines[15] };
                var splitted = resultSet.Select(input => Convert.ToInt32(input.Split(new string[] { " " },
                    StringSplitOptions.None).Last())).ToArray();

                result.Add(splitted);
            }

            return result;
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

        public static IList<List<int>> ConvertInputToIntLists(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine, "," },
                    StringSplitOptions.None);
            var result = new List<List<int>>();
            var intList = new List<int>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(intList);
                    intList = new List<int>();
                    continue;
                }
                intList.Add(int.Parse(line));
            }

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


    }
}