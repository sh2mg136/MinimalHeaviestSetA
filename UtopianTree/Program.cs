// https://www.hackerrank.com/challenges/utopian-tree/problem?isFullScreen=true
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("UtopianTree");

// 0    1   2   3   4   5
// 1    2   3   6   7   14

var res = UtopianTreeClass.utopianTree(5);
Debug.Assert(res == 14);
res = UtopianTreeClass.calc(2, 5, 1);
Debug.Assert(res == 14);

string s2 = "";
var str = UtopianTreeClass.ConvertStr("AAABBCCCC", 0, ' ', 0, s2);
Debug.Assert(str == "3A2B4C");



////////////////////
// Cats and a Mouse
// https://www.hackerrank.com/challenges/cats-and-a-mouse/problem?isFullScreen=true
//
var s = CatAndMouseSolver.Run(2, 5, 4);
Debug.Assert(s == "Cat B");



public class UtopianTreeClass
{
    public static int utopianTree(int n)
    {
        var res = 1;
        for (int i = 2; i <= n + 1; i++)
        {
            if (i % 2 == 0) res *= 2; else res += 1;
        }
        return res;
    }

    public static int calc(int step, int max, int start)
    {
        start += (step % 2 == 0) ? start : 1;
        if (step <= max)
            return calc(++step, max, start);
        else return start;
    }

    /// <summary>
    /// Example of converting the string “AAABCCCCAADDDEF” => “3AB4C2A3DEF”
    /// </summary>
    /// <param name="s"></param>
    /// <param name="pos"></param>
    /// <param name="c"></param>
    /// <param name="k"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static string ConvertStr(string s, int pos, char c, int k, string s2)
    {
        if (pos < s.Length)
        {
            if (pos == 0) // first character of string
                          // go on to the next symbol
                return ConvertStr(s, pos + 1, s[pos], 1, s2);
            else // not the first character of a string
            {
                if (s[pos] == c) // if the next and previous characters are the same, then move on.
                    return ConvertStr(s, pos + 1, s[pos], k + 1, s2);
                else // if the characters are different, then fix the temporary result in the s2 line
                {
                    // if k == 1, then simply add the symbol c to s2,
                    // otherwise, put the number k in front of the character c
                    if (k == 1)
                        s2 = s2 + c.ToString();
                    else
                        s2 = s2 + k.ToString() + c.ToString(); // s2 = s2 + "AAA' = s2 + "3A"

                    // go to the next recursion level, continue processing the string
                    return ConvertStr(s, pos + 1, s[pos], 1, s2);
                }
            }
        }
        else // passed the entire string
        {
            // complete the string processing
            if (k == 1)
                s2 = s2 + c.ToString();
            else
                s2 = s2 + k.ToString() + c.ToString();
            return s2; // finish the recursive process
        }
    }
}


class CatAndMouseSolver
{
    public static string Run(int x, int y, int z)
    {
        var a = Math.Abs(x - z);
        var b = Math.Abs(y - z);
        if (a == b)
            return "Mouse C";
        else return a < b ? "Cat A" : "Cat B";
    }
}