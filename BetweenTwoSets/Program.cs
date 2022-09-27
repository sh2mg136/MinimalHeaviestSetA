// https://www.hackerrank.com/challenges/between-two-sets/problem?isFullScreen=true&h_r=next-challenge&h_v=zen
Console.WriteLine("Between Two Sets");

List<int> a = new List<int>() { 2, 6 };
List<int> b = new List<int>() { 24, 36 };

var res = getTotalX(a, b);
Console.WriteLine(res);

int getTotalX(List<int> a, List<int> b)
{
    List<int> res1 = new List<int>();
    List<int> res2 = new List<int>();

    var start = Math.Min(a.Min(), b.Min());
    var end = Math.Max(a.Max(), b.Max());

    for (int i = start; i <= end; i += start)
    {
        if (a.All(x => i % x == 0))
            res1.Add(i);
    }

    foreach (int k in res1)
    {
        if (b.All(x => x % k == 0) && !res2.Contains(k))
            res2.Add(k);
    }

    Console.WriteLine(res2);
    return res2.Count;
}