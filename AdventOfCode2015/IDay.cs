﻿namespace AdventOfCode2015
{
    public interface IDay<T>
    {
        T Part1(string input);
        T Part2(string input);
    }
}