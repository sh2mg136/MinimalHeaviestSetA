// https://www.hackerrank.com/challenges/grading/problem?isFullScreen=true
Console.WriteLine("Grading Students");
Console.WriteLine(Environment.NewLine);

var res = Grading.Run(84);
Console.WriteLine(res);

List<int> list = new List<int>() { 4, 73, 67, 38, 33 };

List<int> output = Grading.RunAll(list);

Console.WriteLine(String.Join(", ", output));

/// <summary>
/// 
/// </summary>
public class Grading
{
    readonly static List<int> BasePoints = new List<int>();

    static Grading()
    {
        for (int i = 40; i <= 100; i += 5)
        {
            if (i % 5 == 0) BasePoints.Add(i);
        }
    }

    public Grading() { }

    public static int Run(int val)
    {
        if (val < 38) return val;

        var nearestBase = BasePoints.Where(x => x >= val).FirstOrDefault();
        var diff = nearestBase - val;
        return diff < 3 ? nearestBase : val;
    }

    public static List<int> RunAll(List<int> vals)
    {
        List<int> output = new List<int>();

        foreach (int i in vals)
        {
            output.Add(Run(i));
        }
        return output;
    }
}