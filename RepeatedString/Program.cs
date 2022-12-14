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


//
//
//
// Append and Delete
// https://www.hackerrank.com/challenges/append-and-delete/problem?isFullScreen=true
Console.WriteLine("Append and Delete");
string str;
str = AppendAndDeleteClass.appendAndDelete("abc", "def", 6);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("hackerhappy", "hackerrank", 9);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("ashley", "ash", 2);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete("aba", "aba", 7);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("y", "yu", 2);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete("yy", "yyu", 4);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete(
    "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    4);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("abcd", "abcdert", 10);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete(
    "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    "bsdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    4);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete(
    "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    "bsdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv",
    100);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete("aaaaaaaaaa", "aaaaa", 7);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("aaa", "aaaaa", 2);
Debug.Assert(str == "Yes");

str = AppendAndDeleteClass.appendAndDelete("aaa", "aaaaa", 3);
Debug.Assert(str == "No");

str = AppendAndDeleteClass.appendAndDelete("aaa", "aaaaa", 1);
Debug.Assert(str == "No");



//
//
// Beautiful Days at the Movies
// https://www.hackerrank.com/challenges/beautiful-days-at-the-movies/problem?isFullScreen=true
//
int res = BeautifulDaysAtTheMoviesClass.beautifulDays(20, 23, 6);
Debug.Assert(res == 2);

res = BeautifulDaysAtTheMoviesClass.beautifulDays(49860, 205494, 155635764);
Debug.Assert(res == 607);


//
//
// Viral Advertising
// https://www.hackerrank.com/challenges/strange-advertising/problem?isFullScreen=true
//
res = ViralAdvertisingClass.viralAdvertising(1);
Debug.Assert(res == 2);

res = ViralAdvertisingClass.viralAdvertising(2);
Debug.Assert(res == 5);

res = ViralAdvertisingClass.viralAdvertising(3);
Debug.Assert(res == 9);

res = ViralAdvertisingClass.viralAdvertising(4);
Debug.Assert(res == 15);

res = ViralAdvertisingClass.viralAdvertising(5);
Debug.Assert(res == 24);

res = ViralAdvertisingClass.viralAdvertising(6);
Debug.Assert(res == 37);


//
//
// Jumping on the Clouds: Revisited
// https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited/problem?isFullScreen=true

res = JumpingOnTheCloudsClass.jumpingOnClouds(new int[] { 0, 0, 1, 0 }, 2);
Debug.Assert(res == 96);

res = JumpingOnTheCloudsClass.jumpingOnClouds(new int[] { 0, 0, 1, 0, 0, 1, 1, 0 }, 2);
Debug.Assert(res == 92);

res = JumpingOnTheCloudsClass.jumpingOnClouds(new int[] { 0, 0, 1, 0, 0, 1, 0 }, 2);
Debug.Assert(res == 89);

res = JumpingOnTheCloudsClass.jumpingOnClouds(new int[] { 1, 1, 1, 0, 1, 1, 0, 0, 0, 0 }, 3);
Debug.Assert(res == 80);


//
//
// Save the Prisoner!
// https://www.hackerrank.com/challenges/save-the-prisoner/problem?isFullScreen=true

res = SaveThePrisonerClass.saveThePrisoner(4, 6, 2);
Debug.Assert(res == 3);

res = SaveThePrisonerClass.saveThePrisoner(5, 2, 1);
Debug.Assert(res == 2);

res = SaveThePrisonerClass.saveThePrisoner(5, 2, 2);
Debug.Assert(res == 3);

res = SaveThePrisonerClass.saveThePrisoner(1, 1, 1);
Debug.Assert(res == 1);

res = SaveThePrisonerClass.saveThePrisoner(7, 19, 2);
Debug.Assert(res == 6);

res = SaveThePrisonerClass.saveThePrisoner(3, 7, 3);
Debug.Assert(res == 3);

res = SaveThePrisonerClass.saveThePrisoner(352926151, 380324688, 94730870);
Debug.Assert(res == 122129406);

res = SaveThePrisonerClass.saveThePrisoner(499999999, 999999997, 2);
Debug.Assert(res == 499999999);

res = SaveThePrisonerClass.saveThePrisoner(499999999, 999999998, 2);
Debug.Assert(res == 1);

res = SaveThePrisonerClass.saveThePrisoner(999999999, 999999999, 1);
Debug.Assert(res == 999999999);

res = SaveThePrisonerClass.saveThePrisoner(208526924, 756265725, 150817879);
Debug.Assert(res == 72975907);

res = SaveThePrisonerClass.saveThePrisoner(13, 140874526, 1);
Debug.Assert(res == 13);


//
//
// Library Fine
// https://www.hackerrank.com/challenges/library-fine/problem?isFullScreen=true

res = LibraryFineClass.libraryFine(14, 7, 2018, 5, 7, 2018);
Debug.Assert(res == 135);

res = LibraryFineClass.libraryFine(9, 6, 2015, 6, 6, 2015);
Debug.Assert(res == 45);