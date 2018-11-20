using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sudoku
{
    // Using Freezable instead of DependencyObject allows this to be part of the inheritance tree when not frozen
    public class PredicateToObjectConverter : /*DependencyObject*/Freezable, IValueConverter
    {
        public object TrueObject { get; set; }
        public object FalseObject { get; set; }
        virtual protected Predicate<object> Predicate { get; set; } = (value) => value != null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Predicate(value) ? TrueObject : FalseObject);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        // This method is required to be a Freezable, even though we aren't using the Freezable functionality
        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
            //return new PredicateToObjectConverter()
        }
    }
}
