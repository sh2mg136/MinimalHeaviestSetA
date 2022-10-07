using System.Diagnostics;

namespace CountStrings
{
    internal class CountStringsClass
    {
        public static char[] alf = new char[] { 'a', 'b' };

        public static int countStrings(string r, int l)
        {
            List<string> parts = parse(r);

            foreach (var p in parts)
            {
                Debug.WriteLine(p);
            }

            return 0;
        }

        private static List<string> parse(string r)
        {
            List<string> parts = new List<string>();
            var part = string.Empty;

            for (int i = 0; i < r.Length; i++)
            {
                if (alf.Contains(r[i]))
                {
                    var left = r.IndexOf(')', i);
                    var l2 = r.IndexOf('(', i);
                    if (l2 > 0 && l2 < left)
                        left = l2;
                    if (left < 0)
                        continue;
                    part = r.Substring(i, left - i);
                    parts.Add(part);
                    i += part.Length;
                }
                else if (r[i] == '|')
                {
                    part = "|";
                    parts.Add(part);
                }
                else if (r[i] == '*')
                {
                    part = "*";
                    parts.Add(part);
                }
            }
            return parts;
        }
    }
}