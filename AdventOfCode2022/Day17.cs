﻿using AdventOfCode2022.Day17;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day17
    {
        public int Part1(string input)
        {
            List<bool[]> field = new List<bool[]>();

            IDay17Shape shape = new Day17Line(field);

            var cnt = 0;
            while (true)
            {
                foreach (char c in input)
                {
                    switch (c)
                    {
                        case '<':
                            shape.MoveLeft();
                            break;
                        case '>':
                            shape.MoveRight();
                            break;
                    }
                    var moved = shape.MoveDown();

                    if (!moved)
                    {
                        // next shape
                        shape = NextShape(shape);

                        cnt++;
                        if (cnt == 2022)
                        {

                            return field.Count;
                        }
                    }
                }
            }
        }

        private IDay17Shape NextShape(IDay17Shape shape)
        {
            var field = shape.NewHeight();

            if (shape is Day17Line)
            {
                shape = new Day17Cross(field);
            }
            else if (shape is Day17Cross)
            {
                shape = new Day17Hook(field);
            }
            else if (shape is Day17Hook)
            {
                shape = new Day17Vertical(field);
            }
            else if (shape is Day17Vertical)
            {
                shape = new Day17Square(field);
            }
            else if (shape is Day17Square)
            {
                shape = new Day17Line(field);
            }

            return shape;
        }

        public long Part2(string input)
        {
            List<bool[]> field = new List<bool[]>();

            IDay17Shape shape = new Day17Line(field);

            var rocksCount = 0;
            var rowSourceCount = 0;
            var iterationsRest = -1L;
            var iterations = -1L;
            var rowDiff = -1L;
            var rocksSourceCount = 5000;
            while (true)
            {
                foreach (char c in input)
                {
                    switch (c)
                    {
                        case '<':
                            shape.MoveLeft();
                            break;
                        case '>':
                            shape.MoveRight();
                            break;
                    }
                    var moved = shape.MoveDown();

                    if (!moved)
                    {
                        // next shape
                        shape = NextShape(shape);
                        rocksCount++;
                        if (rocksCount == rocksSourceCount)
                        {
                            rowSourceCount = shape.Heights().Count - 1;
                        }

                        if (iterations < 0 && rocksCount > rocksSourceCount + 1 && IsDuplicate(shape.Heights(), rowSourceCount))
                        {

                            var rowCount = shape.Heights().Count;
                            rowDiff = rowCount - rowSourceCount;
                            var countDiff = rocksCount - rocksSourceCount;

                            iterations = (1000000000000L - rocksSourceCount) / countDiff;
                            iterationsRest = (1000000000000L - rocksSourceCount) % countDiff;
                        }

                        if (iterationsRest > 0)
                        {
                            iterationsRest--;
                        }

                        if (iterationsRest == 0)
                        {
                            var heightDiff = (rowDiff * iterations);
                            var height = shape.Heights().Count - rowDiff;


                            return height + heightDiff;
                        }
                    }
                }
            }
        }

        private static bool IsDuplicate(List<bool[]> list, int duplicateSource)
        {
            var index = list.Count - 1;
            for (int i = 0; i < 3; i++)
            {
                if (!list[index - i].SequenceEqual(list[duplicateSource - i]))
                {
                    return false;
                }

            }
            return true;
        }

    }
}
