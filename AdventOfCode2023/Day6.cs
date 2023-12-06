namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day6 : IDay<long>
    {
        public long Part1(string input)
        {
            if (input == "example")
            {
                return PossibleWins(7, 9) * PossibleWins(15, 40) * PossibleWins(30,200);
            }

            return PossibleWins(60, 601) * PossibleWins(80, 1163) * PossibleWins(86, 1559) * PossibleWins(76, 1300);
        }

        public long Part2(string input)
        {
            if (input == "example")
            {
                return PossibleWins(71530, 940200);
            }

            return PossibleWins(60808676, 601116315591300);
        }
        
        public long PossibleWins(long time, long record)
        {
            // total: time
            // record = hold * (time - hold)
            // hold = 0.5(time - sqrt(time^2 -4record))
            // hold = 0.5(time + sqrt(time^2 -4record))

            var recordHoldPoint = Math.Sqrt(time * time - (4 * record));

            var hold1 = 0.5 * (time - recordHoldPoint);
            var firstWinningHoldTime = Math.Floor(hold1) + 1;
            var hold2 = 0.5 * (time + recordHoldPoint);
            var lastWinningHoldTime = Math.Ceiling(hold2) - 1;

            var res = lastWinningHoldTime - firstWinningHoldTime + 1;
            return (long)res;
        }
    }

}
