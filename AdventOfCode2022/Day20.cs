using System.Runtime.ExceptionServices;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day20 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            var order = 0;
            var inputData2 = inputData.Select(data => ((long)data.Item1, order++)).ToList();

            var size = inputData.Count;
            var i = 0;
            //while (i < size)
            //{
            //    var value = inputData[i];
            //    if (value.Item2)
            //    {
            //        i++;
            //        continue;
            //    }

            //    inputData.RemoveAt(i);
            //    value.Item2 = true;
            //    var location = newLocation(i, value.Item1, size - 1);
            //    inputData.Insert(location, value);
            //}
            Mix(inputData2, size);

            var result = 0L;
            var indexZero = inputData2.IndexOf(inputData2.Find(data => data.Item1 == 0));

            result += inputData2[(indexZero + 1000) % inputData2.Count].Item1;
            result += inputData2[(indexZero + 2000) % inputData2.Count].Item1;
            result += inputData2[(indexZero + 3000) % inputData2.Count].Item1;
           
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            var order = 0;
            var inputData2 = inputData.Select(data => (data.Item1 * 811589153L, order++)).ToList();

            var size = inputData.Count;
            for (int j = 0; j < 10; j++)
            {
                Mix(inputData2, size);
            }

            var result = 0L;
            var indexZero = inputData2.IndexOf(inputData2.Where(data => data.Item1 == 0).First());

            result += inputData2[(indexZero + 1000) % size].Item1;
            result += inputData2[(indexZero + 2000) % size].Item1;
            result += inputData2[(indexZero + 3000) % size].Item1;

            return result;
        }

        private static void Mix(List<(long, int)> inputData2, int size)
        {
            for (int i = 0; i < size; i++)
            {
                var value = inputData2.Find(data => data.Item2 == i);
                var currentLocation = inputData2.IndexOf(value);
                var location = newLocation(currentLocation, value.Item1, size - 1);
                inputData2.Remove(value);
                inputData2.Insert(location, value);
            }
        }

        public static List<(int, bool)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None).Select(line => (int.Parse(line), false)).ToList();
            
            return lines;
        }

        public static int newLocation(int currentLocation, long value, int maxSize)
        {
            long newIndex = currentLocation;

            if (value > 0)
            {
                newIndex += value;
                newIndex %= maxSize;
            }
            else if (value < 0)
            {
                var rawIndex = (maxSize + newIndex + value) % maxSize;
                while(rawIndex < 0)
                {
                    rawIndex += maxSize;
                }

                newIndex = rawIndex;

            }

            if(newIndex == 0)
            {
                newIndex = maxSize;
            }

            return (int)newIndex;
        }
    }

}
