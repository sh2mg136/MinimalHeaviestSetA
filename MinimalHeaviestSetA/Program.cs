//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

using System.Diagnostics;
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
        var result = new List<int>();

        if (arr == null || arr.Count == 0)
            return result;

        if (arr.Count() == 1)
            return arr;

        if (arr.Any(x => x < 0))
            return result;

        var ordered = arr.OrderByDescending(x => x).ToList();

        int sum = 0;

        var maxi = int.MaxValue;
        var max_arr = arr.Max();

        try
        {
            sum = arr.Sum();
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

        double half = (double)sum / 2;
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
}