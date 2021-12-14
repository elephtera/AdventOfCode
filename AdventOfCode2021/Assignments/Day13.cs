namespace AdventOfCode2021.Assignments
{
    /**
     
     */
    public class Day13 : IDay
    {
        public string PartA()
        {
            var input = InputHandler.ConvertInputToPointList(Day13Input.Input);

            //x over 655
            var duplicates = 0;
            foreach (var item in input)
            {
                if (item[0] > 655)
                {
                    var value = 655 - (item[0] - 655);
                    if (input.Any(i => i[0] == value && i[1] == item[1]))
                    {
                        duplicates++;
                    }

                    item[0] = value;

                }
            }

            return (input.Count - duplicates).ToString();

        }

        public string PartB()
        {
            var input = InputHandler.ConvertInputToPointList(Day13Input.Input);
            FoldX(input, 655);
            FoldY(input, 447);
            FoldX(input, 327);
            FoldY(input, 223);
            FoldX(input, 163);
            FoldY(input, 111);
            FoldX(input, 81);
            FoldY(input, 55);
            FoldX(input, 40);
            FoldY(input, 27);
            FoldY(input, 13);
            FoldY(input, 6);
            
            var output = new int[100,100];
            foreach (var item in input)
            {
                output[item[0], item[1]] = 1;
            }

            var result = "";
            for (int x = 0; x < 80; x++) 
            {
                for (int y = 0; y < 80; y++)
                {
                    result += output[y, x] == 1 ? '#' : ' ';
                }

                result += "<br />";
            }

            return result;
        }

        private void FoldX(IList<int[]> input, int x)
        {
            foreach (var item in input.Where(item => item[0] > x))
            {

                var value = x - (item[0] - x);

                item[0] = value;
            }
        }

        private void FoldY(IList<int[]> input, int y)
        {
            foreach (var item in input.Where(item => item[1] > y))
            {

                var value = y - (item[1] - y);

                item[1] = value;
            }
        }
    }
}
