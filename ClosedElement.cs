using System;
using System.ComponentModel;

namespace Sudoku
{
    [TypeConverter(typeof(ClosedElementConverter))]
    public class ClosedElement : Element<uint>
    {
        public ClosedElement(uint representation) : base(representation)
        {
        }
        public static explicit operator ClosedElement(string initializer)
        {
            return new ClosedElement((uint)Convert.ChangeType(initializer, typeof(uint)));
        }

    }
}
