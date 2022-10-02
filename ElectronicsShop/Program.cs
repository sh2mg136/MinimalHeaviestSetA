// https://www.hackerrank.com/challenges/electronics-shop/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Electronics Shop");

int[] keyboards = new int[] { 40, 50, 60 };
int[] drives = new int[] { 5, 8, 12 };

var res = ElectronicsShopClass.getMoneySpent(keyboards, drives, 60);
Debug.Assert(res == 58);

class ElectronicsShopClass
{
    public static int getMoneySpent(int[] keyboards, int[] drives, int b)
    {
        var minKb = keyboards.Min();
        var minDr = drives.Min();

        if (minKb + minDr > b)
            return -1;

        List<int> p = new List<int>();

        foreach(var k in keyboards)
        {
            foreach (var d in drives)
            {
                p.Add(d + k);
            }
        }

        return p.Where(x => x <= b).Max();
    }
}