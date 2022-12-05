using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day2 : IDay<int>
    {
        public int PartA(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            
            var score = 0;
            foreach(var item in inputData)
            {
                var opponent = item.Substring(0, 1);
                var myself = item.Substring(2, 1);

                if (opponent.Equals("A")) // rock
                {
                    
                    if (myself.Equals("X")) // rock; draw
                    {
                        score += 1;
                        score += 3;
                    }
                    else if(myself.Equals("Y")) // paper; win
                    {
                        score += 2;
                        score += 6;
                    }
                    else if (myself.Equals("Z")) // scissor; loss
                    {
                        score += 3;
                        score += 0;
                    }
                }
                if (opponent.Equals("B")) // paper
                {
                    if (myself.Equals("X")) // rock; loss
                    {
                        score += 1;
                        score += 0;
                    }
                    else if (myself.Equals("Y")) // paper; draw
                    {
                        score += 2;
                        score += 3;
                    }
                    else if (myself.Equals("Z")) // scissors; win
                    {
                        score += 3;
                        score += 6;
                    }
                }
                if (opponent.Equals("C")) // scissors
                {
                    if (myself.Equals("X")) // rock; win
                    {
                        score += 1;
                        score += 6;
                    }
                    else if (myself.Equals("Y")) // paper; loss
                    {
                        score += 2;
                        score += 0;
                    }
                    else if (myself.Equals("Z")) // scissors; draw
                    {
                        score += 3;
                        score += 3;
                    }
                }
            }
            
            return score;
        }

        public int PartB(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());

            var score = 0;
            foreach (var item in inputData)
            {
                var opponent = item.Substring(0, 1);
                var self = item.Substring(2, 1);
                if (opponent.Equals("A")) // rock
                {
                    if (self.Equals("X")) //lose => scissor
                    {
                        score += 3;
                        score += 0;
                    }
                    else if (self.Equals("Y")) // draw => rock
                    {
                        score += 1;
                        score += 3;
                    }
                    else if (self.Equals("Z")) // win => paper
                    {
                        score += 2;
                        score += 6;
                    }
                }
                if (opponent.Equals("B")) // paper
                {
                    if (self.Equals("X")) //lose => rock
                    {
                        score += 1;
                        score += 0;
                    }
                    else if (self.Equals("Y")) // draw => paper
                    {
                        score += 2;
                        score += 3;
                    }
                    else if (self.Equals("Z")) // win => scissor
                    {
                        score += 3;
                        score += 6;
                    }
                }
                if (opponent.Equals("C")) // scissors
                {
                    if (self.Equals("X")) //lose => paper
                    {
                        score += 2;
                        score += 0;
                    }
                    else if (self.Equals("Y")) // draw => scissor
                    {
                        score += 3;
                        score += 3;
                    }
                    else if (self.Equals("Z")) // win => rock
                    {
                        score += 1;
                        score += 6;
                    }
                }
            }

            return score;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

}
