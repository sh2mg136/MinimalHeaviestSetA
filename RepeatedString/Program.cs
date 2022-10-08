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