namespace AdventOfCode2022.Assignments
{
    public interface IDay<T>
    {
        T Part1(string input);
        T Part2(string input);
    }
}