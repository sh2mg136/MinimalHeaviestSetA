// https://www.hackerrank.com/challenges/dynamic-array/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("DataSructures DynamicArray");

int n = 2;
var data = new List<List<int>>();
data.Add(new List<int>() { 1, 0, 5 });
data.Add(new List<int>() { 1, 1, 7 });
data.Add(new List<int>() { 1, 0, 3 });
data.Add(new List<int>() { 2, 1, 0 });
data.Add(new List<int>() { 2, 1, 1 });

var result = DynamicArrayClass.Run(n, data);
Debug.Assert(result.Count > 0);
bool equals = true;
var correct = new List<int> { 7, 3 };
for (int i = 0; i < result.Count; i++)
{
    if (result[i] != correct[i])
    {
        equals = false;
        break;
    }
}
Debug.Assert(equals);

public class DynamicArrayClass
{
    public static List<int> Run(int n, List<List<int>> queries)
    {
        var result = new List<int>();

        int lastAnswer = 0;
        var idx = 0;

        var arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
            arr.Add(new List<int>() { });

        foreach (var Q in queries)
        {
            idx = (Q[1] ^ lastAnswer) % n;

            if (Q[0] == 1)
            {
                arr[idx].Add(Q[2]);
            }
            else
            {
                var col = Q[2] % Math.Max(1, arr[idx].Count);

                if (arr[idx].Count < col + 1)
                {
                    for (int i = arr[idx].Count; i < col + 1; i++)
                    {
                        arr[idx].Add(0);
                    }
                }

                lastAnswer = arr[idx][col];
                result.Add(lastAnswer);
            }
        }
        return result;
    }

    private static void Exp(ref List<List<int>> arr, int num, int max)
    {
        for (int i = arr.Count; i < max; i++)
        {
            arr[num].Add(0);
        }
    }
}