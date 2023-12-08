namespace AdventOfCode2015.Helpers
{
    public static class InputParsing
    {
        public static bool IsNumber(char val)
        {
            var numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '8', '9', '0' };
            var isNumber = numbers.Contains(val);
            return isNumber;
        }

        public static List<long> ToLongList(string line, char delimeter = ' ')
        {
            var splittedValues = line.Split(delimeter);

            var result = splittedValues.Select(long.Parse).ToList();
            return result;
        }
        public static List<int> ToIntList(string line, char delimeter = ' ')
        {
            var splittedValues = line.Split(delimeter);

            var result = splittedValues.Select(int.Parse).ToList();
            return result;
        }
    }
}
