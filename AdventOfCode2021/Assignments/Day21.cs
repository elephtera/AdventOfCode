namespace AdventOfCode2021.Assignments
{
    /**

     */
    public class Day21 : IDay
    {
        public static List<(int steps, int count)> DiceRoles = new();

        public string Part1()
        {
            return PlayGame(1, 6).ToString();
        }

        public static long PlayGame(int position1, int position2)
        {
            var player1 = new Player(position1);
            var player2 = new Player(position2);
            var dice = new Dice();
            while (true)
            {
                player1.Move(dice.ThrowThreeTimes());
                if (player1.Score >= 1000)
                {
                    long losingScore = (player2.Score * dice.TimesThrown);
                    return losingScore;
                }

                player2.Move(dice.ThrowThreeTimes());
                if (player2.Score >= 1000)
                {
                    long losingScore = (player1.Score * dice.TimesThrown);
                    return losingScore;
                }
            }
        }

        public Day21()
        {
            DiceRoles = GetDiceRoles();
        }

        public string Part2()
        {
            var (winst1, winst2) = Speel(true, 1, 0, 6, 0);

            return (winst1 > winst2 ? winst1 : winst2).ToString();
        }



        public (long Win1, long Win2) Speel(bool speler1, int positie1, int score1, int positie2, int score2)
        {
            (long winnaar1, long winnaar2) res = (0, 0);

            foreach (var dr in DiceRoles)
            {
                int newpos1 = positie1, newscore1 = score1, newpos2 = positie2, newscore2 = score2;
                if (speler1)
                {
                    newpos1 += dr.steps;
                    if (newpos1 > 10) { newpos1 -= 10; }
                    newscore1 += newpos1;
                    if (newscore1 >= 21)
                    {
                        res.winnaar1 += dr.count;
                        continue;
                    }
                }
                else
                {
                    newpos2 += dr.steps;
                    if (newpos2 > 10) { newpos2 -= 10; }
                    newscore2 += newpos2;
                    if (newscore2 >= 21)
                    {
                        res.winnaar2 += dr.count;
                        continue;
                    }
                }

                var next = Speel(!speler1, newpos1, newscore1, newpos2, newscore2);

                // Voor elke diepte de dr.count in acht nemen voor de nieuw behaalde winsten
                res.winnaar1 += next.Win1 * dr.count;
                res.winnaar2 += next.Win2 * dr.count;

            }
            return res;
        }

        private static List<(int steps, int count)> GetDiceRoles()
        {
            var diceRolls = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    for (int k = 1; k <= 3; k++)
                    {
                        diceRolls.Add(i + j + k);
                    }
                }
            }

            return diceRolls.GroupBy(total => total).Select(total => (total.Key, total.Count())).ToList();
        }

        public class Dice
        {
            public int TimesThrown { get; set; } = 0;
            private int value = 0;

            public int ThrowThreeTimes()
            {
                var sum = 0;
                for (var i = 0; i < 3; i++)
                {
                    value++;
                    if (value > 100)
                    {
                        value = 1;
                    }

                    sum += value;
                }

                TimesThrown += 3;
                return sum;
            }
        }

        public class Player
        {
            /// <summary>
            /// Nul based position. Max is 9.
            /// </summary>
            public int Position { get; set; }
            public int Moves { get; set; }
            public long Score { get; set; }

            public Player(int position)
            {
                Score = 0;
                Moves = 0;
                Position = position - 1;
            }

            public void Move(int steps)
            {
                Moves++;
                Position = (Position + steps) % 10;
                Score += Position + 1;
            }
        }

        public record Spel(int positie1, long score1, int positie2, long score2)
        {
            public Spel Speel(bool speler1, int worp)
            {
                if (speler1)
                {
                    var positie = positie1 + worp;
                    positie = positie > 10 ? positie - 10 : positie;
                    var score = score1 + positie;
                    return new Spel(positie, score, positie2, score2);
                }
                else
                {
                    var positie = positie2 + worp;
                    positie = positie > 10 ? positie - 10 : positie;
                    var score = score2 + positie;
                    return new Spel(positie1, score1, positie, score);
                }
            }
        }

    }

}
