using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sudoku
{
    public class SudokuElementSet<T> where T : IComparable<T>
    {
        public ImmutableSortedSet<SudokuElement<T>> Value { get; }
        public SudokuElementSet(IEnumerable<SudokuElement<T>> value)
        {
            Value = ImmutableSortedSet.CreateRange(value);
        }

        public class SudokuElementValue : SortedSet<SudokuElement<T>>
        {
            public SudokuElementSet<T> ElementSet { get; }
            public SudokuElementValue()
            {
                ElementSet = new SudokuElementSet<T>(new SudokuElement<T>[] { });
            }
            public SudokuElementValue(SudokuElementSet<T> elementSet, IEnumerable<SudokuElement<T>> initializers) : base(initializers)
            {
                ElementSet = elementSet;
                if (initializers.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to construct with foreign element");
            }
            public new bool Add(SudokuElement<T> item)
            {
                if (!ElementSet.Value.Contains(item))
                    throw new Exception("Attempt to Add foreign element");

                return base.Add(item);
            }
            public new void SymmetricExceptWith(IEnumerable<SudokuElement<T>> other)
            {
                if (other.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to SymmetricExceptWith foreign element");

                base.SymmetricExceptWith(other);
            }
            public new void UnionWith(IEnumerable<SudokuElement<T>> other)
            {
                if (other.Any(e => !ElementSet.Value.Contains(e)))
                    throw new Exception("Attempt to UnionWith foreign element");

                base.UnionWith(other);
            }
        }
        public SudokuElementValue MakeElementValue(IEnumerable<SudokuElement<T>> initializers)
        {
            return new SudokuElementValue(this,initializers);
        }
    }
}
