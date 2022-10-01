// https://www.hackerrank.com/challenges/angry-professor/problem?isFullScreen=true
using System.Diagnostics;
Console.WriteLine("Angry Professor");
var res = AngryProfessorSolver.Run(3, new List<int>() { 1, 2, -2, -3, -4 });
Debug.Assert(res == "NO");
res = AngryProfessorSolver.Run(4, new List<int>() { 1, 2, -2, -3, -4 });
Debug.Assert(res == "YES");


// Divisible Sum Pairs
List<int> ar = new List<int>() { 1, 2, 3, 4, 5, 6 };
var pairsQty = DivisibleSumPairsSolver.divisibleSumPairs(6, 5, ar);
Debug.Assert(pairsQty == 3);

ar = new List<int>() { 1, 3, 2, 6, 1, 2 };
pairsQty = DivisibleSumPairsSolver.divisibleSumPairs(6, 3, ar);
Debug.Assert(pairsQty == 5);


public class AngryProfessorSolver
{
    public static string Run(int k, List<int> a)
    {
        var cnt = a.Where(x => x <= 0).Count();
        return cnt < k ? "YES" : "NO";
    }
}

/////////////////////////////
// Divisible Sum Pairs

public class DivisibleSumPairsSolver
{
    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
        int res = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var tmp = ar[i] + ar[j];
                if (tmp % k == 0)
                    res++;
            }
        }
        return res;
    }
}