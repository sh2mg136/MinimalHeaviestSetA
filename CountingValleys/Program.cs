// https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true
using CountingValleys;
using System.Diagnostics;


///
/// Sherlock And Squares
/// https://www.hackerrank.com/challenges/sherlock-and-squares/problem?isFullScreen=true
///
Console.WriteLine("Sherlock And Squares");
var ires = 0;

ires = SherlockAndSquares.squares(3, 9);
Debug.Assert(ires == 2);

ires = SherlockAndSquares.squares(17, 24);
Debug.Assert(ires == 0);

ires = SherlockAndSquares.squares(16, 24);
Debug.Assert(ires == 1);

ires = SherlockAndSquares.squares(18, 25);
Debug.Assert(ires == 1);

ires = SherlockAndSquares.squares(395151610, 407596310);
Debug.Assert(ires == 311);

ires = SherlockAndSquares.squares(465868129, 988379794);
Debug.Assert(ires == 9855);

ires = SherlockAndSquares.squares(181510012, 293922871);
Debug.Assert(ires == 3672);

ires = SherlockAndSquares.squares(481403421, 520201871);
Debug.Assert(ires == 867);

ires = SherlockAndSquares.squares(309804254, 776824625);
Debug.Assert(ires == 10270);


Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.NewLine);
//////////////////////////////////////
// https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true
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

Console.WriteLine(Environment.NewLine);

/// <summary>
/// The Hurdle Race
/// https://www.hackerrank.com/challenges/the-hurdle-race/problem?isFullScreen=true
/// </summary>
Console.WriteLine("The Hurdle Race");

result = TheHurdleRaceSolution.hurdleRace(7, new List<int>() { 2, 5, 4, 5, 2 });
Debug.Assert(result == 0);

result = TheHurdleRaceSolution.hurdleRace(4, new List<int>() { 1, 6, 3, 5, 2 });
Debug.Assert(result == 2);

Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.NewLine);

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

internal class TheHurdleRaceSolution
{
    public static int hurdleRace(int k, List<int> height)
    {
        var t = height.Where(x => x > k).ToList();
        return t.Any() ? t.Max() - k : 0;
    }
}