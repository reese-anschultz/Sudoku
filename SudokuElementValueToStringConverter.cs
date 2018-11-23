using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Sudoku
{
    public class SudokuElementValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (SudokuElementValue<ClosedSudokuElement>)value;
            return (v == null || v.Count == 0) ? "" : v.Count == 1 ? v.First().Representation.ToString() : "*";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
