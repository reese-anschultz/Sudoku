using System.Collections.Generic;

namespace Sudoku
{
    public class SudokuElementSetOfUint : SudokuElementSet<uint>
    {
        public SudokuElementSetOfUint(IEnumerable<SudokuElement<uint>> values) : base(values)
        {
        }
    }
}
