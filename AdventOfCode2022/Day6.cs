using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day6 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = input;

            var tmp = "";
            var cnt = 0;
            foreach(var c in inputData)
            {
                tmp += c;
                cnt++;
                if(tmp.Distinct().Count() == 4)
                {
                    return cnt;
                }

                if(tmp.Count() >= 4)
                {
                    tmp = tmp.Substring(1);
                }
            }       

            return 0;
        }

        public int Part2(string input)
        {
            var inputData = input;

            var tmp = "";
            var cnt = 0;
            foreach (var c in inputData)
            {
                tmp += c;
                cnt++;
                if (tmp.Distinct().Count() == 14)
                {
                    return cnt;
                }

                if (tmp.Count() >= 14)
                {
                    tmp = tmp.Substring(1);
                }
            }

            return 0;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
