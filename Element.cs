using System;

namespace Sudoku
{
    public class Element<T> : IComparable<Element<T>> where T : IComparable<T>
    {
        public T Representation { get; }
        public Element(T representation)
        {
            Representation = representation;
        }

        public static explicit operator Element<T>(string initializer)
        {
            return new Element<T>((T)Convert.ChangeType(initializer, typeof(T)));
        }

        public int CompareTo(Element<T> other)
        {
            return Representation.CompareTo(other.Representation);
        }
    }
}
