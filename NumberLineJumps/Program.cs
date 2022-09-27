// https://www.hackerrank.com/challenges/kangaroo/problem?isFullScreen=true

using System.Runtime.Intrinsics;

Console.WriteLine("Number Line Jumps");

var res = kang(1, 2, 2, 1);
Console.WriteLine(res);

res = kang(3, 4, 5, 3);
Console.WriteLine(res ? "YES" : "NO");


bool kang(int x1, int v1, int x2, int v2)
{
    int i = 0;
    long k1 = 0;
    long k2 = 0;
    bool res = false;
    while (i < 100000000)
    {
        i++;
        k1 = x1 + v1 * i;
        k2 = x2 + v2 * i;
        if (k1 == k2)
        {
            res = true;
            break;
        }
    }
    return res;
}
