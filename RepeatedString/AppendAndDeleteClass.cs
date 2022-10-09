using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class AppendAndDeleteClass
    {
        const string YES = "Yes";
        const string NO = "No";

        public static string appendAndDelete(string s, string t, int k)
        {
            var first = s.Select(x => (int)x - 97).ToArray();
            var second = t.Select(x => (int)x - 97).ToArray();

            var minLen = Math.Min(first.Length, second.Length);
            var fullLen = first.Length + second.Length;
            var cnt = 0;

            for (int i = 0; i < minLen; i++)
            {
                if (first[i] == second[i])
                    cnt++;
                else break;
            }

            var ost1 = first.Length - cnt;
            var ost2 = second.Length - cnt;
            var diff = ost1 + ost2;

            /*
            if (diff == 0)
            {
                if (first.Length > k) return YES;
                if (first.Length + second.Length < k) return YES;
                return NO;
            }

            if (diff == k && diff % 2 == k % 2)
                return YES;
            */

            if (diff > k) return NO;
            else if (diff == k) return YES;
            else if (fullLen - k <= 0) return YES;
            else if (Math.Abs(fullLen - k) % 2 == 0) return YES;
            return NO;
        }
    }
}
