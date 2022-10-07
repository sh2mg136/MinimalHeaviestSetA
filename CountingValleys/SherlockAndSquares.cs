using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValleys
{
    internal class SherlockAndSquares
    {
        public static int squares(int a, int b)
        {
            int res = 0;
            var threshold = (a + b) / 2;
            int start = 0;
            int end = 0;
            double sqr;

            if (a == b)
            {
                sqr = Math.Sqrt(a);
                return (sqr - (int)sqr) == 0 ? 1 : 0;
            }

            for (int i = a; i <= threshold; i++)
            {
                sqr = Math.Sqrt(i);
                if (sqr - (int)sqr == 0)
                {
                    res++;
                    start = (int)sqr;
                    break;
                }
            }

            for (int i = b; i > threshold; i--)
            {
                sqr = Math.Sqrt(i);
                if (sqr - (int)sqr == 0)
                {
                    res++;
                    end = (int)sqr;
                    break;
                }
            }

            if (start > 0 && end > 0)
            {
                return end - start + 1;
            }

            if (start == 0 && end == 0)
                return 0;

            res = 0;

            if (start > 0)
            {
                for (int i = a; i <= threshold; i++)
                {
                    sqr = Math.Sqrt(i);
                    if (sqr - (int)sqr == 0) res++;
                }
            }
            else if (end > 0)
            {
                for (int i = b; i > threshold; i--)
                {
                    sqr = Math.Sqrt(i);
                    if (sqr - (int)sqr == 0) res++;
                }
            }

            return res;
        }

        public static int squares_2(int a, int b)
        {
            int res = 0;
            var len = b - a + 1;
            foreach (var val in Enumerable.Range(a, len))
            {
                var sqr = Math.Sqrt(val);
                if (sqr - (int)sqr == 0)
                    res++;
            }
            return res;
        }
    }
}
