using RepeatedString;
using System.Diagnostics;

//
//
// Repeated String
// https://www.hackerrank.com/challenges/repeated-string/problem?isFullScreen=true
Console.WriteLine("Repeated String");

long a_count = RepeatedStringSolution.repeatedString("abcac", 10);
Debug.Assert(a_count == 4);

a_count = RepeatedStringSolution.repeatedString("aba", 10);
Debug.Assert(a_count == 7);

Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.NewLine);
//
//
//
// Cut the sticks
// https://www.hackerrank.com/challenges/cut-the-sticks/problem?isFullScreen=true
Console.WriteLine("Cut the sticks");
var input = new List<int>() { 1, 2, 3, 4, 3, 3, 2, 1 };
var output = new List<int>();
var correct = new List<int>() { 8, 6, 4, 1 };
output = CutTheSticksClass.cutTheSticks(input);
Debug.Assert(output.Sum() == correct.Sum());

input = new List<int>() { 5, 4, 4, 2, 2, 8 };
correct = new List<int>() { 6, 4, 2, 1 };
output = CutTheSticksClass.cutTheSticks(input);
Debug.Assert(output.Sum() == correct.Sum());

input = new List<int>() { 8, 8, 14, 10, 3, 5, 14, 12 };
correct = new List<int>() { 8, 7, 6, 4, 3, 2 };
output = CutTheSticksClass.cutTheSticks(input);
Debug.Assert(output.Sum() == correct.Sum());
