
namespace AdventOfCode2023
{
    /**
*/
    public class Day2 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            // only 12 red cubes, 13 green cubes, and 14 blue cubes
            const int red = 12;
            const int green = 13;
            const int blue = 14;

            return inputData.Where(game => game.IsPossible(red, green, blue)).Sum(game => game.Id);
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            return inputData.Sum(game => game.GamePower);
        }
        public static IList<Game> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None);

            return lines.Select(line => new Game(line)).ToList();
        }
    }

    public class Game
    {
        public Game(string game)
        {
            var gameInfo = game.Split(':');
            this.Id = int.Parse(gameInfo[0].Split(' ')[1]);

            var sets = gameInfo[1].Split(';');
            foreach (var set in sets)
            {
                Sets.Add(new GameSet(set));
            }
        }

        public int Id { get; private set; }

        public List<GameSet> Sets { get; } = new List<GameSet>();

        public bool IsPossible(int red, int green, int blue)
        {
            return Sets.TrueForAll(set => set.IsPossible(red, green, blue));
        }

        public int MinimumRed => Sets.Max(s => s.Red);
        public int MinimumGreen => Sets.Max(s => s.Green);
        public int MinimumBlue => Sets.Max(s => s.Blue);

        public int GamePower => MinimumBlue * MinimumGreen * MinimumRed;
    }

    public class GameSet
    {
        public int Green { get; private set; } = 0;
        public int Blue { get; private set; } = 0;
        public int Red { get; private set; } = 0;


        public GameSet(string set)
        {
            
            var cubes = set.Split(',', StringSplitOptions.TrimEntries);
            foreach (var colourCubes in cubes)
            {
                var colourCubeInfo = colourCubes.Split(' ');
                switch (colourCubeInfo[1])
                {
                    case "green":
                        this.Green = int.Parse(colourCubeInfo[0]);
                        break;
                    case "red":
                        this.Red = int.Parse(colourCubeInfo[0]);
                        break;
                    case "blue":
                        this.Blue = int.Parse(colourCubeInfo[0]);
                        break;
                    default:
                        throw new Exception("invalid color");
                }
            }
        }

        public bool IsPossible(int red, int green, int blue)
        {
            return this.Red <= red && this.Green <= green && this.Blue <= blue;
        }
    }
}
