﻿namespace AdventOfCode2023Tests.Input
{
    public class Day21Input : IDayInput
    {
        public string ExampleInput => @"...........
.....###.#.
.###.##..#.
..#.#...#..
....#.#....
.##..S####.
.##..#...#.
.......##..
.##.#.####.
.##..##.##.
...........";

        public string Input => @"...................................................................................................................................
.#....#......#.#......#...#...##.....#.#.#....#.##....#...#.............#.#......##..#.......#.............#......#...#..#...##....
..#...#.#.#....####.....##.........................##.#..#...............##.......#....#.....#........#...#.....#.......#..........
.#.......#......#.#.#....#..............###...#................................................#....#.#..............#.............
................#....#....#..........#........#....................................##....##........#.....#.#....................#..
.................#..........#...........##...#......#.#.#..................#......#.........##....#...#.....#.#........#..#........
..##...#..........#...#..##..#.............#................................##......#.....#.........#..........#.#.....##.#.#......
.#.......##.....#....#...............#....##.......................#..................................#..#.........................
..#.#.....#........#.........................#................#..............#.................#.......#...#....#.#..#....#..#.....
.......##.........#..............#.........##..#..............#.....#....................#.#..........#..#.#.#....#.......#......#.
.#......##..............#..........#..........#.....................#.##..........##.....#...#...#......#...#......#..#..........#.
....#.........##......#.#.#...#................#.............#..........................#..............#...............#........#..
........##......#..##.....#..#..#.............##.........................#.......#.###....#..#................#....................
...#..#.#..........##...#..#....#...........#........................#...#...............#....#.....#......#....#....#....#........
.........#.......................#.....#..##............##.#.#.#...#.....#.#...........#.#............#..##...##..............#....
.#.#..#.#......#.........#...#..#.......#.#..............##.......##...................#....#........##....##..........#.........#.
...................#.....#..#.....#....###...............#........#......#..#.........#.##.#.#......##..#.....#.#...............##.
.#..#.........##....#...#..........##...#..............#...#........##...#...............#...............##.....#..................
....#.......#...................#...................................#..#...#..#..................#.##..###.......#..#........##....
.#.......................###.....#......................#.#.....#...#..##...#.#...........#.....###............####...........#.#..
...#.........#........................#..............#..#.#..............#................#......#..#.##...............##..........
.....#..........#......#....#....................#.#..........#.#...........#.#.##.............#..#......#..#......#...##...#......
...#..........#.............#.....................#......................#.......................#.............#.....#.............
..............................#..##...................#...#...............#.#....#....................#.......#..............##....
.#...##.....#.....#..#...#........#..............#.#...#.....#.......#..##..#.................#......................#..##.........
....#....................#......#...#...........#.........#.......#..#.#...........#......................................#...#....
..#.#.........##.....#........#...............#.##......##...........#........#.......................#..#.....#...............#...
..##............#........#.....#..#.......#......##...#.#......#......##.............#..........#..#........#..#...............#...
........#...##.......#....#...............##....#.....#.#...#....................#...#...........#...#.....##..........#...........
.#.#.....................##...#.........#............#..#.......#.#....#....#...#..#....#.............#.#.........#................
...........#..........#..#.#...#....................#.................#.##...#.......#.#......................#..#..#.....##.......
...#...#.......##.....#...##...........#............#..................#..#...#.#...#......................#....#...#..........#...
....#..#.....................#.......##.###......#............##....#..#.......##..........##...............##....#...#.........#..
.................#...#.....#..........#...........#..#............#..#...#..#..#....#.#.......#..............#.#......##...........
...#.....................#.........#.#..............#....#....###....##......#......##..................#...........#......#.......
..#..#............#.#..#..........#...#....#.............#......#......#...#........#.#.###..##..........#.#.........#...#..#....#.
.........#............................#.....#.....#...#...#...##......#.......#.#.#....##.#....#.#.......#...#..#.#.......###.#....
.#....#.#......#.......#........##....#....#..#..#.##........#....#.........##............#......#..............##...#..........#..
..#..#..#....#.......#.#.......#...........#..........#.......##..#..........#............#.......................#...#............
........#.#........#...............##..#....##...##....#..#....#........#.................#..................#.##.#.......##.......
..........#....###.##.............#.#.#......#........#........#....#.............#.##........#......................#.#.......##..
........#........#.#..........##..#.#....#.........##..........#..........#..........#....#.#.........#.......#.....#...##......#..
...............#..................#.#.##......#..#..##....#..........#...#......#..#..#.....#...##...............##............#...
............#.................#.........#....#......#.............#........#.......#.#...#........#..............##.........#....#.
...#....#..#...............#...........#.#.....#.......#.................#.#........#..#.#....#.......................###..........
............#.............#......#...#..#..#.......#.###..###...............#...........#...........##....................##.##..#.
........................#.#..#..#..##.#.#....#......#..#..#.....#.#..............#......#..........................................
.#.#.....................#..#...##..........##.#..#..#.##..#................#..##....#........#....#.#.#.........................#.
...#.....................#.....#...#...#....##....#...............................#...#.#................#..#...........#..........
...#....#............#.#.........#.......##.......#....................#.........#......#...........#....#...#.............#..##...
..#......................#.......#....#.#....##....#......#..........#....#.#.##..#.#.....#...##...#.##..###...........#...#....#..
..................#..........#.........#........................#.##...............#...#...#.#............#........................
........#.................#.....#..#.............#...#.#.##.......#.............#.#........#...#..#...........#..................#.
...#................#.#.#.........#.......#....#.........##........##...###.............#..#.#...#.................................
.....#.............##.##...##.............#.......#.#........##......#...#.......##.#.....................#......#.#.......#..##...
.........................#.............#...................##...#.......#.....#.........#..#......#.#.#........#.#..............##.
.............#......#..................#...............#...........#...#..........#.....#.....##....#.#...#...#.#.............#....
..............#....#............##...##....................#............#....#.##....#.##..#.#....#............#..#...........##...
........................#..................##..#.......#......#....#..............###........##.........#...#.....#.#............#.
..........#.............#..#.............#...........#..##........#........#..#................#......................#.........##.
.............#..#.....#..#....#...#.....#....#.#.....##...............#......................#.............#......#...#............
..........#...................#.......#............#....#.........#.............#..............#.#..........##.#........#..........
.............................#...........#...........##..#.#......#....#.....#....#..#...............##.#.....#...........#........
........................#.#.#.......#.##.....##......#....#..........##.........#...............#.#..#.##.....#....#..#............
......#....##...............#..#....#...#.....#......#....#.............#.#........#.#.....#.#.....###.#.........#...#...#...#.....
.................................................................S.................................................................
.....#.#...#...............#.....##......#..........#....#...............#.......#..............#.#.................#..............
................##.#..#..........#.#...#......................#..............#...........#...#..#.....##.........#.................
.......#.#........#.#...........#........#...........#..#.#.............#............#..........#.....#...................#........
..............#..#.................#..#........###..#.......................##.##..........#....#..#...#.##..#.#.###....#..........
.............#.....#.....#.........#..#.......#.......#......#..........#.........#............................#.....#.............
..#.......#....##.......#................#.#...........#...#..###.#........#........#.#...#............#.......#.#...#.............
............#.........#..#....#........#...#.........#...#............#............#....#..#.................#.#......#........#...
...#.............#....................#.............#..............#..#..................#...#...#.#....#...#.##....##..........#..
....#........#..##..........##.....#.....#....................#..........#...........#.#......##................##...........#.....
......#.......#..#..#...##...#................#.#.......#......##.#......#..#..............#....#.....#..#....#.#...#...........#..
.....#.......................#..#..........#..........#........#......#...#..#..#...........................#......#..........#..#.
.....##...........#....#.........#.........##...................#.#..##.#..#..##.#..##...........#......#....#...##.............#..
.#......................#.#..##..#...#.........#.........##.......##.....##.............#.........#.......#...................##.#.
...................#....#..###..#...#.....#......#..............#.........#..................##.##.................................
......#....#.............#..#...#..##.#...#...#......#....#...........#....#...........##....#..#...#.....#......................#.
...#...#............#....#..#.#....................................#..#.....................#....#.........................#.......
.......#.............................#............#......................#...#......#.......###.........#...................#.#....
.......#................##...#...........##........#..#..#..............#.....#..............#.....#......#..........#...#.........
......#.....#.................#....#...........#..........................#..#.##.#.##.............##.#............#....##..#......
....#.....#.......................#..............#......#..........#.....##..#.....#.........#..........................#.#..#...#.
...#...........#.........#......##...#......#......#....#....#..#......#..#........#..#......................................#.#...
.....#...##.....................#.............##..#....#.#..#...#...#....#.........#.......#.....#.............................#...
..............###.##...........#..#.##.....#.#..#....#..............#..#..........................#.##.#...........#...............
.......#.........................#................##.#.....##........#.....#.#......#..........................#...........#...#...
........##...#..#....#...........#....#.........#......#..##..#...........................#...#..............#........#......#.....
...#.....#...#.......#..................#.....#...........#................#......#........#.#.#.......................#...........
.#..#..#.............###........................#.......#....#.........#.....#........#..#.#....#..........#...#...................
......................#...........###........#........#...#.........#..................#...#.....##.........#.............#..#.#...
...#.##.............####.........##..#...#........................................#..........#...................#.##..............
......#...#.....#..................##........#...........#.#...#....##.......#......#.....#..#.............#..#.#.##....##.........
.......#..................#........#........#.........##.#............#.....#....#....#..##..............#.......#.#....#..#.......
..........#...........#..................#...........#.....#......##........##.......#.........................................##..
...#......#................#...........###..#.........#.....##..#.#...............#....#.##.#........#...................#.........
........#...#..##...#.................#......##.......##.....#..#.........#.#....#.......#...........#..#...................#...##.
........#...........#.##..............................................##...#..............##...........#..#...###........#.....#...
....#.......#....#......................#.#.#......................#....#.........#.......................#....#.#.##...........#..
.#................#.#.#.#.................#.......................##.#......#.....#..#..............#....#...#.#...#..#........#...
..#.........#.......#.....#.....##.............#.....................#...........#...#.................##.........#....#.........#.
....#..#..............#.#...................#...#......#.##..........#.........#..#.......................#..##....................
........#..#.#.........#...##.................#......#...#..............#.....................#...#.....#..........#....#...#.#....
.#.....#...#..##.......#...#.......#...............................#..#.....#................##..##.......#.......#..#..#........#.
..............................###..............................#....#..#....#.#..#.............#...#..........#.#.#.........##.....
.......#........#.#................#...#.........#.##.#....................#...................#..#....#...#.....###.....#.#.......
.........#.#............#......#......#.#.........###.#.#..#..#.#....#...###....#............#.....................#......#....#...
..##...#...#.#...........#.....#...#.......................................#..........................#.........#..##.........#.#..
.....#.....#..............#.......................#.........#...#..#.....##................#.#.......#..#...#.#.#..............#.#.
.........#....#.#...#.....#......#.#.................#...#...#.........................#..#....#...#.........#...#...#......###....
.....#.#..#........#.....##..#.##.....##............................#..#.....#.........#.....##.#..##...#.#.....#.............#....
.....#..................#....###.#.#.....#........................#...##....#.........#..........................#....##.#....#..#.
...###........##....#....#...#.......#....#..#.........##................#..........#........##.##.................#......#........
....#.......##..#.......##...#.........###....#........................#.#.#..................#...#.#.........................#....
..##..................#..#........##...#...#..#..............#.......#..............##.......#.........#..#.....................#..
.......#.................#....#.#........###..##..................#...............#......#.#............#...#.............#........
.#.#..........###.......##..#.#......#..#..#.#...#.............##.#.#...............##..#....#..#..............#.............#.....
.....#.#.....#..#..................###...............................................##............##..............................
...........#......#..##.#..#...#...#.#.....##.#.....#........##.................#..#..#....#.....#.....#......#.#..................
....#....................#...........#.......#..#.............#...#...................##............#..............##..............
.........#.#........#..#....#..........#.....#........................................#........#...#..#....#.......#.........#.....
...#............#.....#....#....#.....#....#....#..#................................#..#....#.........#.........#.#...........#....
.............#.......#...........#..#.....#.....................................#.#...#...#........#..##..#.....#.........#........
......#.......#.................#.................#.#.#.................................#........#...........#....#.#..............
.##.##....................#...#.#.............###........#.................#..#.....#..#.......#..............#..#.....#.##........
........#........#.............#..#...#.#........#..#.....#.............#.....#...#....#...###....##..#.....#..#.....#.............
..#.#...........##.....#.................#....#.....##....................#......#..........##....#..#..#...#..#.............#.....
...................................................................................................................................";
    }
}
