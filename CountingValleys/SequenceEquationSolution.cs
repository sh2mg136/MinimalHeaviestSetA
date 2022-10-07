using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValleys
{
    internal class SequenceEquationSolution
    {
        public static List<int> permutationEquation(List<int> p)
        {
            var result = new List<int>();
            int cnt = 0;
            var dict = p.ToDictionary(x => cnt++, x => x);
            foreach (var ii in Enumerable.Range(0, p.Count))
            {
                var pi = dict.Where(x => x.Value == ii + 1).First().Key;
                var pi2 = dict.Where(x => x.Value == pi + 1).First().Key;
                result.Add(pi2 + 1);
            }
            return result;
        }
    }
}
