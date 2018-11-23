using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sudoku
{
    public class ElementValue<T> : SortedSet<T> where T : class
    {
        public ElementSet<T> ReferenceElementSet { get; }

        public ElementValue()
        {
            ReferenceElementSet = new ElementSet<T>(new T[] { });
        }

        public ElementValue(ElementSet<T> referenceElementSet, T[] initializers) : base(initializers)
        {
            ReferenceElementSet = referenceElementSet;
            Debug.Assert(initializers.All(e => ReferenceElementSet.Elements.Contains(e)), "Attempt to construct with foreign element");
        }

        // ReSharper disable once UnusedMember.Global
        public new bool Add(T item)
        {
            Debug.Assert(ReferenceElementSet.Elements.Contains(item), "Attempt to Add foreign element");
            return base.Add(item);
        }

        // ReSharper disable once UnusedMember.Global
        public new void SymmetricExceptWith(IEnumerable<T> other)
        {
            var enumerable = other as T[] ?? other.ToArray();
            Debug.Assert(enumerable.All(e => ReferenceElementSet.Elements.Contains(e)), "Attempt to SymmetricExceptWith foreign element");
            base.SymmetricExceptWith(enumerable);
        }

        // ReSharper disable once UnusedMember.Global
        public new void UnionWith(IEnumerable<T> other)
        {
            var enumerable = other as T[] ?? other.ToArray();
            Debug.Assert(enumerable.All(e => ReferenceElementSet.Elements.Contains(e)));
            base.UnionWith(enumerable);
        }
    }
}
