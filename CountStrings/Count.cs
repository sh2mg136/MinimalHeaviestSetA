namespace CountStrings
{
    internal struct Count
    {
        private const int Z = 1000000007;

        public readonly int count;

        public Count(long i)
        {
            while (i < 0) i += Z;
            this.count = (int)(i % Z);
        }

        public override string ToString()
        {
            return this.count.ToString();
        }

        public static implicit operator Count(long v)
        {
            return new Count(v);
        }

        public static Count operator +(Count a, Count b)
        {
            return new Count((long)a.count + (long)b.count);
        }

        public static Count operator -(Count a, Count b)
        {
            return new Count((long)a.count - (long)b.count);
        }

        public static Count operator *(Count a, Count b)
        {
            return new Count((long)a.count * (long)b.count);
        }
    }
}