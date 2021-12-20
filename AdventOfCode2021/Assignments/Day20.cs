namespace AdventOfCode2021.Assignments
{
    /**

     */
    public class Day20 : IDay
    {
        public string PartA()
        {
            var input = InputHandler.ConvertInputToPadded2DArray(Day20Input.Input);

            var output = EnhanceImage(input, Day20Input.Enhancer, "0");
            output = EnhanceImage(output, Day20Input.Enhancer, "1");
            int count = CountLitItems(output);

            return count.ToString();

        }

        public static int CountLitItems(int[][] output)
        {
            var count = 0;
            for (int x = 0; x < output.Length; x++)
            {
                for (int y = 0; y < output.Length; y++)
                {
                    count += output[x][y];
                }
            }

            return count;
        }

        public static int[][] EnhanceImage(int[][] input, string EnhancerString, string outerChar)
        {

            var output = InputHandler.CreateInitializedDoubleArray(input.Length + 4, input.Length + 4);

            // Iterate over all output pixels
            for (int x = 0; x < output.Length; x++)
            {
                for (int y = 0; y < output.Length; y++)
                {
                    var mappedInputX = x - 2;
                    var mappedInputY = y - 2;
                    // Sliding 3x3 window on input
                    var binary = "";
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (mappedInputX + i < 0 || mappedInputX + i > input.Length - 1 || 
                                mappedInputY + j < 0 || mappedInputY + j > input.Length - 1)
                            {
                                binary += outerChar;
                            }
                            else
                            {
                                binary += input[mappedInputX + i][mappedInputY + j];
                            }
                        }
                    }

                    int lookupIndex = Convert.ToInt32(binary, 2);
                    output[x][y] = EnhancerString[lookupIndex] == '#' ? 1 : 0;
                }
            }

            return output;
        }

        public string PartB()
        {
            var input = InputHandler.ConvertInputToPadded2DArray(Day20Input.Input);
            int[][]? output = input;
            for (int i = 0; i < 50; i++)
            {
                output = EnhanceImage(output, Day20Input.Enhancer, i % 2 == 0 ? "0" : "1");
            }

            var count = CountLitItems(output);
            return count.ToString();
        }

    }

}
