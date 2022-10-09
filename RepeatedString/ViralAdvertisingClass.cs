using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class ViralAdvertisingClass
    {
        public static int viralAdvertising(int n)
        {
            var result = 2;
            var like = 2;
            for (int i = 2; i <= n; i++)
            {
                like = (like * 3) / 2;
                result += like;
            }
            return result;
        }
    }
}
