using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sudoku
{
    public class SudokuElementSet<T> where T : class
    {
        public ImmutableSortedSet<T> Elements { get; }
        public SudokuElementSet(IEnumerable<T> elements)
        {
            Elements = ImmutableSortedSet.CreateRange(elements);
        }
    }
}
