namespace AdventOfCode2022.Day17
{
    public interface IDay17Shape
    {
        public void MoveLeft();
        public void MoveRight();
        public bool MoveDown();

        public List<bool[]> Heights();
        public Coordinate Position();

        public List<bool[]> NewHeight();
    }
}
