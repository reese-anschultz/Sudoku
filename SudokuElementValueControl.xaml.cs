using System.Windows;
using System.Windows.Controls;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for SudokuElementValueControl.xaml
    /// </summary>
    public partial class SudokuElementValueControl : UserControl
    {
        public static readonly DependencyProperty ElementValueProperty =
             DependencyProperty.Register("ElementValue",
                 typeof(SudokuElementSet<uint>.SudokuElementValue),
                 typeof(SudokuElementValueControl),
                 new FrameworkPropertyMetadata(new SudokuElementSet<uint>.SudokuElementValue(),FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementSet<uint>.SudokuElementValue ElementValue
        {
            get { return (SudokuElementSet<uint>.SudokuElementValue)GetValue(ElementValueProperty); }
            set { SetValue(ElementValueProperty, value); }
        }

        public SudokuElementValueControl()
        {
            InitializeComponent();
            ElementValue = new SudokuElementSet<uint>.SudokuElementValue(ElementValue.ElementSet, ElementValue);
        }
    }
}
