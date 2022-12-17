namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day8 : IDay<int>
    {
        public int Part1(string input)
        {
            var forest = ProcessInput(input);
            var lineOfSight = new bool[forest.Count, forest[0].Count];//new List<List<bool>>();
            // vanuit elke kant itereren en checken

            var rowCount = 0;
            foreach (IEnumerable<char> line in forest)
            {
                var colCount = 0;
                var maxHeight = -1;
                foreach (var tree in line)
                {
                    if (tree > maxHeight)
                    {
                        maxHeight = tree;
                        lineOfSight[rowCount, colCount] = true;
                    }

                    colCount++;
                }

                colCount = line.Count() - 1;
                maxHeight = -1;
                foreach (var tree in line.Reverse())
                {
                    if (tree > maxHeight)
                    {
                        maxHeight = tree;
                        lineOfSight[rowCount, colCount] = true;
                    }

                    colCount--;
                }

                rowCount++;
            }

            for (int col = 0; col < forest.Count; col++)
            {
                var maxHeight = -1;
                for (int row = 0; row < forest[col].Count; row++)
                {
                    var tree = forest[row][col];
                    if (tree > maxHeight)
                    {
                        maxHeight = tree;
                        lineOfSight[row, col] = true;
                    }
                }

                maxHeight = -1;
                for (int row = forest[col].Count - 1; row >= 0; row--)
                {
                    var tree = forest[row][col];
                    if (tree > maxHeight)
                    {
                        maxHeight = tree;
                        lineOfSight[row, col] = true;
                    }
                }
            }

            var cnt = 0;
            foreach (var item in lineOfSight)
            {
                if (item)
                {
                    cnt++;
                }
            }

            return cnt;
        }

        public int Part2(string input)
        {
            var forest = ProcessInput(input);
            var maxScore = 0;
            for (int row = 0; row < forest.Count; row++)
            {
                for (int col = 0; col < forest[row].Count; col++)
                {
                    int sceneryScore = CalculateScore(row, col, forest);
                    if (maxScore < sceneryScore)
                    {


                        maxScore = Math.Max(maxScore, sceneryScore);
                    }
                }
            }
            return maxScore;
        }

        private int CalculateScore(int row, int col, List<List<char>> forest)
        {
            if (col == 0 || row == 0 || col == forest[0].Count - 1 || row == forest.Count - 1)
            {
                return 0;
            }

            var treeheight = forest[row][col];
            // 4x
            int left = 0;
            var right = 0;
            var up = 0;
            var down = 0;
            for (int i = col - 1; i > -1; i--)
            {
                left++;
                if (forest[row][i] >= treeheight)
                {
                    break;
                }
            }

            for (int i = col + 1; i < forest[row].Count; i++)
            {
                right++;
                if (forest[row][i] >= treeheight)
                {
                    break;
                }
            }

            for (int i = row - 1; i > -1; i--)
            {
                up++;
                if (forest[i][col] >= treeheight)
                {
                    break;
                }
            }

            for (int i = row + 1; i < forest.Count; i++)
            {
                down++;
                if (forest[i][col] >= treeheight)
                {
                    break;
                }
            }

            return up*down*left*right;
        }

        public static List<List<char>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var forest = new List<List<char>>();
            foreach (var line in lines)
            {
                forest.Add(line.ToList());
            }

            return forest;
        }
    }

}
