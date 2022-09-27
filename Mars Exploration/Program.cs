// See https://aka.ms/new-console-template for more information
Console.WriteLine("MarsExploration");
Console.WriteLine(Environment.NewLine);

MarsExploration m = new MarsExploration("SOSSOSSPSSQSSORSOSSUSD");
var res = m.Solve();
Console.WriteLine(m.Input);
Console.WriteLine(res);
Console.WriteLine(Environment.NewLine);


public class MarsExploration
{
    const string BASE = "SOS";

    public string Input { get; private set; }

    public MarsExploration(string s)
    {
        Input = s;
    }

    public int Solve()
    {
        List<string> slices = new List<string>();

        for (int i = 0; i < Input.Length - 2; i += 3)
        {
            var sub = Input.Substring(i, 3);
            if (sub.Length == 3)
            {
                slices.Add(sub);
            }
        }

        int res = 0;
        foreach(var str in slices)
        {
            res += check(str);
        }

        return res;
    }

    int check(string s)
    {
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != BASE[i])
                res++;
        }
        return res;
    }
}