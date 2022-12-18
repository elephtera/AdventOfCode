using System.Linq;

namespace AdventOfCode2022.Day17
{
    public class Day17Line : IDay17Shape
    {
        private int x = 2;
        private int y = 0;
        private List<bool[]> heights;

        public Day17Line(List<bool[]> heights)
        {
            this.heights = heights;
            y = heights.Count + 3;
        }
        public bool MoveDown()
        {
            if (y > heights.Count)
            {
                y--;
                return true;
            }

            if (y == 0 ||
                heights[y - 1][x] ||
                heights[y - 1][x + 1] ||
                heights[y - 1][x + 2] ||
                heights[y - 1][x + 3])
            {
                return false;
            }

            y--;
            return true;
        }

        public void MoveLeft()
        {
            if (x > 0 && (y >= heights.Count || !heights[y][x - 1]))
            {
                x--;
            }
        }

        public List<bool[]> NewHeight()
        {
            if (y == heights.Count)
            {
                heights.Add(new bool[7]);
            }

            heights[y][x] = true;
            heights[y][x + 1] = true;
            heights[y][x + 2] = true;
            heights[y][x + 3] = true;

            return heights;
        }

        public void MoveRight()
        {
            if (x <= 2 && (y >= heights.Count || !heights[y][x + 4]))
            {
                x++;
            }
        }

        public Coordinate Position() => new Coordinate(x, y);
        public List<bool[]> Heights() => heights;

    }
}
