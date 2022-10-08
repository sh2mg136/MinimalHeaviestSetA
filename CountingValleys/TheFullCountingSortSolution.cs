using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace CountingValleys
{
    internal class TheFullCountingSortSolution
    {
        public static void countSort(List<List<string>> arr)
        {
            var res = Solve(arr);
            Console.WriteLine(res);
        }

        public static string Solve(List<List<string>> arr)
        {
            List<CL> list = new List<CL>();
            int cnt = 0;
            int half = arr.Count / 2;
            foreach (var item in arr)
            {
                list.Add(new CL()
                {
                    Ind = cnt,
                    Num = Convert.ToInt32(item[0]),
                    Val = cnt < half ? "-" : item[1],
                });
                cnt++;
            }

            var sorted = list.OrderBy(x => x.Num).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in sorted)
            {
                sb.Append(item.Val);
                sb.Append(' ');
            }

            Console.WriteLine(sb.ToString());

            return sb.ToString().TrimEnd();
        }

        [DebuggerDisplay("{Ind} - {Num} - {Val}")]
        class CL
        {
            public int Ind { get; set; }
            public int Num { get; set; }
            public string Val { get; set; } = String.Empty;
        }
    }
}