using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day22
    {
        public int Part1(string input, string inputActions)
        {
            var mapData = ProcessInputMap(input);
            var actions = ProcessInputActions(inputActions);

            var map = new Day22Location(mapData, diceFormat:0);
            foreach (var action in actions)
            {
                map.TakeStep(action);
            }

            var result = (map.Y + 1) * 1000 + (map.X + 1) * 4 + map.Direction;
            return result;
        }

        public int Part2(string input, string inputActions)
        {
            var mapData = ProcessInputMap(input);
            var actions = ProcessInputActions(inputActions);

            var map = new Day22Location(mapData, diceFormat:1);
            foreach (var action in actions)
            {
                map.TakeStep(action);
            }

            var result = (map.Y + 1) * 1000 + (map.X + 1) * 4 + map.Direction;
            return result;
        }

        public static IList<char[]> ProcessInputMap(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<char[]>();
            var maxLength = lines.Max(l => l.Length);
            foreach (var line in lines)
            {
                var row = new char[maxLength];
                line.CopyTo(row);
                result.Add(row);
            }

            return result;
        }

        public static IList<Day22Step> ProcessInputActions(string input)
        {
            var result = new List<Day22Step>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'R')
                {
                    result.Add(new Day22Step() { Action = Day22Action.TurnRight });
                }
                else if (input[i] == 'L')
                {
                    result.Add(new Day22Step() { Action = Day22Action.TurnLeft });
                }
                else
                {
                    string number = $"{input[i]}";

                    while (i < input.Count() - 1 && input[i + 1] != 'R' && input[i + 1] != 'L')
                    {

                        i++;
                        number += input[i];
                    }

                    result.Add(new Day22Step() { Action = Day22Action.Move, StepSize = int.Parse(number) });
                }
            }

            return result;
        }


    }
    public class Day22Location
    {
        public int Direction { get; set; } = 0;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public IList<char[]> Map { get; }
        public int DiceFormat { get; set; }

        public Day22Location(IList<char[]> map, int diceFormat)
        {
            DiceFormat = diceFormat;
            Map = map;
            int i = 0;
            var first = Map[0][i];
            while (first != '.')
            {
                first = Map[0][i];
                i++;
            }

            X = i - 1;
        }
        public void TakeStep(Day22Step step)
        {
            switch (step.Action)
            {
                case Day22Action.TurnLeft:
                    Direction--;
                    if (Direction < 0)
                    {
                        Direction = 3;
                    }
                    break;
                case Day22Action.TurnRight:
                    Direction++;
                    if (Direction > 3)
                    {
                        Direction = 0;
                    }
                    break;
                case Day22Action.Move:
                    Move(step.StepSize);
                    break;
            }
        }

        private void Move(int stepSize)
        {
            while (stepSize > 0)
            {
                stepSize--;
                if (Direction == 0)
                {
                    if (X + 1 < Map[Y].Count() && Map[Y][X + 1] == '.')
                    {
                        // Move right
                        X++;
                    }
                    else if (X + 1 < Map[Y].Count() && Map[Y][X + 1] == '#')
                    {
                        // met a wall
                        return;
                    }
                    else if (DiceFormat > 0)
                    {
                        if(Y >= 0 && Y < 50)
                        {
                            // Y: 0 - 49
                            // X: 149
                            // Y = 149 - Y
                            // X = 99
                            var newY = 149 - Y;
                            var newX = 99;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 2;
                            }
                        }
                        else if (Y >= 50 && Y < 100)
                        {
                            // Y = 50-99
                            // X = 99
                            // draai
                            // Y = 49
                            // X = 100 + Y - 50;
                            var newY = 49;
                            var newX = 50 + Y;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 3;
                            }
                        }
                        else if (Y >= 100 && Y < 150)
                        {
                            // Y = 100-149
                            // X = 99
                            // Inverted
                            // Y = 149 - Y
                            // X = 149
                            var newY = 149 - Y;
                            var newX = 149;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 2;
                            }
                        }
                        else if (Y >= 150 && Y < 200)
                        {
                            // Y = 150-199
                            // X = 49
                            // draai
                            // Y = 149
                            // X = 50 + Y - 150
                            var newY = 149;
                            var newX = 50 + (Y - 150);
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 3;
                            }
                        }
                    }
                    else
                    {
                        // wrap around
                        int i = 0;
                        var first = Map[Y][i];
                        while (first != '.' && first != '#')
                        {
                            i++;
                            first = Map[Y][i];
                        }

                        if (first == '#')
                        {
                            return;
                        }

                        X = i;
                    }


                }
                else if (Direction == 1)
                {
                    // Move Down
                    if (Y + 1 < Map.Count() && Map[Y + 1][X] == '.')
                    {
                        // Move down
                        Y++;
                    }
                    else if (Y + 1 < Map.Count() && Map[Y + 1][X] == '#')
                    {
                        // met a wall
                        return;
                    }
                    else if (DiceFormat > 0)
                    {
                        if (X >= 0 && X < 50)
                        {
                            // Y = 199
                            // X = 0-49
                            // 
                            // Y = 0
                            // X = 100 + X
                            var newY = 0;
                            var newX = 100 + X;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 1;
                            }
                        }
                        else if (X >= 50 && X < 100)
                        {
                            // Y = 149
                            // X = 50-99
                            // draai
                            // Y = 100 + X
                            // X = 49
                            var newY = 100 + X;
                            var newX = 49;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 2;
                            }
                        }
                        else if (X >= 100 && X < 150)
                        {
                            // Y = 49
                            // X = 100-149
                            // draai
                            // Y = X - 50
                            // X = 99
                            var newY = X - 50;
                            var newX = 99;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 2;
                            }
                        }
                    }
                    else
                    {
                        // wrap around
                        int i = 0;
                        var first = Map[i][X];
                        while (first != '.' && first != '#')
                        {
                            i++;
                            first = Map[i][X];
                        }

                        if (first == '#')
                        {
                            return;
                        }

                        Y = i;
                    }
                    
                }
                else if (Direction == 2)
                {
                    // Move Left
                    if (X - 1 >= 0 && Map[Y][X - 1] == '.')
                    {
                        // Move left
                        X--;
                    }
                    else if (X - 1 >= 0 && Map[Y][X - 1] == '#')
                    {
                        // met a wall
                        return;
                    }
                    else if (DiceFormat > 0)
                    {
                        if (Y >= 0 && Y < 50)
                        {
                            // Y = 0-49
                            // X = 50
                            // inverted
                            // Y = 149 - Y
                            // X = 0
                            var newY = 149 - Y;
                            var newX = 0;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 0;
                            }
                        }
                        else if (Y >= 50 && Y < 100)
                        {
                            // Y = 50-99
                            // X = 50
                            // draai
                            // Y = 100
                            // X = Y - 50
                            var newY = 100;
                            var newX = Y - 50;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 1;
                            }
                        }
                        else if (Y >= 100 && Y < 150)
                        {
                            // Y = 100-149
                            // X = 0
                            // inverted
                            // Y = 149 - Y
                            // X = 50
                            var newY = 149 - Y;
                            var newX = 50;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 0;
                            }
                        }
                        else if (Y >= 150 && Y < 200)
                        {
                            // Y = 150-199
                            // X = 0
                            // draai
                            // Y = 0
                            // X = Y - 100
                            var newY = 0;
                            var newX = Y - 100;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 1;
                            }
                        }
                    }
                    else
                    {
                        // wrap around
                        int i = Map[Y].Count() - 1;
                        var last = Map[Y][i];
                        while (last != '.' && last != '#')
                        {
                            i--;
                            last = Map[Y][i];
                        }
                        
                        if(last == '#')
                        {
                            return;
                        }

                        X = i;
                    }
                }
                else if (Direction == 3)
                {
                    // Move Up
                    if (Y - 1 >= 0 && Map[Y - 1][X] == '.')
                    {
                        // Move Up
                        Y--;
                    }
                    else if (Y - 1 >= 0 && Map[Y - 1][X] == '#')
                    {
                        // met a wall
                        return;
                    }
                    else if (DiceFormat > 0)
                    {
                        if (X >= 0 && X < 50)
                        {
                            // Y = 100
                            // X = 0-49
                            // draai
                            // Y = 50 + X
                            // X = 50
                            var newY = 50 + X;
                            var newX = 50;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 0;
                            }
                        }
                        else if (X >= 50 && X < 100)
                        {
                            // Y = 0
                            // X = 50-99
                            // draai
                            // Y = 100 + X
                            // X = 0
                            var newY = 100 + X;
                            var newX = 0;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 0;
                            }
                        }
                        else if (X >= 100 && X < 150)
                        {
                            // Y = 0
                            // X = 100-149
                            // 
                            // Y = 199
                            // X = X - 100
                            var newY = 199;
                            var newX = X - 100;
                            var next = Map[newY][newX];
                            if (next != '#')
                            {
                                X = newX;
                                Y = newY;
                                Direction = 3;
                            }
                        }
                    }
                    else
                    {
                        // wrap around
                        int i = Map.Count() - 1;
                        var last = Map[i][X];
                        while (last != '.' && last != '#')
                        {
                            i--;
                            last = Map[i][X];
                        }
                        
                        if(last == '#')
                        {
                            return;
                        }

                        Y = i;
                    }
                }
            }
        }
    }

    public class Day22Step
    {
        public int StepSize { get; set; }
        public Day22Action Action { get; set; }
    }

    public enum Day22Action
    {
        Move,
        TurnLeft,
        TurnRight
    }

}
