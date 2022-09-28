// https://www.hackerrank.com/challenges/find-digits/problem?isFullScreen=true

using System.Diagnostics;

Console.WriteLine("Find Digits");

var res = FindDigit.Solve(122);
Console.WriteLine(res);
Debug.Assert(res == 3);

res = FindDigit.Solve(24);
Console.WriteLine(res);
Debug.Assert(res == 2);

res = FindDigit.Solve(1012);
Console.WriteLine(res);
Debug.Assert(res == 3);

class FindDigit
{
    public static int Solve(int num)
    {
        List<int> all = new List<int>();
        List<int> res = new List<int>();

        foreach (var ch in $"{num}")
        {
            all.Add(int.Parse(ch.ToString()));
        }

        var unique = all.GroupBy(x => x).Select(x => x.Key).ToList();

        foreach (var n in all)
        {
            if (n > 0 && num % n == 0)
            {
                res.Add(n);
            }
        }

        return res.Count;
    }
}