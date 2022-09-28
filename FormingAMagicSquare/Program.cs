// https://www.hackerrank.com/challenges/magic-square-forming/problem?isFullScreen=true

using System.Diagnostics;

Console.WriteLine("Forming a Magic Square");

int n = 3;
var magicSquare = GFG.generateSquare(n);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
        Console.Write(magicSquare[i, j] + " ");
    Console.WriteLine();
}

Console.WriteLine(magicSquare);

foreach (var q in Solver.Qubes)
{
    var ism = Solver.CheckArr(q);
    Console.WriteLine(ism);
}

var s = new List<List<int>>()
{
    new List<int>(){ 8, 3, 4 },
    new List<int>(){ 1, 5, 9 },
    new List<int>(){ 6, 7, 2 },
};

bool isMagic = Solver.Check(s);
Console.WriteLine(isMagic);
Debug.Assert(isMagic);
int cost = Solver.CalcCost(s, s);
Debug.Assert(cost == 0);


var dv = Solver.digitArr2(123);
Console.WriteLine(dv);


s = new List<List<int>>()
{
    new List<int>(){ 5, 3, 4 },
    new List<int>(){ 1, 5, 8 },
    new List<int>(){ 6, 4, 2 },
};

var res = Solver.Solve(s);
Console.WriteLine(res);
Debug.Assert(res > 0);


class Solver
{
    /// <summary>
    /// All magic qubes 3x3
    /// </summary>
    public static List<int[]> Qubes = new List<int[]>
    {
        new int[]{ 8, 1, 6, 3, 5, 7, 4, 9, 2 },
        new int[]{ 6, 1, 8, 7, 5, 3, 2, 9, 4 },
        new int[]{ 4, 9, 2, 3, 5, 7, 8, 1, 6 },
        new int[]{ 2, 9, 4, 7, 5, 3, 6, 1, 8 },
        new int[]{ 8, 3, 4, 1, 5, 9, 6, 7, 2 },
        new int[]{ 4, 3, 8, 9, 5, 1, 2, 7, 6 },
        new int[]{ 6, 7, 2, 1, 5, 9, 8, 3, 4 },
        new int[]{ 2, 7, 6, 9, 5, 1, 4, 3, 8 },
    };


    public static int Solve2(List<List<int>> s)
    {
        if (Check(s))
            return 0;

        List<Box> boxes = new List<Box>();

        List<int> tmp = new List<int>();
        tmp.AddRange(s[0]);
        tmp.AddRange(s[1]);
        tmp.AddRange(s[2]);
        var arr = tmp.ToArray();

        var digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int[] minQube = Qubes[0];
        int minDiff = 100000;
        foreach (var q in Qubes)
        {
            int currentDiff = 0;
            for (int i = 0; i < 9; i++)
            {
                var dif = Math.Abs(q[i] - arr[i]);
                currentDiff += dif;
            }

            if (currentDiff < minDiff)
            {
                minDiff = currentDiff;
                minQube = q;
            }
        }

        Console.WriteLine(minQube);
        Dictionary<int, int> wrongs = new Dictionary<int, int>();
        List<int> corrects = new List<int>();

        for (int i = 0; i < 9; i++)
        {
            if (minQube[i] != arr[i])
            {
                wrongs.Add(i, arr[i]);
            }
            else
            {
                corrects.Add(minQube[i]);
            }
        }

        Console.WriteLine(wrongs);
        var possibleValues = digits.Except(corrects).ToList();
        Console.WriteLine(possibleValues);
        var cost = 0;
        for (int i = 0; i < 9; i++)
        {
            cost += Math.Abs(minQube[i] - arr[i]);
        }

        return cost;
    }


    public static int Solve(List<List<int>> s)
    {
        if (Check(s))
            return 0;

        List<Box> boxes = new List<Box>();

        List<int> tmp = new List<int>();
        tmp.AddRange(s[0]);
        tmp.AddRange(s[1]);
        tmp.AddRange(s[2]);
        var arr = tmp.ToArray();

        var digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var b = CheckArr(arr);
        int[] tarr = arr;

        // int[] result = __int.ToString().Select(o=> Convert.ToInt32(o) - 48 ).ToArray()

        int[] minQube = Qubes[0];
        int minDiff = 100000;
        foreach (var q in Qubes)
        {
            int currentDiff = 0;
            for (int i = 0; i < 9; i++)
            {
                var dif = Math.Abs(q[i] - tarr[i]);
                currentDiff += dif;
            }

            if (currentDiff < minDiff)
            {
                minDiff = currentDiff;
                minQube = q;
            }
        }

        Console.WriteLine(minQube);

        Dictionary<int, int> wrongs = new Dictionary<int, int>();
        List<int> corrects = new List<int>();

        for (int i = 0; i < 9; i++)
        {
            if (minQube[i] != tarr[i])
            {
                wrongs.Add(i, tarr[i]);
            }
            else
            {
                corrects.Add(minQube[i]);
            }
        }

        Console.WriteLine(wrongs);

        var possibleValues = digits.Except(corrects).ToList();

        Console.WriteLine(possibleValues);
        var cost = 0;
        for (int i = 0; i < 9; i++)
        {
            cost += Math.Abs(minQube[i] - tarr[i]);
        }

        return cost;

            /*
            foreach (var arr2 in ints)
            {
                var ism = CheckArr(arr2);

                if (ism)
                {
                    var box = new Box(tarr);
                    boxes.Add(box);
                    box.Cost = CalcCost(s, box.DATA);
                }
            }
            */

            var tmps = arr;

        for (int i = 0; i < 9; i++)
        {
            for (int i2 = 0; i2 < 9; i2++)
            {

            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int x = 1; x <= 9; x++)
            {
                tmps[i] = x;

                if (CheckArr(tmps))
                {
                    boxes.Add(new Box(tmps));
                    break;
                }
            }
        }

        Debug.Assert(boxes.Count > 0);

        return 0;
    }

