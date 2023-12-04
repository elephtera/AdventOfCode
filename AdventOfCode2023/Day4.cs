namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day4 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            ScratchCards = inputData.Select(card => new ScratchCard(card)).ToList();

            var result = ScratchCards.Sum(card => card.Points());
            return result;
        }

        public List<ScratchCard> ScratchCards { get; set; }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            ScratchCards = inputData.Select(card => new ScratchCard(card)).ToList();

            for(int i = 0; i < ScratchCards.Count; i++)
            {
                var winCount = ScratchCards[i].WinCount;
                var copies = ScratchCards[i].Copies;
                for (int j = 1; j <= winCount; j++)
                {
                    ScratchCards[i + j].Copies += copies;
                }
            }


            var result = ScratchCards.Sum(card => card.Copies);
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);


            
            return lines;
        }
    }


    public class ScratchCard
    {
        public ScratchCard(string card)
        {
            var cardInfo = card.Split(':');
            this.Id = int.Parse(cardInfo[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1]);

            var sets = cardInfo[1].Split('|');
            var winning = sets[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var scratched = sets[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            this.Scratched = scratched.Select(int.Parse).ToList();
            this.Winners = winning.Select(int.Parse).ToList();
            this.WinCount = Scratched.Count(number => Winners.Contains(number));
            this.Copies = 1;
        }

        public int Copies { get; set; }

        public int WinCount { get; set; }

        public List<int> Winners { get; set; }

        public List<int> Scratched { get; set; }

        public int Id { get; private set; }

        public int Points()
        {
            if (WinCount == 0)
            {
                return 0;
            }

            var result = 1;
            for (var i = 1; i < WinCount; i++)
            {
                result *= 2;
            }

            return result;
        }
    }

}
