﻿namespace AdventOfCode2023Tests.Input
{
    public class Day16Input : IDayInput
    {
        public string ExampleInput => @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";

        public string Input => @"\..\/|../.-..-....................................|.-..-.......|...--........-......\...\........\............
..\...|.\.........|..|.....................|.....\.........................................-.......|-..../....
......\\\........\............-........\............/.....-|..............|....................\....-.........
................................-..\-.........\.-....-.............................|........\...............\.
................\/..........\................/...........................|./......|...........|...............
......../....|..-........|./..../......................../............./-/....-.....................\.........
../..|/.|.............\..\\.............../...................../..............|....................-.........
...........................\..\......./................/....\......................-........|................/
..........|../.....|./........-.\......../.................../........................|..../......|...........
.........../...../....................-....|.-..........-.........\../..\...\../..|../........|.....\.........
.../........\/....../.......................-......................-|..../.../...-.......-.../................
..........|.....-.././.....|../.\.....................-.......................................-....|.|...|....
............./...-...................|.-...|.-........-.......|..............|......-.........................
........\\..\.................\........-............/|......-.......|........................./.......|.....\.
....|..../..\........................./....|/......../.......-..........|/..........................-.........
.............\...............................................\......\........./.....-..../..\......-...-.....|
.........../.................../...........-......../|.............../.................\../...\...............
................/-.......-......................./....................................-..................|...\
......................................|..................-....\...............|.../.........|..|..|...../.-...
.\......-./..-....\.....\............./...-......\........................-./..//.......-........|............
......|...-...\........|........|........./.....\|.....................\........\.........-....\.....|....|...
....................|.............................-..........................|..........-..../........|.-.....
.-.-.....................|........./.....\........./....\|/..\...........\......./...-.............\.|.../...\
............/...................................................../../................./.-....................
................../.........\.|........./............|........|...............................................
.\............/.-..-......|.....|....-........\..............................|....-.|.........|......./......\
....|..................................-..-......-.............-..-/..........................-........|../...
-..|-.../................-...............|.......-\.........-....../.\..............///....\............../...
.........../......................|........-....-...|....|...-...|......|.................../........-........
........|.........../...............\......................|..-.-.....................|.........-.............
./............/..\......\.....|..\...|........................-.../.......//...|..............\..../\.........
.-...|.-...............\......../.|.../............|.........|../|....././......./........||.\...-............
................-........-/.............../.....-.\/......................../....................\............
....\............./..../.........................-.............\...\.../........../................-/...-...|.
......................................|......./.-....../...................../.....|..........................
.|..................\..........\....-.......-......\..|.-.................-...\.............|......../........
..|...........|./.................\.........................|.........................-\......................
../.../.........../.......-.......-/............./..............\........-..........-..|...\.\/.-..|..........
............./..............-\../..|..\.....................................\............-........-.........|.
.....|-.................|............|/...............................\............/...\.........\............
........\.....\.....\...........\..........-...........................\.......-.......................\../...
........./........|..............................-......\.........................|..|.-.....|....../.........
............-.......\............/...\./.............../\.\..............|............\.../............\......
...../.....\..............|...............................................-......................./...........
...../........|.....................-.....................|.../.....................\.../...../..............\
..........|.........-....................-\............-.....................-...................\..../.......
.............\.........|\..........................\........-.....|.\..............|.......-..\..............\
............./\..\\............|...-/..........-...................//.\.......\................../..........|.
........................|.|.....|......\...-.-...\.......|...|...........\.-.............|......|............|
.....|......|.......\.........\................\\......|......................\.............\..\..............
......................|....../.........|........./.......-...\..............\...||......../..................|
....|..\.-.................|....\.............../.....-......../......................../....../..........|...
./.......|............././../.-...-...........\\..|...\......................../........|....-.\..............
........................|.......|......................-...../....................................../.\.......
....\..-.....|......................\...............|...|\.......|....../......|....\.-../.............../....
....../........-\...|.............|.......................\..................-.........\.......-.....-.....-./
.......|....\.............|.......|....\.../........................|.........................................
.....|.........\.../....-......./......\.........................../................-.................\.......
..|../.../.|.....-../...../..........-....../.\......../........../..................\.....\...-...-...\..|...
..|...........\.\.........\.....-.............-............../...|........./..........\-......................
..../...\............\..........-...../.................................................../......-..|........-
..............\............|................./.\........|.......................|.........\/....-.............
......................-.............\|...|............../........\|../......../........./.\.../\.............|
...........\.....................................\.../.............................|..............-../........
................./...................\......../............................-....\.................\.-.|\......
....-../................|.......\.-.........|...\.|.........\...........\...|.................././.....\......
..-....-....../...-...\/...............\.......\.........................|..|..../.....................\......
/........\......../..............|..............|...|............|...............\............-.|.............
...\./............/....../......--.......-............-..\........\..................\.......\-............./.
-..\-..//......-.............\....\-.|........-|......................./................................../...
...........\......-.........................-.\|...|...........-.....\.......-........|.|.--..|........./.....
.......-........................./............|.............|................./..................-.......|-|./
.......|..........-................../.......................................|..../.......................|...
.....-........../.-../........./\..../.....\...-.....-...............|...../.../.....................\........
.........................|........|\../.../......|.................\..............-|....../..|................
...\...\.....................|.....|....\............|...|...../...|\............-.-........................-.
....................\|..............\...../........../..../........................-..........-...........\...
...\.........................|........-......................./..../................................./........
|......................./.../............../...\....................-.........................-........../|...
.......-../......../....\...................../........................./......\\......\.........\......../...
...-.....-......../..-/........\...............................\..........-.....................|........-....
..-....|............/.|-.........-..............................\.........-.........-....................//-..
...-\......-../..../...|-............................................\...............\...\...\..|\......|.....
......../...........-............................-...........................................\.....\.../......
........................\.......\...\......|.....\..\.-\.............../.......--...../|\.............|/......
.............../...............|....\......-.....|\..................|....-.................-......-........\.
\.......................-........-......|.................................|..-....-................./.........
.........|............\.........../..\......-.................\...\........./|.|.-.........\............./....
.-.........|................................/\......./..........|......................../........\...........
......................................\\...................../........................-\........../.-.......-.
......\....................................../.............................|.../.................\............
........-...|..-...\...\...........-.............-......................../................\..................
...../....../.......................\................/....\.-..-..../........|.......-........................
.........|.....|.......\/..............|....-.-../|\.......\../..........\....\./....-.....|..../.../.........
........\...../......|.................................-...........................-.-.....|............|../..
-../.............\.....|..\......|.../........................./...-...../............../\-.........-.........
...........\.........-....................-.....\...............-.................\...-.../.......\...........
./........................\................-..../.\........./......-....|.............../.-.........../......\
....................-.............\.......\-................|................-.......................|..|.....
.......\.../.....|./..\..........-.........../.......|.................-..................|.|................/
.....\....|.................\.-./........|.........\..-.........\....\.......|...\....-...............-.......
......................................-...........-|..|.../..\...\.\../.................-|......\.....-.......
......|........|......................|....././....././........./......................-./...\................
..........\........|.....\......\......................|......./....................../.\............-.....|..
|.....-............./........|...\../.......|......../\.|.-......\.\........|....\............./..........\...
-.......................|..|/...........-.......-.....-............-........................./................
.......|....-......................\..........................-...|...........................................
\......\........|.\..\.............\-..............\./......................-.....|...../..|..-.............|.
......-.............................../......-........-|............-..........-.....\//.-/.....\..........-\.
...............................|.........|/.../................................................|..............";
    }
}
