// https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem?isFullScreen=true

Console.WriteLine("Breaking the Records");

var scores = new List<int>() { 10, 5, 20, 20, 4, 5, 2, 25, 1 };


Dictionary<int, int> better = new Dictionary<int, int>();
Dictionary<int, int> worse = new Dictionary<int, int>();
Dictionary<int, int> map = new Dictionary<int, int>();

for (int i = 0; i < scores.Count; i++)
{
    map.Add(i, scores[i]);
}

int marker = 0;

foreach (var pair in map)
{
    if (pair.Key == 0)
        continue;

    var prevMin = map.Where(x => x.Key < pair.Key).Min(x => x.Value);
    var prevMax = map.Where(x => x.Key < pair.Key).Max(x => x.Value);

    if (pair.Value > prevMax)
    {
        better.Add(pair.Key, pair.Value);
        marker = pair.Key;
    }

    if (pair.Value < prevMin)
    {
        worse.Add(pair.Key, pair.Value);
        marker = pair.Key;
    }
}

Console.WriteLine(better);
Console.WriteLine(worse);
List<int> res = new List<int>();
res.Add(better.Count);
res.Add(worse.Count);