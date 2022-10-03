using System.Collections;

namespace CountStrings
{

    public class RingLeftRight<T> : List<T>
    {
        private readonly List<T> list;
        private int i = 0;

        public T Current => list[i];

        public RingLeftRight(List<T> list)
        {
            this.list = list;
        }

        public T MoveLeft()
        {
            i--;
            if (i < 0) i = list.Count - 1;
            return Current;
        }

        public T MoveRight()
        {
            i = (i + 1) % list.Count;
            return Current;
        }
    }

    public class RingList<T> : List<T>, IEnumerable<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            return new RingEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new RingEnumerator<T>(this);
        }
    }

    internal class RingEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> list;
        private int i = 0;

        public RingEnumerator(List<T> list)
        {
            this.list = list;
        }

        public T Current => list[i];

        object IEnumerator.Current => this;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            i = (i + 1) % list.Count;
            return true;
        }

        public void Reset()
        {
            i = 0;
        }
    }

    /// <summary>
    /// Move right
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RingLeftList<T> : List<T>, IEnumerable<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            return new RingLeftEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new RingLeftEnumerator<T>(this);
        }
    }

    internal class RingLeftEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> list;
        private int i = 0;

        public RingLeftEnumerator(List<T> list)
        {
            this.list = list;
        }

        public T Current => list[i];

        object IEnumerator.Current => this;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            i -= 1;
            if (i < 0)
            {
                i = list.Count - 1;
            }
            return true;
        }

        public void Reset()
        {
            i = 0;
        }
    }
}