// https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Counting Valleys");

var result = 0;

result = CountingValleysSolution.countingValleys(10, "DUDDDUUDUU");
Debug.Assert(result == 2);

result = CountingValleysSolution.countingValleys(10, "UDUUUDUDDD");
Debug.Assert(result == 0);

result = CountingValleysSolution.countingValleys(8, "UDDDUDUU");
Debug.Assert(result == 1);

result = CountingValleysSolution.countingValleys(8, "DDUUDDUDUUUD");
Debug.Assert(result == 2);

internal class CountingValleysSolution
{
    public static int countingValleys(int steps, string path)
    {
        var result = 0;
        int cnt = 0;
        int dir = 0;

        foreach (var ch in path)
        {
            switch (ch)
            {
                case 'U':
                    cnt++;
                    if (cnt == 0)
                    {
                        if (dir < 0) result++;
                        dir = 0;
                    }
                    else if (cnt > 1)
                    {
                        dir = 1;
                    }
                    break;

                case 'D':
                    cnt--;
                    if (cnt == 0)
                    {
                        dir = 0;
                    }
                    else if (cnt < 0)
                    {
                        dir = -1;
                    }
                    break;

                default:
                    break;
            }
        }

        return result;
    }
}