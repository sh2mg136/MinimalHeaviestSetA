// https://www.hackerrank.com/challenges/count-strings/problem?isFullScreen=true
using CountStrings;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;


// З А М Ы К А Н И Е
string str = "hello";
var funcs = new List<Func<string, int>>();
for (int i = 0; i < 3; i++) funcs.Add((str) => i + i);
// foreach (int i in Enumerable.Range(1, 3)) funcs.Add(() => i + i);
foreach (var func in funcs) Console.WriteLine(func(str));



static Action CreateAction()
{
    int count = 0;
    Action action = () =>
    {
        count++;
        Debug.WriteLine("Count = {0}", count);
        Console.WriteLine("Count = {0}", count);
    };
    return action;
}

string capturedVariable = "captured"; //4

Action d = delegate ()
{
    var msg = string.Format("Captured variable is {0}", capturedVariable);
    Console.WriteLine(msg);
    Debug.WriteLine(msg);
};

var del = d;
del();

var action = CreateAction();
action();
action();

var actions = new List<Action>();

foreach (var i in Enumerable.Range(1, 3))
    actions.Add(() => Debug.WriteLine(i));

foreach (var act in actions)
{
    act();
}

///////////////////////////////////////////////////
/// <summary>
/// Circular Array Rotation
/// https://www.hackerrank.com/challenges/circular-array-rotation/problem?isFullScreen=true
/// </summary>
/// <returns></returns>
Console.WriteLine("Circular Array Rotation");
var result = CircularArrayRotationClass.circularArrayRotation(new List<int>() { 1, 2, 3 }, 2, new List<int>() { 0, 1, 2 });
Debug.Assert(result.Count == 3);

result = CircularArrayRotationClass.circularArrayRotation(new List<int>() { 1, 2, 3 }, 2, new List<int>() { 0, 1, 2 });
Debug.Assert(result.Count == 3);


//////////////////////////////////////////////////
///
///
Console.WriteLine("Count Strings");
var res = 0;

res = CountStringsClass.countStrings("((a*)(b(a*)))", 100);
Debug.Assert(res == 100);

res = CountStringsClass.countStrings("(a|b)*)", 5);
Debug.Assert(res == 32);

res = CountStringsClass.countStrings("((ab)|(ba))", 2);
Debug.Assert(res == 2);


StringBuilder builder = new StringBuilder("((ab)|(ba))");
var _count = ExtSolution.Go(builder, 2);
Debug.Assert(_count.count == 100);


internal class CountStringsClass
{
    public static char[] alf = new char[] { 'a', 'b' };

    public static int countStrings(string r, int l)
    {
        List<string> parts = parse(r);

        foreach (var p in parts)
        {
            Debug.WriteLine(p);
        }

        return 0;
    }

    static List<string> parse(string r)
    {
        List<string> parts = new List<string>();
        var part = string.Empty;

        for (int i = 0; i < r.Length; i++)
        {
            if (alf.Contains(r[i]))
            {
                var left = r.IndexOf(')', i);
                var l2 = r.IndexOf('(', i);
                if (l2 > 0 && l2 < left)
                    left = l2;
                if (left < 0)
                    continue;
                part = r.Substring(i, left - i);
                parts.Add(part);
                i += part.Length;
            }
            else if (r[i] == '|')
            {
                part = "|";
                parts.Add(part);
            }
            else if (r[i] == '*')
            {
                part = "*";
                parts.Add(part);
            }
        }
        return parts;
    }
}

class CircularArrayRotationClass
{
    public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
    {
        var result = new List<int>();
        RingLeftRight<int> ring = new RingLeftRight<int>(a);

        for (int i = 0; i < k; i++)
        {
            ring.MoveLeft();
            Debug.WriteLine(ring.Current);
        }

        var tmp = new List<int>();

        for (int i = 0; i <= queries.Max(); i++)
        {
            tmp.Add(ring.Current);
            ring.MoveRight();
        }

        foreach (var i in queries)
        {
            result.Add(tmp[i]);
        }

        return result;
    }
}