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



// Picking Numbers
var arr = new List<int>() { 1, 1, 2, 2, 4, 4, 5, 5, 5 };
var iRes = PickingNumbersSolver.Run(arr);
Debug.Assert(iRes == 5);

arr = new List<int>() { 4, 6, 5, 3, 3, 1 };
iRes = PickingNumbersSolver.Run(arr);
Debug.Assert(iRes == 3);


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


//////////////////////////
// Picking Numbers
class PickingNumbersSolver
{
    /// <summary>
    /// Given an array of integers, find the longest subarray 
    /// where the absolute difference between any two elements 
    /// is less than or equal to 1.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static int Run(List<int> a)
    {
        var res = 0;
        int cnt = 0;

        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < a.Count; i++)
            dict.Add(i, a[i]);

        for (int i = 0; i < a.Count - 1; i++)
        {
            cnt = dict.Where(x => x.Key != i && x.Value >= a[i] - 1 && x.Value <= a[i]).Count() + 1;
            if (cnt > res)
                res = cnt;
            cnt = dict.Where(x => x.Key != i && x.Value <= a[i] + 1 && x.Value >= a[i]).Count() + 1;
            if (cnt > res)
                res = cnt;
        }
        return res;
    }
}