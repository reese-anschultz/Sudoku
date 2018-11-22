using System.Collections.Generic;

namespace Sudoku
{
    public class SudokuElementSetOfUint : SudokuElementSet<ClosedSudokuElement>
    {
        public SudokuElementSetOfUint(IEnumerable<ClosedSudokuElement> values) : base(values)
        {
        }
    }
}
