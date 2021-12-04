namespace AdventOfCode2021.Assignments.Day4
{
    /**
     * On the other hand, it might be wise to try a different strategy: let the giant squid win.
     * 
     * You aren't sure how many bingo boards a giant squid could play at once, so rather than waste time counting its arms, the safe thing to do is to figure out which board will win last and choose that one. That way, no matter which boards it picks, it will win for sure.
     * 
     * In the above example, the second board is the last to win, which happens after 13 is eventually called and its middle column is completely marked. If you were to keep playing until this point, the second board would have a sum of unmarked numbers equal to 148 for a final score of 148 * 13 = 1924.
     * 
     * Figure out which board will win last. Once it wins, what would its final score be?
     */
    public class Assignment2
    {
        private IList<int[][]> GetBingoCards()
        {
            var input = InputHandler.GetInputAsList(InputDay4.Input2);
            return input;
        }

        private IList<int> GetBingoBalls()
        {
            var input = InputDay4.Input1.ToList();
            return input;
        }

        public string Perform()
        {
            IList<int[][]> bingoCards = GetBingoCards();
            IList<int> bingoBalls = GetBingoBalls();

            var winner = new Tuple<int, int>(int.MinValue, 0);

            foreach (var card in bingoCards)
            {
                var ballcount = 0;
                foreach (var ball in bingoBalls)
                {
                    var rowcount = 0;
                    foreach (var row in card)
                    {

                        var itemcount = 0;
                        foreach (var item in row)
                        {
                            if (item == ball)
                            {
                                card[rowcount][itemcount] = -1;
                            }

                            itemcount++;

                        }
                        rowcount++;
                    }

                    if (CheckCard(card))
                    {
                        if(winner.Item1 < ballcount)
                        {
                            var sum = card.Select(x => x.Where(number => number != -1).Sum()).Sum();
                            var score = sum * ball;
                            winner = new Tuple<int, int>(ballcount, score);
                        }

                        break;
                    };

                    ballcount++;
                }
            }

            return winner.Item2.ToString();
        }

        private static bool CheckCard(int[][] card)
        {

            if (card.Any(row => row.All(item => item == -1)))
            {
                return true;
            }

            for (int column = 0; column < card[0].Length; column++)
            {
                if (card.All(item => item[column] == -1))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
