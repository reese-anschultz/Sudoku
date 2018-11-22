using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sudoku
{
    public class SudokuElementSet<T> where T : class
    {
        //public readonly Type ElementType = typeof(T);
        public ImmutableSortedSet<T> Value { get; }
        public SudokuElementSet(IEnumerable<T> values)
        {
            Value = ImmutableSortedSet.CreateRange(values);
        }

        public class SudokuElementValue : SortedSet<T>
        {
            public SudokuElementSet<T> ElementSet { get; }
            public SudokuElementValue()
            {
                ElementSet = new SudokuElementSet<T>(new T[] { });
            }
            public SudokuElementValue(SudokuElementSet<T> elementSet, T[] initializers) : base(initializers)
            {
                ElementSet = elementSet;
                if (initializers.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to construct with foreign element");
            }
            // ReSharper disable once UnusedMember.Global
            public new bool Add(T item)
            {
                if (!ElementSet.Value.Contains(item))
                    throw new Exception("Attempt to Add foreign element");

                return base.Add(item);
            }
            // ReSharper disable once UnusedMember.Global
            public new void SymmetricExceptWith(IEnumerable<T> other)
            {
                var enumerable = other as T[] ?? other.ToArray();
                if (enumerable.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to SymmetricExceptWith foreign element");

                base.SymmetricExceptWith(enumerable);
            }
            // ReSharper disable once UnusedMember.Global
            public new void UnionWith(IEnumerable<T> other)
            {
                var enumerable = other as T[] ?? other.ToArray();
                if (enumerable.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to UnionWith foreign element");

                base.UnionWith(enumerable);
            }
        }
        public SudokuElementValue MakeElementValue(IEnumerable<T> initializers)
        {
            return new SudokuElementValue(this, initializers.ToArray());
        }
    }
}
