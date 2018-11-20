namespace Sudoku
{
    public class SudokuElementValueItemToObjectConverter : PredicateToObjectConverter
    {
        public SudokuElementValueItemToObjectConverter()
        {
            MultiValuePredicate = (object[] values) =>
            {
                if (values.Length != 2)
                    return (false);

                // Allow arguments to be passed in either order
                if (values[0].GetType() == typeof(int))    // If the index is first
                {
                    var a = values[0];
                    values[0] = values[1];
                    values[1] = a;
                }
                var v = (SudokuElementSet<uint>.SudokuElementValue)(values[0]);
                var i = (int)values[1];
                if (v.ElementSet.Value.Count <= i)
                    return false;

                var x = new SudokuElement<uint>[] { v.ElementSet.Value[i] };
                return (v.IsSupersetOf(x));
            };
        }
    }
}
