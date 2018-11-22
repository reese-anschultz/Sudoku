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
                 typeof(SudokuElementSetOfUint.SudokuElementValue),
                 typeof(SudokuElementValueControl),
                 new FrameworkPropertyMetadata(new SudokuElementSetOfUint.SudokuElementValue(), FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementSetOfUint.SudokuElementValue ElementValue
        {
            get => (SudokuElementSetOfUint.SudokuElementValue)GetValue(ElementValueProperty);
            set => SetValue(ElementValueProperty, value);
        }

        public SudokuElementValueControl()
        {
            InitializeComponent();
            // Make a clone of the default ElementValue so that each control instance does not share the default instance
            ElementValue = new SudokuElementSetOfUint.SudokuElementValue(ElementValue.ElementSet, ElementValue.ToArray());
        }
    }
}
