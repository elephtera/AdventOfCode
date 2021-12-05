namespace AdventOfCode2021.Assignments
{
    internal class Line
    {
        public bool IsHorizontalLine => x1 == x2;
        public bool IsVerticalLine => y1 == y2;
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public IEnumerable<int[]> GetPoints()
        {

            var stepX = (x2 - x1) / Math.Max(Math.Abs(x2 - x1), 1);
            var stepY = (y2 - y1) / Math.Max(Math.Abs(y2 - y1), 1);
            var stepCount = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));

            for (int step = 0; step <= stepCount; step++)
            {
                yield return new[] { x1 + (step * stepX), y1 + (step * stepY) };
            }

        }
    }
}