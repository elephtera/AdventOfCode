namespace AdventOfCode2015.Helpers;

public class MathHelper
{
    /// <summary>
    /// Greatest common divisor
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Least common multiple
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long LCM(long a, long b)
    {
        return a / GCD(a, b) * b;
    }
}