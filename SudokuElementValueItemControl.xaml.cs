using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for SudokuElementValueControl.xaml
    /// </summary>
    public partial class SudokuElementValueItemControl : UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(SudokuElementSetOfUint.SudokuElementValue),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(new SudokuElementSetOfUint.SudokuElementValue(), FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementSetOfUint.SudokuElementValue ElementValue
        {
            get { return (SudokuElementSetOfUint.SudokuElementValue)GetValue(ElementValueProperty); }
            set { SetValue(ElementValueProperty, value); }
        }

        public static readonly DependencyProperty ElementProperty =
             DependencyProperty.Register("Element",
                 typeof(ClosedSudokuElement),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(default(ClosedSudokuElement), FrameworkPropertyMetadataOptions.AffectsRender));
        public ClosedSudokuElement Element
        {
            get { return (ClosedSudokuElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public SudokuElementValueItemControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new SudokuElementSetOfUint.SudokuElementValue(ElementValue.ElementSet, ElementValue.ToArray());
        }
    }
}
