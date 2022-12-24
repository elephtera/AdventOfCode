using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day23 : IDay<int>
    {
        public int Part1(string input)
        {
            var elves = ProcessInput(input);
            var directionCount = 0;

            for (int i = 0; i < 10; i++)
            {
                var proposed = new Dictionary<(int, int), List<(int X, int Y)>>();
                var firstDirection = (Direction)directionCount;

                // First half of the round; proposals
                foreach (var elf in elves)
                {
                    if (IsElfLonely(elf, elves))
                    {
                        // No move
                        proposed.Add(elf, new List<(int X, int Y)>() { elf });
                    }
                    else
                    {
                        AddProposal(elves, proposed, elf, firstDirection);
                    }
                }

                elves = new List<(int X, int Y)>();

                foreach (var elfTarget in proposed)
                {
                    if (elfTarget.Value.Count > 1)
                    {
                        // revert
                        elves.AddRange(elfTarget.Value);
                    }
                    else
                    {
                        elves.Add(elfTarget.Key);
                    }
                }

                directionCount++;
                directionCount %= 4;
            }

            int result = CalculateRectangle(elves);
            return result;
        }

        public bool IsElfLonely((int X, int Y) elf, List<(int X, int Y)> elves)
        {
            var result =  !elves.Any(e => 
                e.X == elf.X + 0 && e.Y == elf.Y - 1 ||
                e.X == elf.X - 1 && e.Y == elf.Y - 1 ||
                e.X == elf.X + 1 && e.Y == elf.Y - 1 ||
                                              
                e.X == elf.X + 0 && e.Y == elf.Y + 1 ||
                e.X == elf.X - 1 && e.Y == elf.Y + 1 ||
                e.X == elf.X + 1 && e.Y == elf.Y + 1 ||
                                              
                e.X == elf.X - 1 && e.Y == elf.Y + 1 ||
                e.X == elf.X - 1 && e.Y == elf.Y + 0 ||
                e.X == elf.X - 1 && e.Y == elf.Y - 1 ||
                                              
                e.X == elf.X + 1 && e.Y == elf.Y + 1 ||
                e.X == elf.X + 1 && e.Y == elf.Y + 0 ||
                e.X == elf.X + 1 && e.Y == elf.Y - 1);
            return result;
        }

        public static int CalculateRectangle(List<(int X, int Y)> elves)
        {
            var minX = elves.Min(elf => elf.X);
            var minY = elves.Min(elf => elf.Y);

            var maxX = elves.Max(elf => elf.X);
            var maxY = elves.Max(elf => elf.Y);

            var result = (maxX + 1 - minX) * (maxY + 1 - minY) - elves.Count;
            return result;
        }

        private static void AddProposal(List<(int X, int Y)>  elves, Dictionary<(int, int), List<(int X, int Y)>> proposed, (int X, int Y) elf, Direction direction)
        {
            if(ElvesNear(elf, elves, direction))
            {
                direction = (Direction)((int)(direction + 1) % 4);
                if (ElvesNear(elf, elves, direction))
                {
                    direction = (Direction)((int)(direction + 1) % 4);
                    if (ElvesNear(elf, elves, direction))
                    {
                        direction = (Direction)((int)(direction + 1) % 4);
                        if (ElvesNear(elf, elves, direction))
                        {
                            proposed.Add(elf, new List<(int X, int Y)>() { elf });
                            return;
                        }
                    }
                }
            }

            var elfTarget = direction switch
            {
                Direction.North => (elf.X, elf.Y - 1),
                Direction.South => (elf.X, elf.Y + 1),
                Direction.West => (elf.X - 1, elf.Y),
                Direction.East => (elf.X + 1, elf.Y),
                _ => throw new InvalidDataException("Unknown direction"),
            };

            if (!proposed.TryAdd(elfTarget, new List<(int X, int Y)>() { elf }))
            {
                proposed[elfTarget].Add(elf);
            }
        }

        public static bool ElvesNear((int X, int Y) elf, IList<(int X, int Y)> inputData, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return inputData.Any(e => e.X == elf.X + 0 && e.Y == elf.Y - 1 ||
                                              e.X == elf.X - 1 && e.Y == elf.Y - 1 ||
                                              e.X == elf.X + 1 && e.Y == elf.Y - 1);
                case Direction.South:
                    return inputData.Any(e => e.X == elf.X + 0 && e.Y == elf.Y + 1 ||
                                              e.X == elf.X - 1 && e.Y == elf.Y + 1 ||
                                              e.X == elf.X + 1 && e.Y == elf.Y + 1);
                case Direction.West:
                    return inputData.Any(e => e.X == elf.X - 1 && e.Y == elf.Y + 1 ||
                                              e.X == elf.X - 1 && e.Y == elf.Y + 0 ||
                                              e.X == elf.X - 1 && e.Y == elf.Y - 1);
                case Direction.East:
                    return inputData.Any(e => e.X == elf.X + 1 && e.Y == elf.Y + 1 ||
                                              e.X == elf.X + 1 && e.Y == elf.Y + 0 ||
                                              e.X == elf.X + 1 && e.Y == elf.Y - 1);
                default:
                    throw new InvalidDataException("Unknown direction");
            }
        }

        public int Part2(string input)
        {
            var elves = ProcessInput(input);
            var directionCount = 0;
            var roundCount = 0;
            while(true)
            {
                var movedElf = false;
                roundCount++;
                var proposed = new Dictionary<(int, int), List<(int X, int Y)>>();
                var firstDirection = (Direction)directionCount;

                // First half of the round; proposals
                foreach (var elf in elves)
                {
                    if (IsElfLonely(elf, elves))
                    {
                        // No move
                        proposed.Add(elf, new List<(int X, int Y)>() { elf });
                    }
                    else
                    {
                        movedElf = true;

                        AddProposal(elves, proposed, elf, firstDirection);
                    }
                }

                elves = new List<(int X, int Y)>();

                foreach (var elfTarget in proposed)
                {
                    if (elfTarget.Value.Count > 1)
                    {
                        // revert
                        elves.AddRange(elfTarget.Value);
                    }
                    else
                    {
                        elves.Add(elfTarget.Key);
                    }
                }

                directionCount++;
                directionCount %= 4;
                if (!movedElf)
                {
                    return roundCount;
                }
            }
        }

        public static List<(int X, int Y)> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var result = new List<(int X, int Y)>();
            var y = 0;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var c in line)
                {
                    if (c == '#')
                    {
                        result.Add((x, y));
                    }

                    x++;
                }

                y++;
            }
            return result;
        }
    }

    public enum Direction
    {
        North = 0,
        South = 1,
        West = 2,
        East = 3,

    }
}
