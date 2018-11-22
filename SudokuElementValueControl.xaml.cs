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
                 typeof(ClosedSudokuElementSet.SudokuElementValue),
                 typeof(SudokuElementValueControl),
                 new FrameworkPropertyMetadata(new ClosedSudokuElementSet.SudokuElementValue(), FrameworkPropertyMetadataOptions.AffectsRender));
        public ClosedSudokuElementSet.SudokuElementValue ElementValue
        {
            get => (ClosedSudokuElementSet.SudokuElementValue)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public SudokuElementValueControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new ClosedSudokuElementSet.SudokuElementValue(ElementValue.ElementSet, ElementValue.ToArray());
        }
    }
}
