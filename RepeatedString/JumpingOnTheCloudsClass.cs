namespace RepeatedString
{
    internal class JumpingOnTheCloudsClass
    {
        public static int jumpingOnClouds(int[] c, int k)
        {
            RingV<int> list = new RingV<int>(c.ToList());
            int power = 100;
            int step = k;
            while (step != 0)
            {
                power--;
                if (list.MoveRight(k) == 1)
                    power -= 2;
                step = list.Index;
            }
            return power;
        }
    }

    public class RingV<T> : List<T>
    {
        private readonly List<T> list = new List<T>();
        private int i = 0;

        public T Current => list[i];

        public int Index => i;

        public RingV(List<T> list)
        {
            this.list = list;
        }

        public T MoveRight()
        {
            i = (i + 1) % list.Count;
            return Current;
        }

        public T MoveRight(int steps)
        {
            i = (i + steps) % list.Count;
            return Current;
        }
    }
}