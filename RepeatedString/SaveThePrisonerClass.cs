namespace RepeatedString
{
    public class SaveThePrisonerClass
    {
        public static int saveThePrisoner(int n, int m, int s)
        {
            if (m >= n) m %= n;
            var sum = m + s - 1;
            if (sum > n) sum %= n;
            if (sum == 0) return n;
            return sum;
        }

        public static int saveThePrisoner2(int n, int m, int s)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            var list = Enumerable.Range(1, n).ToList();
            RingV<int> ring = new RingV<int>(list);
            for (int i = 0; i < m + s - 2; i++)
            {
                ring.MoveRight();
            }
            return ring.Current;
        }
    }
}