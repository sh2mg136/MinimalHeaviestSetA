using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class CutTheSticksClass
    {
        public static List<int> cutTheSticks(List<int> arr)
        {
            var result = new List<int>() { arr.Count };

            while (arr.Count > 1)
            {
                var min = arr.Min();
                var sub = arr.Where(x => x != min).ToList();
                var cnt = 0;
                arr.Clear();
                foreach (var item in sub)
                {
                    arr.Add(item - min);
                    cnt++;
                }
                if (cnt > 0) result.Add(cnt);
            }

            return result;
        }
    }
}
