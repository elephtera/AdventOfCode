namespace AdventOfCode2022.Day17
{
    public class Day17Hook : IDay17Shape
    {
        private int x = 2;
        private int y = 0;
        private List<bool[]> heights;

        public Day17Hook(List<bool[]> heights)
        {
            this.heights = heights;
            y = heights.Count() + 3;
        }
        public bool MoveDown()
        {
            if (y == 0 ||
                y - 1 < heights.Count && heights[y - 1][x + 0] ||
                y - 1 < heights.Count && heights[y - 1][x + 1] ||
                y - 1 < heights.Count && heights[y - 1][x + 2])
            {
                return false;
            }

            y--;
            return true;
        }

        public void MoveLeft()
        {
            if (x == 0 ||
                y + 2 < heights.Count && heights[y + 2][x + 1] ||
                y + 1 < heights.Count && heights[y + 1][x + 1] ||
                y + 0 < heights.Count && heights[y + 0][x - 1])
            {
                return;
            }

            x--;

        }

        public List<bool[]> NewHeight()
        {
            while (y + 2 >= heights.Count)
            {
                heights.Add(new bool[7]);
            }

            heights[y + 2][x + 2] = true;
            heights[y + 1][x + 2] = true;
            heights[y + 0][x + 0] = true;
            heights[y + 0][x + 1] = true;
            heights[y + 0][x + 2] = true;

            return heights;
        }

        public void MoveRight()
        {
            if (x == 4 ||
                y + 2 < heights.Count && heights[y + 2][x + 3] ||
                y + 1 < heights.Count && heights[y + 1][x + 3] ||
                y + 0 < heights.Count && heights[y + 0][x + 3])
            {
                return;
            }

            x++;

        }

        public Coordinate Position() => new Coordinate(x, y);
        public List<bool[]> Heights() => heights;

    }
}
