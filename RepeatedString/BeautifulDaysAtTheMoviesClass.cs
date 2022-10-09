using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class BeautifulDaysAtTheMoviesClass
    {
        public static int beautifulDays(int i, int j, int k)
        {
            var result = 0;
            for (int num = i; num <= j; num++)
            {
                var rev = reverse(num);
                if (Math.Abs(rev - num) % k == 0)
                    result++;
            }
            return result;
        }

        public static int reverse(int i)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in i.ToString().Reverse()) sb.Append(ch);
            var str = sb.ToString().TrimStart('0');
            sb.Clear();
            foreach (var ch in str) sb.Append(ch);
            return Convert.ToInt32(sb.ToString());
        }
    }
}
