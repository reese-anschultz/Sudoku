using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sudoku
{
    public class SudokuElementSet<T> where T : class
    {
        public ImmutableSortedSet<T> Values { get; }
        public SudokuElementSet(IEnumerable<T> values)
        {
            Values = ImmutableSortedSet.CreateRange(values);
        }

        public SudokuElementValue<T> MakeElementValue(IEnumerable<T> initializers)
        {
            return new SudokuElementValue<T>(this, initializers.ToArray());
        }
    }
}
