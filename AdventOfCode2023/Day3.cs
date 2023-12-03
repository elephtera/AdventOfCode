namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day3 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var engineParts = ProcessData(inputData);

            var result = engineParts.Sum(part => part.HasSymbol ? part.Value : 0);
            return result;
        }

        private static List<EnginePart> ProcessData(char[][] inputData)
        {
            var engineParts = new List<EnginePart>();

            var nextEnginePart = new EnginePart();
            for (int y = 0; y < inputData.Length; y++)
            {
                var number = "";
                for (int x = 0; x < inputData[y].Length; x++)
                {
                    var val = inputData[y][x];
                    var isNumber = IsNumber(val);

                    if (isNumber)
                    {
                        if (number.Length == 0)
                        {
                            // first item of number
                            nextEnginePart.X = x;
                            nextEnginePart.Y = y;
                        }

                        number += val;
                    }
                    else if (number.Length > 0)
                    {
                        // end of number
                        // do magic, create engine part
                        nextEnginePart.Value = int.Parse(number);
                        nextEnginePart.FindSymbol(inputData, number.Length);
                        engineParts.Add(nextEnginePart);

                        // reset for next iteration
                        nextEnginePart = new EnginePart();
                        number = "";
                    }
                }

                // next line
                if (number.Length > 0)
                {
                    // do magic, create engine part
                    nextEnginePart.Value = int.Parse(number);
                    nextEnginePart.FindSymbol(inputData, number.Length);
                    engineParts.Add(nextEnginePart);

                    // reset for next iteration
                    nextEnginePart = new EnginePart();
                    number = "";
                }

            }

            return engineParts;
        }

        private static bool IsNumber(char val)
        {
            var numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '8', '9', '0' };
            var isNumber = numbers.Contains(val);
            return isNumber;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            var engineParts = ProcessData(inputData);

            var allGears = engineParts.Where(part => part.Symbol is { value: '*' }).Select(part => part.Symbol);
            var processedGears = new List<Symbol>();
            var result = 0;

            foreach (var gear in allGears)
            {
                var firstGear = processedGears.FirstOrDefault(processed => processed.X == gear.X && processed.Y == gear.Y);
                if (firstGear != null)
                {
                    var ratio = firstGear.Part.Value * gear.Part.Value;
                    result += ratio;
                }
                else
                {
                    processedGears.Add(gear);
                }
            }
            
            return result;
        }

        public static char[][] ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var matrix = lines.Select(line => line.ToCharArray()).ToArray();

            return matrix;
        }
    }

    public class EnginePart
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Value { get; set; }

        public bool HasSymbol => Symbol != null;

        public Symbol? Symbol { get; set; }

        public void FindSymbol(char[][] inputData, int valueLength)
        {
            var maxX = Math.Min(X + valueLength, inputData[0].Length - 1);
            var maxY = Math.Min(Y + 1, inputData.Length - 1);

            var minX = Math.Max(X - 1, 0);
            var minY = Math.Max(Y - 1, 0);

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    var val = inputData[y][x];
                    if (val == '.') continue;
                    if (IsNumber(val)) continue;

                    Symbol = new Symbol()
                    {
                        X = x,
                        Y = y,
                        value = val,
                        Part = this,
                    };


                    return;
                }
            }
        }

        private static bool IsNumber(char val)
        {
            var numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '8', '9', '0' };
            var isNumber = numbers.Contains(val);
            return isNumber;
        }
    }


    public class Symbol
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char value { get; set; }

        public EnginePart Part { get; set; }
    }
}
