namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day7 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var hands = inputData.Select(data => new Hand(data)).ToList();
            hands.Sort();

            var rank = 1;
            var total = 0L;
            foreach (var hand in hands)
            {
                total += hand.Score * rank;
                rank++;
            }

            return total;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var hands = inputData.Select(data => new Hand(data, true)).ToList();
            hands.Sort();

            var rank = 1;
            var total = 0L;
            foreach (var hand in hands)
            {
                total += hand.Score * rank;
                rank++;
            }

            return total;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

    public class Hand : IComparable
    {
        public override string ToString()
        {
            return Cards + " " + Score + " " + Type;
        }

        public Hand(string data, bool withJoker = false)
        {
            var splitted = data.Split(' ');
            this.Score = int.Parse(splitted[1]);
            this.Cards = splitted[0];
            this.WithJoker = withJoker;
            this.Type = CalculateType();
        }

        public bool WithJoker { get; set; }

        public HandType Type { get; set; }

        public string Cards { get; set; }

        public int Score { get; set; }

        public HandType CalculateType()
        {
            var dist = Cards.Distinct().ToList();

            var distCount = dist.Select(distCard => Cards.Count(card => card == distCard)).ToList();

            if (dist.Count == 1)
            {
                return HandType.FiveOfAKind;
            }

            if (dist.Count == 2)
            {
                if (this.WithJoker && dist.Contains('J'))
                {
                    return HandType.FiveOfAKind;
                }

                if (distCount.Any(count => count == 4))
                {
                    return HandType.FourOfAKind;
                }

                if (distCount.Any(count => count == 3))
                {
                    return HandType.FullHouse;
                }
            }

            if (dist.Count == 3)
            {
                if (distCount.Any(count => count == 3))
                {
                    if (this.WithJoker && dist.Contains('J'))
                    {
                        // upgrade to four of a kind due to joker
                        return HandType.FourOfAKind;
                    }

                    return HandType.ThreeOfAKind;
                }

                if (distCount.Count(count => count == 2) == 2)
                {
                    if (this.WithJoker && dist.Contains('J'))
                    {
                        if(Cards.Count(c => c == 'J') == 2){
                            // if J is one of the pairs; upgrade to four of a kind
                            return HandType.FourOfAKind;
                        }

                        // if J is not one of the pairs: upgrade to full house
                        return HandType.FullHouse;
                    }

                    return HandType.TwoPair;
                }
            }

            if (dist.Count == 4)
            {
                if (this.WithJoker && dist.Contains('J'))
                {
                    return HandType.ThreeOfAKind;
                }

                return HandType.OnePair;
            }

            if (this.WithJoker && dist.Contains('J'))
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }

        public int CompareTo(Hand that)
        {
            if (this.Type < that.Type) return -1;
            if (this.Type > that.Type) return 1;
            // Equal
            for (int i = 0; i < 5; i++)
            {
                if (CardToInt(this.Cards[i]) < CardToInt(that.Cards[i])) return -1;
                if (CardToInt(this.Cards[i]) > CardToInt(that.Cards[i])) return 1;
            }

            return 0;
        }

        public int CardToInt(char card)
        {
            switch (card)
            {
                case 'A':
                    return 14;
                case 'K':
                    return 13;
                case 'Q':
                    return 12;
                case 'J':
                    if (WithJoker)
                    {
                        return -1;
                    }
                    return 11;
                case 'T':
                    return 10;
                default:
                    return card - '0';
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj?.GetType() == typeof(Hand))
            {
                return CompareTo(obj as Hand);
            }

            throw new NotImplementedException();
        }
    }

    public enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }
}
