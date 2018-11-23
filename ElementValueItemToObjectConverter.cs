using System.Diagnostics;

namespace Sudoku
{
    public class ElementValueItemToObjectConverter : MultiValueToObjectUsingPredicateConverter
    {
        protected override bool MultiValuePredicate(object[] values)
        {
            Debug.Assert(values.Length == 2);
            if (values.Length != 2)
                return (false);

            var v = (ElementValue<ClosedElement>)(values[0]);
            var e = (ClosedElement)values[1];
            //TODO Debug.Assert(v.ElementSet.Value.Contains(e));
            return (v.Contains(e));
        }
    }
}
