using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sudoku
{
    public class SudokuElementValue<T> : SortedSet<T> where T : class
    {
        public SudokuElementSet<T> ReferenceElementSet { get; }
        public SudokuElementValue()
        {
            ReferenceElementSet = new SudokuElementSet<T>(new T[] { });
        }

        public SudokuElementValue(SudokuElementSet<T> referenceElementSet, T[] initializers) : base(initializers)
        {
            ReferenceElementSet = referenceElementSet;
            Debug.Assert(initializers.All(e => ReferenceElementSet.Values.Contains(e)), "Attempt to construct with foreign element");
        }

        // ReSharper disable once UnusedMember.Global
        public new bool Add(T item)
        {
            Debug.Assert(ReferenceElementSet.Values.Contains(item), "Attempt to Add foreign element");
            return base.Add(item);
        }

        // ReSharper disable once UnusedMember.Global
        public new void SymmetricExceptWith(IEnumerable<T> other)
        {
            var enumerable = other as T[] ?? other.ToArray();
            Debug.Assert(enumerable.All(e => ReferenceElementSet.Values.Contains(e)), "Attempt to SymmetricExceptWith foreign element");
            base.SymmetricExceptWith(enumerable);
        }

        // ReSharper disable once UnusedMember.Global
        public new void UnionWith(IEnumerable<T> other)
        {
            var enumerable = other as T[] ?? other.ToArray();
            Debug.Assert(enumerable.All(e => ReferenceElementSet.Values.Contains(e)));
            base.UnionWith(enumerable);
        }
    }
}
