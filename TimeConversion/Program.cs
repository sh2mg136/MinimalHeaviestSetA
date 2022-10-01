using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("__TestProject1")]

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Time Conversion");

var s = "07:05:45PM";
var res = TConverter.Run(s);
Console.WriteLine(res);

s = "-12:00:00PM";
res = TConverter.Run(s);
Console.WriteLine(res);

s = "-12:01:15PM";
res = TConverter.Run(s);
Console.WriteLine(res);

s = "-12:00:00AM";
res = TConverter.Run(s);
Console.WriteLine(res);

s = "-12:01:15AM";
res = TConverter.Run(s);
Console.WriteLine(res);

internal class TConverter
{
    public static string Run(string input)
    {
        bool isAM = input.Trim().ToUpper().EndsWith("AM");
        var corr = input.Substring(0, input.Length - 2);
        var spl = corr.Split('\u003A');

        var h = Convert.ToInt32(spl[0]);
        var m = Convert.ToInt32(spl[1]);
        var s = Convert.ToInt32(spl[2]);

        var H = h;
        if (isAM)
        {
            if (H >= 12)
                H -= 12;
        }
        else if (H < 12)
        {
            H += 12;
        }

        var M = m;
        var S = s;

        if (h < 0)
        {
            H = h + (isAM ? 12 : 24);

            M = 60 - m;
            if (M == 60)
            {
                M = 0;
            }
            else if (M > 0)
            {
                if (H == 0) H = isAM ? 24 : 12;
                H -= 1;
            }

            if (s > 0)
            {
                S = 60 - s;
                M -= 1;
            }
        }

        var res = $"{H:00}:{M:00}:{S:00}";
        return res;
    }
}