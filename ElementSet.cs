using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sudoku
{
    public class ElementSet<T> where T : class
    {
        public ImmutableSortedSet<T> Elements { get; }
        public ElementSet(IEnumerable<T> elements)
        {
            Elements = ImmutableSortedSet.CreateRange(elements);
        }
    }
}
