// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

int[] data = new int[] { 1, 2, 3, 4, 5 };
var res = GetMinMax(data);
Console.WriteLine($"{GetMin(data.ToList())} {GetMax(data.ToList())}");

static (int, int) GetMinMax(int[] arr)
{
    var res = (0, 0);
    if (arr.Length < 5 || arr.Length > 5)
        return res;

    var min = arr.OrderBy(x => x).Take(4).Sum(x => x);
    var max = arr.OrderByDescending(x => x).Take(4).Sum(x => x);

    return (min, max);
}

static long GetMin(List<int> arr)
{
    return arr.OrderBy(x => x).Take(4).Sum(x => (long)x);
}

static long GetMax(List<int> arr)
{
    return arr.OrderByDescending(x => x).Take(4).Sum(x => (long)x);
}