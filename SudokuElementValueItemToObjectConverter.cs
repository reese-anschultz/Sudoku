using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sudoku
{
    public class SudokuElementValueItemToObjectConverter : PredicateToObjectConverter
    {
        public static readonly DependencyProperty IndexProperty =
             DependencyProperty.Register("Index",
                 typeof(int),
                 typeof(SudokuElementValueItemToObjectConverter),
                 new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsRender));
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public SudokuElementValueItemToObjectConverter()
        {
            Predicate = (object value) =>
            {
                var v = (SudokuElementSet<uint>.SudokuElementValue)value;
                var i = Index;// System.Convert.ToUInt16(Index);
                if (v.ElementSet.Value.Count <= i)
                    return false;

                var x = new SudokuElement<uint>[] { v.ElementSet.Value[i] };
                return (v.IsSupersetOf(x));
            };
        }
    }
}
