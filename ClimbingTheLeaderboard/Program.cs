// https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Climbing the Leaderboard");
Console.WriteLine(Environment.NewLine);

var ranked = new List<int> { 100, 90, 90, 80 };
var player = new List<int> { 70, 80, 105 };
var res = Solver.ClimbingLeaderboardDone(ranked, player);
Console.WriteLine(string.Join(", ", res));
var correct = new List<int> { 4, 3, 1 };
Debug.Assert(res.Count == correct.Count);
var cmn = res.Intersect(correct).ToList();
Debug.Assert(cmn.Count() == correct.Count, "ARRAYS ARE NOT EQUAL");
Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.NewLine);

internal class Holder
{
    public Holder(int id, int threshold, List<int> rank)
    {
        Id = id;
        Threshold = threshold;
        Rank = rank;
        Min = rank.Min();
        Max = rank.Max();
        Cnt = rank.Count;
        Diff = 0;
    }

    public int Id { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public int Cnt { get; set; }
    public int Threshold { get; set; }
    public int Diff { get; set; }
    public List<int> Rank = new List<int>();

    public int GetPos(int pla)
    {
        int res;
        int ind = Rank.BinarySearch(pla);

        if (pla >= Max)
        {
            res = 1;
            if (pla > Max)
            {
                Rank.Add(pla);
                Cnt++;
                Max = pla;
            }
        }
        else if (pla <= Min)
        {
            if (pla < Min)
            {
                Rank.Insert(0, pla);
                res = ++Cnt;
                Min = pla;
            }
            else
            {
                res = Cnt;
            }
        }
        else
        {
            if (ind < 0)
            {
                Rank.Insert(~ind, pla);
                res = ++Cnt - (~ind);
            }
            else
            {
                res = Cnt - ind;
            }
        }

        return res;
    }
}

public class Solver
{
    public static List<int> ClimbingLeaderboardDone(List<int> ranked, List<int> player)
    {
        var res = new List<int>();
        var rank = ranked.Distinct().Reverse().ToList();
        var cnt = rank.Count();

        if (rank.Count == 0)
        {
            return res;
        }
        else if (rank.Count < 100)
        {
            var max = rank.Max();
            var min = rank.Min();

            foreach (var pla in player)
            {
                var pos = GetPos(ref rank, ref min, ref max, ref cnt, pla);
                res.Add(pos);
            }
        }
        else
        {
            int scale = 8;
            int shift = Math.Max(1, cnt / scale) + 1;
            List<Holder> list = new List<Holder>(scale);
            for (int i = 0; i < scale - 1; i++)
            {
                list.Add(new Holder(i + 1,
                    rank[shift * (i + 1)],
                    rank.Skip(shift * i).Take(shift).ToList()));
            }

            list.Add(new Holder(scale, rank.Max(), rank.Skip(shift * (scale - 1)).ToList()));

            int pos;
            int dif = shift - list.Last().Cnt;
            if (dif > 0)
            {
                for (int i = 0; i < scale - 1; i++)
                {
                    list[i].Diff = shift * (scale - list[i].Id) - dif;
                }
            }

            Holder? holder = null;

            foreach (var pla in player)
            {
                holder = list.Where(x => pla < x.Threshold).FirstOrDefault() ?? list.Last();
                pos = holder.GetPos(pla) + holder.Diff;
                res.Add(pos);
            }
        }

        return res;
    }

    public static List<int> climbingLeaderboard5_(List<int> ranked, List<int> player)
    {
        var res = new List<int>();
        var rank = ranked.Distinct().Reverse().ToList();
        var cnt = rank.Count();

        if (rank.Count == 0)
        {
            return res;
        }
        else if (rank.Count < 100)
        {
            var max = rank.Max();
            var min = rank.Min();

            foreach (var pla in player)
            {
                var pos = GetPos(ref rank, ref min, ref max, ref cnt, pla);
                res.Add(pos);
            }
        }
        else
        {
            int shift = Math.Max(1, cnt / 4) + 1;
            var threshold1 = rank[shift];
            var threshold2 = rank[shift * 2];
            var threshold3 = rank[shift * 3];

            var r1 = rank.Take(shift).ToList();
            var r2 = rank.Skip(shift).Take(shift).ToList();
            var r3 = rank.Skip(shift * 2).Take(shift).ToList();
            var r4 = rank.Skip(shift * 3).ToList();

            int pos;

            var max1 = r1.Max();
            var min1 = r1.Min();
            var cnt1 = r1.Count();

            var max2 = r2.Max();
            var min2 = r2.Min();
            var cnt2 = r2.Count();

            var max3 = r3.Max();
            var min3 = r3.Min();
            var cnt3 = r3.Count();

            var max4 = r4.Max();
            var min4 = r4.Min();
            var cnt4 = r4.Count();

            int dif = shift - cnt4;
            // int dif2 = Math.Abs(rank.Count - shift * 4);

            foreach (var pla in player)
            {
                if (pla < threshold1)
                {
                    pos = GetPos(ref r1, ref min1, ref max1, ref cnt1, pla) + shift * 3 - dif;
                }
                else if (pla < threshold2)
                {
                    pos = GetPos(ref r2, ref min2, ref max2, ref cnt2, pla) + shift * 2 - dif;
                }
                else if (pla < threshold3)
                {
                    pos = GetPos(ref r3, ref min3, ref max3, ref cnt3, pla) + shift - dif;
                }
                else
                {
                    pos = GetPos(ref r4, ref min4, ref max4, ref cnt4, pla);
                }
                res.Add(pos);
            }
        }

        return res;
    }

