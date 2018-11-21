using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Sudoku
{
    public class MultiValueToObjectUsingPredicateConverter : IMultiValueConverter
    {
        public object TrueObject { get; set; }
        public object FalseObject { get; set; }
        virtual protected Predicate<object[]> MultiValuePredicate { get; set; } = (values) => !(values == null || values.Any(o => o == null));

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Any(o => o == null || o == DependencyProperty.UnsetValue))
                return (DependencyProperty.UnsetValue);

            return (MultiValuePredicate(values) ? TrueObject : FalseObject);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
