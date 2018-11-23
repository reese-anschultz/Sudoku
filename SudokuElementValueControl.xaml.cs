using System.Linq;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for SudokuElementValueControl.xaml
    /// </summary>
    public partial class SudokuElementValueControl //: UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(ElementValue<ClosedElement>),
                 typeof(SudokuElementValueControl),
                 new FrameworkPropertyMetadata(new ElementValue<ClosedElement>(), FrameworkPropertyMetadataOptions.AffectsRender));
        public ElementValue<ClosedElement> ElementValue
        {
            get => (ElementValue<ClosedElement>)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public SudokuElementValueControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new ElementValue<ClosedElement>(ElementValue.ReferenceElementSet, ElementValue.ToArray());
        }
    }
}
