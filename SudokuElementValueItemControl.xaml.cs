using System.Linq;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for SudokuElementValueControl.xaml
    /// </summary>
    public partial class SudokuElementValueItemControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(SudokuElementValue<ClosedSudokuElement>),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(new SudokuElementValue<ClosedSudokuElement>(), FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementValue<ClosedSudokuElement> ElementValue
        {
            get => (SudokuElementValue<ClosedSudokuElement>)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public static readonly DependencyProperty ElementProperty =
             DependencyProperty.Register("Element",
                 typeof(ClosedSudokuElement),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(default(ClosedSudokuElement), FrameworkPropertyMetadataOptions.AffectsRender));
        public ClosedSudokuElement Element
        {
            get => (ClosedSudokuElement)GetValue(ElementProperty);
            set => SetValue(ElementProperty, value);
        }

        public SudokuElementValueItemControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new SudokuElementValue<ClosedSudokuElement>(ElementValue.ReferenceElementSet, ElementValue.ToArray());
        }
    }
}
