using System;
using System.ComponentModel;
using System.Globalization;

namespace Sudoku
{
    internal class SudokuElementConverter : TypeConverter
    {
        //
        // Summary:
        //     Returns whether this converter can convert an object of the given type to the
        //     type of this converter, using the specified context.
        //
        // Parameters:
        //   context:
        //     An System.ComponentModel.ITypeDescriptorContext that provides a format context.
        //
        //   sourceType:
        //     A System.Type that represents the type you want to convert from.
        //
        // Returns:
        //     true if this converter can perform the conversion; otherwise, false.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        //
        // Summary:
        //     Returns whether this converter can convert the object to the specified type,
        //     using the specified context.
        //
        // Parameters:
        //   context:
        //     An System.ComponentModel.ITypeDescriptorContext that provides a format context.
        //
        //   destinationType:
        //     A System.Type that represents the type you want to convert to.
        //
        // Returns:
        //     true if this converter can perform the conversion; otherwise, false.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(ClosedSudokuElement))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        //
        // Summary:
        //     Converts the given object to the type of this converter, using the specified
        //     context and culture information.
        //
        // Parameters:
        //   context:
        //     An System.ComponentModel.ITypeDescriptorContext that provides a format context.
        //
        //   culture:
        //     The System.Globalization.CultureInfo to use as the current culture.
        //
        //   value:
        //     The System.Object to convert.
        //
        // Returns:
        //     An System.Object that represents the converted value.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     The conversion cannot be performed.
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string s)
            {
                return (ClosedSudokuElement)s;
            }
            return base.ConvertFrom(context, culture, value);
        }

        //
        // Summary:
        //     Converts the given value object to the specified type, using the specified context
        //     and culture information.
        //
        // Parameters:
        //   context:
        //     An System.ComponentModel.ITypeDescriptorContext that provides a format context.
        //
        //   culture:
        //     A System.Globalization.CultureInfo. If null is passed, the current culture is
        //     assumed.
        //
        //   value:
        //     The System.Object to convert.
        //
        //   destinationType:
        //     The System.Type to convert the value parameter to.
        //
        // Returns:
        //     An System.Object that represents the converted value.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The destinationType parameter is null.
        //
        //   T:System.NotSupportedException:
        //     The conversion cannot be performed.
        //public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        //{
        //    return base.ConvertTo(context, culture, value, destinationType);
        //}

        //
        // Summary:
        //     Returns whether the given value object is valid for this type and for the specified
        //     context.
        //
        // Parameters:
        //   context:
        //     An System.ComponentModel.ITypeDescriptorContext that provides a format context.
        //
        //   value:
        //     The System.Object to test for validity.
        //
        // Returns:
        //     true if the specified value is valid for this object; otherwise, false.
        //public override bool IsValid(ITypeDescriptorContext context, object value)
        //{
        //    return false;
        //}
    }
}