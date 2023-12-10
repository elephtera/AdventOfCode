using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    /**
     *  */
    public class Day1 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            var som = 0;
            foreach (var item in inputData)
            {
                var getal = "";
                getal += Regex.Match(item, @"\d").Value;
                getal += Regex.Match(item, @"\d", RegexOptions.RightToLeft).Value;
                som += int.Parse(getal);
            }
            var result = som;            
            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            var som = 0;
            foreach (var item in inputData)
            {
                var getal = "";
                getal += FindNumber(item, false);
                getal += FindNumber(item, true);
                som += int.Parse(getal);
            }
            var result = som;
            return result;
        }
        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None);

            return lines;
        }
        
        public static int FindNumber(string input, bool fromBack = false)
        {
            var match = Regex.Match(input, @"\d", fromBack? RegexOptions.RightToLeft : RegexOptions.None);

            var number = match.Success? int.Parse(match.Value) : 0;
            var index = match.Success ? match.Index : (fromBack ? int.MinValue:int.MaxValue);

            var numbers = new List<string>() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            var intNumber = 0;
            foreach (var regexNumber in numbers)
            {
                intNumber++;
                match = Regex.Match(input, regexNumber, fromBack ? RegexOptions.RightToLeft : RegexOptions.None);
                if (match.Success && (fromBack && match.Index > index || !fromBack && match.Index < index))
                {
                    index = match.Index;
                    number = intNumber;
                }
            }

            return number;
        }
    }

}
