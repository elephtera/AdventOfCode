namespace AdventOfCode2022.Assignments
{
    public interface IDay<T>
    {
        T PartA(IList<string> input);
        T PartB(IList<string> input);
    }
}