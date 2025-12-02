namespace AdventOfCode2025.Helpers;

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

    public static int Mod(int x, int m)
    {
        return ((x % m) + m) % m;
    }

    public static double LagrangeInterpolation(List<(int x, int y)> points, long totalX)
    {
        double result = 0;

        for (var i = 0; i < points.Count; i++)
        {
            // Compute individual terms of formula
            double term = points[i].y;

            for (var j = 0; j < points.Count; j++)
            {
                if (j != i)
                {
                    term = term * (totalX - points[j].x) / (points[i].x - points[j].x);
                }
            }

            // Add current term to result
            result += term;
        }

        return result;
    }
}