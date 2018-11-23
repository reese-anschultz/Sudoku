using System.Diagnostics;

namespace Sudoku
{
    public class SudokuElementValueItemToObjectConverter : MultiValueToObjectUsingPredicateConverter
    {
        protected override bool MultiValuePredicate(object[] values)
        {
            Debug.Assert(values.Length == 2);
            if (values.Length != 2)
                return (false);

            var v = (SudokuElementValue<ClosedSudokuElement>)(values[0]);
            var e = (ClosedSudokuElement)values[1];
            //TODO Debug.Assert(v.ElementSet.Value.Contains(e));
            return (v.Contains(e));
        }
    }
}
