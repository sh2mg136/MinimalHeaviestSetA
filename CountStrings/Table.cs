using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountStrings
{
    internal struct Table
    {
        private Count[,] values;

        private bool tableIsEmpty;

        public static int MAXSIZE = 0;
        private static int size;
        private static Stack<Count[,]> cache = new Stack<Count[,]>();

        private static void ResetSize(int newSize)
        {
            if (newSize != size)
            {
                cache.Clear();
                size = newSize;
                if (size > MAXSIZE)
                {
                    MAXSIZE = size;
                }
            }
        }

        public static Table Create(int size)
        {
            ResetSize(size);
            return Create();
        }

        private static Table Create(bool clear = true)
        {
            Count[,] table;
            if (cache.Count > 0)
            {
                table = cache.Pop();
                Array.Clear(table, 0, table.Length);
            }
            else
            {
                table = new Count[size, size];
            }
            return new Table() { values = table };
        }

        public void Free()
        {
            Debug.Assert(values != null);
            Debug.Assert(size * size == values.Length);

            cache.Push(values);
            values = null;
        }

        public Count this[int i, int j]
        {
            get { return this.values[i, j]; }
            set { this.values[i, j] = value; }
        }

        public Table Clone()
        {
            Table result = Create(clear: false);
            Array.Copy(this.values, result.values, this.values.Length);
            result.tableIsEmpty = this.tableIsEmpty;
            return result;
        }

        public Table Pow(int pow, bool free = true)
        {
            Debug.Assert(pow > 0);
            if (pow == 1)
            {
                Table r = this.Clone();
                if (free) this.Free();
                return r;
            }

            Table halfResult = this.Pow(pow / 2, free: false);
            Table result = halfResult * halfResult;
            halfResult.Free();

            if ((pow % 2) != 0)
            {
                halfResult = result;
                result = halfResult * this;
                halfResult.Free();
            }

            if (free)
            {
                this.Free();
            }

            return result;
        }

        public static Table operator *(Table a, Table b)
        {
            Table result = Create(clear: false);

            result.tableIsEmpty = a.tableIsEmpty || b.tableIsEmpty;

            if (!result.tableIsEmpty)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int column = 0; column < size; column++)
                    {
                        Count cell = 0;
                        for (int i = 0; i < size; i++)
                        {
                            cell += a[row, i] * b[i, column];
                        }
                        result[row, column] = cell;
                    }
                }
            }

            return result;
        }
    }

    internal struct SetCache<T>
    {
        private static Stack<HashSet<T>> CACHE = new Stack<HashSet<T>>();

        public static HashSet<T> Allocate()
        {
            return CACHE.Count == 0 ? new HashSet<T>() : CACHE.Pop();
        }

        public static void Free(HashSet<T> set)
        {
            set.Clear();
            CACHE.Push(set);
        }
    }

    internal struct ListCache<T>
    {
        private static Stack<List<T>> CACHE = new Stack<List<T>>();

        public static List<T> Allocate()
        {
            return CACHE.Count == 0 ? new List<T>() : CACHE.Pop();
        }

        public static void Free(List<T> list)
        {
            list.Clear();
            CACHE.Push(list);
        }
    }
}