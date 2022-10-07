// https://www.hackerrank.com/challenges/count-strings/problem?isFullScreen=true
using CountStrings;
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
Debug.Assert(_count.count == 2);

///
///
///
builder = new StringBuilder("((ab)|(ba))");
var count = 2;
var ndfa = CountStringSolver.Parse(builder);
var dfa = ndfa.CreateDFA();
CountStrings.Count answer = dfa.GetNumberOfStrings(count);
ndfa.Free();
dfa.Free();
Debug.Assert(answer.count == 2);

internal class CountStringSolver
{
    public static FiniteAutomaton Parse(StringBuilder builder)
    {
        int end;
        var result = Parse(builder, 0, out end);
        Debug.Assert(end == builder.Length);
        return result;
    }

    private static FiniteAutomaton Parse(StringBuilder builder, int start, out int end)
    {
        Debug.Assert(builder.Length > start);

        end = start;

        char ch = builder[end++];
        switch (ch)
        {
            case 'a':
            case 'b':
                return FiniteAutomaton.CreateForSymbol(ch);

            case '(':
                FiniteAutomaton first = new FiniteAutomaton();
                FiniteAutomaton second = new FiniteAutomaton();
                FiniteAutomaton result = new FiniteAutomaton();

                first = Parse(builder, end, out end);

                ch = builder[end++];
                switch (ch)
                {
                    case '|':
                        second = Parse(builder, end, out end);
                        result = FiniteAutomaton.CombineAsOrAndFree(first, second);
                        break;

                    case '*':
                        result = FiniteAutomaton.StarAndFree(first);
                        break;

                    default:
                        Debug.Assert(ch == 'a' || ch == 'b' || ch == '(');
                        end--;
                        second = Parse(builder, end, out end);
                        result = FiniteAutomaton.ConcatenateAndFree(first, second);
                        break;
                }

                ch = builder[end++];
                Debug.Assert(ch == ')');

                return result;

            default:
                throw new Exception();
        }
    }

    private static int ReadNextInt()
    {
        int c = Console.Read();
        while (!char.IsDigit((char)c))
        {
            c = Console.Read();
        }

        int value = 0;
        do
        {
            value *= 10;
            value += c - '0';
        }
        while (char.IsDigit((char)(c = Console.Read())));

        return value;
    }

    private static bool IsPatternCharacter(char c)
    {
        return !char.IsWhiteSpace(c);
    }

    private static void ReadNextPattern(StringBuilder builder)
    {
        builder.Clear();

        char c = (char)Console.Read();
        while (!IsPatternCharacter(c))
        {
            c = (char)Console.Read();
        }

        do
        {
            builder.Append(c);
        }
        while (IsPatternCharacter(c = (char)Console.Read()));
    }
}