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
                 typeof(SudokuElementSet<uint>.SudokuElementValue),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(new SudokuElementSet<uint>.SudokuElementValue(),FrameworkPropertyMetadataOptions.AffectsRender));
        public SudokuElementSet<uint>.SudokuElementValue ElementValue
        {
            get { return (SudokuElementSet<uint>.SudokuElementValue)GetValue(ElementValueProperty); }
            set { SetValue(ElementValueProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty =
             DependencyProperty.Register("Index",
                 typeof(int),
                 typeof(SudokuElementValueItemControl),
                 new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsRender));
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public SudokuElementValueItemControl()
        {
            InitializeComponent();
            ElementValue = new SudokuElementSet<uint>.SudokuElementValue(ElementValue.ElementSet, ElementValue);
        }
    }
}
