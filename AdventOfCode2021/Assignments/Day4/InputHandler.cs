namespace AdventOfCode2021.Assignments.Day4
{
    public static class InputHandler
    {
        public static IList<int[][]> GetInputAsList(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            var bingoCards = new List<int[][]>();
            var bingoLines = new List<int[]>();
            foreach (var line in lines)
            {
                bingoLines.Add(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(item => Int32.Parse(item)).ToArray());
            }

            var lineCount = 0;
            var bingoCard = new int[5][];

            foreach (var line in bingoLines)
            {
                bingoCard[lineCount] = line;

                lineCount++;


                if (lineCount == 5)
                {
                    bingoCards.Add(bingoCard);
                    bingoCard = new int[5][];
                    lineCount = 0;
                }
            }

            return bingoCards;
        }

    }

}