using System.Diagnostics;

namespace Sudoku
{
    public class SudokuElementValueItemToObjectConverter : MultiValueToObjectUsingPredicateConverter
    {
        public SudokuElementValueItemToObjectConverter()
        {
            MultiValuePredicate = (object[] values) =>
            {
                Debug.Assert(values.Length == 2);
                if (values.Length != 2)
                    return (false);

                var v = (SudokuElementSetOfUint.SudokuElementValue)(values[0]);
                var e = (SudokuElement<uint>)values[1];
                //Debug.Assert(v.ElementSet.Value.Contains(e));
                return (v.Contains(e));
            };
        }
    }
}