    public static int CalcCost(List<List<int>> s, List<List<int>> t)
    {
        int cost = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (s[i][j] != t[i][j])
                {
                    cost += Math.Abs(s[i][j] - t[i][j]);
                }
            }
        }

        return cost;
    }

    public static bool CheckArr(int[] s)
    {
        bool isUnique = s.GroupBy(x => x).Select(x => x.Count()).Max() <= 1;

        if (!isUnique)
            return false;

        var sum = s[0] + s[1] + s[2];
        return sum == s[3] + s[4] + s[5]
            && sum == s[6] + s[7] + s[8]
            && sum == s[0] + s[3] + s[6]
            && sum == s[1] + s[4] + s[7]
            && sum == s[2] + s[5] + s[8]
            && sum == s[0] + s[4] + s[8]
            && sum == s[2] + s[4] + s[6];
    }

    public static bool Check(List<List<int>> s)
    {
        var sum1 = s[0].Sum();
        var sum2 = s[0][0] + s[1][1] + s[2][2];
        var sum3 = s[2][0] + s[1][1] + s[0][2];
        var sum4 = s[0][0] + s[0][1] + s[0][2];
        var sum5 = s[1][0] + s[1][1] + s[1][2];
        var sum6 = s[2][0] + s[2][1] + s[2][2];

        return sum1 == s[1].Sum()
            && sum1 == s[2].Sum()
            && sum1 == sum2
            && sum1 == sum3
            && sum1 == sum4
            && sum1 == sum5
            && sum1 == sum6;
    }


    public static int numDigits(int n)
    {
        if (n < 0)
        {
            n = (n == Int32.MinValue) ? Int32.MaxValue : -n;
        }
        if (n < 10) return 1;
        if (n < 100) return 2;
        if (n < 1000) return 3;
        if (n < 10000) return 4;
        if (n < 100000) return 5;
        if (n < 1000000) return 6;
        if (n < 10000000) return 7;
        if (n < 100000000) return 8;
        if (n < 1000000000) return 9;
        return 10;
    }

    public static int[] digitArr2(int n)
    {
        var result = new int[numDigits(n)];
        for (int i = result.Length - 1; i >= 0; i--)
        {
            result[i] = n % 10;
            n /= 10;
        }
        return result;
    }
}

public class Box
{
    public Box(int cost, List<List<int>> data)
    {
        Cost = cost;
        DATA = data;

        List<int> tmp = new List<int>();
        tmp.AddRange(data[0]);
        tmp.AddRange(data[1]);
        tmp.AddRange(data[2]);
        ARR = tmp.ToArray();
    }

    public Box(int[] arr)
    {
        Cost = 0;
        ARR = arr;

        DATA.Add(new List<int>());
        DATA.Add(new List<int>());
        DATA.Add(new List<int>());

        DATA[0].Add(arr[0]);
        DATA[0].Add(arr[1]);
        DATA[0].Add(arr[2]);

        DATA[1].Add(arr[3]);
        DATA[1].Add(arr[4]);
        DATA[1].Add(arr[5]);

        DATA[2].Add(arr[6]);
        DATA[2].Add(arr[7]);
        DATA[2].Add(arr[8]);
    }

    public List<List<int>> DATA { get; private set; } = new List<List<int>>();
    public int[] ARR { get; private set; }
    public int Cost { get; set; }
}



class GFG
{

    // Function to generate odd sized magic squares
    public static int[,] generateSquare(int n)
    {
        int[,] magicSquare = new int[n, n];

        // Initialize position for 1
        int i = n / 2;
        int j = n - 1;

        // One by one put all values in magic square
        for (int num = 1; num <= n * n;)
        {
            if (i == -1 && j == n) // 3rd condition
            {
                j = n - 2;
                i = 0;
            }
            else
            {
                // 1st condition helper if next number
                // goes to out of square's right side
                if (j == n)
                    j = 0;

                // 1st condition helper if next number is
                // goes to out of square's upper side
                if (i < 0)
                    i = n - 1;
            }

            // 2nd condition
            if (magicSquare[i, j] != 0)
            {
                j -= 2;
                i++;
                continue;
            }
            else
                // set number
                magicSquare[i, j] = num++;

            // 1st condition
            j++;
            i--;
        }

        // print magic square
        Console.WriteLine("The Magic Square for " + n + ":");
        Console.WriteLine("Sum of each row or column " + n * (n * n + 1) / 2 + ":");

        /*
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
                Console.Write(magicSquare[i, j] + " ");
            Console.WriteLine();
        }
        */

        return magicSquare;
    }

}