using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day6 : IDay<long>
    {
        public long Part1(string input)
        {
            var xCoord = 0;
            var yCoord = 0;

            var inputData = ProcessInput(input);

            // find start
            for(var y = 0; y < inputData.Count; y++)
            {
                for(var x = 0; x < inputData[y].Count; x++)
                {
                    if (inputData[y][x] == '^') 
                    {
                        inputData[y][x] = 'X';
                        yCoord = y;
                        xCoord = x;
                        break;
                    }
                }

                if (xCoord != 0 || yCoord != 0)
                {
                    break;
                }
            }
            
            var direction = 0; // 0=up, 1=right, 2=down, 3=left
            while (xCoord >= 0 && yCoord >= 0 && xCoord < inputData[0].Count && yCoord < inputData.Count)
            {
                var nextX = direction == 1 ? xCoord + 1 : direction == 3 ? xCoord - 1 : xCoord;
                var nextY = direction == 0 ? yCoord - 1 : direction == 2 ? yCoord + 1 : yCoord;
                if (nextX < 0 || nextX >= inputData[0].Count || nextY < 0 || nextY >= inputData.Count)
                {
                    break;
                }

                if (inputData[nextY][nextX] == '#')
                {
                    // will turn right
                    direction = (direction + 1) % 4;
                }
                else
                {
                    xCoord = nextX;
                    yCoord = nextY;
                    inputData[yCoord][xCoord] = 'X';
                }
            }

            var result = 0;

            foreach(var line in inputData)
            {
                foreach (var c in line)
                {
                    if (c == 'X')
                    {
                        result++;
                    }
                }
            }
            

            return result;
        }

        public long Part2(string input)
        {
            var xCoord = 0;
            var yCoord = 0;
            var xOrg = 0;
            var yOrg = 0;

            var inputData = ProcessInput(input);
            var xMax = inputData[0].Count;
            var yMax = inputData.Count;

            // find start
            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    if (inputData[y][x] == '^')
                    {
                        inputData[y][x] = '^';
                        yCoord = y;
                        xCoord = x;
                        yOrg = y;
                        xOrg = x;
                        break;
                    }
                }

                if (xCoord != 0 || yCoord != 0)
                {
                    break;
                }
            }
            var result = 0;
            var resList = new List<(int x, int y)>();
            var direction = 0; // 0=up, 1=right, 2=down, 3=left
            while (true)
            {
                var nextX = direction == 1 ? xCoord + 1 : direction == 3 ? xCoord - 1 : xCoord;
                var nextY = direction == 0 ? yCoord - 1 : direction == 2 ? yCoord + 1 : yCoord;
                if (nextX < 0 || nextX >= inputData[0].Count || nextY < 0 || nextY >= inputData.Count)
                {
                    break;
                }

                if (inputData[nextY][nextX] == '#')
                {
                    // will turn right
                    direction = (direction + 1) % 4;
                }
                else
                {
                    // check if a blockade on the new position would result in an infinite loop
                    if (WillItResultInAnInfiniteLoop(inputData, xOrg, yOrg, 0, nextX, nextY))
                    {
                        resList.Add((nextX, nextY));
                    }

                    xCoord = nextX;
                    yCoord = nextY;
                }
            }

            resList = resList.Distinct().ToList();
            result = resList.Count;

            return result;
        }

        public static IList<IList<char>> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
            StringSplitOptions.None);

            var result = new List<IList<char>>();
            foreach (var line in lines)
            {
                var charList = line.ToList();

                result.Add(charList);
            }

            return result;
        }

        public bool WillItResultInAnInfiniteLoop(IList<IList<char>> inputData, int xCoord, int yCoord, int direction, int newBlockX, int newBlockY)
        {
            var visited = new HashSet<(int x, int y, int dir)>();
            while (true)
            {
                if (visited.Contains((xCoord, yCoord, direction)))
                {
                    return true;
                }

                visited.Add((xCoord, yCoord, direction));
                               
                var nextX = direction == 1? xCoord + 1 : direction == 3? xCoord - 1: xCoord;
                var nextY = direction == 0? yCoord - 1 : direction == 2? yCoord + 1: yCoord;
                if (nextX < 0 || nextX >= inputData[0].Count || nextY < 0 || nextY >= inputData.Count)
                {
                    return false;
                }

                if (inputData[nextY][nextX] == '#' || (nextX == newBlockX && nextY == newBlockY))
                {
                    // will turn right
                    direction = (direction + 1) % 4;
                }
                else
                {
                    xCoord = nextX;
                    yCoord = nextY;
                }
            }
        }
    }
}
