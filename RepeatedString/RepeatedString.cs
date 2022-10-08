using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class RepeatedStringSolution
    {
        public static long repeatedString(string s, long n)
        {
            if (s.Length == 0) return 0;

            var k = n / s.Length;
            var o = n % s.Length;

            var cnt = s.Where(x => x == 'a').Count();

            var extra_cnt = 0;

            if (o > 0)
            {
                extra_cnt = s.Substring(0, (int)o).Where(x => x == 'a').Count();
            }

            return cnt * k + extra_cnt;
        }
    }
}
