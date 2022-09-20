//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

using System.Diagnostics;
using System.Drawing;
using System.Linq;

try
{
    var files = SolutionBase.GetDataFiles();

    var fileInfo = files.First();

    var arr = SolutionBase.GetArray(fileInfo);

    int arrCount = arr.Count;
    Console.WriteLine(arrCount);

    List<int> result = Result.minimalHeaviestSetA(arr);

    //textWriter.WriteLine(String.Join("\n", result));
    //textWriter.Flush();
    //textWriter.Close();
}
catch (Exception ex)
{
    Debug.WriteLine(ex.Message);
}


public class SolutionBase
{
    public static FileInfo[] GetDataFiles()
    {
        var dirName = Path.Combine(Environment.CurrentDirectory, "Data");
        Console.WriteLine(dirName);
        DirectoryInfo dirInfo = new DirectoryInfo(dirName);
        if (!dirInfo.Exists)
            throw new InvalidOperationException("Directory does not exists");
        var files = dirInfo.GetFiles("*.txt");
        return files;
    }

    public static List<int> GetArray(FileInfo fileInfo)
    {
        var lines = File.ReadAllLines(fileInfo.FullName);

        List<int> arr = new List<int>();

        foreach (var line in lines)
        {
            var str = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in str)
            {
                int arrItem = Convert.ToInt32(s);
                arr.Add(arrItem);
            }
        }

        return arr;
    }


    public static long GetHeaviestPackage(List<int> packageWeights)
    {
        return Result.getHeaviestPackage(packageWeights);
    }

}

public class Result
{
    /*
     * Complete the 'minimalHeaviestSetA' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> minimalHeaviestSetA(List<int> arr)
    {

        Dictionary<int, long> d = new Dictionary<int, long>();
        d.Add(1, 1);


        var result = new List<int>();

        if (arr == null || arr.Count == 0)
            return result;

        if (arr.Count() == 1)
            return arr;

        if (arr.Any(x => x < 0))
            return result;

        var ordered = arr.OrderByDescending(x => x).ToList();

        long sum = 0;

        Debug.WriteLine(int.MaxValue);
        Debug.WriteLine(long.MaxValue);
        var max_arr = arr.Max();

        try
        {
            // sum = arr.ConvertAll(new Converter<int, long>(I2L)).Sum(x => (long)x);
            sum = arr.Sum(x => (long)x);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(ex.Message);

            /*
            for (int i = 0; i < ordered.Count; i++)
            {
                if (sum <= int.MaxValue - ordered[i])
                {
                    result.Add(ordered[i]);
                }
                else break;
            }
            */

            return result;
        }

        Console.WriteLine(sum);

        if (sum == 0)
            return new List<int>() { 0 };

        long half = sum / 2;
        Console.WriteLine(half);

        var threshold = 0;

        foreach (var item in ordered)
        {
            threshold += item;
            result.Add(item);
            if (threshold > half)
                break;
        }

        return result.OrderBy(x => x).ToList();
    }

    public static long I2L(int i)
    {
        return (long)i;
    }



    public static long getHeaviestPackage(List<int> packageWeights)
    {
        int k = packageWeights.Count;

        List<long> p = packageWeights.Select(x => (long)x).ToList();

        while (k > 0)
        {
            k = Find(p);
            if (k > 0)
            {
                p[k-1] += p[k];
                p.RemoveAt(k);
            }
        }

        return p.Max();
    }

    static int Find(List<long> packageWeights)
    {
        if (packageWeights.Count <= 1)
            return 0;

        Dictionary<int, long> d = new Dictionary<int, long>();

        for (int i = 1; i < packageWeights.Count; i++)
            d.Add(i, packageWeights[i] - packageWeights[i - 1]);

        try
        {
            var m = d.Where(x => x.Value > 0).OrderBy(x => x.Value).First();
            if (m.Value <= 0)
                return 0;
            return m.Key;
        }
        catch
        {
            return 0;
        }
    }

}