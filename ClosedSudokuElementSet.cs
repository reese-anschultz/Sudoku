using System.Collections.Generic;

namespace Sudoku
{
    public class ClosedSudokuElementSet : SudokuElementSet<ClosedSudokuElement>
    {
        public ClosedSudokuElementSet(IEnumerable<ClosedSudokuElement> values) : base(values)
        {
        }
    }
}
