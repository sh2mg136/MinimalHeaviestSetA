// https://www.hackerrank.com/challenges/strange-code/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Strange Counter");

/*
    3  6  12  24    46-48      96
    2  5  11  23    47-47      95
    1  4  10  22    48-46      94
       3   9  21    49-45      93
       2   8  20    50-44
       1   7  19
           6  18
           5  17
           4  16
           3  15
           2  14
           1  13
              12
              11
              10
               9
               8
               7
               6
               5
               4
               3
               2
               1
*/

var res = StrangeCounterClass.strangeCounter(30);
Debug.Assert(res == 16);

res = StrangeCounterClass.strangeCounter(22);
Debug.Assert(res == 24);

res = StrangeCounterClass.strangeCounter(45);
Debug.Assert(res == 1);

res = StrangeCounterClass.strangeCounter(46);
Debug.Assert(res == 48);

res = StrangeCounterClass.strangeCounter(93);
Debug.Assert(res == 1);

res = StrangeCounterClass.strangeCounter(94);
Debug.Assert(res == 96);


public class StrangeCounterClass
{
    public static long strangeCounter(long t)
    {
        if (t == 1) return 3;
        if (t == 2) return 2;
        if (t == 3) return 1;

        int cnt = 0;
        long tmp = t + 2;

        while (tmp > 2)
        {
            tmp /= 2;
            cnt++;
        }

        long pow = (long)Math.Pow(2, cnt);
        pow += pow / 2;
        return pow - t + pow - 2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static long strangeCounter3(long t)
    {
        if (t == 1) return 3;
        if (t == 2) return 2;
        if (t == 3) return 1;

        int start = 3;
        int cnt = 1;

        while (cnt <= t)
        {
            cnt += start;
            start *= 2;

            if (cnt + start > t)
                break;
        }

        return start - t + cnt;
    }


    public static long strangeCounter2(long t)
    {
        if (t == 1) return 3;
        int start = 3;
        int cnt = start;

        for (long i = 2; i <= t; i++)
        {
            --cnt;
            if (i == t) return cnt;
            else if (cnt == 1)
            {
                start *= 2;
                cnt = start + 1;
            }
        }

        return cnt;
    }
}