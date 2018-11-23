using System;

namespace Sudoku
{
    public class SudokuElement<T> : IComparable<SudokuElement<T>> where T : IComparable<T>
    {
        public T Representation { get; }
        public SudokuElement(T representation)
        {
            Representation = representation;
        }

        public static explicit operator SudokuElement<T>(string initializer)
        {
            return new SudokuElement<T>((T)Convert.ChangeType(initializer, typeof(T)));
        }

        public int CompareTo(SudokuElement<T> other)
        {
            return Representation.CompareTo(other.Representation);
        }
    }
}
