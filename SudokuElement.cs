using System;

namespace Sudoku
{
    public class SudokuElement<T> : IComparable<SudokuElement<T>> where T : IComparable<T>
    {
        public T Representation { get; private set; }
        public SudokuElement(T representation)
        {
            Representation = representation;
        }
        public int CompareTo(SudokuElement<T> other)
        {
            return Representation.CompareTo(other.Representation);
        }
    }
}
