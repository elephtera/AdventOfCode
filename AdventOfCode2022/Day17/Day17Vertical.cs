namespace AdventOfCode2022.Day17
{
    public class Day17Vertical : IDay17Shape
    {
        private int x = 2;
        private int y = 0;
        private List<bool[]> heights;

        public Day17Vertical(List<bool[]> heights)
        {
            this.heights = heights;
            y = heights.Count() + 3;
        }
        public bool MoveDown()
        {
            if (y == 0 ||
                y - 1 < heights.Count && heights[y - 1][x])
            {
                return false;
            }

            y--;
            return true;
        }

        public void MoveLeft()
        {
            if (x == 0 ||
                y + 3 < heights.Count && heights[y + 3][x - 1] ||
                y + 2 < heights.Count && heights[y + 2][x - 1] ||
                y + 1 < heights.Count && heights[y + 1][x - 1] ||
                y + 0 < heights.Count && heights[y + 0][x - 1])
            {
                return;
            }

            x--;

        }

        public List<bool[]> NewHeight()
        {
            while (y + 3 >= heights.Count)
            {
                heights.Add(new bool[7]);
            }

            heights[y + 3][x] = true;
            heights[y + 2][x] = true;
            heights[y + 1][x] = true;
            heights[y + 0][x] = true;

            return heights;
        }

        public void MoveRight()
        {
            if (x == 6 ||
                y + 3 < heights.Count && heights[y + 3][x + 1] ||
                y + 2 < heights.Count && heights[y + 2][x + 1] ||
                y + 1 < heights.Count && heights[y + 1][x + 1] ||
                y + 0 < heights.Count && heights[y + 0][x + 1])
            {
                return;
            }

            x++;

        }

        public Coordinate Position() => new Coordinate(x, y);
        public List<bool[]> Heights() => heights;

    }
}
