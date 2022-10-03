// https://www.hackerrank.com/challenges/bon-appetit/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Bill Division");

List<int> bill = new List<int>() { 2, 4, 6 };
int k = 2, b = 3;
var res = BillDivisionClass.bonAppetit(bill, k, b);
Debug.Assert(res == BillDivisionClass.BON);

bill = new List<int>() { 3, 10, 2, 9 };
k = 1;
b = 12;
res = BillDivisionClass.bonAppetit(bill, k, b);
Debug.Assert(res == "5");

///////////////////
/// Sales by Match
/// https://www.hackerrank.com/challenges/sock-merchant/problem?isFullScreen=true
///
Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.NewLine);
Console.WriteLine("Sales by Match");

int n = 7;
List<int> data = new List<int>() { 1, 2, 1, 2, 1, 3, 2 };
var iRes = SalesByMatchClass.sockMerchant(n, data);
Debug.Assert(iRes == 2);

/// <summary>
/// DrawingBook
/// https://www.hackerrank.com/challenges/drawing-book/problem?isFullScreen=true
/// </summary>
iRes = DrawingBookClass.pageCount(5, 3);
Debug.Assert(iRes == 1);

iRes = DrawingBookClass.pageCount(6, 2);
Debug.Assert(iRes == 1);

iRes = DrawingBookClass.pageCount(5, 3);
Debug.Assert(iRes == 1);

iRes = DrawingBookClass.pageCount(10, 4);
Debug.Assert(iRes == 2);

internal class DrawingBookClass
{
    public static int pageCount(int n, int p)
    {
        if (p == 1 || p == n)
            return 0;

        var h = n / 2;
        var p2 = p / 2;
        return Math.Min(p2, h - p2);
    }
}

internal class SalesByMatchClass
{
    public static int sockMerchant(int n, List<int> ar)
    {
        var dict = ar.GroupBy(x => x).ToDictionary(keySelector: x => x, elementSelector: x => x.Count());
        var pairs = 0;
        foreach (var sock in dict)
        {
            pairs += sock.Value / 2;
        }
        return pairs;
    }
}

internal class BillDivisionClass
{
    public const string BON = "Bon Appetit";

    public static string bonAppetit(List<int> bill, int k, int b)
    {
        int cnt = 0;
        var dict = bill.ToDictionary(keySelector: x => cnt++, x => x);
        var anna = dict.Where(x => x.Key != k).ToList();
        var annaMustPay = anna.Sum(x => x.Value) / 2;
        if (b > annaMustPay)
            return (b - annaMustPay).ToString();

        return BON;
    }
}