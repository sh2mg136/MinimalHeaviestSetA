// https://www.hackerrank.com/challenges/encryption/problem?isFullScreen=true
using System.Text;

Console.WriteLine("HakerRank Encryption");
Console.WriteLine(Environment.NewLine);

/*
 * https://www.hackerrank.com/challenges/migratory-birds/problem?isFullScreen=true
 * Migratory Birds
 *
var arr = new List<int>() { 1, 1, 2, 2, 3 };
var dict = arr.GroupBy(x => x).Select(x => new { Key = x.Key, Val = x.Count() });
var maxQty = dict.OrderByDescending(x => x.Val).First().Val;
var res = dict.Where(x => x.Val == maxQty).OrderBy(x => x.Key).First().Key;
Console.WriteLine(res);
Debug.Assert(res == 1);
*/

/*
 * HakerRankEncryption
 *
An English text needs to be encrypted using the following encryption scheme.
First, the spaces are removed from the text.
Let  "L"  be the length of this text.
Then, characters are written into a grid, whose rows and columns have the following constraints:

FLOOR (  Sqrt(L)  )  <=   row   <=   columns   <=   CEIL (  Sqrt(L)  )

rows * columns >= L

ifmanwas
meanttos
tayonthe
groundgo
dwouldha
vegivenu
sroots

=

imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau

*/

// haveaniceday -> "hae and via ecy"
public class HakerRankEncryptionSolver
{
    public static string Run(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return string.Empty;

        int L = s.Length;
        double sqrt = Math.Sqrt(L);
        int sqr1 = (int)Math.Round(sqrt, 0);
        int sqr2 = (int)Math.Ceiling(sqrt);

        List<string> list1 = new List<string>();
        List<string> list2 = new List<string>();

        list1 = GetList(s, sqr1);
        var len = GetLen(list1);
        var res1 = Convert(list1, sqr1);

        list2 = GetList(s, sqr2);
        var len2 = GetLen(list2);
        var res2 = Convert(list2, sqr2);

        return res2;
    }

    private static string Convert(List<string> list1, int rowLen)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rowLen; i++)
        {
            foreach (var str in list1)
            {
                if (i < str.Length)
                    sb.Append(str[i]);
            }
            sb.Append(' ');
        }
        return sb.ToString().Trim();
    }

    private static List<string> GetList(string s, int len)
    {
        List<string> list = new List<string>();
        StringBuilder sb;
        int rows = (int)Math.Ceiling(s.Length / (double)len);

        for (int i = 0; i < rows; i++)
        {
            var ns = s.Skip(i * len).Take(len).ToList();
            sb = new StringBuilder();
            foreach (var ch in ns)
            {
                sb.Append(ch);
            }
            list.Add(sb.ToString());
        }
        return list;
    }

    private static int GetLen(List<string> list)
    {
        int res = 0;
        foreach (var s in list)
        {
            res += s.Length;
        }
        return res;
    }

    private static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
    {
        int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newColumn, newRow = 0;
        for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
        {
            newColumn = 0;
            for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
            {
                newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                newColumn++;
            }
            newRow++;
        }
        return newMatrix;
    }
}