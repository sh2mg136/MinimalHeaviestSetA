// https://www.hackerrank.com/challenges/the-birthday-bar/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Prepare Algorithms Implementation Subarray Division");

List<int> s = new List<int>() { 2, 2, 1, 3, 2 };
int d = 4;
int m = 2;
var res = SubarrayDivisionSolver.birthday(s, d, m);
Debug.Assert(res == 2);

s = new List<int>() { 1, 2, 1, 4, 12, 2, 2, 6, 3, 10, 1, 1 };
d = 20;
m = 4;
res = SubarrayDivisionSolver.birthday(s, d, m);
Debug.Assert(res == 2);

s = new List<int>() { 4 };
d = 4;
m = 1;
res = SubarrayDivisionSolver.birthday(s, d, m);
Debug.Assert(res == 1);

s = new List<int>() { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1 };
d = 18;
m = 7;
res = SubarrayDivisionSolver.birthday(s, d, m);
Debug.Assert(res == 3);


public class SubarrayDivisionSolver
{
    public static int birthdayDone(List<int> s, int d, int m)
    {
        if (s.Count == 1)
            return s[0] == d && m == 1 ? 1 : 0;
        int res = 0;
        for (int i = 0; i < s.Count(); i++)
        {
            var arr = s.Skip(i).Take(m).ToList();
            if (arr.Count != m)
                break;
            if (arr.Sum() == d)
                res++;
        }
        return res;
    }

    public static int birthday(List<int> s, int d, int m)
    {
        if (s.Count == 1)
            return s[0] == d && m == 1 ? 1 : 0;

        int res = 0, sum;
        for (int i = 0; i < s.Count(); i++)
        {
            sum = 0;

            if (i + m > s.Count)
                break;

            for (int j = i; j < i + m; j++)
            {
                sum += s[j];
            }

            if (sum == d)
                res++;
        }
        return res;
    }
}