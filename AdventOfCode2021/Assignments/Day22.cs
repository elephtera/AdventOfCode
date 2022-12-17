namespace AdventOfCode2021.Assignments
{
    /**

     */
    public class Day22 : IDay
    {
        public string Part1()
        {
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputA);
            var result = Calc(input);
            return result.ToString();

        }

        public string Part2()
        {
            var input = InputHandler.ConvertInputToCubes(Day22Input.InputB);
            var result = Calc(input);
            return result.ToString();
        }

        public long Calc(List<Cube> input)
        {
            var resultingCubes = new List<Cube>();
            foreach (var cube in input)
            {
                var cubesToAdd = new List<Cube>();
                if (cube.TurnedOn)
                {
                    cubesToAdd.Add(cube);
                }

                foreach (var otherCube in resultingCubes)
                {
                    // Add the intersection of the new cube with any other cube as a new "cube" to keep track of its state.
                    var intersection = cube.Intersect(otherCube, !otherCube.TurnedOn);
                    if (intersection != null)
                    {
                        cubesToAdd.Add(intersection.Value);
                    }
                }
                resultingCubes.AddRange(cubesToAdd);
            }
            return resultingCubes.Aggregate(0L, (totalVolume, c) => totalVolume + c.Volume * (c.TurnedOn ? 1 : -1));
        }

    }

    public record struct Cube(int MinX, int MaxX, int MinY, int MaxY, int MinZ, int MaxZ, bool TurnedOn)
    {
        public Cube? Intersect(Cube other, bool turnedOn)
        {
            if (MinX > other.MaxX || MaxX < other.MinX || MinY > other.MaxY || MaxY < other.MinY || MinZ > other.MaxZ || MaxZ < other.MinZ)
            {
                // No intersection
                return null;
            }

            return new Cube(
                Math.Max(MinX, other.MinX), Math.Min(MaxX, other.MaxX),
                Math.Max(MinY, other.MinY), Math.Min(MaxY, other.MaxY),
                Math.Max(MinZ, other.MinZ), Math.Min(MaxZ, other.MaxZ),
                turnedOn);
        }

        public long Volume => (MaxX - MinX + 1L) * (MaxY - MinY + 1L) * (MaxZ - MinZ + 1L);
    }
}
