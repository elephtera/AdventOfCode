﻿namespace AdventOfCode2022Tests.Input
{
    public class Day23Input : IDayInput
    {
        public string ExampleInput => @"....#..
..###.#
#...#.#
.#...##
#.###..
##.#.##
.#..#..";

        public string Input => @"#.#.####.###...###..#....#.....##.#.#.#..#.#.#######...##...#..###..#..
#..##..####.#.#....##..#...##.#.#.######.....##.#.########....####...##
.##.#....##.#..#####...#.#.##.....#...##..##...#####.##.#########...#..
..##.###.#.###.#.#.#.#...#..#.###..#.....##.....#.#.......####...#.##..
..#####...##...#...###.##..###...#..#.##...##...#.#.#.##...##.#..##...#
##..########...###.#.#####.#..##..######.#....#....##.#..####..#####.#.
.....###...#.#.###.###......#.#.#...#.##.#..##.#.#...#...###.#...#.#..#
..##......#..##.#.#######.##.....###.....###..#..#..#.##.#....#.#..###.
####..##..###.####.#.#.##...#..####..#...#.######..##....#.#.#..#######
####.#..###########.....#..###.#..#...##.#.####.....##.##..#...#..##...
#.##.##.#...#.....#..#.###.#.#.#..##.#####..#..#..###.###.###...###.##.
.#..#.######...##...##.#.###..###.....###.#..###...##.#.###....##.####.
###.#..##.....####.###.##..##.##..#...#...#.#....#.#.##.#..#.#...#.#.#.
...####..###.#..#..###..#...#.#..######.##..#....##.#######.....#.#..#.
#.#.#.##.#.#.##..##...#.#...#...##.#.###.#...#..#..#.##..##.######...##
.#.#...#.#.#.#..#.#......#.##########..###...##.#..#####.##.###..#.#.##
.###..#..####..##......#..#..#.##...##.#.#....##.#..#.#..##.#...#.##...
#.#.......###.#.###.##.##.##.......###...#....#.####.##.#..#.##.##.####
.######...#.###.###.#.#.##.##.#.#.......##.##.##.###.##......#.#..#.#..
..##.##..####.#..##.#.#....#.#...#..#....###.##.#.....##.#.##.####.###.
....##...##.####.#....##.....#.####..#.####.#.##..###..##.##..#..##..##
..##.####...##.#.#.#..#.#..#.....####..###..#.###...#.#####..##......##
###..#.#####.###.#..###.#....##.##.....#.#.###.#....##...##..#....##.#.
#.##.#####..##.###.#......#.#####..#....#..#....####.#######.##.#######
.##.##.#..#...##.#.##.#.###.#.##.########.##....#.##...####.#.####.###.
#.#.##.######.#...####.###.#.#..#.####....#...####.####.....###.##.####
..##..##......#.#.#.#..##.#.#..#.##.####.#.###...##........#.####..##..
#....###.##..###....#.##.#..#.#####.#..##.###.##.##...#.###......#.#..#
.##.##.....#.#.##.#.##.###.##...#.#.###.#.####.###........#.#..###.#..#
.#...##..##.#.#.####.....#.#..#..#.#####..##..#####.######..#....######
##.##.##.###.#..#..#.###.#...##.##.#..###....##.#..#.##.##........###.#
...#..###.#####....#....#..#.#...#...#...#.#...##..##.#.#.##.###..#.#.#
###.#####.#.###..#.#...#.#.#######.#..##.#.....##.#..##.......#.##.#.#.
#..#.##..##.##....#..#..##...###.#.#....#...#.##.#.##.#...##.....##.##.
###..#.#.#.......###.####...###...##.....#..#............#..###..#.#...
.....#..#..#..###.#.##.###.#.#..##...##...#.#.#..#.###.##.##..#####.##.
...#.#..#.###..#....#.##..#.#..##.#...#.####.#.#.....#..#.##..###.#####
##.##..#.#.###.#.#.#....#.#...###.#.#.#.#..#.#.#..##..##.####.##..##..#
..#.....#.#...#..#.#...#..##.....#####..#.....#..##..#..######..#......
.##.....#.#...##....#....####..#.#..###.#.##.#####.....##..##..#.###.##
....###..#...##..###.##..#..#....#.###.#.##.....#....#.###.##.###.#....
........#.####.#.#.###..#..#.#.###......##.##.##..#.#..#.#...##.#.....#
..###.##.#..#.#....#.##......#.#...#.#.###.##.##.#......#.####.##.##.#.
#...#####..###.###...#...##..#.#.###..#..####....#.#.#####.#.########..
#####.....##..#...##..###......#.##..#.#..##.###.###..#.##..#.#.#......
#....#.##.##.#.#..#.####.###..#.###.###.#.#..#.....#####.####...##.####
##.####......#..#.#..#..#....##.##....##.##.##.####.....#..#.###.##.#..
.###...#.#....######..#.#.#......#..#.#...######..#.##.##...#.##.....#.
#..#########....##...##.#..##.#..##.#..#####.......#..##.###....###..##
#...#.#.#...#...##.##...#####...#####.....##...#..#.##..#####.##....#.#
##..#....#..###.##..###..##.##..###...##.#.##.#...#...#.##.##.##..##.#.
#.#.#...##.##..#...###.#.....#....#....##...#.##...#.#.#.##.#####..###.
#####....##.####.#..##...##..###....#....#.##.#..#######..###..###.....
#.####..####.#.##.##.#.#####.#.##..#.....#.#..##............##..#...###
.######...#..###.###.##..#...###..#....#.##.....###.#....##..##.#####.#
###..#......#.##.#.#..#.#....###.##...#.##.#..##.#.#####....###....###.
#######.#.#....####....##....##.####....#.#####.##.####.###.###..#.##..
.#..##...####.#.#...###.#.##...####...#.##..##...#..##.#####..##..##..#
#...#...#..###.#.####.#####.####..#....#....##.....#.#####.#.#....###.#
#..##.#.#.....##..#....##..#.#...##...##..#..####.##......#...#.#...#..
###..#####...#..##..##..##...###...###.###.##...#...#####.####.####.#.#
.#...#.#..##.#....#.###..#....#.......#.##..##.###..#.####..#.#.####...
.#..##.#.....##.###..##...##.#.####...#.#..#..######..###..##..##..###.
...#.###..#.##....#####..######..#..##.######..#.#..#....###.....##....
.##...#####..##..#..#.#.........#...##.##..#.#..#.##.##........###..#..
##.##..#...###.#####...#...##..#.#....#...##..##.##...#.#.##...#.#.#.#.
..#####.#..###.....##..#..##.##..###.#.##.#.#.#.###.######..####.##.###
####.###.#.##...#.###..#########.#...##..#..#..#.###.###.####.###....#.
#..###.####..##.#.##..#...#.#.#.##...#..#.#####.......#.##.#....#..####
##....#.##.######......##.#####.#....#.##....#####.#.#...##..#.#.#.#..#
..##.##....##.###......#..##.###..##.##.####....#..#.##.....#.##.###.#.";
    }
}
