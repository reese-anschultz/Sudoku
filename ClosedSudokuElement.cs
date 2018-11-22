using System;
using System.ComponentModel;

namespace Sudoku
{
    [TypeConverter(typeof(SudokuElementConverter))]
    public class ClosedSudokuElement : SudokuElement<uint>
    {
        public ClosedSudokuElement(uint representation) : base(representation)
        {
        }
        public static explicit operator ClosedSudokuElement(string initializer)
        {
            return new ClosedSudokuElement((uint)Convert.ChangeType(initializer, typeof(uint)));
        }

    }
}
