using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
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

        public static int[] StringToIntArray(string line)
        {
            int[] result = line.Select(c => c - '0').ToArray();

            return result;
        }

        public static List<string> StringToStringLineList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None).ToList();

            return lines;
        }

        public static int[][] StringToIntArrays(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();
            var doubleIntArray = lines.Select(StringToIntArray).ToArray();

            return doubleIntArray;
        }

        
    }
}
