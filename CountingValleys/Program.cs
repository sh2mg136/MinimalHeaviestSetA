// https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true
using System.Diagnostics;
using System.Text.RegularExpressions;

Console.WriteLine("Counting Valleys");

var result = 0;

result = CountingValleysSolution.countingValleys(10, "DUDDDUUDUU");
Debug.Assert(result == 2);

result = CountingValleysSolution.countingValleys(10, "UDUUUDUDDD");
Debug.Assert(result == 0);

result = CountingValleysSolution.countingValleys(8, "UDDDUDUU");
Debug.Assert(result == 1);

result = CountingValleysSolution.countingValleys(8, "DDUUDDUDUUUD");
Debug.Assert(result == 2);

/// <summary>
/// The Hurdle Race
/// https://www.hackerrank.com/challenges/the-hurdle-race/problem?isFullScreen=true
/// </summary>
Console.WriteLine("The Hurdle Race");

result = TheHurdleRaceSolution.hurdleRace(7, new List<int>() { 2, 5, 4, 5, 2 });
Debug.Assert(result == 0);

result = TheHurdleRaceSolution.hurdleRace(4, new List<int>() { 1, 6, 3, 5, 2 });
Debug.Assert(result == 2);


///
/// Sequence Equation
/// https://www.hackerrank.com/challenges/permutation-equation/problem?isFullScreen=true
/// 
var list = new List<int>();

list = SequenceEquationSolution.permutationEquation(new List<int>() { 2, 3, 1 });
var correct = new List<int>() { 2, 3, 1 };
Debug.Assert(list.Count == correct.Count);
Debug.Assert(list.Sum() == correct.Sum());

list = SequenceEquationSolution.permutationEquation(new List<int>() { 5, 2, 1, 3, 4 });
correct = new List<int>() { 4, 2, 5, 1, 3 };
Debug.Assert(list.Count == correct.Count);
Debug.Assert(list.Sum() == correct.Sum());

list = SequenceEquationSolution.permutationEquation(new List<int>() { 4, 3, 5, 1, 2 });
correct = new List<int>() { 1, 3, 5, 4, 2 };
Debug.Assert(list.Count == correct.Count);
Debug.Assert(correct.Sum() == list.Sum());
var dups = list.Intersect(correct).ToList();
Debug.Assert(dups.Count == list.Count);
var distinct = list.Except(correct).ToList();
Debug.Assert(distinct.Count == 0);



/// <summary>
///
/// </summary>
internal class CountingValleysSolution
{
    public static int countingValleys(int steps, string path)
    {
        var result = 0;
        int cnt = 0;
        int dir = 0;

        foreach (var ch in path)
        {
            switch (ch)
            {
                case 'U':
                    cnt++;
                    if (cnt == 0)
                    {
                        if (dir < 0) result++;
                        dir = 0;
                    }
                    else if (cnt > 1)
                    {
                        dir = 1;
                    }
                    break;

                case 'D':
                    cnt--;
                    if (cnt == 0)
                    {
                        dir = 0;
                    }
                    else if (cnt < 0)
                    {
                        dir = -1;
                    }
                    break;

                default:
                    break;
            }
        }

        return result;
    }
}

internal class TheHurdleRaceSolution
{
    public static int hurdleRace(int k, List<int> height)
    {
        var t = height.Where(x => x > k).ToList();
        return t.Any() ? t.Max() - k : 0;
    }
}

internal class SequenceEquationSolution
{
    public static List<int> permutationEquation(List<int> p)
    {
        var result = new List<int>();
        int cnt = 0;
        var dict = p.ToDictionary(x => cnt++, x => x);
        foreach (var ii in Enumerable.Range(0, p.Count))
        {
            var pi = dict.Where(x => x.Value == ii + 1).First().Key;
            var pi2 = dict.Where(x => x.Value == pi + 1).First().Key;
            result.Add(pi2 + 1);
        }
        return result;
    }
}