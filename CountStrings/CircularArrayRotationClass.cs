using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountStrings
{
    internal class CircularArrayRotationClass
    {
        public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
        {
            var result = new List<int>();
            RingLeftRight<int> ring = new RingLeftRight<int>(a);

            for (int i = 0; i < k; i++)
            {
                ring.MoveLeft();
                Debug.WriteLine(ring.Current);
            }

            var tmp = new List<int>();

            for (int i = 0; i <= queries.Max(); i++)
            {
                tmp.Add(ring.Current);
                ring.MoveRight();
            }

            foreach (var i in queries)
            {
                result.Add(tmp[i]);
            }

            return result;
        }
    }
}