    private static int GetPos(ref List<int> rank, ref int min, ref int max, ref int cnt, int pla)
    {
        int res;
        int ind = rank.BinarySearch(pla);

        if (pla >= max)
        {
            res = 1;
            if (pla > max)
            {
                rank.Add(pla);
                cnt++;
                max = pla;
            }
        }
        else if (pla <= min)
        {
            if (pla < min)
            {
                rank.Insert(0, pla);
                res = ++cnt;
                min = pla;
            }
            else
            {
                res = cnt;
            }
        }
        else
        {
            if (ind < 0)
            {
                rank.Insert(~ind, pla);
                res = ++cnt - (~ind);
            }
            else
            {
                res = cnt - ind;
            }
        }

        return res;
    }

    public static List<int> climbingLeaderboard4(List<int> ranked, List<int> player)
    {
        var res = new List<int>();
        var rank = ranked.Distinct().Reverse().ToList();
        var max = rank.Max();
        var min = rank.Min();
        var cnt = rank.Count();
        int ind;

        foreach (var pla in player)
        {
            ind = rank.BinarySearch(pla);

            if (pla > max)
            {
                rank.Add(pla);
                max = pla;
                res.Add(1);
                cnt++;
            }
            else if (pla < min)
            {
                rank.Insert(0, pla);
                min = pla;
                res.Add(++cnt);
            }
            else
            {
                if (ind < 0)
                {
                    rank.Insert(~ind, pla);
                    res.Add(++cnt - ~ind);
                }
                else
                {
                    res.Add(cnt - ind);
                }
            }
        }

        return res;
    }

    public static List<int> climbingLeaderboard3(List<int> ranked, List<int> player)
    {
        var res = new List<int>();

        SortedList<int, int> list = new SortedList<int, int>();
        int i = 0;
        foreach (var p in ranked.Distinct())
        {
            list.Add(++i, p);
        }

        foreach (var pla in player)
        {
            var prev = list.Count(x => x.Value > pla);
            int pos = (prev == 0) ? 1 : prev + 1;
            res.Add(pos);
            list.Add(pos, pla);
        }

        // SortedSet<int> s = new SortedSet<int>();

        return res;
    }

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        var res = new List<int>();
        var rank = ranked.Distinct().Select(x => x).ToList();
        foreach (var pla in player)
        {
            var prev = rank.Count(x => x > pla);
            int pos = (prev == 0) ? 1 : prev + 1;
            res.Add(pos);

            if (!rank.Contains(pla))
            {
                if (pos > rank.Count())
                    rank.Add(pla);
                else
                    rank.Insert(pos, pla);
            }
        }
        return res;
    }

    public static List<int> climbingLeaderboard2(List<int> ranked, List<int> player)
    {
        var res = new List<int>();
        Ranks ranks = new Ranks();

        foreach (var p in ranked)
        {
            var new_rank = ranks.Add(p);
            Debug.WriteLine(new_rank);
        }

        foreach (var p in player)
        {
            var new_rank = ranks.Add(p);
            Debug.WriteLine(new_rank);
            res.Add(new_rank);
        }

        Debug.WriteLine(ranks.Data.Count);
        return res;
    }
}

internal class Ranks
{
    public List<Tuple<int, int>> Data { get; set; } = new List<Tuple<int, int>>();

    public int Add(int score)
    {
        var prev = Data
            .Where(x => x.Item2 > score)
            .Count();

        int pos = (prev == 0) ? 1 : prev + 1;

        var exists = Data.Where(x => x.Item2 == score).FirstOrDefault();
        if (exists == null)
        {
            // Data.Where(x => x.Item1 >= pos).ToList().ForEach(x => x.Item1++);
            Data.Add(new Tuple<int, int>(pos, score));
        }
        return pos;
    }
}