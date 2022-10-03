using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountStrings
{
    public class ExtSolution
    {

        public static Count Go(StringBuilder pattern, int count)
        {
            var ndfa = ParsePatternIntoNdfa(pattern);
            var dfa = ndfa.CreateDFA();
            Count result = dfa.GetNumberOfStrings(count);
            ndfa.Free();
            dfa.Free();
            return result;
        }

        private static FiniteAutomata ParsePatternIntoNdfa(StringBuilder builder)
        {
            int end;
            var result = ParsePatternIntoNdfa(builder, 0, out end);
            Debug.Assert(end == builder.Length);
            return result;
        }

        private static FiniteAutomata ParsePatternIntoNdfa(StringBuilder builder, int start, out int end)
        {
            Debug.Assert(builder.Length > start);

            end = start;

            char ch = builder[end++];
            switch (ch)
            {
                case 'a':
                case 'b':
                    return FiniteAutomata.CreateForSymbol(ch);

                case '(':
                    FiniteAutomata first = new FiniteAutomata();
                    FiniteAutomata second = new FiniteAutomata();
                    FiniteAutomata result = new FiniteAutomata();

                    first = ParsePatternIntoNdfa(builder, end, out end);

                    ch = builder[end++];
                    switch (ch)
                    {
                        case '|':
                            second = ParsePatternIntoNdfa(builder, end, out end);
                            result = FiniteAutomata.CombineAsOrAndFree(first, second);
                            break;

                        case '*':
                            result = FiniteAutomata.StarAndFree(first);
                            break;

                        default:
                            Debug.Assert(ch == 'a' || ch == 'b' || ch == '(');
                            end--;
                            second = ParsePatternIntoNdfa(builder, end, out end);
                            result = FiniteAutomata.ConcatenateAndFree(first, second);
                            break;
                    }

                    ch = builder[end++];
                    Debug.Assert(ch == ')');

                    return result;

                default:
                    throw new Exception();
            }
        }

        private struct FiniteAutomata
        {
            private List<List<Transition>> transitions;
            private int start;
            private int finish;

            private HashSet<int> dfaAcceptingStates;

            public HashSet<int> DfaAcceptingStates { get { return dfaAcceptingStates; } }

            private struct Transition
            {
                public const char Lambda = '*';

                public readonly char Symbol;
                public readonly int State;

                public Transition(char symbol, int state)
                {
                    this.Symbol = symbol;
                    this.State = state;
                }

                public Transition WithShift(int shift)
                {
                    return new Transition(this.Symbol, this.State + shift);
                }
            }

            public static FiniteAutomata CreateForSymbol(char a)
            {
                var result = CreateEmpty();
                result.transitions[result.start].Add(new Transition(a, result.finish));
                return result;
            }

            private static FiniteAutomata CreateEmpty(bool initialize = true)
            {
                var result = new FiniteAutomata();
                result.transitions = ListCache<List<Transition>>.Allocate();
                if (initialize)
                {
                    result.start = result.AddState();
                    result.finish = result.AddState();
                }
                return result;
            }

            private void ImportStates(FiniteAutomata a, out int start, out int finish)
            {
                int shift = this.transitions.Count;

                int otherCount = a.transitions.Count;
                for (int i = 0; i < otherCount; i++)
                {
                    int state = AddState();
                    Debug.Assert(state == (shift + i));

                    foreach (var trans in a.transitions[i])
                    {
                        this.transitions[i + shift].Add(trans.WithShift(shift));
                    }
                }

                start = a.start + shift;
                finish = a.finish + shift;
            }

            public static FiniteAutomata CombineAsOrAndFree(FiniteAutomata a, FiniteAutomata b)
            {
                var result = CreateEmpty();

                int aStart;
                int aFinish;
                result.ImportStates(a, out aStart, out aFinish);

                int bStart;
                int bFinish;
                result.ImportStates(b, out bStart, out bFinish);

                result.transitions[result.start].Add(new Transition(Transition.Lambda, aStart));
                result.transitions[result.start].Add(new Transition(Transition.Lambda, bStart));

                result.transitions[aFinish].Add(new Transition(Transition.Lambda, result.finish));
                result.transitions[bFinish].Add(new Transition(Transition.Lambda, result.finish));

                a.Free();
                b.Free();

                return result;
            }

            public static FiniteAutomata ConcatenateAndFree(FiniteAutomata a, FiniteAutomata b)
            {
                var result = CreateEmpty();

                int aStart;
                int aFinish;
                result.ImportStates(a, out aStart, out aFinish);

                int bStart;
                int bFinish;
                result.ImportStates(b, out bStart, out bFinish);

                result.transitions[result.start].Add(new Transition(Transition.Lambda, aStart));
                result.transitions[aFinish].Add(new Transition(Transition.Lambda, bStart));
                result.transitions[bFinish].Add(new Transition(Transition.Lambda, result.finish));

                a.Free();
                b.Free();

                return result;
            }

            public static FiniteAutomata StarAndFree(FiniteAutomata a)
            {
                var result = CreateEmpty();

                int aStart;
                int aFinish;
                result.ImportStates(a, out aStart, out aFinish);

                result.transitions[result.start].Add(new Transition(Transition.Lambda, result.finish));
                result.transitions[result.start].Add(new Transition(Transition.Lambda, aStart));

                result.transitions[aFinish].Add(new Transition(Transition.Lambda, aStart));
                result.transitions[aFinish].Add(new Transition(Transition.Lambda, result.finish));

                a.Free();

                return result;
            }

            private int AddState()
            {
                int state = this.transitions.Count;
                this.transitions.Add(ListCache<Transition>.Allocate());
                return state;
            }

            public void Free()
            {
                if (transitions != null)
                {
                    foreach (var list in this.transitions)
                    {
                        ListCache<Transition>.Free(list);
                    }
                    ListCache<List<Transition>>.Free(this.transitions);
                    transitions = null;

                    if (dfaAcceptingStates != null)
                    {
                        SetCache<int>.Free(dfaAcceptingStates);
                        dfaAcceptingStates = null;
                    }
                }
            }

            private string StateName(int state)
            {
                if (state == this.start)
                {
                    return "START";
                }
                else if (state == this.finish)
                {
                    Debug.Assert(this.transitions[state].Count == 0);
                    return "FINISH";
                }
                else if (this.dfaAcceptingStates != null && this.dfaAcceptingStates.Contains(state))
                {
                    return "$" + state.ToString();
                }
                else
                {
                    return "#" + state.ToString();
                }
            }

            public override string ToString()
            {
                var builder = new StringBuilder();
                for (int i = 0; i < this.transitions.Count; i++)
                {
                    builder.Append(StateName(i));
                    builder.Append(":");

                    foreach (var t in this.transitions[i])
                    {
                        builder.AppendFormat(" '{0}' -> {1};", t.Symbol, StateName(t.State));
                    }

                    builder.AppendLine();
                }
                return builder.ToString();
            }

            private static Queue<int> Q = new Queue<int>();

            private HashSet<int> AddAllReachableViaLambdaAndFree(HashSet<int> set)
            {
                Debug.Assert(Q.Count == 0);
                foreach (var state in set)
                {
                    Q.Enqueue(state);
                }

                while (Q.Count > 0)
                {
                    var s = Q.Dequeue();
                    foreach (var state in this.transitions[s])
                    {
                        if (state.Symbol == Transition.Lambda && set.Add(state.State))
                        {
                            Q.Enqueue(state.State);
                        }
                    }
                }

                return set;
            }

            private class HashSetComparer : IEqualityComparer<HashSet<int>>
            {
                private HashSetComparer()
                {
                }

                public static HashSetComparer Instance = new HashSetComparer();

                public bool Equals(HashSet<int> x, HashSet<int> y)
                {
                    return (x.Count == y.Count) && x.SetEquals(y);
                }

                public int GetHashCode(HashSet<int> obj)
                {
                    int hash = 0;
                    foreach (var k in obj)
                    {
                        hash ^= k;
                    }
                    return hash;
                }
            }

            private static Queue<Entry> QQ = new Queue<Entry>();

            private struct Entry
            {
                public HashSet<int> Set;
                public int State;
            }

            public FiniteAutomata CreateDFA()
            {
                var dfa = FiniteAutomata.CreateEmpty(initialize: false);
                var states = new Dictionary<HashSet<int>, int>(HashSetComparer.Instance);

                Debug.Assert(QQ.Count == 0);

                HashSet<int> finalStates = SetCache<int>.Allocate();

                //  start state
                {
                    HashSet<int> set = SetCache<int>.Allocate();
                    set.Add(this.start);
                    set = AddAllReachableViaLambdaAndFree(set);

                    dfa.start = dfa.AddState();
                    states.Add(set, dfa.start);
                    QQ.Enqueue(new Entry() { Set = set, State = dfa.start });

                    if (set.Contains(this.finish)) finalStates.Add(dfa.start);
                }

                dfa.finish = -1;

                while (QQ.Count > 0)
                {
                    var entry = QQ.Dequeue();

                    var next4a = SetCache<int>.Allocate();
                    var next4b = SetCache<int>.Allocate();

                    foreach (var state in entry.Set)
                    {
                        foreach (var t in this.transitions[state])
                        {
                            switch (t.Symbol)
                            {
                                case 'a':
                                    next4a.Add(t.State);
                                    break;

                                case 'b':
                                    next4b.Add(t.State);
                                    break;

                                default:
                                    Debug.Assert(t.Symbol == Transition.Lambda);
                                    break;
                            }
                        }
                    }

                    if (next4a.Count > 0)
                    {
                        next4a = AddAllReachableViaLambdaAndFree(next4a);
                        int state;
                        if (!states.TryGetValue(next4a, out state))
                        {
                            state = dfa.AddState();
                            states.Add(next4a, state);
                            QQ.Enqueue(new Entry() { Set = next4a, State = state });
                            if (next4a.Contains(this.finish)) finalStates.Add(state);
                        }
                        dfa.transitions[entry.State].Add(new Transition('a', state));
                    }
                    else
                    {
                        SetCache<int>.Free(next4a);
                    }

                    if (next4b.Count > 0)
                    {
                        next4b = AddAllReachableViaLambdaAndFree(next4b);
                        int state;
                        if (!states.TryGetValue(next4b, out state))
                        {
                            state = dfa.AddState();
                            states.Add(next4b, state);
                            QQ.Enqueue(new Entry() { Set = next4b, State = state });
                            if (next4b.Contains(this.finish)) finalStates.Add(state);
                        }
                        dfa.transitions[entry.State].Add(new Transition('b', state));
                    }
                    else
                    {
                        SetCache<int>.Free(next4b);
                    }
                }

                dfa.dfaAcceptingStates = finalStates;

                foreach (var s in states.Keys)
                {
                    SetCache<int>.Free(s);
                }

                return dfa;
            }

            public Count GetNumberOfStrings(int count)
            {
                Debug.Assert(this.finish < 0);
                Debug.Assert(this.dfaAcceptingStates != null);

                if (count == 0)
                {
                    return this.dfaAcceptingStates.Contains(this.start) ? 1 : 0;
                }

                int stateCount = this.transitions.Count;
                Table matrix = Table.Create(stateCount);

                for (int i = 0; i < stateCount; i++)
                {
                    var trans = this.transitions[i];
                    Debug.Assert(trans.Count <= 2);
                    for (int j = 0; j < trans.Count; j++)
                    {
                        var t = trans[j];
                        Debug.Assert(t.Symbol == 'a' || t.Symbol == 'b');
                        matrix[i, t.State] = 1;
                    }
                }

                matrix = matrix.Pow(count);

                Count result = 0;

                foreach (var final in this.dfaAcceptingStates)
                {
                    result += matrix[this.start, final];
                }

                matrix.Free();

                return result;
            }
        }

        private struct Table
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

        private struct SetCache<T>
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

        private struct ListCache<T>
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

        public struct Count
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

        private static int ReadNextInt()
        {
            int c = Console.Read();
            while (!char.IsDigit((char)c))
            {
                c = Console.Read();
            }

            int value = 0;
            do
            {
                value *= 10;
                value += c - '0';
            }
            while (char.IsDigit((char)(c = Console.Read())));

            return value;
        }

        private static bool IsPatternCharacter(char c)
        {
            return !char.IsWhiteSpace(c);
        }

        private static void ReadNextPattern(StringBuilder builder)
        {
            builder.Clear();

            char c = (char)Console.Read();
            while (!IsPatternCharacter(c))
            {
                c = (char)Console.Read();
            }

            do
            {
                builder.Append(c);
            }
            while (IsPatternCharacter(c = (char)Console.Read()));
        }
    }


}
